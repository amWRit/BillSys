Option Strict On
Option Explicit On
Imports System.Data.OleDb



Friend Class AddItems

    Dim daItems As New OleDbDataAdapter()
    Dim dsItems As New DataSet()

    Public ID As String
    Public State As gModule.FormState

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As DataTable = dsItems.Tables("Items")

        If txtItemID.Text = "" Or txtItemName.Text = "" Or txtItemPrice.Text = "" Or txtItemQty.Text = "" Then
            MsgBox("Please fill up all the  information.", MsgBoxStyle.Critical)

            Exit Sub
        End If

        Try
            If State = gModule.FormState.adStateAddMode Then
                ' add a row
                Dim newRow As DataRow

                newRow = dt.NewRow()
                newRow("ID") = txtItemID.Text
                newRow("Items") = txtItemName.Text
                newRow("Price") = txtItemPrice.Text
                newRow("Qty") = txtItemQty.Text


                ' newRow("Fax") = IIf(txtFax.Text = "", System.DBNull.Value, txtFax.Text)

                dt.Rows.Add(newRow)
            Else
                With dt
                    .Rows(0)("ID") = txtItemID.Text
                    .Rows(0)("Items") = txtItemName.Text
                    .Rows(0)("Price") = txtItemPrice.Text
                    .Rows(0)("Qty") = txtItemQty.Text


                End With
            End If
            daItems.Update(dsItems, "Items")

            MsgBox("Record successfully saved.", MsgBoxStyle.Information)
        Catch ex As OleDbException
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class