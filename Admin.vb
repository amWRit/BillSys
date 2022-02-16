Imports System.Data
Imports System.Data.OleDb
Public Class Admin
    Inherits System.Windows.Forms.Form
    'Dim mypath = Application.StartupPath & "\login.mdb"
    Dim mypassword = ""
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/members.accdb ;Jet OLEDB:Database Password= & mypassword")
    Dim cmd As OleDbCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Me.Hide()
        Dim sql = "SELECT UserID ,PassID FROM Admins WHERE USERID='" & txtAdminUsername.Text & "' AND PASSID='" & txtAdminPassword.Text & "'"

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
                Dim frmDialogue As New Admin2
                Me.Hide()
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

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
        frmLogin.Show()
    End Sub
End Class
