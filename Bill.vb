Imports System.Data
Imports System.Data.OleDb
Public Class Bill
    Inherits System.Windows.Forms.Form
    'Dim mypath = Application.StartupPath & "\login.mdb"
    Dim mypassword = ""
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/members.accdb ;Jet OLEDB:Database Password= & mypassword")
    Dim cmd As OleDbCommand

    Dim MyFunction As New ClsFunction

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Me.Hide()
        Dim sql = "SELECT UserID ,PassID FROM BillMakers WHERE USERID='" & txtBillUsername.Text & "' AND PASSID='" & txtBillPassword.Text & "'"

        cmd = New OleDbCommand(sql, conn)
        conn.Open()
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Try
            If dr.Read = False Then
                'MessageBox.Show("Authentication failed...")
                If MsgBox("Authentication failed... !!!" & vbNewLine & "           *RETRY*", MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then
                    Me.Show()
                Else
                    frmLogin.Show()

                End If
            Else
                'MessageBox.Show("Login successfully...")
                Dim frmDialogue As New MakeBill2
                Me.Hide()
                conn.Close()
                'DoAttendance

                Dim UserID As String
                UserID = txtBillUsername.Text
               
                Dim Designation As String
                Designation = "BillMaker"

                MyFunction.CheckAttendance(UserID, Designation)


                'Clear()

                frmDialogue.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conn.Close()
    End Sub
   


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        frmLogin.Show()
    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
        frmLogin.Show()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call MyFunction.AddTempDate()
    End Sub
End Class
