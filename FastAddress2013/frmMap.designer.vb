<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMap))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCSV = New System.Windows.Forms.Label()
        Me.lstDataField = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(29, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Imported Field"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCSV
        '
        Me.lblCSV.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCSV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCSV.Location = New System.Drawing.Point(32, 32)
        Me.lblCSV.Name = "lblCSV"
        Me.lblCSV.Size = New System.Drawing.Size(213, 23)
        Me.lblCSV.TabIndex = 1
        Me.lblCSV.Text = "Imported Field"
        Me.lblCSV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstDataField
        '
        Me.lstDataField.CheckOnClick = true
        Me.lstDataField.FormattingEnabled = true
        Me.lstDataField.Location = New System.Drawing.Point(32, 85)
        Me.lstDataField.Name = "lstDataField"
        Me.lstDataField.Size = New System.Drawing.Size(217, 199)
        Me.lstDataField.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(36, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Select the field to import into"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(155, 301)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 25)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&OK"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'frmMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 338)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lstDataField)
        Me.Controls.Add(Me.lblCSV)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmMap"
        Me.Text = "Map Imported Field"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCSV As System.Windows.Forms.Label
    Friend WithEvents lstDataField As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
