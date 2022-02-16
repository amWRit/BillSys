Imports System.Data.OleDb
Public Class frmCustomersList2

    Dim Con As System.Data.OleDb.OleDbConnection
    Dim DBName As String = "ItemsList.mdb"


    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshLV()
    End Sub

    Sub RefreshLV()
        Try
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/Customers.mdb;User ID=Admin;Password="
            Dim SQL As String
            SQL = "SELECT * FROM Customers" 'This statement grabs all records from the table

            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            oData.Fill(DS)

            'DS should contain our records, lets parse it and add them to the
            'listview. Remember that DS.Tables will contain all tables in our query
            'Since we only asked for 1 table of data, our data is located in
            'DS.Tables(0) (which is a DataTable Object)
            'If you prefered you could do:
            'Dim DT As New System.Data.DataTable
            'DT = DS.Tables(0)
            'And work off of DT, but it doesn't gain you much if your not working
            'with hundreds of thousands of records...

            lvData.Items.Clear() 'prep Listview by clearing it
            lvData.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                lvData.Columns.Add(DS.Tables(0).Columns(i).Caption, 92, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                'We use a ListViewItem to add items to a ListView
                'When you declare a ListViewItem (as follows)
                'Dim xItem as ListViewItem
                'you have to set it equal to a NEW instance of the object
                'or you will get a null reference error
                'The first String you pass it goes in the first column
                'Each subitem there after will go in the next column

                'I consolidate these two lines into one line in the following code...
                'Dim xItem As ListViewItem
                'xItem = New ListViewItem(DS.Tables(0).Rows(i)("ID").ToString)

                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)("ID").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("CusID").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("FirstName").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("MiddleName").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("LastName").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("CIty").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Street").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("House").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Phone").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Mobile").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Fax").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Amount").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("MembershipType").ToString)

                lvData.Items.Add(xItem)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
            lvData.Items.Clear()

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

   

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim SQL As String
            SQL = "SELECT * FROM Customers where (FirstName LIKE '%" & txtSearch.Text & "%')" 'This statement grabs all records from the table

            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            oData.Fill(DS)

            'DS should contain our records, lets parse it and add them to the
            'listview. Remember that DS.Tables will contain all tables in our query
            'Since we only asked for 1 table of data, our data is located in
            'DS.Tables(0) (which is a DataTable Object)
            'If you prefered you could do:
            'Dim DT As New System.Data.DataTable
            'DT = DS.Tables(0)
            'And work off of DT, but it doesn't gain you much if your not working
            'with hundreds of thousands of records...

            lvData.Items.Clear() 'prep Listview by clearing it
            lvData.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                lvData.Columns.Add(DS.Tables(0).Columns(i).Caption, 92, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                'We use a ListViewItem to add items to a ListView
                'When you declare a ListViewItem (as follows)
                'Dim xItem as ListViewItem
                'you have to set it equal to a NEW instance of the object
                'or you will get a null reference error
                'The first String you pass it goes in the first column
                'Each subitem there after will go in the next column

                'I consolidate these two lines into one line in the following code...
                'Dim xItem As ListViewItem
                'xItem = New ListViewItem(DS.Tables(0).Rows(i)("ID").ToString)

                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)("ID").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("CusID").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("FirstName").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("MiddleName").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("LastName").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("CIty").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Street").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("House").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Phone").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Mobile").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Fax").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Amount").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("MembershipType").ToString)


                lvData.Items.Add(xItem)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
            lvData.Items.Clear()

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub
    Private Sub lvData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvData.Click
        If lvData.Items.Count <> 0 Then lvData.Tag = lvData.SelectedItems.Item(0).Text
    End Sub
    

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    

    
    Private Sub frmCustomersList2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshLV()
    End Sub
End Class