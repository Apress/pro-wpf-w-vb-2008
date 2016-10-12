Imports System.Data

Public Class StoreDB2
    Public Function GetProducts() As DataTable
        Return StoreDB2.ReadDataSet().Tables(0)
    End Function

    Public Function GetCategoriesAndProducts() As DataSet
        Return StoreDB2.ReadDataSet()
    End Function

    Friend Shared Function ReadDataSet() As DataSet
        Dim ds As New DataSet()
        ds.ReadXmlSchema("store.xsd")
        ds.ReadXml("store.xml")
        Return ds
    End Function

End Class
