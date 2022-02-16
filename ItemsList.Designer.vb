<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemsList
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
        Me.SuspendLayout()
        '
        'lvData
        '
        Me.lvData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvData.FullRowSelect = True
        Me.lvData.GridLines = True
        Me.lvData.HideSelection = False
        Me.lvData.Location = New System.Drawing.Point(53, 38)
        Me.lvData.MultiSelect = False
        Me.lvData.Name = "lvData"
        Me.lvData.Size = New System.Drawing.Size(1235, 487)
        Me.lvData.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvData.TabIndex = 71
        Me.lvData.UseCompatibleStateImageBehavior = False
        Me.lvData.View = System.Windows.Forms.View.Details
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(53, 552)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(159, 58)
        Me.btnRefresh.TabIndex = 70
        Me.btnRefresh.Text = "Refresh ITEM LIST"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(271, 627)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(711, 24)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "In case you don't know the complete Item name, put % sign before or after the let" & _
            "ters"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(782, 570)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(118, 40)
        Me.btnSearch.TabIndex = 66
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(444, 570)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(257, 40)
        Me.txtSearch.TabIndex = 65
        '
        'Search
        '
        Me.Search.AutoSize = True
        Me.Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search.Location = New System.Drawing.Point(338, 579)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(100, 31)
        Me.Search.TabIndex = 64
        Me.Search.Text = "Search"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnExit.Location = New System.Drawing.Point(1172, 570)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(116, 58)
        Me.btnExit.TabIndex = 72
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'ItemsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 712)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lvData)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Search)
        Me.Name = "ItemsList"
        Me.Text = "ItemsList"
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
End Class
