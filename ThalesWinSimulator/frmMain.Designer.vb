<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtParameters As System.Windows.Forms.TextBox
    Friend WithEvents rbDebug As System.Windows.Forms.RadioButton
    Friend WithEvents rbVerbose As System.Windows.Forms.RadioButton
    Friend WithEvents rbInfo As System.Windows.Forms.RadioButton
    Friend WithEvents rbWarning As System.Windows.Forms.RadioButton
    Friend WithEvents rbError As System.Windows.Forms.RadioButton
    Friend WithEvents rbNothing As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents sb As System.Windows.Forms.StatusBar
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pbAbout As System.Windows.Forms.PictureBox
    Friend WithEvents txtMajorEvents As System.Windows.Forms.TextBox
    Friend WithEvents txtMinorEvents As System.Windows.Forms.TextBox
    Friend WithEvents txtPrinterOutput As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearMajor As System.Windows.Forms.Button
    Friend WithEvents cmdCopyMajor As System.Windows.Forms.Button
    Friend WithEvents cmdClearMinor As System.Windows.Forms.Button
    Friend WithEvents cmdClearPrinter As System.Windows.Forms.Button
    Friend WithEvents cmdCopyMinor As System.Windows.Forms.Button
    Friend WithEvents cmdCopyPrinter As System.Windows.Forms.Button
    Friend WithEvents cmdStartSim As System.Windows.Forms.Button
    Friend WithEvents cmdStopSim As System.Windows.Forms.Button
    Friend WithEvents cmdChangeAuth As System.Windows.Forms.Button
    Friend WithEvents cmdLMK As System.Windows.Forms.Button
    Friend WithEvents authMode As System.Windows.Forms.StatusBarPanel
    Friend WithEvents status As System.Windows.Forms.StatusBarPanel
    Friend WithEvents various As System.Windows.Forms.StatusBarPanel
    Friend WithEvents gb As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLMKPairs As System.Windows.Forms.Button

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtParameters = New System.Windows.Forms.TextBox()
        Me.gb = New System.Windows.Forms.GroupBox()
        Me.rbNothing = New System.Windows.Forms.RadioButton()
        Me.rbError = New System.Windows.Forms.RadioButton()
        Me.rbWarning = New System.Windows.Forms.RadioButton()
        Me.rbInfo = New System.Windows.Forms.RadioButton()
        Me.rbVerbose = New System.Windows.Forms.RadioButton()
        Me.rbDebug = New System.Windows.Forms.RadioButton()
        Me.txtMajorEvents = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMinorEvents = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrinterOutput = New System.Windows.Forms.TextBox()
        Me.sb = New System.Windows.Forms.StatusBar()
        Me.authMode = New System.Windows.Forms.StatusBarPanel()
        Me.status = New System.Windows.Forms.StatusBarPanel()
        Me.various = New System.Windows.Forms.StatusBarPanel()
        Me.cmdClearMajor = New System.Windows.Forms.Button()
        Me.cmdCopyMajor = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClearMinor = New System.Windows.Forms.Button()
        Me.cmdClearPrinter = New System.Windows.Forms.Button()
        Me.cmdCopyMinor = New System.Windows.Forms.Button()
        Me.cmdCopyPrinter = New System.Windows.Forms.Button()
        Me.cmdCopyDataSent = New System.Windows.Forms.Button()
        Me.cmdClearDataSent = New System.Windows.Forms.Button()
        Me.cmdCopyDataReceived = New System.Windows.Forms.Button()
        Me.cmdClearDataReceived = New System.Windows.Forms.Button()
        Me.cmdStartSim = New System.Windows.Forms.Button()
        Me.cmdStopSim = New System.Windows.Forms.Button()
        Me.cmdChangeAuth = New System.Windows.Forms.Button()
        Me.pbAbout = New System.Windows.Forms.PictureBox()
        Me.cmdLMK = New System.Windows.Forms.Button()
        Me.cmdLMKPairs = New System.Windows.Forms.Button()
        Me.cmdConsole = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDataSent = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDataReceived = New System.Windows.Forms.TextBox()
        Me.gb.SuspendLayout()
        CType(Me.authMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.various, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAbout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Parameters file:"
        '
        'txtParameters
        '
        Me.txtParameters.Location = New System.Drawing.Point(154, 7)
        Me.txtParameters.Name = "txtParameters"
        Me.txtParameters.Size = New System.Drawing.Size(384, 27)
        Me.txtParameters.TabIndex = 1
        Me.txtParameters.Text = "..\..\..\ThalesCore\ThalesParameters.xml"
        '
        'gb
        '
        Me.gb.Controls.Add(Me.rbNothing)
        Me.gb.Controls.Add(Me.rbError)
        Me.gb.Controls.Add(Me.rbWarning)
        Me.gb.Controls.Add(Me.rbInfo)
        Me.gb.Controls.Add(Me.rbVerbose)
        Me.gb.Controls.Add(Me.rbDebug)
        Me.gb.Enabled = False
        Me.gb.Location = New System.Drawing.Point(13, 46)
        Me.gb.Name = "gb"
        Me.gb.Size = New System.Drawing.Size(136, 251)
        Me.gb.TabIndex = 2
        Me.gb.TabStop = False
        Me.gb.Text = "Detail level"
        '
        'rbNothing
        '
        Me.rbNothing.Location = New System.Drawing.Point(13, 206)
        Me.rbNothing.Name = "rbNothing"
        Me.rbNothing.Size = New System.Drawing.Size(102, 34)
        Me.rbNothing.TabIndex = 5
        Me.rbNothing.Tag = "0"
        Me.rbNothing.Text = "Nothing"
        '
        'rbError
        '
        Me.rbError.Location = New System.Drawing.Point(13, 171)
        Me.rbError.Name = "rbError"
        Me.rbError.Size = New System.Drawing.Size(102, 35)
        Me.rbError.TabIndex = 4
        Me.rbError.Tag = "1"
        Me.rbError.Text = "Error"
        '
        'rbWarning
        '
        Me.rbWarning.Location = New System.Drawing.Point(13, 137)
        Me.rbWarning.Name = "rbWarning"
        Me.rbWarning.Size = New System.Drawing.Size(113, 34)
        Me.rbWarning.TabIndex = 3
        Me.rbWarning.Tag = "2"
        Me.rbWarning.Text = "Warning"
        '
        'rbInfo
        '
        Me.rbInfo.Location = New System.Drawing.Point(13, 103)
        Me.rbInfo.Name = "rbInfo"
        Me.rbInfo.Size = New System.Drawing.Size(102, 34)
        Me.rbInfo.TabIndex = 2
        Me.rbInfo.Tag = "3"
        Me.rbInfo.Text = "Info"
        '
        'rbVerbose
        '
        Me.rbVerbose.Location = New System.Drawing.Point(13, 69)
        Me.rbVerbose.Name = "rbVerbose"
        Me.rbVerbose.Size = New System.Drawing.Size(102, 34)
        Me.rbVerbose.TabIndex = 1
        Me.rbVerbose.Tag = "4"
        Me.rbVerbose.Text = "Verbose"
        '
        'rbDebug
        '
        Me.rbDebug.Checked = True
        Me.rbDebug.Location = New System.Drawing.Point(13, 34)
        Me.rbDebug.Name = "rbDebug"
        Me.rbDebug.Size = New System.Drawing.Size(102, 35)
        Me.rbDebug.TabIndex = 0
        Me.rbDebug.TabStop = True
        Me.rbDebug.Tag = "5"
        Me.rbDebug.Text = "Debug"
        '
        'txtMajorEvents
        '
        Me.txtMajorEvents.Location = New System.Drawing.Point(158, 86)
        Me.txtMajorEvents.Multiline = True
        Me.txtMajorEvents.Name = "txtMajorEvents"
        Me.txtMajorEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMajorEvents.Size = New System.Drawing.Size(487, 383)
        Me.txtMajorEvents.TabIndex = 3
        Me.txtMajorEvents.WordWrap = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(158, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 33)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Application Events"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.Location = New System.Drawing.Point(718, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 33)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Command Events"
        '
        'txtMinorEvents
        '
        Me.txtMinorEvents.Location = New System.Drawing.Point(718, 86)
        Me.txtMinorEvents.Multiline = True
        Me.txtMinorEvents.Name = "txtMinorEvents"
        Me.txtMinorEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMinorEvents.Size = New System.Drawing.Size(487, 383)
        Me.txtMinorEvents.TabIndex = 5
        Me.txtMinorEvents.WordWrap = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label4.Location = New System.Drawing.Point(158, 474)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(231, 33)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Printer Output"
        '
        'txtPrinterOutput
        '
        Me.txtPrinterOutput.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPrinterOutput.Location = New System.Drawing.Point(158, 511)
        Me.txtPrinterOutput.Multiline = True
        Me.txtPrinterOutput.Name = "txtPrinterOutput"
        Me.txtPrinterOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPrinterOutput.Size = New System.Drawing.Size(1045, 163)
        Me.txtPrinterOutput.TabIndex = 7
        Me.txtPrinterOutput.WordWrap = False
        '
        'sb
        '
        Me.sb.Location = New System.Drawing.Point(0, 1060)
        Me.sb.Name = "sb"
        Me.sb.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.authMode, Me.status, Me.various})
        Me.sb.ShowPanels = True
        Me.sb.Size = New System.Drawing.Size(1358, 32)
        Me.sb.SizingGrip = False
        Me.sb.TabIndex = 9
        '
        'authMode
        '
        Me.authMode.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.authMode.Name = "authMode"
        Me.authMode.Width = 10
        '
        'status
        '
        Me.status.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.status.Name = "status"
        Me.status.Text = "Stopped"
        Me.status.Width = 77
        '
        'various
        '
        Me.various.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.various.Name = "various"
        Me.various.Width = 1271
        '
        'cmdClearMajor
        '
        Me.cmdClearMajor.BackgroundImage = CType(resources.GetObject("cmdClearMajor.BackgroundImage"), System.Drawing.Image)
        Me.cmdClearMajor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdClearMajor.Location = New System.Drawing.Point(658, 87)
        Me.cmdClearMajor.Name = "cmdClearMajor"
        Me.cmdClearMajor.Size = New System.Drawing.Size(51, 46)
        Me.cmdClearMajor.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.cmdClearMajor, "Click to clear application events")
        '
        'cmdCopyMajor
        '
        Me.cmdCopyMajor.BackgroundImage = CType(resources.GetObject("cmdCopyMajor.BackgroundImage"), System.Drawing.Image)
        Me.cmdCopyMajor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCopyMajor.Location = New System.Drawing.Point(658, 143)
        Me.cmdCopyMajor.Name = "cmdCopyMajor"
        Me.cmdCopyMajor.Size = New System.Drawing.Size(51, 46)
        Me.cmdCopyMajor.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.cmdCopyMajor, "Click to copy application events to the clipboard")
        '
        'cmdClearMinor
        '
        Me.cmdClearMinor.BackgroundImage = CType(resources.GetObject("cmdClearMinor.BackgroundImage"), System.Drawing.Image)
        Me.cmdClearMinor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdClearMinor.Location = New System.Drawing.Point(1216, 87)
        Me.cmdClearMinor.Name = "cmdClearMinor"
        Me.cmdClearMinor.Size = New System.Drawing.Size(51, 46)
        Me.cmdClearMinor.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.cmdClearMinor, "Click to clear command events")
        '
        'cmdClearPrinter
        '
        Me.cmdClearPrinter.BackgroundImage = CType(resources.GetObject("cmdClearPrinter.BackgroundImage"), System.Drawing.Image)
        Me.cmdClearPrinter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdClearPrinter.Location = New System.Drawing.Point(1211, 509)
        Me.cmdClearPrinter.Name = "cmdClearPrinter"
        Me.cmdClearPrinter.Size = New System.Drawing.Size(51, 45)
        Me.cmdClearPrinter.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.cmdClearPrinter, "Click to clear printer output")
        '
        'cmdCopyMinor
        '
        Me.cmdCopyMinor.BackgroundImage = CType(resources.GetObject("cmdCopyMinor.BackgroundImage"), System.Drawing.Image)
        Me.cmdCopyMinor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCopyMinor.Location = New System.Drawing.Point(1216, 143)
        Me.cmdCopyMinor.Name = "cmdCopyMinor"
        Me.cmdCopyMinor.Size = New System.Drawing.Size(51, 46)
        Me.cmdCopyMinor.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.cmdCopyMinor, "Click to copy command events to the clipboard")
        '
        'cmdCopyPrinter
        '
        Me.cmdCopyPrinter.BackgroundImage = CType(resources.GetObject("cmdCopyPrinter.BackgroundImage"), System.Drawing.Image)
        Me.cmdCopyPrinter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCopyPrinter.Location = New System.Drawing.Point(1211, 566)
        Me.cmdCopyPrinter.Name = "cmdCopyPrinter"
        Me.cmdCopyPrinter.Size = New System.Drawing.Size(51, 45)
        Me.cmdCopyPrinter.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.cmdCopyPrinter, "Click to copy printer output to the clipboard")
        '
        'cmdCopyDataSent
        '
        Me.cmdCopyDataSent.BackgroundImage = CType(resources.GetObject("cmdCopyDataSent.BackgroundImage"), System.Drawing.Image)
        Me.cmdCopyDataSent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCopyDataSent.Location = New System.Drawing.Point(1214, 774)
        Me.cmdCopyDataSent.Name = "cmdCopyDataSent"
        Me.cmdCopyDataSent.Size = New System.Drawing.Size(52, 46)
        Me.cmdCopyDataSent.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.cmdCopyDataSent, "Click to copy data sent to the clipboard")
        '
        'cmdClearDataSent
        '
        Me.cmdClearDataSent.BackgroundImage = CType(resources.GetObject("cmdClearDataSent.BackgroundImage"), System.Drawing.Image)
        Me.cmdClearDataSent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdClearDataSent.Location = New System.Drawing.Point(1214, 719)
        Me.cmdClearDataSent.Name = "cmdClearDataSent"
        Me.cmdClearDataSent.Size = New System.Drawing.Size(52, 45)
        Me.cmdClearDataSent.TabIndex = 31
        Me.ToolTip1.SetToolTip(Me.cmdClearDataSent, "Click to clear data sent")
        '
        'cmdCopyDataReceived
        '
        Me.cmdCopyDataReceived.BackgroundImage = CType(resources.GetObject("cmdCopyDataReceived.BackgroundImage"), System.Drawing.Image)
        Me.cmdCopyDataReceived.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCopyDataReceived.Location = New System.Drawing.Point(656, 774)
        Me.cmdCopyDataReceived.Name = "cmdCopyDataReceived"
        Me.cmdCopyDataReceived.Size = New System.Drawing.Size(51, 46)
        Me.cmdCopyDataReceived.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.cmdCopyDataReceived, "Click to copy data received to the clipboard")
        '
        'cmdClearDataReceived
        '
        Me.cmdClearDataReceived.BackgroundImage = CType(resources.GetObject("cmdClearDataReceived.BackgroundImage"), System.Drawing.Image)
        Me.cmdClearDataReceived.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdClearDataReceived.Location = New System.Drawing.Point(656, 719)
        Me.cmdClearDataReceived.Name = "cmdClearDataReceived"
        Me.cmdClearDataReceived.Size = New System.Drawing.Size(51, 45)
        Me.cmdClearDataReceived.TabIndex = 29
        Me.ToolTip1.SetToolTip(Me.cmdClearDataReceived, "Click to clear data received")
        '
        'cmdStartSim
        '
        Me.cmdStartSim.Location = New System.Drawing.Point(13, 320)
        Me.cmdStartSim.Name = "cmdStartSim"
        Me.cmdStartSim.Size = New System.Drawing.Size(120, 69)
        Me.cmdStartSim.TabIndex = 16
        Me.cmdStartSim.Text = "Start Simulator"
        '
        'cmdStopSim
        '
        Me.cmdStopSim.Enabled = False
        Me.cmdStopSim.Location = New System.Drawing.Point(13, 400)
        Me.cmdStopSim.Name = "cmdStopSim"
        Me.cmdStopSim.Size = New System.Drawing.Size(120, 69)
        Me.cmdStopSim.TabIndex = 17
        Me.cmdStopSim.Text = "Stop Simulator"
        '
        'cmdChangeAuth
        '
        Me.cmdChangeAuth.Enabled = False
        Me.cmdChangeAuth.Location = New System.Drawing.Point(13, 481)
        Me.cmdChangeAuth.Name = "cmdChangeAuth"
        Me.cmdChangeAuth.Size = New System.Drawing.Size(120, 79)
        Me.cmdChangeAuth.TabIndex = 18
        Me.cmdChangeAuth.Text = "Change Authorized Mode"
        '
        'pbAbout
        '
        Me.pbAbout.Image = CType(resources.GetObject("pbAbout.Image"), System.Drawing.Image)
        Me.pbAbout.Location = New System.Drawing.Point(1211, 7)
        Me.pbAbout.Name = "pbAbout"
        Me.pbAbout.Size = New System.Drawing.Size(51, 46)
        Me.pbAbout.TabIndex = 20
        Me.pbAbout.TabStop = False
        '
        'cmdLMK
        '
        Me.cmdLMK.Enabled = False
        Me.cmdLMK.Location = New System.Drawing.Point(13, 571)
        Me.cmdLMK.Name = "cmdLMK"
        Me.cmdLMK.Size = New System.Drawing.Size(120, 46)
        Me.cmdLMK.TabIndex = 21
        Me.cmdLMK.Text = "LMK Store"
        '
        'cmdLMKPairs
        '
        Me.cmdLMKPairs.Enabled = False
        Me.cmdLMKPairs.Location = New System.Drawing.Point(13, 629)
        Me.cmdLMKPairs.Name = "cmdLMKPairs"
        Me.cmdLMKPairs.Size = New System.Drawing.Size(120, 45)
        Me.cmdLMKPairs.TabIndex = 23
        Me.cmdLMKPairs.Text = "LMK Pairs"
        '
        'cmdConsole
        '
        Me.cmdConsole.BackgroundImage = CType(resources.GetObject("cmdConsole.BackgroundImage"), System.Drawing.Image)
        Me.cmdConsole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdConsole.Location = New System.Drawing.Point(26, 717)
        Me.cmdConsole.Name = "cmdConsole"
        Me.cmdConsole.Size = New System.Drawing.Size(88, 67)
        Me.cmdConsole.TabIndex = 24
        Me.cmdConsole.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdConsole.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label5.Location = New System.Drawing.Point(717, 684)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(230, 33)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Data Sent"
        '
        'txtDataSent
        '
        Me.txtDataSent.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtDataSent.Location = New System.Drawing.Point(717, 717)
        Me.txtDataSent.Multiline = True
        Me.txtDataSent.Name = "txtDataSent"
        Me.txtDataSent.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDataSent.Size = New System.Drawing.Size(486, 267)
        Me.txtDataSent.TabIndex = 27
        Me.txtDataSent.WordWrap = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.Location = New System.Drawing.Point(157, 684)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(230, 33)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Data Received"
        '
        'txtDataReceived
        '
        Me.txtDataReceived.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtDataReceived.Location = New System.Drawing.Point(157, 717)
        Me.txtDataReceived.Multiline = True
        Me.txtDataReceived.Name = "txtDataReceived"
        Me.txtDataReceived.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDataReceived.Size = New System.Drawing.Size(486, 267)
        Me.txtDataReceived.TabIndex = 25
        Me.txtDataReceived.WordWrap = False
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 20)
        Me.ClientSize = New System.Drawing.Size(1358, 1092)
        Me.Controls.Add(Me.cmdCopyDataSent)
        Me.Controls.Add(Me.cmdClearDataSent)
        Me.Controls.Add(Me.cmdCopyDataReceived)
        Me.Controls.Add(Me.cmdClearDataReceived)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDataSent)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDataReceived)
        Me.Controls.Add(Me.cmdConsole)
        Me.Controls.Add(Me.cmdLMKPairs)
        Me.Controls.Add(Me.cmdLMK)
        Me.Controls.Add(Me.pbAbout)
        Me.Controls.Add(Me.cmdChangeAuth)
        Me.Controls.Add(Me.cmdStopSim)
        Me.Controls.Add(Me.cmdStartSim)
        Me.Controls.Add(Me.cmdCopyPrinter)
        Me.Controls.Add(Me.cmdClearPrinter)
        Me.Controls.Add(Me.cmdCopyMinor)
        Me.Controls.Add(Me.cmdClearMinor)
        Me.Controls.Add(Me.cmdCopyMajor)
        Me.Controls.Add(Me.cmdClearMajor)
        Me.Controls.Add(Me.sb)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPrinterOutput)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMinorEvents)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMajorEvents)
        Me.Controls.Add(Me.gb)
        Me.Controls.Add(Me.txtParameters)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thales Simulator"
        Me.gb.ResumeLayout(False)
        CType(Me.authMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.various, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAbout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdConsole As System.Windows.Forms.Button
    Friend WithEvents cmdCopyDataSent As System.Windows.Forms.Button
    Friend WithEvents cmdClearDataSent As System.Windows.Forms.Button
    Friend WithEvents cmdCopyDataReceived As System.Windows.Forms.Button
    Friend WithEvents cmdClearDataReceived As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDataSent As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDataReceived As System.Windows.Forms.TextBox
End Class
