<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cus
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cus))
        Me.ItemsListDataSet4 = New BillSys.ItemsListDataSet4
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsTableAdapter = New BillSys.ItemsListDataSet4TableAdapters.ItemsTableAdapter
        Me.TableAdapterManager = New BillSys.ItemsListDataSet4TableAdapters.TableAdapterManager
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnEstimate = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Search = New System.Windows.Forms.Label
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label = New System.Windows.Forms.Label
        Me.lvData = New System.Windows.Forms.ListView
        Me.Combo = New System.Windows.Forms.ComboBox
        Me.Test = New System.Windows.Forms.Button
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.pnlCaption = New System.Windows.Forms.Panel
        Me.txtEstimate = New System.Windows.Forms.TextBox
        Me.LabelEstimate = New System.Windows.Forms.Label
        Me.LabelInfo = New System.Windows.Forms.Label
        Me.Labeltest = New System.Windows.Forms.Label
        Me.btnClear = New System.Windows.Forms.Button
        CType(Me.ItemsListDataSet4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ItemsListDataSet4
        '
        Me.ItemsListDataSet4.DataSetName = "ItemsListDataSet4"
        Me.ItemsListDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.ItemsListDataSet4
        '
        'ItemsTableAdapter
        '
        Me.ItemsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.ItemsTableAdapter = Me.ItemsTableAdapter
        Me.TableAdapterManager.SalesTableAdapter = Nothing
        Me.TableAdapterManager.TempTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = BillSys.ItemsListDataSet4TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(115, 581)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(819, 25)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "In case you don't know the complete Item name, put % sign before or after the let" & _
            "ters"
        '
        'btnEstimate
        '
        Me.btnEstimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEstimate.Location = New System.Drawing.Point(467, 631)
        Me.btnEstimate.Name = "btnEstimate"
        Me.btnEstimate.Size = New System.Drawing.Size(224, 48)
        Me.btnEstimate.TabIndex = 58
        Me.btnEstimate.Text = "Estimate Bill"
        Me.btnEstimate.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(567, 538)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 40)
        Me.btnSearch.TabIndex = 57
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(296, 538)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(233, 40)
        Me.txtSearch.TabIndex = 56
        '
        'Search
        '
        Me.Search.AutoSize = True
        Me.Search.BackColor = System.Drawing.Color.Transparent
        Me.Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search.ForeColor = System.Drawing.Color.Crimson
        Me.Search.Location = New System.Drawing.Point(147, 541)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(107, 33)
        Me.Search.TabIndex = 55
        Me.Search.Text = "Search"
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(100, 631)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(302, 46)
        Me.btnRefresh.TabIndex = 62
        Me.btnRefresh.Text = "Refresh ITEM LIST"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnExit.Location = New System.Drawing.Point(1127, 613)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(161, 76)
        Me.btnExit.TabIndex = 64
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.ForeColor = System.Drawing.Color.Crimson
        Me.Label.Location = New System.Drawing.Point(125, 90)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(214, 33)
        Me.Label.TabIndex = 65
        Me.Label.Text = "Available Items"
        '
        'lvData
        '
        Me.lvData.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.lvData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvData.ForeColor = System.Drawing.Color.White
        Me.lvData.FullRowSelect = True
        Me.lvData.GridLines = True
        Me.lvData.HideSelection = False
        Me.lvData.Location = New System.Drawing.Point(131, 160)
        Me.lvData.MultiSelect = False
        Me.lvData.Name = "lvData"
        Me.lvData.Size = New System.Drawing.Size(1096, 355)
        Me.lvData.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvData.TabIndex = 72
        Me.lvData.UseCompatibleStateImageBehavior = False
        Me.lvData.View = System.Windows.Forms.View.Details
        '
        'Combo
        '
        Me.Combo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo.ForeColor = System.Drawing.Color.SteelBlue
        Me.Combo.FormattingEnabled = True
        Me.Combo.Items.AddRange(New Object() {"None", "Children", "Clothes", "Food", ""})
        Me.Combo.Location = New System.Drawing.Point(605, 95)
        Me.Combo.Name = "Combo"
        Me.Combo.Size = New System.Drawing.Size(239, 28)
        Me.Combo.TabIndex = 73
        Me.Combo.Text = "BrowseByCategory"
        '
        'Test
        '
        Me.Test.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Test.Location = New System.Drawing.Point(868, 84)
        Me.Test.Name = "Test"
        Me.Test.Size = New System.Drawing.Size(102, 39)
        Me.Test.TabIndex = 75
        Me.Test.Text = "Browse"
        Me.Test.UseVisualStyleBackColor = True
        Me.Test.UseWaitCursor = True
        Me.Test.Visible = False
        '
        'PictureBox
        '
        Me.PictureBox.Location = New System.Drawing.Point(355, 53)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(121, 70)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox.TabIndex = 76
        Me.PictureBox.TabStop = False
        Me.PictureBox.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(1127, 26)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(59, 60)
        Me.PictureBox2.TabIndex = 78
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(1229, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(59, 60)
        Me.PictureBox1.TabIndex = 77
        Me.PictureBox1.TabStop = False
        '
        'pnlCaption
        '
        Me.pnlCaption.BackColor = System.Drawing.Color.Transparent
        Me.pnlCaption.Location = New System.Drawing.Point(45, 12)
        Me.pnlCaption.Name = "pnlCaption"
        Me.pnlCaption.Size = New System.Drawing.Size(1076, 35)
        Me.pnlCaption.TabIndex = 1000
        '
        'txtEstimate
        '
        Me.txtEstimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstimate.Location = New System.Drawing.Point(851, 633)
        Me.txtEstimate.Name = "txtEstimate"
        Me.txtEstimate.Size = New System.Drawing.Size(119, 44)
        Me.txtEstimate.TabIndex = 1001
        Me.txtEstimate.Visible = False
        '
        'LabelEstimate
        '
        Me.LabelEstimate.AutoSize = True
        Me.LabelEstimate.BackColor = System.Drawing.Color.Transparent
        Me.LabelEstimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEstimate.ForeColor = System.Drawing.Color.LightSalmon
        Me.LabelEstimate.Location = New System.Drawing.Point(848, 614)
        Me.LabelEstimate.Name = "LabelEstimate"
        Me.LabelEstimate.Size = New System.Drawing.Size(108, 16)
        Me.LabelEstimate.TabIndex = 1002
        Me.LabelEstimate.Text = "Estimate Amount"
        Me.LabelEstimate.Visible = False
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.BackColor = System.Drawing.Color.Transparent
        Me.LabelInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInfo.ForeColor = System.Drawing.Color.LightSalmon
        Me.LabelInfo.Location = New System.Drawing.Point(417, 643)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(414, 25)
        Me.LabelInfo.TabIndex = 1003
        Me.LabelInfo.Text = "DOUBLE CLICK on any item to add to cart"
        Me.LabelInfo.Visible = False
        '
        'Labeltest
        '
        Me.Labeltest.AutoSize = True
        Me.Labeltest.BackColor = System.Drawing.Color.Transparent
        Me.Labeltest.Enabled = False
        Me.Labeltest.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeltest.ForeColor = System.Drawing.Color.Red
        Me.Labeltest.Location = New System.Drawing.Point(987, 560)
        Me.Labeltest.Name = "Labeltest"
        Me.Labeltest.Size = New System.Drawing.Size(47, 25)
        Me.Labeltest.TabIndex = 1004
        Me.Labeltest.Text = "test"
        Me.Labeltest.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(976, 633)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(80, 46)
        Me.btnClear.TabIndex = 1005
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        Me.btnClear.Visible = False
        '
        'cus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1366, 750)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Labeltest)
        Me.Controls.Add(Me.LabelInfo)
        Me.Controls.Add(Me.LabelEstimate)
        Me.Controls.Add(Me.txtEstimate)
        Me.Controls.Add(Me.pnlCaption)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.Test)
        Me.Controls.Add(Me.Combo)
        Me.Controls.Add(Me.lvData)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEstimate)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Search)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "cus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Available Items"
        CType(Me.ItemsListDataSet4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ItemsListDataSet4 As BillSys.ItemsListDataSet4
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemsTableAdapter As BillSys.ItemsListDataSet4TableAdapters.ItemsTableAdapter
    Friend WithEvents TableAdapterManager As BillSys.ItemsListDataSet4TableAdapters.TableAdapterManager
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEstimate As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Search As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents lvData As System.Windows.Forms.ListView
    Friend WithEvents Combo As System.Windows.Forms.ComboBox
    Friend WithEvents Test As System.Windows.Forms.Button
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCaption As System.Windows.Forms.Panel
    Friend WithEvents txtEstimate As System.Windows.Forms.TextBox
    Friend WithEvents LabelEstimate As System.Windows.Forms.Label
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents Labeltest As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
End Class
