<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLabels
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLabels))
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtVertical = New System.Windows.Forms.TextBox()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.btnTestPrint = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPrintLabels = New System.Windows.Forms.TabPage()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnPrinter = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFont = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbRight = New System.Windows.Forms.RadioButton()
        Me.rbCentre = New System.Windows.Forms.RadioButton()
        Me.rbLeft = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.udSkip = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboGroups = New System.Windows.Forms.ComboBox()
        Me.lblUseTagsDetails = New System.Windows.Forms.Label()
        Me.lblUseTags = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.tabLabelSetup = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPad = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstLayoutNames = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbCent = New System.Windows.Forms.RadioButton()
        Me.rbInch = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtGutter = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLM = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTM = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDown = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAcross = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dlgPreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.dlgPrint = New System.Windows.Forms.PrintDialog()
        Me.dlgFont = New System.Windows.Forms.FontDialog()
        Me.PrintPreviewDialog3 = New System.Windows.Forms.PrintPreviewDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout
        Me.tabPrintLabels.SuspendLayout
        Me.GroupBox4.SuspendLayout
        Me.GroupBox3.SuspendLayout
        CType(Me.udSkip,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabLabelSetup.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.GroupBox1.SuspendLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 304)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(192, 48)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Printing a test page prints a sheet with rectangles showing the borders of all la"& _ 
    "bels on the page"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(480, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(60, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Vertical (V)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVertical
        '
        Me.txtVertical.Location = New System.Drawing.Point(544, 128)
        Me.txtVertical.Name = "txtVertical"
        Me.txtVertical.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVertical.Size = New System.Drawing.Size(48, 20)
        Me.txtVertical.TabIndex = 18
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(492, 319)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDone.Size = New System.Drawing.Size(96, 32)
        Me.btnDone.TabIndex = 10
        Me.btnDone.Text = "E&xit"
        '
        'btnTestPrint
        '
        Me.btnTestPrint.Location = New System.Drawing.Point(56, 264)
        Me.btnTestPrint.Name = "btnTestPrint"
        Me.btnTestPrint.Size = New System.Drawing.Size(96, 32)
        Me.btnTestPrint.TabIndex = 23
        Me.btnTestPrint.Text = "&Print Test Page"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabPrintLabels)
        Me.TabControl1.Controls.Add(Me.tabLabelSetup)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(604, 396)
        Me.TabControl1.TabIndex = 0
        '
        'tabPrintLabels
        '
        Me.tabPrintLabels.Controls.Add(Me.btnPreview)
        Me.tabPrintLabels.Controls.Add(Me.btnPrevious)
        Me.tabPrintLabels.Controls.Add(Me.btnPrinter)
        Me.tabPrintLabels.Controls.Add(Me.Label15)
        Me.tabPrintLabels.Controls.Add(Me.txtFont)
        Me.tabPrintLabels.Controls.Add(Me.Label14)
        Me.tabPrintLabels.Controls.Add(Me.btnFont)
        Me.tabPrintLabels.Controls.Add(Me.GroupBox4)
        Me.tabPrintLabels.Controls.Add(Me.btnDone)
        Me.tabPrintLabels.Controls.Add(Me.GroupBox3)
        Me.tabPrintLabels.Controls.Add(Me.btnPrint)
        Me.tabPrintLabels.Location = New System.Drawing.Point(4, 22)
        Me.tabPrintLabels.Name = "tabPrintLabels"
        Me.tabPrintLabels.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tabPrintLabels.Size = New System.Drawing.Size(596, 370)
        Me.tabPrintLabels.TabIndex = 1
        Me.tabPrintLabels.Text = "Print Labels"
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(390, 281)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPreview.Size = New System.Drawing.Size(96, 32)
        Me.btnPreview.TabIndex = 7
        Me.btnPreview.Text = "Pre&view Labels"
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(288, 319)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrevious.Size = New System.Drawing.Size(96, 32)
        Me.btnPrevious.TabIndex = 8
        Me.btnPrevious.Text = "&Label Setup >"
        '
        'btnPrinter
        '
        Me.btnPrinter.Location = New System.Drawing.Point(390, 243)
        Me.btnPrinter.Name = "btnPrinter"
        Me.btnPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrinter.Size = New System.Drawing.Size(96, 32)
        Me.btnPrinter.TabIndex = 6
        Me.btnPrinter.Text = "Printer &Setup"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(320, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(248, 48)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "The label print routine will try to use the font size you chose. If a line is too"& _ 
    " long for the chosen label font size will be reduced until it fits."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFont
        '
        Me.txtFont.Location = New System.Drawing.Point(392, 206)
        Me.txtFont.Name = "txtFont"
        Me.txtFont.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFont.Size = New System.Drawing.Size(176, 20)
        Me.txtFont.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(304, 203)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(80, 24)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Font Selected"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnFont
        '
        Me.btnFont.Location = New System.Drawing.Point(390, 168)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnFont.Size = New System.Drawing.Size(96, 32)
        Me.btnFont.TabIndex = 3
        Me.btnFont.Text = "&Choose Font"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbRight)
        Me.GroupBox4.Controls.Add(Me.rbCentre)
        Me.GroupBox4.Controls.Add(Me.rbLeft)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(352, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox4.Size = New System.Drawing.Size(192, 96)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = false
        Me.GroupBox4.Text = "Text Alignment"
        '
        'rbRight
        '
        Me.rbRight.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbRight.Location = New System.Drawing.Point(55, 67)
        Me.rbRight.Name = "rbRight"
        Me.rbRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rbRight.Size = New System.Drawing.Size(79, 24)
        Me.rbRight.TabIndex = 2
        Me.rbRight.Text = "Right"
        Me.rbRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rbCentre
        '
        Me.rbCentre.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbCentre.Location = New System.Drawing.Point(55, 43)
        Me.rbCentre.Name = "rbCentre"
        Me.rbCentre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rbCentre.Size = New System.Drawing.Size(79, 24)
        Me.rbCentre.TabIndex = 1
        Me.rbCentre.Text = "Centre"
        Me.rbCentre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rbLeft
        '
        Me.rbLeft.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbLeft.Checked = true
        Me.rbLeft.Location = New System.Drawing.Point(55, 19)
        Me.rbLeft.Name = "rbLeft"
        Me.rbLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rbLeft.Size = New System.Drawing.Size(79, 24)
        Me.rbLeft.TabIndex = 0
        Me.rbLeft.TabStop = true
        Me.rbLeft.Text = "Left"
        Me.rbLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.udSkip)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.cboGroups)
        Me.GroupBox3.Controls.Add(Me.lblUseTagsDetails)
        Me.GroupBox3.Controls.Add(Me.lblUseTags)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox3.Size = New System.Drawing.Size(264, 336)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = false
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label21.Location = New System.Drawing.Point(149, 104)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(62, 16)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "LABELS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'udSkip
        '
        Me.udSkip.Location = New System.Drawing.Point(111, 102)
        Me.udSkip.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.udSkip.Name = "udSkip"
        Me.udSkip.Size = New System.Drawing.Size(37, 20)
        Me.udSkip.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(15, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(239, 42)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "If you have used a few labels on the first sheet you can skip them by entering th"& _ 
    "e number to skip here (from top left reading across)."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label19.Location = New System.Drawing.Point(23, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(211, 16)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "GROUP"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label18.Location = New System.Drawing.Point(64, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(51, 16)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "SKIP "
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(27, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(211, 37)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Select the group of addresses you want to print labels for"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboGroups
        '
        Me.cboGroups.FormattingEnabled = true
        Me.cboGroups.Location = New System.Drawing.Point(67, 69)
        Me.cboGroups.Name = "cboGroups"
        Me.cboGroups.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboGroups.Size = New System.Drawing.Size(145, 21)
        Me.cboGroups.TabIndex = 2
        '
        'lblUseTagsDetails
        '
        Me.lblUseTagsDetails.Location = New System.Drawing.Point(12, 227)
        Me.lblUseTagsDetails.Name = "lblUseTagsDetails"
        Me.lblUseTagsDetails.Size = New System.Drawing.Size(242, 80)
        Me.lblUseTagsDetails.TabIndex = 8
        Me.lblUseTagsDetails.Text = "UseTags Details"
        Me.lblUseTagsDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblUseTags
        '
        Me.lblUseTags.Location = New System.Drawing.Point(23, 181)
        Me.lblUseTags.Name = "lblUseTags"
        Me.lblUseTags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUseTags.Size = New System.Drawing.Size(211, 16)
        Me.lblUseTags.TabIndex = 7
        Me.lblUseTags.Text = "UseTags Heading"
        Me.lblUseTags.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(390, 319)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrint.Size = New System.Drawing.Size(96, 32)
        Me.btnPrint.TabIndex = 9
        Me.btnPrint.Text = "&Print Labels"
        '
        'tabLabelSetup
        '
        Me.tabLabelSetup.AccessibleName = ""
        Me.tabLabelSetup.Controls.Add(Me.Button1)
        Me.tabLabelSetup.Controls.Add(Me.txtPad)
        Me.tabLabelSetup.Controls.Add(Me.Label17)
        Me.tabLabelSetup.Controls.Add(Me.btnNext)
        Me.tabLabelSetup.Controls.Add(Me.btnExit)
        Me.tabLabelSetup.Controls.Add(Me.GroupBox2)
        Me.tabLabelSetup.Controls.Add(Me.GroupBox1)
        Me.tabLabelSetup.Controls.Add(Me.Label13)
        Me.tabLabelSetup.Controls.Add(Me.btnTestPrint)
        Me.tabLabelSetup.Controls.Add(Me.Label9)
        Me.tabLabelSetup.Controls.Add(Me.txtVertical)
        Me.tabLabelSetup.Controls.Add(Me.Label10)
        Me.tabLabelSetup.Controls.Add(Me.txtGutter)
        Me.tabLabelSetup.Controls.Add(Me.Label11)
        Me.tabLabelSetup.Controls.Add(Me.Label7)
        Me.tabLabelSetup.Controls.Add(Me.txtHeight)
        Me.tabLabelSetup.Controls.Add(Me.Label8)
        Me.tabLabelSetup.Controls.Add(Me.txtWidth)
        Me.tabLabelSetup.Controls.Add(Me.Label4)
        Me.tabLabelSetup.Controls.Add(Me.txtLM)
        Me.tabLabelSetup.Controls.Add(Me.Label5)
        Me.tabLabelSetup.Controls.Add(Me.txtTM)
        Me.tabLabelSetup.Controls.Add(Me.Label6)
        Me.tabLabelSetup.Controls.Add(Me.Label3)
        Me.tabLabelSetup.Controls.Add(Me.txtDown)
        Me.tabLabelSetup.Controls.Add(Me.Label2)
        Me.tabLabelSetup.Controls.Add(Me.txtAcross)
        Me.tabLabelSetup.Controls.Add(Me.Label1)
        Me.tabLabelSetup.Controls.Add(Me.PictureBox1)
        Me.tabLabelSetup.Location = New System.Drawing.Point(4, 22)
        Me.tabLabelSetup.Name = "tabLabelSetup"
        Me.tabLabelSetup.Size = New System.Drawing.Size(596, 370)
        Me.tabLabelSetup.TabIndex = 0
        Me.tabLabelSetup.Text = "Label Setup"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(56, 224)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 32)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Printer &Setup"
        '
        'txtPad
        '
        Me.txtPad.Location = New System.Drawing.Point(520, 160)
        Me.txtPad.Name = "txtPad"
        Me.txtPad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPad.Size = New System.Drawing.Size(48, 20)
        Me.txtPad.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.txtPad, "Space between label edge and text")
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label17.Location = New System.Drawing.Point(416, 162)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 16)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Inner Margin (M)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label17, "Space between label edge and text")
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(464, 270)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnNext.Size = New System.Drawing.Size(96, 32)
        Me.btnNext.TabIndex = 26
        Me.btnNext.Text = "< Printing"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(464, 308)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnExit.Size = New System.Drawing.Size(96, 32)
        Me.btnExit.TabIndex = 27
        Me.btnExit.Text = "E&xit"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstLayoutNames)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Location = New System.Drawing.Point(208, 216)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(216, 136)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Saved Labels"
        '
        'lstLayoutNames
        '
        Me.lstLayoutNames.Location = New System.Drawing.Point(28, 27)
        Me.lstLayoutNames.Name = "lstLayoutNames"
        Me.lstLayoutNames.Size = New System.Drawing.Size(160, 21)
        Me.lstLayoutNames.TabIndex = 0
        Me.lstLayoutNames.Text = "ComboBox1"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(28, 73)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(160, 36)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Add / Edit / Delete Saved Labels"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCent)
        Me.GroupBox1.Controls.Add(Me.rbInch)
        Me.GroupBox1.Location = New System.Drawing.Point(440, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(136, 72)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "All Dimensions in ..."
        '
        'rbCent
        '
        Me.rbCent.Checked = true
        Me.rbCent.Location = New System.Drawing.Point(24, 16)
        Me.rbCent.Name = "rbCent"
        Me.rbCent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rbCent.Size = New System.Drawing.Size(88, 24)
        Me.rbCent.TabIndex = 0
        Me.rbCent.TabStop = true
        Me.rbCent.Text = "Centimeters"
        '
        'rbInch
        '
        Me.rbInch.Location = New System.Drawing.Point(24, 42)
        Me.rbInch.Name = "rbInch"
        Me.rbInch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rbInch.Size = New System.Drawing.Size(64, 24)
        Me.rbInch.TabIndex = 1
        Me.rbInch.Text = "Inches"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(344, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(75, 16)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Horizontal (G)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtGutter
        '
        Me.txtGutter.Location = New System.Drawing.Point(424, 128)
        Me.txtGutter.Name = "txtGutter"
        Me.txtGutter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGutter.Size = New System.Drawing.Size(48, 20)
        Me.txtGutter.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label11.Location = New System.Drawing.Point(422, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(160, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Space Between Labels"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(480, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Height (H)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(544, 88)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHeight.Size = New System.Drawing.Size(48, 20)
        Me.txtHeight.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(360, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Width (W)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(424, 88)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWidth.Size = New System.Drawing.Size(48, 20)
        Me.txtWidth.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(360, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Left (LM)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLM
        '
        Me.txtLM.Location = New System.Drawing.Point(424, 64)
        Me.txtLM.Name = "txtLM"
        Me.txtLM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLM.Size = New System.Drawing.Size(48, 20)
        Me.txtLM.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(480, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Top (TM)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTM
        '
        Me.txtTM.Location = New System.Drawing.Point(544, 64)
        Me.txtTM.Name = "txtTM"
        Me.txtTM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTM.Size = New System.Drawing.Size(48, 20)
        Me.txtTM.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label6.Location = New System.Drawing.Point(422, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "First Label"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(496, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Down"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDown
        '
        Me.txtDown.Location = New System.Drawing.Point(544, 24)
        Me.txtDown.Name = "txtDown"
        Me.txtDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDown.Size = New System.Drawing.Size(48, 20)
        Me.txtDown.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(368, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Across"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAcross
        '
        Me.txtAcross.Location = New System.Drawing.Point(424, 24)
        Me.txtAcross.Name = "txtAcross"
        Me.txtAcross.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAcross.Size = New System.Drawing.Size(48, 20)
        Me.txtAcross.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(422, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(160, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Labels per Page"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"),System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(328, 216)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = false
        '
        'dlgPreview
        '
        Me.dlgPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.dlgPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.dlgPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.dlgPreview.Enabled = true
        Me.dlgPreview.Icon = CType(resources.GetObject("dlgPreview.Icon"),System.Drawing.Icon)
        Me.dlgPreview.Name = "dlgPreview"
        Me.dlgPreview.Visible = false
        '
        'dlgFont
        '
        Me.dlgFont.ShowEffects = false
        '
        'PrintPreviewDialog3
        '
        Me.PrintPreviewDialog3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog3.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog3.Enabled = true
        Me.PrintPreviewDialog3.Icon = CType(resources.GetObject("PrintPreviewDialog3.Icon"),System.Drawing.Icon)
        Me.PrintPreviewDialog3.Name = "PrintPreviewDialog3"
        Me.PrintPreviewDialog3.Visible = false
        '
        'frmLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 396)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmLabels"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Label Printing"
        Me.TabControl1.ResumeLayout(false)
        Me.tabPrintLabels.ResumeLayout(false)
        Me.tabPrintLabels.PerformLayout
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox3.ResumeLayout(false)
        CType(Me.udSkip,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabLabelSetup.ResumeLayout(false)
        Me.tabLabelSetup.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox1.ResumeLayout(false)
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtVertical As System.Windows.Forms.TextBox
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents btnTestPrint As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabLabelSetup As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtPad As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLayoutNames As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCent As System.Windows.Forms.RadioButton
    Friend WithEvents rbInch As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtGutter As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLM As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTM As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDown As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAcross As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tabPrintLabels As System.Windows.Forms.TabPage
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnPrinter As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFont As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbRight As System.Windows.Forms.RadioButton
    Friend WithEvents rbCentre As System.Windows.Forms.RadioButton
    Friend WithEvents rbLeft As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUseTagsDetails As System.Windows.Forms.Label
    Friend WithEvents lblUseTags As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents dlgPreview As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents dlgPrint As System.Windows.Forms.PrintDialog
    Friend WithEvents dlgFont As System.Windows.Forms.FontDialog
    Friend WithEvents PrintPreviewDialog3 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboGroups As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents udSkip As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
