Public Class Window1

    Private Sub OpenWindow(ByVal sender As Object, ByVal args As RoutedEventArgs)
        CType(New TestWindow(), TestWindow).Visibility = Visibility.Visible
    End Sub

    Private Sub OpenNavWindow(ByVal sender As Object, ByVal args As RoutedEventArgs)
        CType(New TestNavigationWindow(), TestNavigationWindow).Visibility = Visibility.Visible
    End Sub
End Class
