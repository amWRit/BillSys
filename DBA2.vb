Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class DBA2

    Dim Con As System.Data.OleDb.OleDbConnection
    Dim DBName As String = "ItemsList.mdb"

    'declaration for MOVING FORMS
    'Width of the 'resizable border', the area where you can resize.
    Private Const BorderWidth As Integer = 6
    Private _resizeDir As ResizeDirection = ResizeDirection.None

    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 3
        TopRight = 4
        Right = 5
        BottomRight = 6
        Bottom = 7
        BottomLeft = 8
    End Enum

    Public Property resizeDir() As ResizeDirection
        Get
            Return _resizeDir
        End Get
        Set(ByVal value As ResizeDirection)
            _resizeDir = value

            'Change cursor

        End Set
    End Property

#Region " Functions and Constants "

    <DllImport("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2


#End Region



#Region " Moving  "

    Private Sub MoveForm()
        ReleaseCapture()
        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub


#End Region

    Private Sub pnlCaption_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCaption.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            MoveForm()
        End If
    End Sub

    Private Sub pnlCaption_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCaption.MouseMove
        resizeDir = ResizeDirection.None
    End Sub
    'end of MOVE
    

    Private Sub Form38_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Con = New OleDbConnection
        'If you click refresh without clicking Open first
        'the above line will ensure there is no Nullreferenceerror on the Finally clause
        'in the Try Catch
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim FO As OpenFileDialog
        FO = New OpenFileDialog
        FO.InitialDirectory = Application.StartupPath
        If FO.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DBName = FO.FileName
        Else 'Mustve clicked Cancel, exit
            Return
        End If

        'Set the Connection String of the Connection Object.
        'I found this connection string online, it seems to be the standard
        'for connecting to MS Access databases. If you use a Username and
        'password for your database, then you will need to use the correct
        'ones on the end of this connection string

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DBName & ";User ID=Admin;Password="
        Try
            'Error handling keeps our software from crashing
            'when an error occurs
            Con.Open()
        Catch ex As Exception
            'You could opt to do something here
            'This code is called when an error occurs
            'I usually do a MsgBox
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connection Error")
        End Try

        If Con.State = ConnectionState.Open Then
            'It openned
            btnOpen.BackColor = Color.Green
        Else
            'It didn't open
            btnOpen.BackColor = Color.Red
        End If

        Con.Close() 'We don't want to keep the database connection
        'open constantly. In an access world it isn't as bad because the
        'database typically resides on you local machine
        'but if it were on a server, a constant connection would slow
        'down the network significatnly
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshLV()
    End Sub

    Sub RefreshLV()
        Try
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/ItemsList.mdb;User ID=Admin;Password="
            CheckQuantity()
            Dim SQL As String
            SQL = "SELECT * FROM Items" 'This statement grabs all records from the table

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
                lvData.Columns.Add(DS.Tables(0).Columns(i).Caption, 187, HorizontalAlignment.Left)
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
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Quantity").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("Category").ToString)

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

    Sub ClearTextBoxes()
        lblID.Text = ""
        txtItemCode.Text = ""
        txtName.Text = ""
        txtPrice.Text = ""
        txtQty.Text = ""
        txtCategory.Text = ""

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'This function will prep the TextBoxes for entering New data
        'This function will set EDITMODE to false incase we were in EDITMODE
        'This function will set NEWMODE to True and make the lblID say "NEW RECORD"
        ClearTextBoxes()
        lblID.Visible = True
        lblID.Text = "NEW RECORD"
        EDITMODE = False
        NEWMODE = True
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        'Edit will require somewhere for us to enter in new values, for this I added
        'some objects to the form, txtFName, txtLName, txtAddress, txtCity, txtState, txtZip, lblID
        '
        'Since we cannot change the ID, and this Primary key record is needed to update
        'a row in the database, we will just use a Label to display it (lblID)
        '
        '*************************
        'Check if there is a row selected on the ListView
        If lvData.SelectedIndices.Count > 0 Then
            'ListViews have the capability to select multiple lines
            'Since we want to edit just one record at a time, we have to change
            'the MultiSelect option on the listview to False

            'Since we know that there will only be one selected record anytime,
            'we can directly reference the first selected row always.

            ItemNo = lvData.SelectedIndices(0) 'Grab the selected Index

            'We have to set these global varialbes
            'to tell our Save button what it is doing
            'Look under btnSave_Click to see where these variables get used
            EDITMODE = True
            NEWMODE = False

            lblID.Text = lvData.Items(ItemNo).SubItems(0).Text
            txtItemCode.Text = lvData.Items(ItemNo).SubItems(1).Text
            txtName.Text = lvData.Items(ItemNo).SubItems(2).Text
            txtPrice.Text = lvData.Items(ItemNo).SubItems(3).Text
            txtQty.Text = lvData.Items(ItemNo).SubItems(4).Text
            txtCategory.Text = lvData.Items(ItemNo).SubItems(5).Text

        Else
            'I wrote the following subroutine to clear the textboxes
            'and lblID to make this process look cleaner, since I will do this
            'in a few other places.
            'It's best practice to make subroutines out of lines of code that get repeated
            'in multiple places.
            ClearTextBoxes()
        End If
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
                Dim cmd2 As New OleDb.OleDbCommand("DELETE FROM Items WHERE ID = " & lvData.Items(ItemNo).SubItems(0).Text, Con)

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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If EDITMODE = True Then
            'So the EDITMODE Boolean has been set, and we know that we will be updating
            'a record in our database. Since there is a chance that the user selected a different
            'record in the ListView, we will use lblID to grab the ID of the record that
            'we are updating
            
            'We have a CON object declared globally, so I will use that

            Dim ID As String = Trim(lblID.Text) 'Trim takes any spaces off the left or right sides of a string, probably not needed

            Try
                Dim NewItemNo As Integer
                NewItemNo = ItemNo
                'This connection string is the same as the one we just used with btnOpen
                ' (recycles the DBName var that we have declared globally)

                'Here we are going to build a SQL statement that we pass parameters with
                'the OleDbCommand object, which is used to Execute NonQuery based commands
                'such as INSERT (new row) DELETE (delete row) or DROP TABLE (deletes a table from the db)
                'Here we are using the UPDATE command which is used to update an existing record or records based on WHERE criteria

                'UPDATE TableName SET Field=@a0, Field=@a1 WHERE PrimaryKey = @a2
                'the @a0 represents a Parameter that will be set with the OleDbCommand object
                Con = New OleDbConnection
                Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/ItemsList.mdb;User ID=Admin;Password="
                Con.Open()

                Dim cmd2 As New OleDb.OleDbCommand("UPDATE Items SET ItemCode=@a0, Item=@a1, Price=@a2, Quantity=@a3, Category=@a4  WHERE ID = " & ID & " ", Con)

                cmd2.Parameters.AddWithValue("@a0", txtItemCode.Text)
                cmd2.Parameters.AddWithValue("@a1", txtName.Text)
                cmd2.Parameters.AddWithValue("@a2", txtPrice.Text)
                cmd2.Parameters.AddWithValue("@a3", txtQty.Text)
                cmd2.Parameters.AddWithValue("@a4", txtCategory.Text)

                cmd2.ExecuteNonQuery()

                MsgBox("Record Updated Successfully")
                EDITMODE = False ' Add success, end EDITMODE
                ClearTextBoxes() 'Add Success, clean up textboxes
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Con.Close()
            End Try

        ElseIf NEWMODE = True Then

            Dim oAdapter As OleDb.OleDbDataAdapter
            Dim cb As OleDb.OleDbCommandBuilder
            Dim dr As DataRow
            Dim ds As DataSet
            Dim strSQL As String = "SELECT * FROM Items"

            ds = New DataSet()
            oAdapter = New OleDb.OleDbDataAdapter(strSQL, Con)
            oAdapter.Fill(ds) 'Execute the Query and grab results

            Try
                dr = ds.Tables(0).NewRow()
                dr.BeginEdit()

                dr("ItemCode") = txtItemCode.Text
                dr("Item") = txtName.Text
                dr("Price") = txtPrice.Text
                dr("Quantity") = txtQty.Text
                dr("Category") = txtCategory.Text

                dr.EndEdit()

                ds.Tables(0).Rows.Add(dr)
                cb = New OleDb.OleDbCommandBuilder(oAdapter)
                oAdapter.InsertCommand = cb.GetInsertCommand
                oAdapter.Update(ds)
                ds.AcceptChanges()

                MessageBox.Show("Insert Successful")
                NEWMODE = False 'Add success, end NEWMODE
                ClearTextBoxes() 'Add Success, clean up textboxes
            Catch ex As Exception
                MessageBox.Show(ex.Message)

            Finally
                Con.Close()
            End Try

        Else 'Its not Editmode or Newmode
            'Do nothing
        End If

        RefreshLV() 'Regardless of what happens, might as well refresh the data in the Listview

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Pretty straight forward
        ClearTextBoxes()
        EDITMODE = False
        NEWMODE = False
    End Sub

   


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
    Sub CheckQuantity()
        Dim SQL As String
        SQL = "SELECT * FROM Items  " 'This statement grabs all records from the table
        'SQL = "SELECT * FROM Items "
        'SQL = "INSERT INTO Temp(ItemCode,Item,Price) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Con.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, Con)
        oData.Fill(DS)

        Dim Quantity As Integer = 0

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            Quantity = DS.Tables(0).Rows(i).Item("Quantity")
            If Quantity = 0 Then
                MsgBox(" ItemCode   [ " & DS.Tables(0).Rows(i).Item("ItemCode") & " ]" & vbNewLine & "" & DS.Tables(0).Rows(i).Item("Item") & " is OUT OF STOCK", MsgBoxStyle.Exclamation, "OUT OF STOCK")

            End If
        Next
        'DS.Tables(0).Rows(0).Item("Quantity") -= DS.Tables(0).Rows(0).Item("Quantity")

        'Con.Open()

        Con.Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub

    Private Sub btnBrowsePicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsePicture.Click

        Dim openFile As New OpenFileDialog()
        openFile.Filter = "JPG Files(*.jpg)|*.jpg" 'Only show XML files in Open Dialog Window
        openFile.InitialDirectory = "/ItemPics"
        If openFile.ShowDialog() = DialogResult.OK Then
            txtPicturePath.Text = openFile.FileName
            'MessageBox.Show(openFile.FileName)
        End If
    End Sub
End Class