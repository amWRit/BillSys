Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class MakeBill2

    Inherits System.Windows.Forms.Form
    'Dim mypath = Application.StartupPath & "\login.mdb"

    Dim mypassword = ""
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/ItemsList.mdb ;Jet OLEDB:Database Password= & mypassword")
    Dim cmd As OleDbCommand


    'declarations for barcode reader
    Dim BarcodeStr As String = ""
    Dim IsBarcodeTaken As Boolean = False
    Dim Str As String = ""
    Dim str3 As String = ""

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
    'end of WINDOW move code
    

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim SQL As String
        Dim txtItemCode As String = txtID.Text
        'SQL = "SELECT * FROM Temp WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table
        SQL = "SELECT * FROM Items WHERE ItemCode='" & txtItemCode & "'"
        Dim Quantity As Integer = 0
        Dim TotalPrice As Integer = 0
        Dim BillQuantity As Integer = 0
        Dim PricePerQuantity As Integer = 0
        'Dim ID As Integer
        conn.Open()

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            Quantity = DS.Tables(0).Rows(i).Item("Quantity")
        Next

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            PricePerQuantity = DS.Tables(0).Rows(i).Item("Price")
        Next

        If txtQuantity.Text = "" Then
            BillQuantity = 1
        Else
            BillQuantity = txtQuantity.Text
        End If

        labelBillQuantity.Text = BillQuantity
        TotalPrice = PricePerQuantity * BillQuantity

        conn.Close()



        If Quantity = 0 Then
            MsgBox("Item OUT OF STOCK", MsgBoxStyle.Exclamation, "Out of stock")

        Else


            InsertIntoTemp2(BillQuantity, TotalPrice)
            InsertIntoSales()
            RefreshLV()
            DecreaseQty(BillQuantity)
            sum()

        End If

        txtID.Text = ""
        txtQuantity.Text = ""
        btnAdd.Enabled = False
        txtID.Focus 
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
                lvData.Columns.Add(DS.Tables(0).Columns(i).Caption, 200, HorizontalAlignment.Left)
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
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("BillQuantity").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("PricePerQuantity").ToString)
                xItem.SubItems.Add(DS.Tables(0).Rows(i)("TotalPrice").ToString)




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



    Sub InsertIntoTemp2(ByVal BillQuantity As Integer, ByVal TotalPrice As Integer)
        Dim SQL As String
        'SQL = "SELECT * FROM Temp WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table
        SQL = "SELECT * FROM Items WHERE ItemCode='" & txtID.Text & "'"

        Dim ItemCode As String
        Dim ItemName As String
        Dim Quantity As Integer
        Dim newTotalPrice As Integer
        Dim newBillQuantity As Integer
        Dim PricePerQuantity As Integer
        Dim ID As Integer

        newTotalPrice = TotalPrice
        newBillQuantity = BillQuantity
        conn.Open()

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        conn.Close()
        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            ItemCode = DS.Tables(0).Rows(i).Item("ItemCode")
        Next

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            ItemName = DS.Tables(0).Rows(i).Item("Item")
        Next

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            PricePerQuantity = DS.Tables(0).Rows(i).Item("Price")
        Next

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            Quantity = DS.Tables(0).Rows(i).Item("Quantity")
        Next

        Dim Con As System.Data.OleDb.OleDbConnection
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/ItemsList.mdb;User ID=Admin;Password="


        Dim oAdapter As OleDb.OleDbDataAdapter
        Dim cb As OleDb.OleDbCommandBuilder
        Dim dr As DataRow
        'Dim ds As DataSet
        Dim strSQL As String = "SELECT * FROM Temp  WHERE ItemCode='" & txtID.Text & "'"

        DS = New DataSet()
        oAdapter = New OleDb.OleDbDataAdapter(strSQL, Con)
        oAdapter.Fill(DS) 'Execute the Query and grab results


        Try
            dr = DS.Tables(0).NewRow()
            dr.BeginEdit()

            dr("ItemCode") = ItemCode
            dr("Item") = ItemName
            dr("BillQuantity") = BillQuantity
            dr("PricePerQuantity") = PricePerQuantity
            dr("TotalPrice") = TotalPrice


            dr.EndEdit()

            DS.Tables(0).Rows.Add(dr)
            cb = New OleDb.OleDbCommandBuilder(oAdapter)
            oAdapter.InsertCommand = cb.GetInsertCommand
            oAdapter.Update(DS)
            DS.AcceptChanges()

            MsgBox("Insert Successful", MsgBoxStyle.Information, "INSERTED")
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
            'AddTable()
        End Try

    End Sub

    Sub InsertIntoTemp()
        Dim SQL As String

        'Dim SQL As String
        'SQL = "SELECT * FROM Items WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table

        SQL = "INSERT INTO Temp(ItemCode,Item,PricePerQuantity) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        conn.Close()

    End Sub
    Sub InsertIntoSales()
        Dim SQL As String

        'Dim SQL As String
        'SQL = "SELECT * FROM Items WHERE ItemCode='" & txtID.Text & "' " 'This statement grabs all records from the table

        SQL = "INSERT INTO Sales(MyDateTime,ItemCode,Item,QuantitySold,PricePerQuantity,TotalPrice) SELECT  Date(),ItemCode,Item,BillQuantity,PricePerQuantity,TotalPrice FROM Temp WHERE ItemCode='" & txtID.Text & "' "


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)
        'MsgBox("done")
        conn.Close()



    End Sub

    Sub DecreaseQty(ByVal BillQuantity As Integer)
        Dim SQL As String
        Dim newBillQuantity As Integer
        newBillQuantity = BillQuantity
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
            Quantity -= newBillQuantity

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

        If Not txtTotal.Text = "" Then
            InsertTotalBillAmount()
            Clear()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not txtTotal.Text = "" Then
            InsertTotalBillAmount()
        End If

        Clear()

    End Sub
    Sub InsertTotalBillAmount()
        'for retrieving Tempdate 

        Dim SQL As String

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

        'for adding total amount to sales table

        ' Dim DS As DataSet 'Object to store data in
        ' DS = New DataSet 'Declare a new instance, or we get Null Reference Error


        Dim Con As System.Data.OleDb.OleDbConnection
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/ItemsList.mdb;User ID=Admin;Password="


        Dim oAdapter As OleDb.OleDbDataAdapter
        Dim cb As OleDb.OleDbCommandBuilder
        Dim dr As DataRow
        'Dim ds As DataSet
        Dim strSQL As String = "SELECT * FROM Sales  "

        DS = New DataSet()
        oAdapter = New OleDb.OleDbDataAdapter(strSQL, Con)
        oAdapter.Fill(DS) 'Execute the Query and grab results

        Dim TotalBillAmount As Double = totalSum

        Try
            dr = DS.Tables(0).NewRow()
            dr.BeginEdit()


            'dr("QuantitySold") = 0
            'dr("TotalPrice") = 0

            dr("TotalBillAmount") = TotalBillAmount
            dr("MyDateTime") = TempDate

            'dr("BillID") = 1

            dr.EndEdit()

            DS.Tables(0).Rows.Add(dr)
            cb = New OleDb.OleDbCommandBuilder(oAdapter)
            oAdapter.InsertCommand = cb.GetInsertCommand
            oAdapter.Update(DS)
            DS.AcceptChanges()

            MsgBox("Total AMount Insert Successful", MsgBoxStyle.Information, "INSERTED")
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
            'AddTable()
        End Try

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
    Sub AddBillTempDate()
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
    Public Sub RetrieveBillDate(ByVal newUserID As String, ByVal Designation As String)
       



    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        sum()
    End Sub

    Sub sum()
        txtDiscount.Text = ""
        Discount = 0
        totalSum = 0

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
        'Dim Discount As Double = 0

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            totalSum += DS.Tables(0).Rows(i).Item("TotalPrice")
        Next
        If txtDiscount.Text = "" Then
            'Discount = 0
            CalculateDiscount()
        Else
            Discount = txtDiscount.Text.ToString
        End If

        totalSum -= Discount / 100 * totalSum
        txtTotal.Text = totalSum.ToString()
        conn.Close()


    End Sub
    Sub CalculateDiscount()
        'Dim Discount As Double = 0
        If totalSum < 1000 Then
            Discount = 0
        ElseIf totalSum > 1000 And totalSum < 3000 Then
            Discount = 5
        ElseIf totalSum > 3000 Then
            Discount = 7
        End If
        txtDiscount.Text = Discount
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

            Dim I As Integer = MsgBox("Are you sure you want to delete this item?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Are you sure?")
            If I = MsgBoxResult.Yes Then
                conn.Open()

                'DELETE FROM TableName WHERE PrimaryKey = ID
                Dim cmd2 As New OleDb.OleDbCommand("DELETE FROM Temp WHERE ID = " & lvData.Items(ItemNo).SubItems(0).Text, conn)

                cmd2.ExecuteNonQuery()

                MsgBox("Record Removed Successfully", MsgBoxStyle.Information, "REMOVED")

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
        sum()
        IncreaseQty()
    End Sub

    Sub IncreaseQty()
        Dim SQL As String
        Dim BillQuantity As Integer
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
        BillQuantity = labelBillQuantity.Text

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            Quantity = DS.Tables(0).Rows(i).Item("Quantity")
            Quantity += BillQuantity
        Next
        'DS.Tables(0).Rows(0).Item("Quantity") -= DS.Tables(0).Rows(0).Item("Quantity")

        'Con.Open()
        Dim cmd2 As New OleDb.OleDbCommand("UPDATE Items SET  Quantity=@a0  WHERE ItemCode='" & txtID.Text & "' ", conn)

        cmd2.Parameters.AddWithValue("@a0", Quantity)

        cmd2.ExecuteNonQuery()
        conn.Close()
    End Sub

    Private Sub MakeBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddBillTempDate()
        RefreshLV()
        'lvData.Columns.Add("ID:", 150, HorizontalAlignment.Left)
    End Sub


    Private Sub MakeBill_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress



        BarcodeStr = BarcodeStr & e.KeyChar
        If Asc(e.KeyChar) = 13 And Len(BarcodeStr) >= 4 Then
            IsBarcodeTaken = True
            txtID.Text = BarcodeStr

            'Label.Text = BarcodeStr

        End If

    End Sub

    
    Private Sub txtID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged
        If Not txtID.Text = "" Then
            btnAdd.Enabled = True
        End If

    End Sub

    'FOR PRINTING
  

#Region "Print related declarations"
    Protected WithEvents pd As Printing.PrintDocument 'used by Print sub 
    Protected Ratio As Single = 0, CurrRow As Integer = 0
#End Region
#Region "Simple Printing of ListView"
    ''' <summary> 
    ''' Print the List view as a simple report 
    ''' </summary> 
    Public Sub Print()
        pd = New Printing.PrintDocument
        pd.DocumentName = "Print-of-Bill-on-"
        '& lvData.Name
        Ratio = 1
        CurrRow = 0
        pd.Print()
    End Sub
    ''' <summary> 
    ''' Print Preview the List view as a simple report 
    ''' </summary> 
    Public Sub PrintPreview()
        pd = New Printing.PrintDocument
        pd.DefaultPageSettings.Landscape = True
        pd.DocumentName = "Print of " & lvData.Name
        Ratio = 1
        CurrRow = 0
        Dim ppv As New PrintPreviewDialog
        ppv.Document = pd
        ppv.ShowDialog()
    End Sub

    Private Sub pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pd.PrintPage
        Dim c As ColumnHeader
        Dim g As Graphics = e.Graphics
        Dim l As Integer = 0 'stores current left 
        Dim iCount As Integer
        Dim f As Font = lvData.Font
        Dim b As Brush = Brushes.Black
        Dim currentY As Integer = 0, maxY As Integer = 0
        Dim gap As Integer = 1
        Dim lvsi As ListViewItem.ListViewSubItem
        Dim colLefts(lvData.Columns.Count) As Integer, colWidths(lvData.Columns.Count) As Integer, idx As Integer = 0, ii As Integer
        Dim lr As RectangleF
        e.HasMorePages = False
        'Headings 
        currentY = 10
        For Each c In lvData.Columns
            maxY = Math.Max(maxY, g.MeasureString(c.Text, f, c.Width).Height)
            colLefts(idx) = l
            colWidths(idx) = c.Width
            lr = New RectangleF(colLefts(idx), currentY, colWidths(idx), maxY)
            g.DrawString(c.Text, f, b, lr)
            l += c.Width
            idx += 1
        Next
        currentY += maxY + gap
        g.DrawLine(Pens.Black, 0, currentY, e.PageBounds.Width, currentY)
        currentY += gap
        'Rows 
        iCount = lvData.Items.Count - 1
        For ii = CurrRow To iCount
            If (currentY + maxY + maxY) > e.PageBounds.Height Then 'jump down another line to see if this line will fit 
                CurrRow = ii - 1
                e.HasMorePages = True
                Exit For 'does next page 
            End If
            l = 0
            maxY = 0
            idx = 0
            For Each lvsi In lvData.Items(ii).SubItems
                maxY = Math.Max(maxY, g.MeasureString(lvsi.Text, f, colWidths(idx)).Height)
                lr = New RectangleF(colLefts(idx), currentY, colWidths(idx), maxY)
                g.DrawString(lvsi.Text, f, b, lr)
                idx += 1
            Next
            currentY += maxY + gap
        Next
    End Sub
#End Region


    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        PrintPreview()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Print()
    End Sub

End Class