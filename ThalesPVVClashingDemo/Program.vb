Imports System
Imports System.Text
Imports System.Windows.Forms

Module Program
    <STAThread>
    Sub Main()
        ' Register code page provider for Encoding.GetEncoding(1252) support
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New frmMain())
    End Sub
End Module