<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImport))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFindFile = New System.Windows.Forms.Button()
        Me.dialogGet = New System.Windows.Forms.OpenFileDialog()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.lblSelect = New System.Windows.Forms.Label()
        Me.btnMap = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(382, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "You can import contact names and address details from any other programme that al"& _ 
    "lows data to be exported as comma separated values (.csv file)."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnFindFile
        '
        Me.btnFindFile.Location = New System.Drawing.Point(95, 47)
        Me.btnFindFile.Name = "btnFindFile"
        Me.btnFindFile.Size = New System.Drawing.Size(208, 23)
        Me.btnFindFile.TabIndex = 1
        Me.btnFindFile.Text = "1. Click here to Select the File to Import"
        Me.btnFindFile.UseVisualStyleBackColor = true
        '
        'dialogGet
        '
        Me.dialogGet.DefaultExt = "csv"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = true
        Me.CheckedListBox1.FormattingEnabled = true
        Me.CheckedListBox1.Location = New System.Drawing.Point(75, 76)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(249, 304)
        Me.CheckedListBox1.TabIndex = 2
        '
        'lblSelect
        '
        Me.lblSelect.Location = New System.Drawing.Point(94, 383)
        Me.lblSelect.Name = "lblSelect"
        Me.lblSelect.Size = New System.Drawing.Size(211, 32)
        Me.lblSelect.TabIndex = 3
        Me.lblSelect.Text = "2. Check the fields you wish to import in the list above"
        Me.lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMap
        '
        Me.btnMap.Enabled = false
        Me.btnMap.Location = New System.Drawing.Point(95, 417)
        Me.btnMap.Name = "btnMap"
        Me.btnMap.Size = New System.Drawing.Size(208, 34)
        Me.btnMap.TabIndex = 4
        Me.btnMap.Text = "3. Click here to map imported fields to the address database"
        Me.btnMap.UseVisualStyleBackColor = true
        '
        'btnImport
        '
        Me.btnImport.Enabled = false
        Me.btnImport.Location = New System.Drawing.Point(95, 457)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(208, 34)
        Me.btnImport.TabIndex = 5
        Me.btnImport.Text = "4. Click here to import"
        Me.btnImport.UseVisualStyleBackColor = true
        '
        'frmImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 503)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnMap)
        Me.Controls.Add(Me.lblSelect)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.btnFindFile)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmImport"
        Me.Text = "Import from CSV"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindFile As System.Windows.Forms.Button
    Friend WithEvents dialogGet As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblSelect As System.Windows.Forms.Label
    Friend WithEvents btnMap As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
End Class
