Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class frmBecomeMember

    Dim Con As System.Data.OleDb.OleDbConnection
    Dim DBName As String = "Customers.mdb"

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
    


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If EDITMODE = True Then
            Try
                Dim Tag As Integer
                Tag = CurVal
                'This connection string is the same as the one we just used with btnOpen
                ' (recycles the DBName var that we have declared globally)

                'Here we are going to build a SQL statement that we pass parameters with
                'the OleDbCommand object, which is used to Execute NonQuery based commands
                'such as INSERT (new row) DELETE (delete row) or DROP TABLE (deletes a table from the db)
                'Here we are using the UPDATE command which is used to update an existing record or records based on WHERE criteria

                'UPDATE TableName SET Field=@a0, Field=@a1 WHERE PrimaryKey = @a2
                'the @a0 represents a Parameter that will be set with the OleDbCommand object
                Con = New OleDbConnection
                Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/Customers.mdb;User ID=Admin;Password="
                Con.Open()

                Dim cmd2 As New OleDb.OleDbCommand("UPDATE Customers SET FirstName=@a0, MiddleName=@a1, LastName=@a2, City=@a3 , Street=@a4 , House=@a5 , Phone=@a6 , Mobile=@a7 , Fax=@a8, Amount=@a9, CusID=@a10, MembershipType = @a11 WHERE ID = " & CInt(Tag) & " ", Con)

                cmd2.Parameters.AddWithValue("@a0", txtFirstName.Text)
                cmd2.Parameters.AddWithValue("@a1", txtMiddleName.Text)
                cmd2.Parameters.AddWithValue("@a2", txtLastName.Text)
                cmd2.Parameters.AddWithValue("@a3", txtCity.Text)
                cmd2.Parameters.AddWithValue("@a4", txtStreet.Text)
                cmd2.Parameters.AddWithValue("@a5", txtHouse.Text)
                cmd2.Parameters.AddWithValue("@a6", txtPhone.Text)
                cmd2.Parameters.AddWithValue("@a7", txtMobile.Text)
                cmd2.Parameters.AddWithValue("@a8", txtFax.Text)
                cmd2.Parameters.AddWithValue("@a9", txtAmount.Text)
                cmd2.Parameters.AddWithValue("@a10", txtCusID.Text)
                cmd2.Parameters.AddWithValue("@a11", txtMembership.Text)


                cmd2.ExecuteNonQuery()

                MsgBox("Record Updated Successfully")
                EDITMODE = False ' Add success, end EDITMODE
                ClearTextBoxes() 'Add Success, clean up textboxes
                ' AddTable()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Con.Close()
            End Try

        Else
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/Customers.mdb;User ID=Admin;Password="


            Dim oAdapter As OleDb.OleDbDataAdapter
            Dim cb As OleDb.OleDbCommandBuilder
            Dim dr As DataRow
            Dim ds As DataSet
            Dim strSQL As String = "SELECT * FROM Customers"

            ds = New DataSet()
            oAdapter = New OleDb.OleDbDataAdapter(strSQL, Con)
            oAdapter.Fill(ds) 'Execute the Query and grab results

            Try
                dr = ds.Tables(0).NewRow()
                dr.BeginEdit()

                'dr("CustomerID") = txtCustomerID.Text
                dr("FirstName") = txtFirstName.Text
                dr("MiddleName") = txtMiddleName.Text
                dr("LastName") = txtLastName.Text
                dr("City") = txtCity.Text
                dr("Street") = txtStreet.Text
                dr("House") = txtHouse.Text
                dr("Phone") = txtPhone.Text
                dr("Mobile") = txtMobile.Text
                dr("Fax") = txtFax.Text
                dr("Amount") = txtAmount.Text
                dr("CusID") = txtCusID.Text
                dr("MembershipType") = txtMembership.Text


               

                dr.EndEdit()

                ds.Tables(0).Rows.Add(dr)
                cb = New OleDb.OleDbCommandBuilder(oAdapter)
                oAdapter.InsertCommand = cb.GetInsertCommand
                oAdapter.Update(ds)
                ds.AcceptChanges()

                MessageBox.Show("Insert Successful")

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            Finally
                Con.Close()
                'AddTable()
            End Try
        End If


    End Sub
    Sub AddTable()
        Const strConnection As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../data/Customers.mdb;Persist Security Info=False"

        Dim cnn As New ADODB.Connection
        Dim cmd As New ADODB.Command


        cnn.ConnectionString = strConnection
        cnn.Open()

        cmd.ActiveConnection = cnn
        cmd.CommandText = "create '" & txtFirstName.Text & "'    (a text(10), b text)"

        cmd.Execute()
        cnn.Close()


    End Sub
    Sub ClearTextBoxes()

        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        txtCity.Text = ""
        txtStreet.Text = ""
        txtHouse.Text = ""
        txtPhone.Text = ""
        txtMobile.Text = ""
        txtFax.Text = ""
        txtAmount.Text = ""
        txtCusID.Text = ""
        txtMembership.Text = ""

    End Sub
  
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ClearTextBoxes()
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        ClearTextBoxes()
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        Dim Advance As Double
        Dim strAdvance As String
        strAdvance = txtAmount.Text
        Advance = Val(strAdvance)

        If Advance <= 5000 Then
            txtMembership.Text = "BRONZE"

        ElseIf Advance > 5000 And Advance <= 10000 Then
            txtMembership.Text = "SILVER"

        Else
            txtMembership.Text = "GOLD"
        End If
    End Sub

    Private Sub frmBecomeMember_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ClearTextBoxes()
    End Sub
End Class