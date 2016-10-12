Public Class AlternatingRowStyleSelector
    Inherits StyleSelector

    Private _defaultStyle As Style
    Public Property DefaultStyle() As Style
        Get
            Return _defaultStyle
        End Get
        Set(ByVal value As Style)
            _defaultStyle = value
        End Set
    End Property

    Private _alternateStyle As Style
    Public Property AlternateStyle() As Style
        Get
            Return _alternateStyle
        End Get
        Set(ByVal value As Style)
            _alternateStyle = value
        End Set
    End Property

    ' Track the position.
    Private i As Integer = 0
    Public Overrides Function SelectStyle(ByVal item As Object, ByVal container As DependencyObject) As Style
        ' Reset the counter if this is the first item.
        Dim ctrl As ItemsControl = ItemsControl.ItemsControlFromItemContainer(container)
        If item Is ctrl.Items(0) Then
            i = 0
        End If
        i += 1

        ' Choose between the two styles based on the current position.
        If i Mod 2 = 1 Then
            Return DefaultStyle
        Else
            Return AlternateStyle
        End If

    End Function
End Class
