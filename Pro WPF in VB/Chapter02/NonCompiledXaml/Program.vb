Public Class Program
    Inherits Application

    Shared Sub Main()
        Dim mn As New Program()
        mn.MainWindow = New Window1()
        mn.MainWindow.ShowDialog()
    End Sub
End Class
