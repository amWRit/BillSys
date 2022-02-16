Imports System.Data.OleDb

Module gModule
    Public Const cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/items.accdb "

    Public Enum FormState
        adStateAddMode = 0
        adStateEditMode = 1
    End Enum

   

End Module
