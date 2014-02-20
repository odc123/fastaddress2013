<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveLabel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaveLabel))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtNew = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.SS = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SS.SuspendLayout
        Me.SuspendLayout
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(41, 31)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(351, 31)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save label settings under current name : xxx"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(41, 120)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(351, 31)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "Save current setting with a new Label Name"
        Me.btnNew.UseVisualStyleBackColor = true
        '
        'txtNew
        '
        Me.txtNew.Location = New System.Drawing.Point(140, 94)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.Size = New System.Drawing.Size(223, 20)
        Me.txtNew.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(66, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "New Label"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(41, 172)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(351, 31)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete label xxx from saved label settings"
        Me.btnDelete.UseVisualStyleBackColor = true
        '
        'SS
        '
        Me.SS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
        Me.SS.Location = New System.Drawing.Point(0, 252)
        Me.SS.Name = "SS"
        Me.SS.Size = New System.Drawing.Size(433, 22)
        Me.SS.TabIndex = 6
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(237, 17)
        Me.StatusLabel.Text = "- Default - label settings cannot be deleted. "
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(317, 209)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 31)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'frmSaveLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 274)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.SS)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNew)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmSaveLabel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add / Update / Delete Saved Label Settings"
        Me.SS.ResumeLayout(false)
        Me.SS.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents SS As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
