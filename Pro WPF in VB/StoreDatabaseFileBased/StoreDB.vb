Imports System.Data
Imports System.Collections.ObjectModel

Public Class StoreDB
    Public Function GetProduct(ByVal ID As Integer) As Product
        Dim ds As DataSet = StoreDB2.ReadDataSet()
        Dim productRow As DataRow = ds.Tables("Products").Select("ProductID = " & ID.ToString())(0)
        Dim product As New Product(CStr(productRow("ModelNumber")), CStr(productRow("ModelName")), CDec(productRow("UnitCost")), CStr(productRow("Description")), CStr(productRow("CategoryName")), CStr(productRow("ProductImage")))
        Return product
    End Function

    Public Function GetProducts() As ICollection(Of Product)
        Dim ds As DataSet = StoreDB2.ReadDataSet()

        Dim products As ObservableCollection(Of Product) = New ObservableCollection(Of Product)()
        For Each productRow As DataRow In ds.Tables("Products").Rows
            products.Add(New Product(CStr(productRow("ModelNumber")), CStr(productRow("ModelName")), CDec(productRow("UnitCost")), CStr(productRow("Description")), CStr(productRow("CategoryName")), CStr(productRow("ProductImage"))))
        Next
        Return products
    End Function

    Public Function GetProductsSlow() As ICollection(Of Product)
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5))
        Return GetProducts()
    End Function

    Public Function GetCategoriesAndProducts() As ICollection(Of Category)
        Dim ds As DataSet = StoreDB2.ReadDataSet()
        Dim relCategoryProduct As DataRelation = ds.Relations(0)

        Dim categories As ObservableCollection(Of Category) = New ObservableCollection(Of Category)()
        For Each categoryRow As DataRow In ds.Tables("Categories").Rows
            Dim products As ObservableCollection(Of Product) = New ObservableCollection(Of Product)()
            For Each productRow As DataRow In categoryRow.GetChildRows(relCategoryProduct)
                products.Add(New Product(productRow("ModelNumber").ToString(), productRow("ModelName").ToString(), CDec(productRow("UnitCost")), productRow("Description").ToString()))
            Next
            categories.Add(New Category(categoryRow("CategoryName").ToString(), products))
        Next
        Return categories
    End Function
End Class

