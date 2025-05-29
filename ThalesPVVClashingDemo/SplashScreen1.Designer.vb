<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen1
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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
    Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label
    Friend WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DetailsLayoutPanel As System.Windows.Forms.TableLayoutPanel

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen1))
        MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        DetailsLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Version = New System.Windows.Forms.Label()
        Copyright = New System.Windows.Forms.Label()
        ApplicationTitle = New System.Windows.Forms.Label()
        MainLayoutPanel.SuspendLayout()
        DetailsLayoutPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' MainLayoutPanel
        ' 
        MainLayoutPanel.BackgroundImage = CType(resources.GetObject("MainLayoutPanel.BackgroundImage"), Drawing.Image)
        MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        MainLayoutPanel.ColumnCount = 2
        MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243F))
        MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F))
        MainLayoutPanel.Controls.Add(DetailsLayoutPanel, 1, 1)
        MainLayoutPanel.Controls.Add(ApplicationTitle, 1, 0)
        MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        MainLayoutPanel.Location = New System.Drawing.Point(0, 0)
        MainLayoutPanel.Name = "MainLayoutPanel"
        MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 218F))
        MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F))
        MainLayoutPanel.Size = New System.Drawing.Size(496, 303)
        MainLayoutPanel.TabIndex = 0
        ' 
        ' DetailsLayoutPanel
        ' 
        DetailsLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        DetailsLayoutPanel.BackColor = Drawing.Color.Transparent
        DetailsLayoutPanel.ColumnCount = 1
        DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F))
        DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F))
        DetailsLayoutPanel.Controls.Add(Version, 0, 0)
        DetailsLayoutPanel.Controls.Add(Copyright, 0, 1)
        DetailsLayoutPanel.Location = New System.Drawing.Point(246, 221)
        DetailsLayoutPanel.Name = "DetailsLayoutPanel"
        DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F))
        DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F))
        DetailsLayoutPanel.Size = New System.Drawing.Size(247, 79)
        DetailsLayoutPanel.TabIndex = 1
        ' 
        ' Version
        ' 
        Version.Anchor = System.Windows.Forms.AnchorStyles.None
        Version.BackColor = Drawing.Color.Transparent
        Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        Version.Location = New System.Drawing.Point(3, 1)
        Version.Name = "Version"
        Version.Size = New System.Drawing.Size(241, 36)
        Version.TabIndex = 1
        Version.Text = "Prova de Conceito"
        Version.TextAlign = Drawing.ContentAlignment.MiddleLeft
        ' 
        ' Copyright
        ' 
        Copyright.Anchor = System.Windows.Forms.AnchorStyles.None
        Copyright.BackColor = Drawing.Color.Transparent
        Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        Copyright.Location = New System.Drawing.Point(3, 45)
        Copyright.Name = "Copyright"
        Copyright.Size = New System.Drawing.Size(241, 28)
        Copyright.TabIndex = 2
        Copyright.Text = "2025 - BugaSoft"
        Copyright.TextAlign = Drawing.ContentAlignment.BottomRight
        ' 
        ' ApplicationTitle
        ' 
        ApplicationTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        ApplicationTitle.BackColor = Drawing.Color.Transparent
        ApplicationTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, CByte(0))
        ApplicationTitle.Location = New System.Drawing.Point(246, 3)
        ApplicationTitle.Name = "ApplicationTitle"
        ApplicationTitle.Size = New System.Drawing.Size(247, 212)
        ApplicationTitle.TabIndex = 0
        ApplicationTitle.Text = "Brute Force - PVV"
        ApplicationTitle.TextAlign = Drawing.ContentAlignment.MiddleCenter
        ' 
        ' SplashScreen1
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(10F, 25F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(496, 303)
        ControlBox = False
        Controls.Add(MainLayoutPanel)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "SplashScreen1"
        ShowInTaskbar = False
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        MainLayoutPanel.ResumeLayout(False)
        DetailsLayoutPanel.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

End Class
