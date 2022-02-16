<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TotalSales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lvData = New System.Windows.Forms.ListView
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Search = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.LabelDate = New System.Windows.Forms.Label
        Me.txtTotalSales = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTotalQuantity = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSortItemCode = New System.Windows.Forms.TextBox
        Me.LabelBillAmount = New System.Windows.Forms.Label
        Me.txtTotalBillAmount = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lvData
        '
        Me.lvData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvData.FullRowSelect = True
        Me.lvData.GridLines = True
        Me.lvData.HideSelection = False
        Me.lvData.Location = New System.Drawing.Point(26, 60)
        Me.lvData.MultiSelect = False
        Me.lvData.Name = "lvData"
        Me.lvData.Size = New System.Drawing.Size(1141, 416)
        Me.lvData.TabIndex = 78
        Me.lvData.UseCompatibleStateImageBehavior = False
        Me.lvData.View = System.Windows.Forms.View.Details
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(26, 501)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(269, 95)
        Me.btnRefresh.TabIndex = 77
        Me.btnRefresh.Text = "Refresh ITEM LIST"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(301, 571)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(819, 25)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "In case you don't know the complete Item name, put % sign before or after the let" & _
            "ters"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(839, 508)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(134, 38)
        Me.btnSearch.TabIndex = 74
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(470, 508)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(271, 38)
        Me.txtSearch.TabIndex = 73
        '
        'Search
        '
        Me.Search.AutoSize = True
        Me.Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search.Location = New System.Drawing.Point(333, 515)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(100, 31)
        Me.Search.TabIndex = 72
        Me.Search.Text = "Search"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnExit.Location = New System.Drawing.Point(1136, 622)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(138, 60)
        Me.btnExit.TabIndex = 79
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(149, 13)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(364, 31)
        Me.DateTimePicker1.TabIndex = 84
        '
        'LabelDate
        '
        Me.LabelDate.AutoSize = True
        Me.LabelDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.Location = New System.Drawing.Point(22, 20)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Size = New System.Drawing.Size(121, 24)
        Me.LabelDate.TabIndex = 85
        Me.LabelDate.Text = "Sort by Date :"
        '
        'txtTotalSales
        '
        Me.txtTotalSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSales.Location = New System.Drawing.Point(1189, 111)
        Me.txtTotalSales.Name = "txtTotalSales"
        Me.txtTotalSales.Size = New System.Drawing.Size(141, 29)
        Me.txtTotalSales.TabIndex = 86
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1185, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 48)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sales Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1185, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 48)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Quantity Sold"
        '
        'txtTotalQuantity
        '
        Me.txtTotalQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQuantity.Location = New System.Drawing.Point(1187, 302)
        Me.txtTotalQuantity.Name = "txtTotalQuantity"
        Me.txtTotalQuantity.Size = New System.Drawing.Size(143, 29)
        Me.txtTotalQuantity.TabIndex = 88
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(534, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 24)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Sort by ItemCode :"
        '
        'txtSortItemCode
        '
        Me.txtSortItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSortItemCode.Location = New System.Drawing.Point(706, 15)
        Me.txtSortItemCode.Name = "txtSortItemCode"
        Me.txtSortItemCode.Size = New System.Drawing.Size(190, 29)
        Me.txtSortItemCode.TabIndex = 91
        '
        'LabelBillAmount
        '
        Me.LabelBillAmount.AutoSize = True
        Me.LabelBillAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBillAmount.Location = New System.Drawing.Point(1185, 154)
        Me.LabelBillAmount.Name = "LabelBillAmount"
        Me.LabelBillAmount.Size = New System.Drawing.Size(105, 48)
        Me.LabelBillAmount.TabIndex = 93
        Me.LabelBillAmount.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bill Amount"
        '
        'txtTotalBillAmount
        '
        Me.txtTotalBillAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBillAmount.Location = New System.Drawing.Point(1189, 205)
        Me.txtTotalBillAmount.Name = "txtTotalBillAmount"
        Me.txtTotalBillAmount.Size = New System.Drawing.Size(141, 29)
        Me.txtTotalBillAmount.TabIndex = 92
        '
        'TotalSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 712)
        Me.Controls.Add(Me.LabelBillAmount)
        Me.Controls.Add(Me.txtTotalBillAmount)
        Me.Controls.Add(Me.txtSortItemCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTotalQuantity)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTotalSales)
        Me.Controls.Add(Me.LabelDate)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lvData)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Search)
        Me.Name = "TotalSales"
        Me.Text = "TotalSales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvData As System.Windows.Forms.ListView
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Search As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelDate As System.Windows.Forms.Label
    Friend WithEvents txtTotalSales As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSortItemCode As System.Windows.Forms.TextBox
    Friend WithEvents LabelBillAmount As System.Windows.Forms.Label
    Friend WithEvents txtTotalBillAmount As System.Windows.Forms.TextBox
End Class
