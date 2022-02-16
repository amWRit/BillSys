<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddToAccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddToAccount))
        Me.Button4 = New System.Windows.Forms.Button
        Me.Add = New System.Windows.Forms.Button
        Me.txtCusID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.labelDiscount = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(276, 171)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(110, 46)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Exit"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Add
        '
        Me.Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add.Location = New System.Drawing.Point(138, 171)
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(110, 46)
        Me.Add.TabIndex = 14
        Me.Add.Text = "Add"
        Me.Add.UseVisualStyleBackColor = True
        '
        'txtCusID
        '
        Me.txtCusID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCusID.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCusID.Location = New System.Drawing.Point(276, 109)
        Me.txtCusID.Name = "txtCusID"
        Me.txtCusID.Size = New System.Drawing.Size(175, 38)
        Me.txtCusID.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(78, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 31)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "CustomerID"
        '
        'txtAmount
        '
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(276, 56)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(175, 38)
        Me.txtAmount.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(23, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(225, 25)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Amount to be Added"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Button1.ForeColor = System.Drawing.Color.Crimson
        Me.Button1.Location = New System.Drawing.Point(332, 244)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 40)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "View Customers' List"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'labelDiscount
        '
        Me.labelDiscount.AutoSize = True
        Me.labelDiscount.Location = New System.Drawing.Point(86, 244)
        Me.labelDiscount.Name = "labelDiscount"
        Me.labelDiscount.Size = New System.Drawing.Size(39, 13)
        Me.labelDiscount.TabIndex = 19
        Me.labelDiscount.Text = "Label3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 244)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Discount :"
        '
        'AddToAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(483, 306)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.labelDiscount)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Add)
        Me.Controls.Add(Me.txtCusID)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddToAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddToAccount"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Add As System.Windows.Forms.Button
    Friend WithEvents txtCusID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents labelDiscount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
