﻿Imports System.Windows.Forms
Imports ThalesSim
Imports ThalesSim.Core
Imports System.Text

Public Class frmMain

    Dim WithEvents thales As TCP.WorkerClient
    Dim thalesData As String = ""

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.PIN = txtPIN.Text
        My.Settings.PAN = txtPAN.Text
        My.Settings.clearTPK = txtClearTPK.Text
        My.Settings.encryptedTPK = txtCryptTPK.Text
        My.Settings.encryptedPVK = txtCryptPVK.Text
        My.Settings.thalesIP = txtIPAddress.Text
        My.Settings.thalesPort = txtPort.Text
        My.Settings.Save()
    End Sub

    Private Sub cmdFindAllPINs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindAllPINs.Click
        Me.Enabled = False

        ' Validação do comprimento do PAN antes de usar Substring
        If txtPAN.Text.Length < 13 Then
            MessageBox.Show("O campo PAN deve conter pelo menos 13 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Enabled = True
            Exit Sub
        End If

        Try
            thales = New TCP.WorkerClient(New Net.Sockets.TcpClient(txtIPAddress.Text, Convert.ToInt32(txtPort.Text)))
            thales.InitOps()
        Catch ex As Exception
            doLog("Connection error (" + ex.Message + ")")
            Me.Enabled = True
            Exit Sub
        End Try

        txtLog.Text = ""

        doLog("Finding PVV for PIN " + txtPIN.Text + "...")
        Dim key As New Cryptography.HexKey(txtClearTPK.Text)
        Dim PB As String = Cryptography.TripleDES.TripleDESEncrypt(key, txtPIN.Text + New String("F"c, 12))
        Dim acctNumber As String = txtPAN.Text.Substring(txtPAN.Text.Length - 13, 12)

        Dim reply As String = SendFunctionCommand("1234JC" + txtCryptTPK.Text + PB + "03" + acctNumber)
        If reply.Substring(6, 2) = "00" Then
            reply = SendFunctionCommand("1234DG" + txtCryptPVK.Text + reply.Substring(8, 5) + acctNumber + "1")
            If reply.Substring(6, 2) = "00" Then

                Dim PVV As String = reply.Substring(8, 4)
                doLog("PVV is " + PVV)
                doLog("Running PIN verification for all PINs and this PVV, wait it will last a little bit...")

                ' Loop principal que executa 9999 vezes pra achar todos os possiveis
                For i As Integer = 0 To 9999
                    PB = Cryptography.TripleDES.TripleDESEncrypt(key, i.ToString.PadLeft(4, "0"c) + New String("F"c, 12))
                    reply = SendFunctionCommand("1234DC" + txtCryptTPK.Text + txtCryptPVK.Text + PB + "03" + acctNumber + "1" + PVV)
                    If reply.Substring(6, 2) = "00" Then
                        doLog("Verified for PIN [" + i.ToString.PadLeft(4, "0"c) + "]")
                    End If
                    If i Mod 50 = 0 Then
                        lblStatus.Text = "Running verification for PIN #" + i.ToString.PadLeft(4, "0"c) + "..."
                        Application.DoEvents()
                    End If
                Next

                lblStatus.Text = "Done."
            Else
                doLog("Error on DG: " + reply)
            End If
        Else
            doLog("Error on JC: " + reply)
        End If

        thales.TermClient()
        thales = Nothing
        Me.Enabled = True
    End Sub

    Private Function SendFunctionCommand(ByVal s As String) As String
        thalesData = ""
        thales.send(s)

        While thalesData = "" AndAlso thales.IsConnected
            Threading.Thread.Sleep(1)
        End While

        If Not thales.IsConnected Then
            Return ""
        Else
            Return thalesData
        End If
    End Function

    Private Sub thales_Disconnected(ByVal sender As ThalesSim.Core.TCP.WorkerClient) Handles thales.Disconnected
        doLog("Disconnected from HSM")
    End Sub

    Private Sub thales_MessageArrived(ByVal sender As ThalesSim.Core.TCP.WorkerClient, ByRef b() As Byte, ByVal len As Integer) Handles thales.MessageArrived
        thalesData = System.Text.Encoding.Default.GetString(b, 0, len)
    End Sub

    Private Sub doLog(ByVal s As String)
        txtLog.AppendText(s + vbCrLf)
        txtLog.ScrollToCaret()
    End Sub

    'Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Dim key As RSAKey = RSAFunctions.GetStandardRSAKey
    '    Dim pbcrypt() As Byte = RSAFunctions.GetRSAEncryptedPINBlock(key, "1234", "407000025321")
    '    Dim pbclear As String = RSAFunctions.GetRSADecryptedPINBlock(key, pbcrypt)
    '    Dim pinclear As String = PIN.PINBlockFormat.ToPIN(pbclear, "407000025321", Core.PIN.PINBlockFormat.PIN_Block_Format.AnsiX98)
    '    Dim pbstring As String = String.Empty
    '    Utility.ByteArrayToHexString(pbcrypt, pbstring)
    'End Sub
End Class