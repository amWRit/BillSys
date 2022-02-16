Imports System.Data.OleDb
Public Class Welcome
    Dim Con As System.Data.OleDb.OleDbConnection

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MsgBox("Are you sure you want to EXIT?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        cus.Show()
        Me.Hide()
    End Sub


    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        frmLogin.Show()
        Me.Hide()
    End Sub


End Class
