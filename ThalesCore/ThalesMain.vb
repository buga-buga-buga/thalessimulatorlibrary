''
'' This program is free software; you can redistribute it and/or modify
'' it under the terms of the GNU General Public License as published by
'' the Free Software Foundation; either version 2 of the License, or
'' (at your option) any later version.
''
'' This program is distributed in the hope that it will be useful,
'' but WITHOUT ANY WARRANTY; without even the implied warranty of
'' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'' GNU General Public License for more details.
''
'' You should have received a copy of the GNU General Public License
'' along with this program; if not, write to the Free Software
'' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'' 

Imports System.Net.Sockets
Imports ThalesSim.Core
Imports ThalesSim.Core.Log
Imports ThalesSim.Core.Resources

''' <summary>
''' Main Racal simulator driver.
''' </summary>
''' <remarks>
''' This class drives the Racal simulator processing. It reads configuration data,
''' starts up the TCP listener socket, accepts incoming connections and creates
''' <see cref="HostCommands.AHostCommand"/> objects to serve requests.
''' </remarks>
Public Class ThalesMain
    Implements ILogProcs

    Private port As Integer
    Private consolePort As Integer
    Private maxCons As Integer
    Private curCons As Integer = 0
    Private consoleCurCons As Integer = 0
    Private LMKFile As String
    Private VBsources As String
    Private CheckLMKParity As Boolean
    Private HostDefsDir As String
    Private DoubleLengthZMKs As Boolean
    Private LegacyMode As Boolean
    Private ExpectTrailers As Boolean
    Private HeaderLength As Integer
    Private EBCDIC As Boolean

    'Listening thread for hosts
    Private LT As Threading.Thread

    'Listening thread for console
    Private CLT As Threading.Thread

    'Host commands explorer
    Private CE As HostCommands.CommandExplorer

    'Console commands explorer
    Private CCE As ConsoleCommands.ConsoleCommandExplorer

    'Host connections
    Private WC() As TCP.WorkerClient

    'Console connection - we allow only one at a time
    Private CWC As TCP.WorkerClient

    'Host TCP listener
    Private SL As TcpListener

    'Console TCP listener
    Private CSL As TcpListener

    Private curMsg As ConsoleCommands.AConsoleCommand = Nothing

    ''' <summary>
    ''' This event is raised when a Thales command is called.
    ''' </summary>
    ''' <param name="sender">This instance.</param>
    ''' <param name="commandCode">The Thales command code.</param>
    ''' <remarks></remarks>
    Public Event CommandCalled(ByVal sender As ThalesMain, ByVal commandCode As String)

    ''' <summary>
    ''' Major event.
    ''' </summary>
    ''' <remarks>
    ''' This event is raised to communicate major events. These are simulator-wide
    ''' events like data arrival, client connect/disconnect events, errors etc.
    ''' </remarks>
    Public Event MajorLogEvent(ByVal sender As ThalesMain, ByVal s As String)

    ''' <summary>
    ''' Minor event.
    ''' </summary>
    ''' <remarks>
    ''' This event is raised to communicate minor events. These are specific events like
    ''' host command processing actions.
    ''' </remarks>
    Public Event MinorLogEvent(ByVal sender As ThalesMain, ByVal s As String)

    ''' <summary>
    ''' Printer output.
    ''' </summary>
    ''' <remarks>
    ''' This event is raised to indicate that data has been printed by an executing
    ''' host command.
    ''' </remarks>
    Public Event PrinterData(ByVal sender As ThalesMain, ByVal s As String)

    Public Event DataArrived(ByVal sender As ThalesMain, ByVal e As TCPEventArgs)

    Public Event DataSent(ByVal sender As ThalesMain, ByVal e As TCPEventArgs)

    ''' <summary>
    ''' Initialization method.
    ''' </summary>
    ''' <remarks>
    ''' This method initializes the object and starts up processing.
    ''' </remarks>
    Public Sub StartUp(ByVal XMLParameterFile As String)

        StartCrypto(XMLParameterFile)
        Logger.MajorInfo(SayConfiguration())
        StartTCP()

    End Sub

    ''' <summary>
    ''' Initialization method for testing.
    ''' </summary>
    ''' <remarks>
    ''' This method initializes the object for testing.
    ''' </remarks>
    Public Sub StartUpWithoutTCP(ByVal XMLParameterFile As String)

        StartCrypto(XMLParameterFile)

    End Sub

    ''' <summary>
    ''' Return a human-readable string with the configuration.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SayConfiguration() As String
        Return "Host command port: " + port.ToString + vbCrLf +
               "Console port: " + consolePort.ToString + vbCrLf +
               "Maximum connections: " + maxCons.ToString + vbCrLf +
               "Log level: " + Logger.CurrentLogLevel.ToString + vbCrLf +
               "Check LMK parity: " + CheckLMKParity.ToString + vbCrLf +
               "XML host command definitions: " + HostDefsDir + vbCrLf +
               "Use double-length ZMKs: " + DoubleLengthZMKs.ToString + vbCrLf +
               "Header length: " + HeaderLength.ToString + vbCrLf +
               "Trailer: " + ExpectTrailers.ToString + vbCrLf +
               "EBCDIC: " + EBCDIC.ToString
    End Function

    ''' <summary>
    ''' Startup TCP.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartTCP()

        StartThread(LT, AddressOf ListenerThread, "TCP listening")
        StartThread(CLT, AddressOf ConsoleListenerThread, "Console TCP listening")

        Logger.MajorInfo("Startup complete")

    End Sub

    ''' <summary>
    ''' Starts a new thread that hosts a tcp listener.
    ''' </summary>
    ''' <param name="t">Thread variable of thread to start.</param>
    ''' <param name="threadStart">Thread entry point</param>
    ''' <param name="threadMsg">Debug message.</param>
    ''' <remarks></remarks>
    Private Sub StartThread(ByRef t As Threading.Thread, ByVal threadStart As System.Threading.ThreadStart, ByVal threadMsg As String)

        Logger.MajorVerbose(String.Format("Starting up the {0} thread...", threadMsg))
        t = New Threading.Thread(threadStart)
        t.IsBackground = True
        Try
            t.Start()
            Dim cntr As Integer = 0
            Threading.Thread.Sleep(100)
        Catch ex As Exception
            Logger.MajorError(String.Format("Error while starting the {0} thread: " + ex.ToString(), threadMsg))
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Starts the crypto only.
    ''' </summary>
    ''' <param name="XMLParameterFile">Full or relative path to XML parameters file.</param>
    ''' <remarks></remarks>
    Private Sub StartCrypto(ByVal XMLParameterFile As String)
        Logger.LogInterface = Me

        ThalesSim.Core.Resources.CleanUp()

        If Not ReadXMLFile(XMLParameterFile) Then
            Logger.MajorError("Trying to load key/value file for Mono...")
            If Not TryToReadValuePairFile(XMLParameterFile) Then
                Logger.MajorDebug("Using default configuration...")
                SetDefaultConfiguration()
            End If
        End If

        'Parse the loaded host commands
        Logger.MajorDebug("Searching for host command implementors...")
        CE = New HostCommands.CommandExplorer
        Logger.MinorInfo("Loaded commands dump" + vbCrLf + CE.GetLoadedCommands())

        'Parse the loaded console commands
        Logger.MajorDebug("Searching for console command implementors...")
        CCE = New ConsoleCommands.ConsoleCommandExplorer
        Logger.MinorInfo("Loaded console commands dump " + vbCrLf + CCE.GetLoadedCommands())
    End Sub

    ''' <summary>
    ''' Attempts to read an XML file with the parameters and start the crypto.
    ''' </summary>
    ''' <param name="fileName">XML file name.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReadXMLFile(ByVal fileName As String) As Boolean
        Try
            'Try to load from the configuration file.
            Logger.MajorDebug("Reading XML configuration...")

            Dim reader As New Xml.XmlTextReader(fileName)
            reader.WhitespaceHandling = Xml.WhitespaceHandling.None
            reader.MoveToContent()
            reader.Read()

            Dim doc As New Xml.XmlDocument
            doc.Load(reader)

            port = Convert.ToInt32(GetParameterValue(doc, "Port"))
            consolePort = Convert.ToInt32(GetParameterValue(doc, "ConsolePort"))
            maxCons = Convert.ToInt32(GetParameterValue(doc, "MaxConnections"))
            LMKFile = Convert.ToString(GetParameterValue(doc, "LMKStorageFile"))
            VBsources = Convert.ToString(GetParameterValue(doc, "VBSourceDirectory"))
            Logger.CurrentLogLevel = DirectCast([Enum].Parse(GetType(Logger.LogLevel), Convert.ToString(GetParameterValue(doc, "LogLevel")), True), Logger.LogLevel)
            CheckLMKParity = Convert.ToBoolean(GetParameterValue(doc, "CheckLMKParity"))
            HostDefsDir = Convert.ToString(GetParameterValue(doc, "XMLHostDefinitionsDirectory"))
            DoubleLengthZMKs = Convert.ToBoolean(GetParameterValue(doc, "DoubleLengthZMKs"))
            LegacyMode = Convert.ToBoolean(GetParameterValue(doc, "LegacyMode"))
            ExpectTrailers = Convert.ToBoolean(GetParameterValue(doc, "ExpectTrailers"))
            HeaderLength = Convert.ToInt32(GetParameterValue(doc, "HeaderLength"))
            EBCDIC = Convert.ToBoolean(GetParameterValue(doc, "EBCDIC"))

            StartUpCore(Convert.ToString(GetParameterValue(doc, "FirmwareNumber")), _
                        Convert.ToString(GetParameterValue(doc, "DSPFirmwareNumber")), _
                        Convert.ToBoolean(GetParameterValue(doc, "StartInAuthorizedState")), _
                        Convert.ToInt32(GetParameterValue(doc, "ClearPINLength")))

            reader.Close()
            reader = Nothing
            Return True
        Catch ex As Exception
            Logger.MajorError("Error loading the configuration file")
            Logger.MajorError(ex.ToString)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Attempts to read a key/value pair file with the parameters and start the crypto.
    ''' </summary>
    ''' <param name="fileName">File to read.</param>
    ''' <remarks>This is used in order to read the parameters under Mono where, for some
    ''' reason, we get an exception when trying to load the XML document from the reader.
    ''' We expect a file with the following format:
    ''' - A starting ; denotes a comment and is ignored.
    ''' - Other lines must have a Key=Value format and we expect the folliwng keys:
    '''   * Port
    '''   * ConsolePort
    '''   * MaxConnections
    '''   * LMKStorageFile
    '''   * VBSourceDirectory
    '''   * XMLHostDefinitionsDirectory
    '''   * LogLevel
    '''   * CheckLMKParity
    '''   * FirmwareNumber
    '''   * DSPFirmwareNumber
    '''   * StartInAuthorizedState
    '''   * ClearPINLength
    '''   * LegacyMode
    ''' </remarks>
    Private Function TryToReadValuePairFile(ByVal fileName As String) As Boolean
        Try
            Dim list As New SortedList(Of String, String)
            Using SR As IO.StreamReader = New IO.StreamReader(fileName, System.Text.Encoding.Default)
                While SR.Peek > -1
                    Dim s As String = SR.ReadLine
                    If Not (String.IsNullOrEmpty(s) OrElse s.StartsWith(";"c)) Then
                        Dim sSplit() As String = s.Split("="c)
                        list.Add(sSplit(0).ToUpper, sSplit(1))
                    End If
                End While
            End Using

            port = Convert.ToInt32(list("PORT"))
            consolePort = Convert.ToInt32(list("CONSOLEPORT"))
            maxCons = Convert.ToInt32(list("MAXCONNECTIONS"))
            LMKFile = list("LMKSTORAGEFILE")
            VBsources = list("VBSOURCEDIRECTORY")
            Logger.CurrentLogLevel = DirectCast([Enum].Parse(GetType(Logger.LogLevel), Convert.ToString(list("LOGLEVEL")), True), Logger.LogLevel)
            CheckLMKParity = Convert.ToBoolean(list("CHECKLMKPARITY"))
            HostDefsDir = list("XMLHOSTDEFINITIONSDIRECTORY")
            DoubleLengthZMKs = Convert.ToBoolean(list("DOUBLELENGTHZMKS"))
            LegacyMode = Convert.ToBoolean(list("LEGACYMODE"))
            ExpectTrailers = Convert.ToBoolean(list("EXPECTTRAILERS"))
            HeaderLength = Convert.ToInt32(list("HEADERLENGTH"))
            EBCDIC = Convert.ToBoolean(list("EBCDIC"))

            If HostDefsDir = "" Then HostDefsDir = Utility.GetExecutingDirectory
            If VBsources = "" Then VBsources = Utility.GetExecutingDirectory

            StartUpCore(list("FIRMWARENUMBER"), _
                        list("DSPFIRMWARENUMBER"), _
                        Convert.ToBoolean(list("STARTINAUTHORIZEDSTATE")), _
                        Convert.ToInt32(list("CLEARPINLENGTH")))

            Return True
        Catch ex As Exception
            Logger.MajorError("Error loading key/value file")
            Logger.MajorError(ex.ToString)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Starts the crypto with default parameters.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDefaultConfiguration()
        Logger.MajorDebug("Using default configuration...")
        port = 9998
        consolePort = 9997
        maxCons = 5
        LMKFile = ""
        VBsources = Utility.GetExecutingDirectory
        Logger.CurrentLogLevel = Logger.LogLevel.Debug
        CheckLMKParity = True
        HostDefsDir = Utility.GetExecutingDirectory
        DoubleLengthZMKs = True
        LegacyMode = False
        ExpectTrailers = False
        HeaderLength = 4
        EBCDIC = False

        StartUpCore("0007-E000", _
                    "0001", _
                    True, _
                    4)
    End Sub

    Private Sub StartUpCore(ByVal firmwareNumber As String, _
                            ByVal dspFirmwareNumber As String, ByVal startInAuthorizedState As Boolean, _
                            ByVal clearPINLength As Integer)
        CompileAndLoad(VBSources)

        Resources.AddResource(Resources.CONSOLE_PORT, consolePort)
        Resources.AddResource(Resources.WELL_KNOWN_PORT, port)
        Resources.AddResource(Resources.FIRMWARE_NUMBER, firmwareNumber)
        Resources.AddResource(Resources.DSP_FIRMWARE_NUMBER, dspFirmwareNumber)
        Resources.AddResource(Resources.MAX_CONS, maxCons)
        Resources.AddResource(Resources.AUTHORIZED_STATE, startInAuthorizedState)
        Resources.AddResource(Resources.CLEAR_PIN_LENGTH, clearPINLength)
        Resources.AddResource(Resources.DOUBLE_LENGTH_ZMKS, DoubleLengthZMKs)
        Resources.AddResource(Resources.LEGACY_MODE, LegacyMode)
        Resources.AddResource(Resources.EXPECT_TRAILERS, ExpectTrailers)
        Resources.AddResource(Resources.HEADER_LENGTH, HeaderLength)
        Resources.AddResource(Resources.EBCDIC, EBCDIC)

        'Make sure it ends with a directory separator, both for Windows and Linux.
        HostDefsDir = Utility.AppendDirectorySeparator(HostDefsDir)

        Resources.AddResource(Resources.HOST_COMMANDS_XML_DEFS, HostDefsDir)

        If LMKFile = "" Then
            Logger.MajorInfo("No LMK storage file specified, creating new keys")
            ThalesSim.Core.Cryptography.LMK.LMKStorage.LMKStorageFile = "LMKSTORAGE.TXT"
            ThalesSim.Core.Cryptography.LMK.LMKStorage.GenerateTestLMKs()
        Else
            Logger.MajorDebug("Reading LMK storage")
            ThalesSim.Core.Cryptography.LMK.LMKStorage.ReadLMKs(LMKFile)
        End If

        Resources.AddResource(Core.Resources.LMK_CHECK_VALUE, Cryptography.LMK.LMKStorage.GenerateLMKCheckValue())
    End Sub

    Private Sub CompileAndLoad(ByVal vbDir As String)

        If vbDir = "" Then Exit Sub

        Dim files() As String = IO.Directory.GetFiles(vbDir, "*.vb")
        For i As Integer = 0 To files.GetUpperBound(0)
            CompileCode(files(i), "VB")
        Next

        files = IO.Directory.GetFiles(vbDir, "*.cs")
        For i As Integer = 0 To files.GetUpperBound(0)
            CompileCode(files(i), "CSharp")
        Next

    End Sub

    Private Function CompileCode(ByVal sourceFile As String, ByVal language As String) As Reflection.Assembly

        Dim vbSource As String = ""
        Dim fName As String = New IO.FileInfo(sourceFile).Name
        Logger.MajorVerbose("Compiling " + fName + "...")
        Try
            Using SR As IO.StreamReader = New IO.StreamReader(sourceFile)
                While SR.Peek > -1
                    vbSource += SR.ReadLine() + vbCrLf
                End While
            End Using
        Catch ex As Exception
            Logger.MajorError("Exception raised while reading " + fName + vbCrLf + _
                                  ex.ToString())
            Return Nothing
        End Try

        Dim prov As CodeDom.Compiler.CodeDomProvider = Nothing
        Dim compParams As System.CodeDom.Compiler.CompilerParameters = New System.CodeDom.Compiler.CompilerParameters
        Dim compResults As System.CodeDom.Compiler.CompilerResults

        compParams.GenerateExecutable = False
        compParams.GenerateInMemory = False
        compParams.IncludeDebugInformation = True
        compParams.OutputAssembly = ""
        compParams.TempFiles.KeepFiles = True

        'Add some common refs
        Dim refs() As String = {"System.dll", "Microsoft.VisualBasic.dll", "System.XML.dll", "System.Data.dll", My.Application.Info.DirectoryPath + "\ThalesCore.dll", Reflection.Assembly.GetAssembly(GetType(ThalesMain)).Location}
        compParams.ReferencedAssemblies.AddRange(refs)

        Try
            prov = System.CodeDom.Compiler.CodeDomProvider.CreateProvider(language)
            compResults = prov.CompileAssemblyFromSource(compParams, vbSource)
        Catch ex As Exception
            'Oops
            Logger.MajorError("Exception raised during compilation of " + fName + vbCrLf + _
                              ex.ToString())
            Return Nothing
        End Try

        If compResults.Errors.Count > 0 Then
            Logger.MajorError("Compilation errors of " + fName)
            For Each Err As System.CodeDom.Compiler.CompilerError In compResults.Errors
                Logger.MajorError("Line: " + Err.Line.ToString + vbCrLf + _
                                  "Column: " + Err.Column.ToString + vbCrLf + _
                                  "Error: " + Err.ErrorText)
            Next
            Return Nothing
        Else
            Return System.Reflection.Assembly.LoadFrom(compResults.PathToAssembly)
        End If

    End Function

    Private Function GetParameterValue(ByVal doc As Xml.XmlDocument, ByVal element As String) As String
        Return doc.DocumentElement(element).Attributes("value").Value
    End Function

    ''' <summary>
    ''' Stops processing.
    ''' </summary>
    ''' <remarks>
    ''' This method stops processing.
    ''' </remarks>
    Public Sub ShutDown()

        If Not LT Is Nothing Then

            Try
                SL.Stop()
                SL = Nothing
            Catch ex As Exception
            End Try

            Logger.MajorVerbose("Stopping the listening thread...")
            Try
                LT.Abort()
                LT = Nothing
            Catch ex As Exception
            End Try

            Logger.MajorVerbose("Disconnecting connected clients...")

            For i As Integer = 0 To WC.GetUpperBound(0)
                Try
                    If Not WC(i) Is Nothing AndAlso WC(i).IsConnected = True Then WC(i).TermClient()
                    WC(i) = Nothing
                Catch ex As Exception
                End Try
            Next

            Try
                CSL.Stop()
                CSL = Nothing
            Catch ex As Exception
            End Try

            Logger.MajorVerbose("Stopping the console listening thread...")
            Try
                CLT.Abort()
                CLT = Nothing
            Catch ex As Exception
            End Try

            Try
                If Not CWC Is Nothing AndAlso CWC.IsConnected Then CWC.TermClient()
                CWC = Nothing
            Catch ex As Exception
            End Try

        End If

        Logger.MajorInfo("Shutdown complete")

    End Sub

    'Thread for the console listening socket.
    Private Sub ConsoleListenerThread()
        Try
            CSL = New TcpListener(New System.Net.IPEndPoint(0, consolePort))
            CSL.Start()

            While True
                CWC = New TCP.WorkerClient(CSL.AcceptTcpClient())
                CWC.InitOps()

                AddHandler CWC.Disconnected, AddressOf CWCDisconnected
                AddHandler CWC.MessageArrived, AddressOf CWCMessageArrived

                Logger.MajorInfo("Console client from " + CWC.ClientIP + " is connected")

                'If we have one connection, don't accept others.
                consoleCurCons = 1
                While consoleCurCons = 1
                    Threading.Thread.Sleep(50)
                End While
            End While
        Catch ex As Exception
            Logger.MajorInfo("Exception on console listening thread (" + ex.Message + ")")
            If Not CSL Is Nothing Then
                CSL.Stop()
                CSL = Nothing
            End If
        End Try
    End Sub

    'Thread for the host listening socket.
    Private Sub ListenerThread()

        ReDim WC(-1)

        Try

            SL = New TcpListener(New System.Net.IPEndPoint(0, port))
            SL.Start()

            While True
                Dim wClient As New TCP.WorkerClient(SL.AcceptTcpClient())
                wClient.InitOps()

                AddHandler wClient.Disconnected, AddressOf WCDisconnected
                AddHandler wClient.MessageArrived, AddressOf WCMessageArrived

                Logger.MajorInfo("Cliente ta vindo de " + wClient.ClientIP + " is connected")

                curCons += 1

                Dim slotedIt As Boolean = False

                For i As Integer = 0 To WC.GetUpperBound(0)
                    If WC(i) Is Nothing OrElse WC(i).IsConnected = False Then
                        WC(i) = wClient
                        slotedIt = True
                        Exit For
                    End If
                Next

                If slotedIt = False Then
                    ReDim Preserve WC(WC.GetLength(0))
                    WC(WC.GetUpperBound(0)) = wClient
                End If

                While curCons >= maxCons
                    Threading.Thread.Sleep(50)
                End While

            End While

        Catch ex As Exception
            Logger.MajorInfo("Exception on listening thread (" + ex.Message + ")")
            If Not SL Is Nothing Then
                SL.Stop()
                SL = Nothing
            End If
        End Try

    End Sub

    'Console client disconnect event
    Private Sub CWCDisconnected(ByVal sender As TCP.WorkerClient)

        Logger.MajorInfo("Console client disconnected.")
        sender.TermClient()

        'Indicate that the console is off
        consoleCurCons -= 1

        curMsg = Nothing

    End Sub

    'Console client data event
    Private Sub CWCMessageArrived(ByVal sender As TCP.WorkerClient, ByRef b() As Byte, ByVal len As Integer)
        ' Dispara DataArrived para o console
        Dim e As New TCPEventArgs
        e.RemoteClient = sender.ClientIP
        ReDim e.Data(len - 1)
        Array.Copy(b, 0, e.Data, 0, len)
        RaiseEvent DataArrived(Me, e)

        ' For�ando a verificacao/extra��o de trailer na mensagem.
        Dim msg As New ThalesSim.Core.Message.Message(b)

        Dim trailer As String = ""
        If ExpectTrailers Then
            trailer = msg.GetTrailers()
            If String.IsNullOrEmpty(trailer) Then
                Logger.MajorError("Trailer n�o encontrado mas habilitado nas configura��es.")
            Else
                Logger.MajorDebug("Trailer extra�do: [" & trailer & "]")
            End If
        Else
            Logger.MajorDebug("Parametro do trailer desligado.")
        End If

        Try
            'Do we have a current command?
            If curMsg Is Nothing Then
                'No, find the appropriate one.
                Logger.MajorDebug("Client: " + sender.ClientIP + vbCrLf +
                                    "Request: " + msg.MessageData())
                Logger.MajorDebug("Localizando o processador do comando " + msg.MessageData + "...")
                Logger.MajorDebug("HeaderLength: " + HeaderLength.ToString())
                Dim messageHeader As String = msg.GetSubstring(HeaderLength)
                Logger.MajorDebug("Header: " + messageHeader)
                msg.AdvanceIndex(HeaderLength)
                Dim commandCode As String = msg.GetSubstring(2)
                Logger.MajorDebug("CommandCode: " + commandCode)
                msg.AdvanceIndex(2)

                ' Primeiro tenta como comando de console
                Dim CC As ConsoleCommands.ConsoleCommandClass = CCE.GetLoadedCommand(msg.MessageData)
                Logger.MajorDebug("Localizando o processador do comando " + msg.MessageData + "...")

                If CC Is Nothing Then
                    ' Se n�o achou, tenta como comando de host
                    Dim HC As ThalesSim.Core.HostCommands.CommandClass = CE.GetLoadedCommand(commandCode)

                    If HC IsNot Nothing Then
                        Logger.MajorDebug("Executando comando de host pelo console: " + commandCode)
                        Dim o As ThalesSim.Core.HostCommands.AHostCommand
                        o = CType(Activator.CreateInstance(HC.DeclaringType), HostCommands.AHostCommand)

                        Logger.MajorDebug("Comando recebido: " & commandCode)
                        Logger.MajorDebug("Classe do comando: " & HC.DeclaringType.FullName())
                        Logger.MajorDebug("ResponseCode configurado para este comando: " & HC.ResponseCode)
                        Logger.MajorDebug("ResponseCodeAfterIO configurado: " & HC.ResponseCodeAfterIO)

                        Logger.MajorDebug("Executando AcceptMessage()...")
                        o.AcceptMessage(msg)
                        Logger.MajorDebug("XMLParseResult ap�s AcceptMessage: " & o.XMLParseResult)

                        Dim retMsg As ThalesSim.Core.Message.MessageResponse

                        If o.XMLParseResult <> ErrorCodes.ER_00_NO_ERROR Then
                            Logger.MajorDebug("Erro detectado, montando resposta de erro.")
                            retMsg = New ThalesSim.Core.Message.MessageResponse
                            retMsg.AddElement(o.XMLParseResult)
                        Else
                            Logger.MajorDebug("Executando ConstructResponse()...")
                            retMsg = o.ConstructResponse()
                        End If

                        If o.XMLParseResult <> ErrorCodes.ER_00_NO_ERROR Then
                            Logger.MajorDebug("Erro detectado, montando resposta de erro.")
                            retMsg = New ThalesSim.Core.Message.MessageResponse
                            retMsg.AddElement(o.XMLParseResult)
                        Else
                            Logger.MajorDebug("Executando ConstructResponse()...")
                            retMsg = o.ConstructResponse()
                        End If

                        Logger.MajorDebug("Montando resposta final:")
                        Logger.MajorDebug(" - Header: " & messageHeader)
                        Logger.MajorDebug(" - Response Code: " & HC.ResponseCode)
                        Logger.MajorDebug(" - Error Code: " & o.XMLParseResult)
                        Logger.MajorDebug(" - Data: " & retMsg.MessageDataWithoutErrorCode())
                        Logger.MajorDebug(" - Trailer: " & trailer)

                        retMsg.AddElementFront(HC.ResponseCode)
                        retMsg.AddElementFront(messageHeader)
                        retMsg.AddElement(trailer)

                        Logger.MajorVerbose("Resposta final montada: " & retMsg.MessageData())
                        Dim resposta As String = retMsg.MessageData() + vbCrLf
                        sender.send(resposta)

                        ' Dispara DataSent para o console
                        Dim eSent As New TCPEventArgs
                        eSent.RemoteClient = sender.ClientIP
                        eSent.Data = Utility.GetBytesFromString(resposta)
                        RaiseEvent DataSent(Me, eSent)

                        o.Terminate()
                        curMsg = Nothing
                        Exit Sub
                    End If
                End If

                If CC Is Nothing Then
                    Logger.MajorError("No implementor for " + msg.MessageData + ".")

                    ' Garante que commandCode, messageHeader e trailer est�o definidos
                    ' (j� est�o definidos acima no m�todo, mas garanta que n�o est�o vazios)
                    Dim respCode As String
                    If commandCode.Length = 2 Then
                        Dim c1 As Char = commandCode(0)
                        Dim c2 As Char = commandCode(1)
                        respCode = c1 & Chr(Asc(c2) + 1)
                    Else
                        respCode = commandCode
                    End If

                    ' Monta resposta: header + respCode + erro 67 + trailer
                    Dim retMsgLic As New ThalesSim.Core.Message.MessageResponse
                    retMsgLic.AddElementFront(ErrorCodes.ER_67_COMMAND_NOT_LICENSED)
                    retMsgLic.AddElementFront(respCode)
                    retMsgLic.AddElementFront(messageHeader)
                    If trailer <> "" Then
                        retMsgLic.AddElement(trailer)
                    End If

                    Dim resposta As String = retMsgLic.MessageData() + vbCrLf
                    sender.send(resposta)
                    ' Dispara DataSent para o console
                    Dim eSent As New TCPEventArgs
                    eSent.RemoteClient = sender.ClientIP
                    eSent.Data = Utility.GetBytesFromString(resposta)
                    RaiseEvent DataSent(Me, eSent)
                    Exit Sub
                End If

                'Instantiate and let it initialize its command stack.
                curMsg = CType(Activator.CreateInstance(CC.CommandType), ConsoleCommands.AConsoleCommand)
                curMsg.InitializeStack()
            Else
                'We already have a command so we'll pass the data from the console to it.
                Dim returnMsg As String = Nothing

                'This catches exceptions of the last process.
                Try
                    returnMsg = curMsg.AcceptMessage(msg.MessageData)
                Catch ex As Exception
                    returnMsg = ex.Message
                End Try

                'If it returns some string and it signaled a finish, we're done with the command.
                If returnMsg IsNot Nothing AndAlso curMsg.CommandFinished Then
                    Logger.MajorDebug("002 - Retornando essa string aqui :" + returnMsg)
                    Dim resposta As String = returnMsg + vbCrLf
                    sender.send(resposta)
                    ' Dispara DataSent para o console
                    Dim eSent As New TCPEventArgs
                    eSent.RemoteClient = sender.ClientIP
                    eSent.Data = Utility.GetBytesFromString(resposta)
                    RaiseEvent DataSent(Me, eSent)
                    curMsg = Nothing
                Else
                    'Else, let the command send the next prompt to the console.
                    Logger.MajorDebug("003 - Retornando :" + curMsg.GetClientMessage())
                    Dim resposta As String = curMsg.GetClientMessage()
                    sender.send(resposta)
                    ' Dispara DataSent para o console
                    Dim eSent As New TCPEventArgs
                    eSent.RemoteClient = sender.ClientIP
                    eSent.Data = Utility.GetBytesFromString(resposta)
                    RaiseEvent DataSent(Me, eSent)
                End If
                Exit Sub
            End If

            'This is reached when a command has just been instantiated.
            'There are some commands that require no input. If this is one
            'of them, just run the ProcessMessage method and return the result.
            If curMsg.IsNoinputCommand Then
                Try
                    Logger.MajorDebug("004 - Retornando :" + curMsg.ProcessMessage)
                    Dim resposta As String = curMsg.ProcessMessage + vbCrLf
                    sender.send(resposta)
                    ' Dispara DataSent para o console
                    Dim eSent As New TCPEventArgs
                    eSent.RemoteClient = sender.ClientIP
                    eSent.Data = Utility.GetBytesFromString(resposta)
                    RaiseEvent DataSent(Me, eSent)
                Catch ex As Exception
                    Dim resposta As String = ex.Message
                    sender.send(resposta)
                    ' Dispara DataSent para o console
                    Dim eSent As New TCPEventArgs
                    eSent.RemoteClient = sender.ClientIP
                    eSent.Data = Utility.GetBytesFromString(resposta)
                    RaiseEvent DataSent(Me, eSent)
                End Try
                curMsg = Nothing
            Else
                'Else, let the command send the first prompt to the console.
                Logger.MajorDebug("005 - Retornando :" + curMsg.GetClientMessage())
                Dim resposta As String = curMsg.GetClientMessage()
                sender.send(resposta)
                ' Dispara DataSent para o console
                Dim eSent As New TCPEventArgs
                eSent.RemoteClient = sender.ClientIP
                eSent.Data = Utility.GetBytesFromString(resposta)
                RaiseEvent DataSent(Me, eSent)
            End If

        Catch ex As Exception
            Logger.MajorError("Exception while parsing message or creating implementor instance" + vbCrLf + ex.ToString())
            Logger.MajorError("Disconnecting client.")
            sender.TermClient()
            curMsg = Nothing
        End Try

    End Sub

    'Host disconnect event
    Private Sub WCDisconnected(ByVal sender As TCP.WorkerClient)

        Logger.MajorInfo("Client disconnected.")
        sender.TermClient()
        curCons -= 1

    End Sub

    'Host date event
    Private Sub WCMessageArrived(ByVal sender As TCP.WorkerClient, ByRef b() As Byte, ByVal len As Integer)

        'Raise a data-arrived event.
        Dim e As New TCPEventArgs
        e.RemoteClient = sender.ClientIP
        ReDim e.Data(len - 1)
        Array.Copy(b, 0, e.Data, 0, len)
        Debug.WriteLine("RaiseEvent DataArrived chamado!")
        RaiseEvent DataArrived(Me, e)

        Dim msg As New ThalesSim.Core.Message.Message(b)

        Logger.MajorVerbose("Client: " + sender.ClientIP + vbCrLf + _
                            "Request: " + msg.MessageData())

        Try
            Logger.MajorDebug("Parsing header and code of message " + msg.MessageData + "...")

            'Dim sHex As String = ""
            'Utility.ByteArrayToHexString(Utility.GetBytesFromString(msg.MessageData), sHex)
            'Logger.MajorDebug("TEMP: Hex dump is [" + sHex + "]")

            'Dim messageHeader As String = msg.GetSubstring(4)
            'msg.AdvanceIndex(4)
            Dim messageHeader As String = msg.GetSubstring(HeaderLength)
            msg.AdvanceIndex(HeaderLength)
            Dim commandCode As String = msg.GetSubstring(2)
            msg.AdvanceIndex(2)

            RaiseEvent CommandCalled(Me, commandCode)

            Logger.MajorDebug("Procurando for implementor of " + commandCode + "...")
            Dim CC As ThalesSim.Core.HostCommands.CommandClass = CE.GetLoadedCommand(commandCode)

            If CC Is Nothing Then
                Logger.MajorError("No implementor for " + commandCode + ".")

                ' Incrementa a �ltima letra do comando (ex: OI -> OJ)
                Dim respCode As String
                If commandCode.Length = 2 Then
                    Dim c1 As Char = commandCode(0)
                    Dim c2 As Char = commandCode(1)
                    respCode = c1 & Chr(Asc(c2) + 1)
                Else
                    respCode = commandCode
                End If

                ' Extrai trailer se necess�rio
                Dim trailingChars As String = ""
                If ExpectTrailers Then
                    trailingChars = msg.GetTrailers()
                End If

                ' Monta resposta: header + respCode + erro 67 + trailer
                Dim retMsgB As New ThalesSim.Core.Message.MessageResponse
                retMsgB.AddElementFront(ErrorCodes.ER_67_COMMAND_NOT_LICENSED)
                retMsgB.AddElementFront(respCode)
                retMsgB.AddElementFront(messageHeader)
                retMsgB.AddElement(trailingChars)

                sender.send(retMsgB.MessageData())
                RaiseDataSentEvent(sender.ClientIP, retMsgB)
                sender.TermClient()
                Exit Sub
            End If

            Logger.MajorDebug("Found implementor " + CC.DeclaringType.FullName() + ", instantiating...")
            Dim o As ThalesSim.Core.HostCommands.AHostCommand
            o = CType(Activator.CreateInstance(CC.DeclaringType), HostCommands.AHostCommand)

            Dim retMsg As ThalesSim.Core.Message.MessageResponse
            Dim retMsgAfterIO As ThalesSim.Core.Message.MessageResponse = Nothing

            Try
                Dim trailingChars As String = ""
                If ExpectTrailers Then
                    trailingChars = msg.GetTrailers()
                    Logger.MajorDebug("Trailer extra�do: [" & trailingChars & "]")
                End If

                If CheckLMKParity = False OrElse Cryptography.LMK.LMKStorage.CheckLMKStorage() = True Then
                    Logger.MinorInfo("=== [" + commandCode + "], starts " + Utility.getTimeMMHHSSmmmm + " =======")

                    Logger.MajorDebug("Comando recebido: " & commandCode)
                    Logger.MajorDebug("Classe do comando: " & CC.DeclaringType.FullName())
                    Logger.MajorDebug("ResponseCode configurado para este comando: " & CC.ResponseCode)
                    Logger.MajorDebug("ResponseCodeAfterIO configurado: " & CC.ResponseCodeAfterIO)

                    Logger.MajorDebug("Executando AcceptMessage()...")
                    o.AcceptMessage(msg)
                    Logger.MajorDebug("XMLParseResult ap�s AcceptMessage: " & o.XMLParseResult)

                    If o.XMLParseResult <> ErrorCodes.ER_00_NO_ERROR Then
                        Logger.MajorDebug("Erro detectado, montando resposta de erro.")
                        retMsg = New ThalesSim.Core.Message.MessageResponse
                        retMsg.AddElement(o.XMLParseResult)
                    Else
                        Logger.MajorDebug("Executando ConstructResponse()...")
                        retMsg = o.ConstructResponse()
                    End If

                    If o.XMLParseResult <> ErrorCodes.ER_00_NO_ERROR Then
                        Logger.MajorDebug("Erro detectado, montando resposta de erro.")
                        retMsg = New ThalesSim.Core.Message.MessageResponse
                        retMsg.AddElement(o.XMLParseResult)
                    Else
                        Logger.MajorDebug("Executando ConstructResponse()...")
                        retMsg = o.ConstructResponse()
                    End If

                    Logger.MajorDebug("Montando resposta final:")
                    Logger.MajorDebug(" - ResponseCode: " & CC.ResponseCode)
                    Logger.MajorDebug(" - Header: " & messageHeader)


                    Logger.MajorDebug("Montando resposta final:")
                    Logger.MajorDebug(" - Header: " & messageHeader)
                    Logger.MajorDebug(" - Response Code: " & CC.ResponseCode)
                    Logger.MajorDebug(" - Error Code: " & o.XMLParseResult)
                    Logger.MajorDebug(" - Data: " & retMsg.MessageDataWithoutErrorCode())
                    Logger.MajorDebug(" - Trailer: " & trailingChars)

                    retMsg.AddElementFront(CC.ResponseCode)
                    retMsg.AddElementFront(messageHeader)
                    retMsg.AddElement(trailingChars)

                    Logger.MajorVerbose("Resposta final montada: " & retMsg.MessageData())
                    sender.send(retMsg.MessageData())

                    RaiseDataSentEvent(sender.ClientIP, retMsg)

                    If retMsgAfterIO IsNot Nothing Then
                        Logger.MajorDebug("Attaching header/response code to response after I/O...")
                        retMsgAfterIO.AddElementFront(CC.ResponseCodeAfterIO)
                        retMsgAfterIO.AddElementFront(messageHeader)

                        'With "Generate and print" type of commands, we get another message after I/O.
                        'If we have end delimiter and trailer, only the end delimiter is added at the
                        'end of the last message.
                        If ExpectTrailers Then
                            retMsgAfterIO.AddElement(Utility.GetStringFromBytes(New Byte() {&H19}))
                        End If

                        Logger.MajorVerbose("Sending: " + retMsgAfterIO.MessageData())
                        sender.send(retMsgAfterIO.MessageData())

                        RaiseDataSentEvent(sender.ClientIP, retMsgAfterIO)
                    End If

                    Logger.MinorInfo("=== [" + commandCode + "],   ends " + Utility.getTimeMMHHSSmmmm + " =======" + vbCrLf)
                Else
                    Logger.MajorError("LMK parity error")
                    retMsg = New Message.MessageResponse
                    retMsg.AddElementFront(Core.ErrorCodes.ER_13_MASTER_KEY_PARITY_ERROR)
                    retMsg.AddElementFront(CC.ResponseCode)
                    retMsg.AddElementFront(messageHeader)
                    retMsg.AddElement(trailingChars)
                    sender.send(retMsg.MessageData())

                    RaiseDataSentEvent(sender.ClientIP, retMsgAfterIO)
                End If

            Catch ex As Exception
                Logger.MajorError("Exception while processing message" + vbCrLf + ex.ToString())
                Logger.MajorError("Disconnecting client.")
                sender.TermClient()
            End Try

            If o.PrinterData <> "" Then
                RaiseEvent PrinterData(Me, o.PrinterData)
            End If

            Logger.MajorDebug("Calling Terminate()...")
            o.Terminate()
            Logger.MajorDebug("Implementor to Nothing")
            o = Nothing

        Catch ex As Exception
            Logger.MajorError("Exception while parsing message or creating implementor instance" + vbCrLf + ex.ToString())
            Logger.MajorError("Disconnecting client.")
            sender.TermClient()
        End Try

    End Sub

    Private Sub RaiseDataSentEvent(ByVal remoteClient As String, ByVal msg As Message.MessageResponse)
        Dim e As New TCPEventArgs
        e.RemoteClient = remoteClient
        e.Data = Utility.GetBytesFromString(msg.MessageData)
        Debug.WriteLine("RaiseEvent DataSent chamado!")
        RaiseEvent DataSent(Me, e)
    End Sub

    Private Sub GetMajor(ByVal s As String) Implements Log.ILogProcs.GetMajor
        RaiseEvent MajorLogEvent(Me, s)
    End Sub

    Private Sub GetMinor(ByVal s As String) Implements Log.ILogProcs.GetMinor
        RaiseEvent MinorLogEvent(Me, s)
    End Sub

End Class
