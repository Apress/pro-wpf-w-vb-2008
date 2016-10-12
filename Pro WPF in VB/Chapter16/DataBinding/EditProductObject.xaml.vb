Imports StoreDatabase
Imports System.Text

Public Class EditProductObject

    Private product As Product

    Private Sub cmdGetProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim ID As Integer
        If Int32.TryParse(txtID.Text, ID) Then
            Try
                product = Application.StoreDB.GetProduct(ID)
                gridProductDetails.DataContext = product
            Catch
                MessageBox.Show("Error contacting database.")
            End Try
        Else
            MessageBox.Show("Invalid ID.")
        End If
    End Sub

    Private Sub cmdUpdateProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Make sure update has taken place.
        FocusManager.SetFocusedElement(Me, CType(sender, Button))

        MessageBox.Show(product.UnitCost.ToString())
    End Sub


    Private Sub cmdIncreasePrice_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        product.UnitCost *= 1.1D
    End Sub

    Private Sub validationError(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
        If e.Action = ValidationErrorEventAction.Added Then
            MessageBox.Show(e.Error.ErrorContent.ToString())
        End If
    End Sub

    Private Sub cmdGetExceptions_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim sb As New StringBuilder()
        GetErrors(sb, gridProductDetails)
        Dim message As String = sb.ToString()
        If message <> "" Then
            MessageBox.Show(message)
        End If
    End Sub

    Private Sub GetErrors(ByVal sb As StringBuilder, ByVal obj As DependencyObject)
        For Each child As Object In LogicalTreeHelper.GetChildren(obj)
            ' Ignore strings and dependency objects that aren't elements.
            Dim element As TextBox = TryCast(child, TextBox)
            If element Is Nothing Then
                Continue For
            End If

            If Validation.GetHasError(element) Then
                sb.Append(element.Text & " has errors:" & Constants.vbCrLf)
                For Each [error] As ValidationError In Validation.GetErrors(element)
                    sb.Append("  " & [error].ErrorContent.ToString())

                    sb.Append(Constants.vbCrLf)
                Next
            End If

            ' Check the children of this object.
            GetErrors(sb, element)
        Next
    End Sub
End Class