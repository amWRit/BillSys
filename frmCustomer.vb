Public Class frmCustomer

   

    Private Sub Customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Me.ItemsTableAdapter.Fill(Me.ItemsListDataSet4.Items)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ItemsDataGridView.DataSource = Me.ItemsListDataSet4.Items.Select("Item like'" & TextBox1.Text & "'")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmBecomeMember.show()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
