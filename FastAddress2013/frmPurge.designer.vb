<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurge
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
        Me.btnPurge = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PurgeCalendar = New System.Windows.Forms.MonthCalendar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'btnPurge
        '
        Me.btnPurge.Location = New System.Drawing.Point(172, 268)
        Me.btnPurge.Name = "btnPurge"
        Me.btnPurge.Size = New System.Drawing.Size(104, 25)
        Me.btnPurge.TabIndex = 4
        Me.btnPurge.Text = "&Purge"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(49, 268)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 25)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        '
        'PurgeCalendar
        '
        Me.PurgeCalendar.Location = New System.Drawing.Point(49, 83)
        Me.PurgeCalendar.Name = "PurgeCalendar"
        Me.PurgeCalendar.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(23, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select the date from which you wish to retain deleted records."
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(23, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(301, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "If you select tomorrow's date all deleted records will be purged."
        '
        'frmPurge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 316)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PurgeCalendar)
        Me.Controls.Add(Me.btnPurge)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmPurge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Purge Deleted Records"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents btnPurge As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents PurgeCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
