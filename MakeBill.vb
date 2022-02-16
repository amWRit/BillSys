Imports System.Data
Imports System.Data.OleDb
Public Class MakeBill
    Inherits System.Windows.Forms.Form
    'Dim mypath = Application.StartupPath & "\login.mdb"

    Dim mypassword = ""
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/ItemsList.mdb ;Jet OLEDB:Database Password= & mypassword")
    Dim cmd As OleDbCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdd.Click
        Dim SQL As String
        'SQL = "SELECT * FROM Temp WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table
        SQL = "SELECT Quantity FROM Items WHERE ItemCode='" & txtID.Text & "'"
        Dim Quantity As Integer = 0

        conn.Open()

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            Quantity = DS.Tables(0).Rows(i).Item("Quantity")
        Next
        conn.Close()

        If Quantity = 0 Then
            MsgBox("Item OUT OF STOCK", MsgBoxStyle.Exclamation, "Out of stock")

        Else
            InsertIntoTemp()
            InsertIntoSales()
            RefreshLV()
            DecreaseQty()

        End If

        
    End Sub
  

    Sub RefreshLV()
        Try

            Dim SQL As String
            'SQL = "SELECT * FROM Temp WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table
            SQL = "SELECT * FROM Temp "
            'SQL = "INSERT INTO Temp(ItemCode,Item,Price) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "

            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error

            conn.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, conn)
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
                lvData.Columns.Add(DS.Tables(0).Columns(i).Caption, 330, HorizontalAlignment.Left)
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
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("ItemCode").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Item").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Price").ToString)
                'xItem.SubItems.Add(DS.Tables(0).Rows(i)("Quantity").ToString)


                lvData.Items.Add(xItem)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
            lvData.Items.Clear()

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            conn.Close()
        End Try
    End Sub


    Sub InsertIntoTemp()
        Dim SQL As String

        'Dim SQL As String
        'SQL = "SELECT * FROM Items WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table

        SQL = "INSERT INTO Temp(ItemCode,Item,Price) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)


        ' MakeBill.RunSQL(strSQL)
        'MsgBox("done")
        conn.Close()
    End Sub

    Sub InsertIntoSales()
        Dim SQL As String

        'Dim SQL As String
        'SQL = "SELECT * FROM Items WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table

        SQL = "INSERT INTO Sales(MyDateTime,ItemCode,Item,Price) SELECT  Date(),ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)
        'MsgBox("done")
        conn.Close()

        'CODE FOR DATE
        'Dim Con As System.Data.OleDb.OleDbConnection
        'Con = New OleDbConnection
        'Con.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=../data/ItemsList.mdb"
        ' using (OleDbConnection cn = new OleDbConnection(connect))
        'Dim sSQL As String
        'sSQL = "INSERT INTO Sales (MyDateTime) VALUES (Date()) SELECT  ItemCode FROM Items WHERE ItemCode='" & txtID.Text & "' "

        'Dim cmd As New OleDb.OleDbCommand
        'cmd = New OleDbCommand(sSQL, Con)

        'cmd.Parameters.AddWithValue("", DateTime.Now.AddHours(36).ToOADate())
        'Con.Open()
        'cmd.ExecuteNonQuery()

    End Sub

    Sub DecreaseQty()
        Dim SQL As String
        SQL = "SELECT * FROM Items WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table
        'SQL = "SELECT * FROM Items "
        'SQL = "INSERT INTO Temp(ItemCode,Item,Price) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        Dim Quantity As Integer = 0

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            Quantity = DS.Tables(0).Rows(i).Item("Quantity")
            Quantity -= 1

            If Quantity = 0 Then
                MsgBox("After this transaction" & vbNewLine & "ItemCode   [ " & DS.Tables(0).Rows(i).Item("ItemCode") & " ]" & vbNewLine & "" & DS.Tables(0).Rows(i).Item("Item") & " has gone OUT OF STOCK" & vbNewLine & "Contact DBA soon.. ", MsgBoxStyle.Exclamation, "Out of stock")
            End If
        Next

        
        'DS.Tables(0).Rows(0).Item("Quantity") -= DS.Tables(0).Rows(0).Item("Quantity")

        'Con.Open()
        Dim cmd2 As New OleDb.OleDbCommand("UPDATE Items SET  Quantity=@a0  WHERE ItemCode='" & txtID.Text & "' ", conn)

        cmd2.Parameters.AddWithValue("@a0", Quantity)

        cmd2.ExecuteNonQuery()
        conn.Close()
    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If MsgBox("Are you sure you want to EXIT?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Application.Exit()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Clear()

    End Sub

    Sub Clear()
        'DoCmd.SetWarnings(False)
        'DoCmd.RunSQL("DELETE * FROM NameOfTable")
        'DoCmd.SetWarnings(True)

        Dim SQL As String
        SQL = "DELETE FROM Temp"
        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        conn.Close()
        MsgBox("** BILL CLEARED **", MsgBoxStyle.Information)

        totalSum = 0
        txtDiscount.Text = ""
        txtTotal.Text = ""
        RefreshLV()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        sum()
    End Sub

    Sub sum()


        Dim SQL As String
        'SQL = "SELECT * FROM Temp WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table
        SQL = "SELECT * FROM Temp"
        'SQL = "INSERT INTO Temp(ItemCode,Item,Price) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        'Dim totalSum As Double = 0
        Dim Discount As Double = 0

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            totalSum += DS.Tables(0).Rows(i).Item("Price")
        Next
        If txtDiscount.Text = "" Then
            Discount = 0
        Else
            Discount = txtDiscount.Text.ToString
        End If

        totalSum -= Discount / 100 * totalSum
        txtTotal.Text = totalSum.ToString()
        conn.Close()


    End Sub

    Private Sub btnAddToAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToAccount.Click
        AddToAccount.Show()
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lvData.SelectedIndices.Count <= 0 Then
            MsgBox("Item not selected... ", MsgBoxStyle.Exclamation, "Not Selected")
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
                conn.Open()

                'DELETE FROM TableName WHERE PrimaryKey = ID
                Dim cmd2 As New OleDb.OleDbCommand("DELETE FROM Temp WHERE ID = " & lvData.Items(ItemNo).SubItems(0).Text, conn)

                cmd2.ExecuteNonQuery()

                MsgBox("Record Removed Successfully")

            Else
                'They didn't really want to delete, so exit
                Return 'This exits the sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
        RefreshLV()
        IncreaseQty()
    End Sub

    Sub IncreaseQty()
        Dim SQL As String
        SQL = "SELECT * FROM Items WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table
        'SQL = "SELECT * FROM Items "
        'SQL = "INSERT INTO Temp(ItemCode,Item,Price) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        Dim Quantity As Integer = 0

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            Quantity = DS.Tables(0).Rows(i).Item("Quantity")
            Quantity += 1
        Next
        'DS.Tables(0).Rows(0).Item("Quantity") -= DS.Tables(0).Rows(0).Item("Quantity")

        'Con.Open()
        Dim cmd2 As New OleDb.OleDbCommand("UPDATE Items SET  Quantity=@a0  WHERE ItemCode='" & txtID.Text & "' ", conn)

        cmd2.Parameters.AddWithValue("@a0", Quantity)

        cmd2.ExecuteNonQuery()
        conn.Close()
    End Sub

    Private Sub MakeBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lvData.Columns.Add("ID:", 150, HorizontalAlignment.Left)
    End Sub

  

    
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
    Private Sub txtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscount.TextChanged

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
    Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged

    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub lvData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvData.SelectedIndexChanged

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub txtID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged

    End Sub
End Class
