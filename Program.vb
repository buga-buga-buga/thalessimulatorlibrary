Imports System.Threading

Module Program
    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        ' Cria e mostra o SplashScreen
        Dim splash As New SplashScreen1()
        splash.Show()
        splash.Refresh()
        Application.DoEvents() ' Garante que o splash seja desenhado

        ' Simula carregamento pesado (substitua pelo seu código de inicialização)
        Threading.Thread.Sleep(3000) ' 3 segundos

        ' Fecha o SplashScreen
        splash.Close()

        ' Inicia o formulário principal
        Application.Run(New MainForm())
    End Sub
End Module