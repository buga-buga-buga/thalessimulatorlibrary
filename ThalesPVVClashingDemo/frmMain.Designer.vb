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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim MySettings1 As ThalesPVVClashingDemo.My.MySettings = New My.MySettings()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        txtIPAddress = New System.Windows.Forms.TextBox()
        GroupBox2 = New System.Windows.Forms.GroupBox()
        txtCryptPVK = New System.Windows.Forms.TextBox()
        txtCryptTPK = New System.Windows.Forms.TextBox()
        txtClearTPK = New System.Windows.Forms.TextBox()
        Label5 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        GroupBox3 = New System.Windows.Forms.GroupBox()
        txtPIN = New System.Windows.Forms.MaskedTextBox()
        Label7 = New System.Windows.Forms.Label()
        txtPAN = New System.Windows.Forms.TextBox()
        Label6 = New System.Windows.Forms.Label()
        cmdFindAllPINs = New System.Windows.Forms.Button()
        txtLog = New System.Windows.Forms.TextBox()
        Label1 = New System.Windows.Forms.Label()
        txtPort = New System.Windows.Forms.MaskedTextBox()
        lblStatus = New System.Windows.Forms.Label()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtIPAddress
        ' 
        txtIPAddress.Location = New System.Drawing.Point(195, 9)
        txtIPAddress.Name = "txtIPAddress"
        txtIPAddress.Size = New System.Drawing.Size(131, 27)
        txtIPAddress.TabIndex = 1
        txtIPAddress.Text = "127.0.0.1"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(txtCryptPVK)
        GroupBox2.Controls.Add(txtCryptTPK)
        GroupBox2.Controls.Add(txtClearTPK)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Location = New System.Drawing.Point(12, 45)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New System.Drawing.Size(614, 178)
        GroupBox2.TabIndex = 2
        GroupBox2.TabStop = False
        GroupBox2.Text = "Chaves"
        ' 
        ' txtCryptPVK
        ' 
        txtCryptPVK.Location = New System.Drawing.Point(136, 141)
        txtCryptPVK.Name = "txtCryptPVK"
        txtCryptPVK.Size = New System.Drawing.Size(465, 27)
        txtCryptPVK.TabIndex = 8
        txtCryptPVK.Text = "UA8B1520E201412938388191885FFA50A"
        ' 
        ' txtCryptTPK
        ' 
        txtCryptTPK.Location = New System.Drawing.Point(143, 91)
        txtCryptTPK.Name = "txtCryptTPK"
        txtCryptTPK.Size = New System.Drawing.Size(458, 27)
        txtCryptTPK.TabIndex = 7
        txtCryptTPK.Text = "U8463435FC4B4DAA0C49025272C29B12C"
        ' 
        ' txtClearTPK
        ' 
        MySettings1.clearTPK = "D3DCC7EA9BCB755D254620B376B3D007"
        MySettings1.encryptedPVK = "UA8B1520E201412938388191885FFA50A"
        MySettings1.encryptedTPK = "U8463435FC4B4DAA0C49025272C29B12C"
        MySettings1.PAN = "5044070000253237"
        MySettings1.PIN = "1234"
        MySettings1.SettingsKey = ""
        MySettings1.thalesIP = "127.0.0.1"
        MySettings1.thalesPort = "9998"
        txtClearTPK.DataBindings.Add(New System.Windows.Forms.Binding("Text", MySettings1, "clearTPK", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        txtClearTPK.Location = New System.Drawing.Point(143, 39)
        txtClearTPK.Name = "txtClearTPK"
        txtClearTPK.Size = New System.Drawing.Size(458, 27)
        txtClearTPK.TabIndex = 6
        txtClearTPK.Text = "D3DCC7EA9BCB755D254620B376B3D007"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(0, 147)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(124, 21)
        Label5.TabIndex = 5
        Label5.Text = "Encrypted PVK:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(0, 94)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(124, 21)
        Label4.TabIndex = 4
        Label4.Text = "Encrypted TPK:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(0, 45)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(88, 21)
        Label3.TabIndex = 3
        Label3.Text = "Clear TPK:"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(txtPIN)
        GroupBox3.Controls.Add(Label7)
        GroupBox3.Controls.Add(txtPAN)
        GroupBox3.Controls.Add(Label6)
        GroupBox3.Location = New System.Drawing.Point(12, 250)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New System.Drawing.Size(342, 103)
        GroupBox3.TabIndex = 3
        GroupBox3.TabStop = False
        GroupBox3.Text = "PAN and PIN"
        ' 
        ' txtPIN
        ' 
        txtPIN.Location = New System.Drawing.Point(82, 59)
        txtPIN.Mask = "0000"
        txtPIN.Name = "txtPIN"
        txtPIN.Size = New System.Drawing.Size(54, 27)
        txtPIN.TabIndex = 9
        txtPIN.Text = "1234"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(11, 62)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(42, 21)
        Label7.TabIndex = 8
        Label7.Text = "PIN:"
        ' 
        ' txtPAN
        ' 
        txtPAN.Location = New System.Drawing.Point(82, 26)
        txtPAN.MaxLength = 19
        txtPAN.Name = "txtPAN"
        txtPAN.Size = New System.Drawing.Size(291, 27)
        txtPAN.TabIndex = 7
        txtPAN.Text = "5044070000253237"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(6, 20)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(47, 21)
        Label6.TabIndex = 4
        Label6.Text = "PAN:"
        ' 
        ' cmdFindAllPINs
        ' 
        cmdFindAllPINs.Location = New System.Drawing.Point(417, 292)
        cmdFindAllPINs.Name = "cmdFindAllPINs"
        cmdFindAllPINs.Size = New System.Drawing.Size(180, 61)
        cmdFindAllPINs.TabIndex = 4
        cmdFindAllPINs.Text = "Find all PINs"
        cmdFindAllPINs.UseVisualStyleBackColor = True
        ' 
        ' txtLog
        ' 
        txtLog.Location = New System.Drawing.Point(648, 12)
        txtLog.Multiline = True
        txtLog.Name = "txtLog"
        txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        txtLog.Size = New System.Drawing.Size(335, 325)
        txtLog.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(18, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(150, 21)
        Label1.TabIndex = 8
        Label1.Text = "IP e porta do HSM:"
        ' 
        ' txtPort
        ' 
        txtPort.Location = New System.Drawing.Point(360, 6)
        txtPort.Mask = "00000"
        txtPort.Name = "txtPort"
        txtPort.Size = New System.Drawing.Size(98, 27)
        txtPort.TabIndex = 4
        txtPort.Text = "9998"
        txtPort.ValidatingType = GetType(Integer)
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New System.Drawing.Point(12, 420)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New System.Drawing.Size(0, 21)
        lblStatus.TabIndex = 99
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(9.0F, 21.0F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(1005, 382)
        Controls.Add(txtPort)
        Controls.Add(Label1)
        Controls.Add(txtLog)
        Controls.Add(txtIPAddress)
        Controls.Add(cmdFindAllPINs)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(lblStatus)
        Font = New System.Drawing.Font("Tahoma", 8.25F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(161))
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Drawing.Icon)
        MaximizeBox = False
        Name = "frmMain"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Text = "Brute Force - PVV Clashing Demo"
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCryptPVK As System.Windows.Forms.TextBox
    Friend WithEvents txtCryptTPK As System.Windows.Forms.TextBox
    Friend WithEvents txtClearTPK As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPIN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPAN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdFindAllPINs As System.Windows.Forms.Button
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
