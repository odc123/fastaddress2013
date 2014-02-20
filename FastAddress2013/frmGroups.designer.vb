<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroups
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGroups))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.lstAvailable = New System.Windows.Forms.ListBox()
        Me.lstAllocated = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(319, 37)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Use drag and drop or < and > buttons to enrol (or remove) this address in any num"& _ 
    "ber of groups."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(187, 244)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(115, 23)
        Me.btnApply.TabIndex = 8
        Me.btnApply.Text = "Apply && E&xit"
        Me.btnApply.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(40, 244)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(115, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(208, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Available"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Enrolled"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(159, 147)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(27, 25)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "<"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(159, 116)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(27, 25)
        Me.btnRemove.TabIndex = 5
        Me.btnRemove.Text = ">"
        Me.btnRemove.UseVisualStyleBackColor = true
        '
        'lstAvailable
        '
        Me.lstAvailable.AllowDrop = true
        Me.lstAvailable.FormattingEnabled = true
        Me.lstAvailable.Location = New System.Drawing.Point(207, 80)
        Me.lstAvailable.Name = "lstAvailable"
        Me.lstAvailable.Size = New System.Drawing.Size(125, 147)
        Me.lstAvailable.TabIndex = 4
        '
        'lstAllocated
        '
        Me.lstAllocated.AllowDrop = true
        Me.lstAllocated.FormattingEnabled = true
        Me.lstAllocated.Location = New System.Drawing.Point(14, 80)
        Me.lstAllocated.Name = "lstAllocated"
        Me.lstAllocated.Size = New System.Drawing.Size(125, 147)
        Me.lstAllocated.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(37, 275)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(265, 37)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "To create a new group go to the Tools menu Change Groups item."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmGroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 321)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.lstAvailable)
        Me.Controls.Add(Me.lstAllocated)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmGroups"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Groups"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lstAvailable As System.Windows.Forms.ListBox
    Friend WithEvents lstAllocated As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
