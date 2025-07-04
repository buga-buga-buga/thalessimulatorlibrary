﻿''
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

Imports ThalesSim.Core

Public Class frmMain

    Delegate Sub UpdateTextBox(ByVal s As String)

    Dim o As ThalesSim.Core.ThalesMain

    Private Sub cmdStartSim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStartSim.Click
        Try
            ' Se já existe um objeto, remove os handlers antigos
            If o IsNot Nothing Then
                RemoveHandler o.DataArrived, AddressOf o_DataArrived
                RemoveHandler o.DataSent, AddressOf o_DataSent
                RemoveHandler o.MajorLogEvent, AddressOf o_MajorLogEvent
                RemoveHandler o.MinorLogEvent, AddressOf o_MinorLogEvent
                RemoveHandler o.PrinterData, AddressOf o_PrinterData
            End If

            o = New ThalesMain

            ' Adiciona os handlers manualmente
            AddHandler o.DataArrived, AddressOf o_DataArrived
            AddHandler o.DataSent, AddressOf o_DataSent
            AddHandler o.MajorLogEvent, AddressOf o_MajorLogEvent
            AddHandler o.MinorLogEvent, AddressOf o_MinorLogEvent
            AddHandler o.PrinterData, AddressOf o_PrinterData

            o.StartUp(txtParameters.Text)
            EnDeGUI(False)
            sb.Panels(1).Text = "Running"
            UpdateAuthMode()
        Catch ex As Exception
            If o IsNot Nothing Then o.ShutDown()
            o = Nothing
            MessageBox.Show(Me, "Error during startup!" + vbCrLf + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnDeGUI(ByVal flag As Boolean)
        txtParameters.Enabled = flag
        cmdStartSim.Enabled = flag
        cmdStopSim.Enabled = Not flag
        cmdChangeAuth.Enabled = Not flag
        cmdLMK.Enabled = Not flag
        cmdLMKPairs.Enabled = Not flag
        gb.Enabled = Not flag
    End Sub

    Private Function GetByteDisplay(ByVal b() As Byte) As String
        Dim ret As New System.Text.StringBuilder, str As String = ""
        Dim hexStr As String = "", charStr As String = Utility.GetStringFromBytes(b)
        Utility.ByteArrayToHexString(b, hexStr)
        For i As Integer = 0 To b.GetLength(0) - 1
            ret.Append(hexStr.Substring(i * 2, 2) + " ")
            str = str + charStr.Substring(i, 1)
            If (i + 1) Mod 8 = 0 Then
                ret.Append("| " + str + vbCrLf)
                str = ""
            End If
        Next
        If str <> "" Then
            ret.Append(New String(" "c, (8 - (b.GetLength(0) Mod 8)) * 3) + "| " + str)
        End If
        Return ret.ToString
    End Function

    Private Sub o_DataArrived(ByVal sender As Core.ThalesMain, ByVal e As Core.TCPEventArgs)
        Debug.WriteLine("Evento o_DataArrived chamado!")
        '' If ThalesSim.Core.Log.Logger.CurrentLogLevel >= Log.Logger.LogLevel.Info Then
        Me.Invoke(New UpdateTextBox(AddressOf UpdateDataReceived), New String() {e.RemoteClient + vbCrLf + GetByteDisplay(e.Data) + vbCrLf})
        '' End If
    End Sub

    Private Sub o_DataSent(ByVal sender As Core.ThalesMain, ByVal e As Core.TCPEventArgs)
        ''If ThalesSim.Core.Log.Logger.CurrentLogLevel >= Log.Logger.LogLevel.Info Then
        Me.Invoke(New UpdateTextBox(AddressOf UpdateDataSent), New String() {e.RemoteClient + vbCrLf + GetByteDisplay(e.Data) + vbCrLf})
        '' End If
    End Sub

    Private Sub o_MajorLogEvent(ByVal sender As ThalesMain, ByVal s As String)
        Me.Invoke(New UpdateTextBox(AddressOf UpdateMajorLogEvent), New String() {s})
    End Sub

    Private Sub o_MinorLogEvent(ByVal sender As ThalesMain, ByVal s As String)
        Me.Invoke(New UpdateTextBox(AddressOf UpdateMinorLogEvent), New String() {s})
    End Sub

    Private Sub o_PrinterData(ByVal sender As ThalesMain, ByVal s As String)
        Me.Invoke(New UpdateTextBox(AddressOf UpdatePrinterData), New String() {s})
    End Sub

    Private Sub UpdateDataReceived(ByVal s As String)
        txtDataReceived.AppendText(s + vbCrLf)
    End Sub

    Private Sub UpdateDataSent(ByVal s As String)
        txtDataSent.AppendText(s + vbCrLf)
    End Sub

    Private Sub UpdateMajorLogEvent(ByVal s As String)
        txtMajorEvents.AppendText(s + vbCrLf)
    End Sub

    Private Sub UpdateMinorLogEvent(ByVal s As String)
        txtMinorEvents.AppendText(s + vbCrLf)
    End Sub

    Private Sub UpdatePrinterData(ByVal s As String)
        txtPrinterOutput.AppendText(s + vbCrLf)
    End Sub

    Private Sub cmdChangeAuth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeAuth.Click
        Resources.UpdateResource(Resources.AUTHORIZED_STATE, _
                                 Not Convert.ToBoolean(Resources.GetResource(Resources.AUTHORIZED_STATE)))
        UpdateAuthMode()
    End Sub

    Private Sub UpdateAuthMode()
        Dim authMode As Boolean = Convert.ToBoolean(Resources.GetResource(Resources.AUTHORIZED_STATE))
        If authMode Then
            sb.Panels(0).Text = "In authorized mode"
        Else
            sb.Panels(0).Text = "Not in authorized mode"
        End If
    End Sub

    Private Sub cmdStopSim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStopSim.Click
        ShutdownSim()
        EnDeGUI(True)
        sb.Panels(1).Text = "Stopped"
    End Sub

    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not (o Is Nothing) Then ShutdownSim()
    End Sub

    Private Sub ShutdownSim()
        RemoveHandler o.MajorLogEvent, AddressOf o_MajorLogEvent
        RemoveHandler o.MinorLogEvent, AddressOf o_MinorLogEvent
        RemoveHandler o.PrinterData, AddressOf o_PrinterData
        o.ShutDown()
        o = Nothing
        EnDeGUI(True)
    End Sub

    Private Sub cmdClearMajor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearMajor.Click
        txtMajorEvents.Clear()
        sb.Panels(2).Text = "Application events cleared"
    End Sub

    Private Sub cmdClearMinor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearMinor.Click
        txtMinorEvents.Clear()
        sb.Panels(2).Text = "Command events cleared"
    End Sub

    Private Sub cmdClearPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearPrinter.Click
        txtPrinterOutput.Clear()
        sb.Panels(2).Text = "Printer output cleared"
    End Sub

    Private Sub cmdCopyMajor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyMajor.Click
        Clipboard.SetDataObject(txtMajorEvents.Text)
        sb.Panels(2).Text = "Application events copied to clipboard"
    End Sub

    Private Sub cmdCopyMinor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyMinor.Click
        Clipboard.SetDataObject(txtMinorEvents.Text)
        sb.Panels(2).Text = "Command events copied to clipboard"
    End Sub

    Private Sub cmdCopyPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyPrinter.Click
        Clipboard.SetDataObject(txtPrinterOutput.Text)
        sb.Panels(2).Text = "Printer output copied to clipboard"
    End Sub

    Private Sub cmdClearDataReceived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearDataReceived.Click
        txtDataReceived.Clear()
        sb.Panels(2).Text = "Data received cleared"
    End Sub

    Private Sub cmdClearDataSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearDataSent.Click
        txtDataSent.Clear()
        sb.Panels(2).Text = "Data sent cleared"
    End Sub

    Private Sub cmdCopyDataReceived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyDataReceived.Click
        Clipboard.SetDataObject(txtDataReceived.Text)
        sb.Panels(2).Text = "Data received copied to clipboard"
    End Sub

    Private Sub cmdCopyDataSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyDataSent.Click
        Clipboard.SetDataObject(txtDataSent.Text)
        sb.Panels(2).Text = "Data sent copied to clipboard"
    End Sub

    Private Sub cmdLMK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLMK.Click
        MessageBox.Show(Me, "LMK parity OK: " + Cryptography.LMK.LMKStorage.CheckLMKStorage().ToString(), "LMK Check", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Clipboard.SetDataObject(Cryptography.LMK.LMKStorage.DumpLMKs())
        sb.Panels(2).Text = "LMKs copied to clipboard"
    End Sub

    Private Sub pbAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAbout.Click
        Dim frm As New frmAbout
        frm.ShowDialog(Me)
        frm = Nothing
    End Sub

    Private Sub rbLevel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDebug.CheckedChanged, rbError.CheckedChanged, rbInfo.CheckedChanged, rbNothing.CheckedChanged, rbVerbose.CheckedChanged, rbWarning.CheckedChanged
        If Not (CType(sender, RadioButton).Tag Is Nothing) Then
            Log.Logger.CurrentLogLevel = CType(CType(sender, RadioButton).Tag, Log.Logger.LogLevel)
            sb.Panels(2).Text = "Changed logging level to " + CType(CType(sender, RadioButton).Tag, Log.Logger.LogLevel).ToString()
        End If
    End Sub

    Private Sub cmdLMKPairs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLMKPairs.Click
        Dim frm As New frmKeyTypeTable
        frm.ShowDialog(Me)
        frm = Nothing
    End Sub

    Private Sub cmdConsole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsole.Click
        Dim frm As New frmConsole
        frm.ShowDialog(Me)
        frm = Nothing
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IO.File.Exists("ThalesParameters.xml") Then
            txtParameters.Text = "ThalesParameters.xml"
        Else
            'See where we are...
            Dim path As String = Reflection.Assembly.GetExecutingAssembly.Location
            'If there are / characters in the path, we assume it's Mono.
            If path.IndexOf("/") > -1 Then
                txtParameters.Text = path.Replace("ThalesWinSimulator.exe", "ThalesMonoParameters.txt")
            End If
        End If
    End Sub

End Class