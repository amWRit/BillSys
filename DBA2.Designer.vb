<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DBA2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DBA2))
        Me.ItemsDataSet = New BillSys.itemsDataSet
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsTableAdapter = New BillSys.itemsDataSetTableAdapters.ItemsTableAdapter
        Me.TableAdapterManager = New BillSys.itemsDataSetTableAdapters.TableAdapterManager
        Me.lvData = New System.Windows.Forms.ListView
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblID = New System.Windows.Forms.Label
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtItemCode = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCategory = New System.Windows.Forms.TextBox
        Me.pnlCaption = New System.Windows.Forms.Panel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPicturePath = New System.Windows.Forms.TextBox
        Me.btnBrowsePicture = New System.Windows.Forms.Button
        CType(Me.ItemsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ItemsDataSet
        '
        Me.ItemsDataSet.DataSetName = "itemsDataSet"
        Me.ItemsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.ItemsDataSet
        '
        'ItemsTableAdapter
        '
        Me.ItemsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.ItemsTableAdapter = Me.ItemsTableAdapter
        Me.TableAdapterManager.UpdateOrder = BillSys.itemsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'lvData
        '
        Me.lvData.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.lvData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvData.ForeColor = System.Drawing.Color.White
        Me.lvData.FullRowSelect = True
        Me.lvData.GridLines = True
        Me.lvData.HideSelection = False
        Me.lvData.Location = New System.Drawing.Point(66, 144)
        Me.lvData.MultiSelect = False
        Me.lvData.Name = "lvData"
        Me.lvData.Size = New System.Drawing.Size(856, 480)
        Me.lvData.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvData.TabIndex = 41
        Me.lvData.UseCompatibleStateImageBehavior = False
        Me.lvData.View = System.Windows.Forms.View.Details
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.PaleVioletRed
        Me.Label5.Location = New System.Drawing.Point(964, 342)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 31)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Quantity"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.PaleVioletRed
        Me.Label4.Location = New System.Drawing.Point(1004, 287)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 31)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.PaleVioletRed
        Me.Label3.Location = New System.Drawing.Point(994, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 31)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.PaleVioletRed
        Me.Label2.Location = New System.Drawing.Point(941, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 31)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Item Code"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BackColor = System.Drawing.Color.Turquoise
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.Red
        Me.lblID.Location = New System.Drawing.Point(945, 107)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(67, 37)
        Me.lblID.TabIndex = 36
        Me.lblID.Text = ">.<"
        Me.lblID.Visible = False
        '
        'txtQty
        '
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(1096, 335)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(181, 38)
        Me.txtQty.TabIndex = 35
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(1097, 280)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(180, 38)
        Me.txtPrice.TabIndex = 34
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(1097, 225)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(180, 38)
        Me.txtName.TabIndex = 33
        '
        'txtItemCode
        '
        Me.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(1096, 172)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(181, 38)
        Me.txtItemCode.TabIndex = 32
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(1193, 562)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 50)
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1077, 562)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 50)
        Me.btnSave.TabIndex = 30
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(371, 659)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(172, 55)
        Me.btnDelete.TabIndex = 29
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(636, 659)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(169, 55)
        Me.btnEdit.TabIndex = 28
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(957, 562)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 50)
        Me.btnAdd.TabIndex = 27
        Me.btnAdd.Text = "Add New Item"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(111, 661)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(157, 53)
        Me.btnRefresh.TabIndex = 26
        Me.btnRefresh.Text = "Refresh LIST"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Enabled = False
        Me.btnOpen.Location = New System.Drawing.Point(23, 671)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(82, 43)
        Me.btnOpen.TabIndex = 25
        Me.btnOpen.Text = "Open FILE"
        Me.btnOpen.UseVisualStyleBackColor = True
        Me.btnOpen.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Location = New System.Drawing.Point(1162, 661)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 53)
        Me.Button1.TabIndex = 45
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.PaleVioletRed
        Me.Label1.Location = New System.Drawing.Point(955, 399)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 31)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Category"
        '
        'txtCategory
        '
        Me.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory.Location = New System.Drawing.Point(1096, 392)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(181, 38)
        Me.txtCategory.TabIndex = 46
        '
        'pnlCaption
        '
        Me.pnlCaption.BackColor = System.Drawing.Color.Transparent
        Me.pnlCaption.Location = New System.Drawing.Point(47, 23)
        Me.pnlCaption.Name = "pnlCaption"
        Me.pnlCaption.Size = New System.Drawing.Size(1076, 60)
        Me.pnlCaption.TabIndex = 1003
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(1140, 23)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(59, 60)
        Me.PictureBox2.TabIndex = 1002
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(1242, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(59, 60)
        Me.PictureBox1.TabIndex = 1001
        Me.PictureBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.PaleVioletRed
        Me.Label6.Location = New System.Drawing.Point(981, 456)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 31)
        Me.Label6.TabIndex = 1005
        Me.Label6.Text = "Picture"
        '
        'txtPicturePath
        '
        Me.txtPicturePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPicturePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPicturePath.Location = New System.Drawing.Point(1096, 449)
        Me.txtPicturePath.Name = "txtPicturePath"
        Me.txtPicturePath.Size = New System.Drawing.Size(181, 38)
        Me.txtPicturePath.TabIndex = 1004
        '
        'btnBrowsePicture
        '
        Me.btnBrowsePicture.Location = New System.Drawing.Point(1193, 493)
        Me.btnBrowsePicture.Name = "btnBrowsePicture"
        Me.btnBrowsePicture.Size = New System.Drawing.Size(84, 26)
        Me.btnBrowsePicture.TabIndex = 1006
        Me.btnBrowsePicture.Text = "Browse"
        Me.btnBrowsePicture.UseVisualStyleBackColor = True
        '
        'DBA2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1366, 750)
        Me.Controls.Add(Me.btnBrowsePicture)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPicturePath)
        Me.Controls.Add(Me.pnlCaption)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lvData)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtItemCode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnOpen)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DBA2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DBA2"
        CType(Me.ItemsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ItemsDataSet As BillSys.itemsDataSet
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemsTableAdapter As BillSys.itemsDataSetTableAdapters.ItemsTableAdapter
    Friend WithEvents TableAdapterManager As BillSys.itemsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents lvData As System.Windows.Forms.ListView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents pnlCaption As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPicturePath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowsePicture As System.Windows.Forms.Button
End Class
