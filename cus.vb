Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class cus
    Dim Con As System.Data.OleDb.OleDbConnection

    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/ItemsList.mdb ;Jet OLEDB:Database Password= & mypassword")

    Dim DBName As String = "ItemsList.mdb"
    Dim EDITMODE As Boolean = False
    Dim NEWMODE As Boolean = False

    Dim MyFunction As New ClsFunction

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

    Private Sub ItemsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.ItemsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ItemsListDataSet4)

    End Sub

   


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimate.Click
        LabelEstimate.Visible = True
        txtEstimate.Visible = True
        LabelInfo.Visible = True
        btnEstimate.Visible = False
        btnClear.visible = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshLV()
    End Sub

    Sub RefreshLV()
        Try
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/ItemsList.mdb;User ID=Admin;Password="
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
                lvData.Columns.Add(DS.Tables(0).Columns(i).Caption, 181, HorizontalAlignment.Left)
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

        Label.Text = "Available Items"
        PictureBox.Visible = False
        'PictureBox.Image = Image.FromFile("../data/pics/nopic.gif")
    End Sub

    
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim SQL As String
            SQL = "SELECT * FROM Items where (Item LIKE '%" & txtSearch.Text & "%')" 'This statement grabs all records from the table

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
                lvData.Columns.Add(DS.Tables(0).Columns(i).Caption, 247, HorizontalAlignment.Left)
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

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub Test_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Test.Click
   

        
    End Sub

    Sub Browse()
        Try
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/ItemsList.mdb;User ID=Admin;Password="
            Dim SQL As String
            SQL = "SELECT * FROM Items WHERE Category='" & Combo.Text & "'" 'This statement grabs all records from the table

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
                lvData.Columns.Add(DS.Tables(0).Columns(i).Caption, 247, HorizontalAlignment.Left)
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

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub

    

    'Private Sub lvData_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvData.ItemSelectionChanged
    ' Labeltest.Text = "TEST"
    'EstimateBill()
    'Calculate()
    ' End Sub
    Private Sub lvData_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvData.MouseDoubleClick
        If LabelInfo.Visible = True Then
            Calculate()
        Else
            AboutItemShow()
        End If
    End Sub

    Sub EstimateBill() 'NOT USED
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

            Dim I As Integer = MsgBox("Are you sure you want to add this to cart?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Are you sure?")
            If I = MsgBoxResult.Yes Then
                Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/ItemsList.mdb ;Jet OLEDB:Database Password= & mypassword")
                conn.Open()

                'DELETE FROM TableName WHERE PrimaryKey = ID
                Dim cmd2 As New OleDb.OleDbCommand("INSERT INTO EstimateTemp(PricePerQuantity) SELECT  Price FROM Items WHERE ID= " & lvData.Items(ItemNo).SubItems(0).Text, conn)

                cmd2.ExecuteNonQuery()

                MsgBox("item added Successfully", MsgBoxStyle.Information, "added")

            Else
                'They didn't really want to delete, so exit
                Return 'This exits the sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try


    End Sub

    Sub Calculate() 'Calculates the TOtal Estimate and puts in the TEXTBOX
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
            ' Labeltest.Text = lvData.Items(ItemNo).SubItems(1).Text
            Dim I As Integer = MsgBox("Are you sure you want to add this to cart?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Are you sure?")
            If I = MsgBoxResult.Yes Then
                Dim SQL As String

                'SQL = "SELECT * FROM Temp WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table
                SQL = "SELECT * FROM Items WHERE ItemCode ='" & lvData.Items(ItemNo).SubItems(1).Text & "'"

                Dim PricePerQuantity As Integer = 0

                conn.Open()

                Dim DS As DataSet 'Object to store data in
                DS = New DataSet 'Declare a new instance, or we get Null Reference Error

                Dim oData As OleDbDataAdapter
                oData = New OleDbDataAdapter(SQL, conn)
                oData.Fill(DS)

                For j As Integer = 0 To DS.Tables(0).Rows.Count - 1
                    PricePerQuantity = DS.Tables(0).Rows(j).Item("Price")
                Next

                TotalEstimate += PricePerQuantity

                txtEstimate.Text = TotalEstimate

                MsgBox("item added Successfully", MsgBoxStyle.Information, "added")
                ' lvData.SelectedIndices.Clear()



            Else
                'They didn't really want to delete, so exit
                Return 'This exits the sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtEstimate.Text = ""
        TotalEstimate = 0
    End Sub

    Sub AboutItemShow()
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
            ' Labeltest.Text = lvData.Items(ItemNo).SubItems(1).Text

            Dim SQL As String

            'SQL = "SELECT * FROM Temp WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table
            SQL = "SELECT * FROM Items WHERE ItemCode ='" & lvData.Items(ItemNo).SubItems(1).Text & "'"

            Dim ItemCode As String = 0
            Dim ItemName As String = 0
            Dim Quantity As Integer = 0
            Dim Category As String = 0
            Dim PricePerQuantity As Integer = 0

            Dim Test As String


            conn.Open()

            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, conn)
            oData.Fill(DS)

            For j As Integer = 0 To DS.Tables(0).Rows.Count - 1
                ItemCode = DS.Tables(0).Rows(j).Item("ItemCode")
            Next

            For j As Integer = 0 To DS.Tables(0).Rows.Count - 1
                ItemName = DS.Tables(0).Rows(j).Item("Item")
            Next

            For j As Integer = 0 To DS.Tables(0).Rows.Count - 1
                PricePerQuantity = DS.Tables(0).Rows(j).Item("Price")
            Next

            For j As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Quantity = DS.Tables(0).Rows(j).Item("Quantity")
            Next

            For j As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Category = DS.Tables(0).Rows(j).Item("Category")
            Next


            With AboutItems

                .LabelItemCode.Text = ItemCode
                .LabelItemName.Text = ItemName
                .LabelPrice.Text = PricePerQuantity
                .LabelQty.Text = Quantity
                .LabelCategory.Text = Category

                .PictureItem.Visible = True
                Test = "../data/pics/ItemPics/" & ItemCode & ".jpg"
                .PictureItem.Image = Image.FromFile(Test)
                '.Call(MyFunction.ItemsInfo(ItemCode))
                .ShowDialog(Owner)
            End With


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo.SelectedIndexChanged
        Dim Test As String

        If Combo.Text = "None" Then
            Test = "../data/pics/nopic.gif"

            RefreshLV()
        ElseIf Combo.Text = "" Then
            RefreshLV()

        Else
            Label.Text = Combo.Text

            'PictureBox.Picture = LoadPicture("c:\windows\setup.bmp")
            'PictureBox.Image = Image.FromFile("../data/pics/  '" & Combo.Text & "' .jpg")
            PictureBox.Visible = True
            Test = "../data/pics/" & Combo.Text & ".jpg"
            PictureBox.Image = Image.FromFile(Test)

            Browse()
        End If
    End Sub
End Class