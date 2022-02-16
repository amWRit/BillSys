Imports System.Data
Imports System.Data.OleDb
Public Class AddToAccount
    Inherits System.Windows.Forms.Form
    'Dim mypath = Application.StartupPath & "\login.mdb"

    Dim mypassword = ""
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../data/Customers.mdb ;Jet OLEDB:Database Password= & mypassword")
    Dim cmd As OleDbCommand
    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        AddToAccount()
    End Sub
    Sub AddToAccount()
        Dim SQL As String
        SQL = "SELECT * FROM Customers WHERE CusID='" & txtCusID.Text & "' " 'This statement grabs all records from the table
        'SQL = "SELECT * FROM Items "
        'SQL = "INSERT INTO Temp(ItemCode,Item,Price) SELECT  ItemCode,Item,Price FROM Items WHERE ItemCode='" & txtID.Text & "' "

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        conn.Open() 'Open connection

        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(SQL, conn)
        oData.Fill(DS)

        'txtAmount.Text = totalSum.ToString()

        Dim newAmount As Double = 0
        Dim Amount As Double = 0

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            Amount = DS.Tables(0).Rows(i).Item("Amount")

            newAmount = Amount
            newAmount += totalSum

            If newAmount > 20000 Then
                MsgBox("Your TOTAL DUE exceeds Rs. 20000!!! " & vbNewLine & "FIRST PAY THE DUE,PLEASE :)", MsgBoxStyle.Exclamation, "CANNOT ADD TO ACCOUNT")

            Else

                Dim MembershipType As String = ""
                For j As Integer = 0 To DS.Tables(0).Rows.Count - 1

                    MembershipType = DS.Tables(0).Rows(j).Item("MembershipType")

                Next

                If MembershipType = "Bronze" Then
                    Discount += 3
                ElseIf MembershipType = "Silver" Then
                    Discount += 5
                Else
                    Discount += 7
                End If

                labelDiscount.Text = Discount.ToString

                totalSum -= Discount / 100 * totalSum

                Amount += totalSum


                Dim cmd2 As New OleDb.OleDbCommand("UPDATE Customers SET  Amount=@a0  WHERE CusID='" & txtCusID.Text & "' ", conn)

                cmd2.Parameters.AddWithValue("@a0", Amount)

                cmd2.ExecuteNonQuery()


                MsgBox("Amount  Rs. " & totalSum & "   added to " & vbNewLine & "CustomerID    [ " & DS.Tables(0).Rows(i).Item("CusID") & " ]" & vbNewLine & "" & DS.Tables(0).Rows(i).Item("FirstName") & "    " & DS.Tables(0).Rows(i).Item("MiddleName") & "     " & DS.Tables(0).Rows(i).Item("LastName") & " " & vbNewLine & "", MsgBoxStyle.Information, "ADDED")
            End If

            'If Amount = 0 Then
            'MsgBox("After this transaction" & vbNewLine & "ItemCode   [ " & DS.Tables(0).Rows(i).Item("ItemCode") & " ]" & vbNewLine & "" & DS.Tables(0).Rows(i).Item("Item") & " has gone OUT OF STOCK" & vbNewLine & "Contact DBA soon.. ", MsgBoxStyle.Exclamation, "Out of stock")
            'End If
        Next
        conn.Close()

        txtAmount.Text = ""
        txtCusID.Text = ""
        
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub AddToAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAmount.Text = totalSum.ToString()
        labelDiscount.text = Discount.ToString
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmCustomersList2.Show()
    End Sub
End Class