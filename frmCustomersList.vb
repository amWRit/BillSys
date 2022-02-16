Imports System.Data.OleDb
Public Class frmCustomersList
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMember.Click
        EDITMODE = False
        NEWMODE = True
        frmBecomeMember.Show()
        RefreshLV()
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
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Not lvData.Tag = "" Then
            If MsgBox("Are you sure you want to Edit records?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim MyCom As New OleDb.OleDbCommand
                Dim MyCN As New OleDb.OleDbConnection
                Dim MyRead As OleDb.OleDbDataReader
                'Dim CurVal As Integer
                Dim FetchType As String
                Dim TempNumero As String

                Dim ConString As String
                ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/Customers.mdb;User ID=Admin;Password="
                MyCN.ConnectionString = ConString
                MyCN.Open()

                MyCom.Connection = MyCN
                MyCom.CommandText = "Select * from Customers WHERE ID = " & CInt(lvData.Tag) & ""
                MyRead = MyCom.ExecuteReader

                EDITMODE = True
                NEWMODE = False

                'FetchType = "EDIT"
                With frmBecomeMember
                    While MyRead.Read
                        '.txtCusID.Text = MyRead(2)
                        .txtCusID.Text = MyRead(1)
                        .txtFirstName.Text = MyRead(2)
                        .txtMiddleName.Text = MyRead(3)
                        .txtLastName.Text = MyRead(4)
                        .txtCity.Text = MyRead(5)
                        .txtStreet.Text = MyRead(6)
                        .txtHouse.Text = MyRead(7)
                        .txtPhone.Text = MyRead(8)
                        .txtMobile.Text = MyRead(9)
                        .txtFax.Text = MyRead(10)
                        .txtAmount.Text = MyRead(11)

                        .Tag = lvData.Tag
                        'TempNumero = MyRead(4)
                        CurVal = lvData.Tag
                        .ShowDialog(Owner)
                    End While
                End With
                lvData.Tag = ""
            Else
                lvData.Tag = ""
            End If
        Else
            MsgBox("Please Select Records to be Edited!", MsgBoxStyle.Exclamation)
            lvData.Focus()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        Admin2.Show()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lvData.SelectedIndices.Count <= 0 Then
            Return 'No selected Item so exit
        End If

        Dim ItemNo As Integer = lvData.SelectedIndices(0) 'Grab the selected Index
        Try
            'Like the UPDATE command, we are going to use
            'OleDbCommand to execute a non-query and delete our record with WHERE parameters
            'In this case, I won't build the parameters, but instead just include them in the
            'SQL statement

            Dim I As Integer = MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.YesNo, "Are you sure?")
            If I = MsgBoxResult.Yes Then
                Con.Open()

                'DELETE FROM TableName WHERE PrimaryKey = ID
                Dim cmd2 As New OleDb.OleDbCommand("DELETE FROM Customers WHERE ID = " & lvData.Items(ItemNo).SubItems(0).Text, Con)

                cmd2.ExecuteNonQuery()

                MsgBox("Record Removed Successfully")

            Else
                'They didn't really want to delete, so exit
                Return 'This exits the sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        RefreshLV()
    End Sub

    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub lvData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvData.SelectedIndexChanged

    End Sub
End Class