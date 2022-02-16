Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Public Class ClsFunction
    Inherits System.Windows.Forms.Form
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/members.accdb ;Jet OLEDB:Database Password= & mypassword")

    Public Sub CheckAttendance(ByVal UserID As String, ByVal Designation As String)
        Dim newUserID As String
        newUserID = UserID

        Dim newDesignation As String = Designation
        Dim SQL As String

        SQL = "SELECT * FROM Attendance WHERE USERID='" & newUserID & "' AND  Designation='" & newDesignation & "' AND MyDateTime = Date() " 'This statement grabs all records from the table
        'SQL = "SELECT * FROM Items "
        'SQL = "INSERT INTO Temp(ItemCode,Item,Price) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        Dim newAttendance As String = 0

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            newAttendance = DS.Tables(0).Rows(i).Item("Attendance")
        Next
        conn.Close()

        If newAttendance = "Present" Then
            MsgBox("You are already attended for today. " & vbNewLine & " THANKS! :) ", MsgBoxStyle.Information)
            ClearTemp()

        Else
            RetrieveDate(newUserID, newDesignation)
        End If



    End Sub
    Public Sub AddTempDate()
        Dim SQL As String

        'Dim SQL As String
        'SQL = "SELECT * FROM Items WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table

        SQL = "INSERT INTO TempDate(TempDate) SELECT  Date() "


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)
        'MsgBox("done")
        conn.Close()



    End Sub
    Public Sub RetrieveDate(ByVal newUserID As String, ByVal Designation As String)
        Dim SQL As String
        Dim UserID As String
        UserID = newUserID

        Dim newDesignation As String = Designation
        SQL = "SELECT * FROM TempDate  " 'This statement grabs all records from the table
        'SQL = "SELECT * FROM Items "
        'SQL = "INSERT INTO Temp(ItemCode,Item,Price) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        Dim TempDate As String = 0

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            TempDate = DS.Tables(0).Rows(i).Item("TempDate")
        Next
        conn.Close()
        DoAttendance(TempDate, UserID, newDesignation)


    End Sub

    Public Sub DoAttendance(ByVal TempDate As String, ByVal UserID As String, ByVal Designation As String)
        Dim Con As System.Data.OleDb.OleDbConnection
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/members.accdb ;Jet OLEDB:Database Password= & mypassword"


        Dim oAdapter As OleDb.OleDbDataAdapter
        Dim cb As OleDb.OleDbCommandBuilder
        Dim dr As DataRow
        Dim ds As DataSet

        Dim Today() As Date
        Dim MyDate As Date

        Dim newTempDate As String
        newTempDate = TempDate

        Dim newUserID As String
        newUserID = UserID

        Dim newDesignation As String = Designation

        Dim strSQL As String = "SELECT * FROM Attendance"

        ds = New DataSet()
        oAdapter = New OleDb.OleDbDataAdapter(strSQL, Con)
        oAdapter.Fill(ds) 'Execute the Query and grab results

        Try
            dr = ds.Tables(0).NewRow()
            dr.BeginEdit()

            'dr("CustomerID") = txtCustomerID.Text
            dr("MyDateTime") = newTempDate
            dr("UserID") = UserID
            dr("Designation") = newDesignation
            dr("Attendance") = "Present"




            dr.EndEdit()

            ds.Tables(0).Rows.Add(dr)
            cb = New OleDb.OleDbCommandBuilder(oAdapter)
            oAdapter.InsertCommand = cb.GetInsertCommand
            oAdapter.Update(ds)
            ds.AcceptChanges()

            MsgBox("Attendance done for '" & newTempDate & "' " & vbNewLine & " THANKS :) ", MsgBoxStyle.Information)


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            Con.Close()
            ClearTemp()
            'AddTable()
        End Try

    End Sub
    Public Sub ClearTemp()
        'DoCmd.SetWarnings(False)
        'DoCmd.RunSQL("DELETE * FROM NameOfTable")
        'DoCmd.SetWarnings(True)

        Dim SQL As String
        SQL = "DELETE FROM TempDate"
        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        conn.Close()
        'MsgBox("** BILL CLEARED **", MsgBoxStyle.Information)


    End Sub

   
End Class
