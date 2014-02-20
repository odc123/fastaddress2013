
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq


Public Class frmLabels

    Private AddressSource As New AddressLayer
    Private CurrentLabelDimensions As LabelData
    Private CurrentFont As Font
    Private LabelSettingsChanged As Boolean
    Private lpOutline As New clsLabelPrint
    Private lpPrint As New clsLabelPrint
    Private FormLoading As Boolean          ' Flag to inhibit some events during form load

    Private Enum WhichGroup As Integer
        All
        Tag1
        Tag2
        Tag3
        Tag4
        NoEmail
    End Enum

    Dim SelectedGroup As WhichGroup = WhichGroup.All

    Private Sub frmLabels_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Save current settengs
        'If File.Exists(LabelDataLocation) Then
        '    File.Delete(LabelDataLocation)
        'End If
        dsLabels.WriteXml(LabelDataLocation, XmlWriteMode.WriteSchema)
        lpOutline.Dispose()
        lpPrint.Dispose()
    End Sub

    Friend Sub RefreshLabelSettingsList()
        lstLayoutNames.Items.Clear()
        With dsLabels.Tables("Dimensions")
            For i As Integer = 0 To .Rows.Count - 1
                lstLayoutNames.Items.Add(.Rows(i)("Description"))
            Next
        End With
        ' Read the Last used label index from the dataset and set the list accordingly
        lstLayoutNames.SelectedIndex = CInt(dsLabels.Tables("Settings").Rows(0)("LastUsed"))
    End Sub

    Private Sub frmLabels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormLoading = True
        lblUseTags.Text = "For a customised set of labels: "
        lblUseTagsDetails.Text = "- Return to the main page " & ControlChars.CrLf & _
                    "- In the admin menu select Clear All Tags" & ControlChars.CrLf & _
                    "- Set Tag on those for whom you want labels" & ControlChars.CrLf & _
                    "- Select 'Members with Tag set' above"
        Try
            dsLabels = New DataSet
            dsLabels.ReadXml(LabelDataLocation)
            dsLabels.AcceptChanges()
        Catch ' If the xml file does not exist create dsLabels with default values and save it as xml
            CreateDefaultSettingsFile()
        End Try
        ' Populate the list with the available label template names
        RefreshLabelSettingsList()
        ' Read the settings for the selected label into CurrentLabel

        ' Put the values into the text boxes

        ' Set text alignment to last used
        rbLeft.Checked = True
        Select Case dsLabels.Tables("Settings").Rows(0).Item(1).ToString
        Case "Centre" 
            rbCentre.Checked = True
        Case "Right" 
            rbRight.Checked = True
        End Select
        ' Set the font to last used
        Dim fRow As DataRow = dsLabels.Tables("Font").Rows(0)
        Dim FStyle As FontStyle = FontStyle.Regular
        If CBool(fRow("Bold")) = True And CBool(fRow("Italic")) = True Then
            FStyle = FontStyle.Bold Or FontStyle.Italic
        ElseIf CBool(fRow("Bold")) = True Then
            FStyle = FontStyle.Bold
        ElseIf (fRow("Italic")) = True Then
            FStyle = FontStyle.Italic
        End If
        CurrentFont = New Font(fRow("Name").ToString, CSng(fRow("Size")), FStyle)
        txtFont.Text = String.Format("{0} : {1} pt", CurrentFont.Name, CurrentFont.Size)
        ' Populate the groups combo on the second tab
        cboGroups.Items.Clear 
        Dim dvGroup As New DataView(AddressSource.Groups)
        Dim clGp As New clGroup(0, "All")
        cboGroups.Items.Add(clGp)
        For Each r As DataRowView In dvGroup
            clGp = New clGroup(r("GroupID"), r("Group"))
            cboGroups.Items.Add(clGp)
        Next
        cboGroups.SelectedIndex = 0 ' All records
        FormLoading = False
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub btnTestPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestPrint.Click
        ' Layout Frames of Labels and print
        lpOutline.CurrentLabel = CurrentLabelDimensions
        lpOutline.Print()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        frmSaveLabel.OldLabel = lstLayoutNames.SelectedItem
        frmSaveLabel.ShowDialog()
        ' On return refresh labels list
        RefreshLabelSettingsList()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click, btnDone.Click
        Me.Close()
    End Sub

    Private Sub LabelSettingChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtAcross.LostFocus, txtDown.LostFocus, txtGutter.LostFocus, txtLM.LostFocus, txtTM.LostFocus, txtVertical.LostFocus,
    txtWidth.LostFocus, txtHeight.LostFocus, txtPad.LostFocus
        ' Ignore changes during form load
        If Not FormLoading Then
            LabelSettingsChanged = True
            ' Set converter to convert entered dimensions to inches and x100
            Dim converter As Single
            If rbCent.Checked Then ' Centimeter selected
                converter = 100 / InToCm
            Else                    ' Inches selected
                converter = 100
            End If
            'CurrentLabelSettings = SetCurrentLabel(dsLabels.Tables("Dimensions").Rows(lstLayoutNames.SelectedIndex))
            With CurrentLabelDimensions
                .Name = lstLayoutNames.Text
                .NoAcross = CType(fixsetting(txtAcross.Text), Integer)
                If .NoAcross = 0 Then
                    MessageBox.Show("Number of Labels must be greater than zero", "Bad Setting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                .NoDown = CType(fixsetting(txtDown.Text), Integer)
                If .NoDown = 0 Then
                    MessageBox.Show("Number of Rows must be greater than zero", "Bad Setting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                .TM = CInt(CType(fixsetting(txtTM.Text), Single) * converter)
                .LM = CInt(CType(fixsetting(txtLM.Text), Single) * converter)
                .W = CInt(CType(fixsetting(txtWidth.Text), Single) * converter)
                .H = CInt(CType(fixsetting(txtHeight.Text), Single) * converter)
                .V = CInt(CType(fixsetting(txtVertical.Text), Single) * converter)
                .G = CInt(CType(fixsetting(txtGutter.Text), Single) * converter)
                .Pad = CInt(CType(fixsetting(txtPad.Text), Single) * converter)
            End With
        End If
    End Sub

    'Private Sub rbCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim s As String = sender.text
    '    Select Case s
    '        Case "All Members"
    '            SelectedGroup = WhichGroup.All
    '        Case "Records with Tag 1 set"
    '            SelectedGroup = WhichGroup.Tag1
    '        Case "Records with Tag 2 set"
    '            SelectedGroup = WhichGroup.Tag2
    '        Case "Records with Tag 3 set"
    '            SelectedGroup = WhichGroup.Tag3
    '        Case "Records with Tag 4 set"
    '            SelectedGroup = WhichGroup.Tag4
    '        Case "Records without Email"
    '            SelectedGroup = WhichGroup.NoEmail
    '    End Select
    'End Sub

    Private Sub UnitsChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCent.CheckedChanged, rbInch.CheckedChanged
        If Me.Visible Then ' Not during form load
            CurrentLabelDimensions = SetCurrentLabel(dsLabels.Tables("Dimensions").Rows(lstLayoutNames.SelectedIndex))
            FillFormLabelDimensions(CurrentLabelDimensions)
        End If
    End Sub

    Private Sub Alignment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLeft.CheckedChanged, rbCentre.CheckedChanged, rbRight.CheckedChanged
        If Me.Visible = True Then ' Dont execute if form is still loading
            If rbLeft.Checked = True Then
                dsLabels.Tables("Settings").Rows(0).Item(1) = "Left"
            ElseIf rbCentre.Checked = True Then
                dsLabels.Tables("Settings").Rows(0).Item(1) = "Centre"
            Else
                dsLabels.Tables("Settings").Rows(0).Item(1) = "Right"
            End If
        End If
    End Sub

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        dlgFont.Font = CurrentFont
        dlgFont.ShowDialog()
        CurrentFont = dlgFont.Font
        txtFont.Text = String.Format("{0} : {1} pt", CurrentFont.Name, CurrentFont.Size)
        With dsLabels.Tables("Font").Rows(0)
            .Item(0) = CurrentFont.Name
            .Item(1) = CurrentFont.Size
            .Item(2) = CurrentFont.Bold
            .Item(3) = CurrentFont.Italic
        End With
    End Sub

    Private Function SetCurrentLabel(ByVal ds As DataRow) As LabelData
        Dim LD As New LabelData
        With LD
            .Name = ds("Description")
            .NoDown = CInt(ds(1))
            .NoAcross = CInt(ds(2))
            .TM = CInt(ds(3))
            .LM = CInt(ds(4))
            .H = CInt(ds(5))
            .W = CInt(ds(6))
            .V = CInt(ds(7))
            .G = CInt(ds(8))
            .Pad = CInt(ds(9))
        End With
        Return LD
    End Function

    Private Sub lstLayoutNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLayoutNames.SelectedIndexChanged
        CurrentLabelDimensions = SetCurrentLabel(dsLabels.Tables("Dimensions").Rows(lstLayoutNames.SelectedIndex))
        FillFormLabelDimensions(CurrentLabelDimensions)
    End Sub

    Private Sub FillFormLabelDimensions(ByVal LD As LabelData)
        If Me.Visible = True Then
            Dim converter As Single
            If rbCent.Checked Then
                converter = InToCm / 100
            Else
                converter = 1 / 100
            End If
            CurrentLabelDimensions.Name = lstLayoutNames.Text
            With LD
                txtAcross.Text = .NoAcross.ToString
                txtDown.Text = .NoDown.ToString
                txtTM.Text = TwoPlaceString(.TM * converter)
                txtLM.Text = TwoPlaceString(.LM * converter)
                txtHeight.Text = TwoPlaceString(.H * converter)
                txtWidth.Text = TwoPlaceString(.W * converter)
                txtVertical.Text = TwoPlaceString(.V * converter)
                txtGutter.Text = TwoPlaceString(.G * converter)
                txtPad.Text = TwoPlaceString(.Pad * converter)
            End With
            LabelSettingsChanged = False
        End If
    End Sub

    Private Function TwoPlaceString(ByVal x As Single) As String
        Return Format(x, "Fixed")
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnPrint.Click, btnPreview.Click
        ' Build the Address Label Data in a DataTable
        Dim Contacts As DataTable = AddressSource.Contacts
        Dim Addresses As DataTable = AddressSource.Addresses
        Dim CustGroup As DataTable = AddressSource.Contact_Group
        Dim LabelsContent As DataTable = BuildEmptyLabelTable()
        ' Eliminate deleted rows from Contacts table and sort alphabetically
        Dim dvContacts As New DataView(Contacts)
        dvContacts.RowFilter = "Deleted = 0"
        dvContacts.Sort = "Surname, FirstName"
        ' Iterate through All Contacts 
        For Each cRow As DataRowView In dvContacts
            ' Is Contact in current group?
            Dim ContactInCurrentGroup As Boolean = False
            If cboGroups.SelectedItem.GroupID = 0 Then ' All Records
                ContactInCurrentGroup = True
            Else
                Dim dvCustGroup As New DataView(CustGroup)
                dvCustGroup.RowFilter = String.Format("ContactID = {0} and GroupID = {1}", cRow("ContactID"), cboGroups.SelectedItem.GroupID)
                If dvCustGroup.Count > 0 Then ContactInCurrentGroup = True
            End If
            ' If Contact is a member of the selected group add him to the LabelData table, lookup his address and add that to the table as well
            If ContactInCurrentGroup Then
                Dim lr As DataRow = LabelsContent.NewRow
                lr("Surname") = cRow("Surname")
                lr("FirstName") = cRow("FirstName")
                lr("Title") = cRow("Title")
                lr("ID") = cRow("ContactID").ToString.Padleft(3,"0")
                Dim dvAddress As New DataView(Addresses)
                If Not IsDBNull(cRow("AddressID")) then
                dvAddress.RowFilter = "AddressID = " & cRow("AddressID")
                    If dvAddress.Count > 0 then
                        lr("AddressLine1") = dvAddress(0)("AddressLine1")
                        lr("AddressLine2") = dvAddress(0)("AddressLine2")
                        lr("PostTown") = dvAddress(0)("Town")
                        lr("County") = dvAddress(0)("County")
                        lr("PostCode") = dvAddress(0)("PostCode")
                        lr("Country") = dvAddress(0)("Country")
                        LabelsContent.Rows.Add(lr)
                    Else ' Address not found - delete reference
                        cRow("AddressID") = DBNull.Value
                    End If
                End if
            End If
        Next
        If LabelsContent.Rows.Count = 0 Then
            MessageBox.Show("There are no current records in the selected category!", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        lpPrint.DataToPrint = LabelsContent
        lpPrint.CurrentLabel = CurrentLabelDimensions
        lpPrint.Font = CurrentFont
        lpPrint.Skip = udSkip.Value
        If rbLeft.Checked Then
            lpPrint.algLabel = StringAlignment.Near
        ElseIf rbCentre.Checked Then
            lpPrint.algLabel = StringAlignment.Center
        Else
            lpPrint.algLabel = StringAlignment.Far
        End If
        If sender.text = "&Print Labels" Then
            lpPrint.Print()
        ElseIf sender.text = "Pre&view Labels" Then
            dlgPreview.ClientSize=New Size(600,800)
            dlgPreview.Top = Me.Top
            dlgPreview.Left = Me.Left
            'dlgPreview.Width = Me.Width * 2
            'dlgPreview.Height = Me.Height * 2
            Dim ts As ToolStrip 
            Dim tsb As ToolStripButton 
            ts = dlgPreview.Controls(1)
            tsb = ts.Items(0)
            tsb.Visible=false
            dlgPreview.Document = lpPrint
            dlgPreview.ShowDialog()
        End If
    End Sub

    Private Sub btnPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrinter.Click, Button1.Click
        With dlgPrint
            .PrinterSettings = lpPrint.PrinterSettings
            .AllowSelection = False
            .AllowSomePages = False
            .ShowDialog()
            lpPrint.PrinterSettings = .PrinterSettings
            lpOutline.PrinterSettings = .PrinterSettings
        End With
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub CreateDefaultSettingsFile()
        Dim strType As System.Type = System.Type.GetType("System.String")
        Dim iType As System.Type = System.Type.GetType("System.Int32")
        Dim sType As System.Type = System.Type.GetType("System.Single")
        Dim bType As System.Type = System.Type.GetType("System.Boolean")
        Dim Dims As New DataTable("Dimensions")
        Dim col As New DataColumn("Description", strType)
        Dims.Columns.Add(col)
        col = Nothing
        col = New DataColumn("Rows", iType)
        Dims.Columns.Add(col)
        col = Nothing
        col = New DataColumn("Cols", iType)
        Dims.Columns.Add(col)
        col = Nothing
        col = New DataColumn("TM", sType)
        Dims.Columns.Add(col)
        col = Nothing
        col = New DataColumn("LM", sType)
        Dims.Columns.Add(col)
        col = Nothing
        col = New DataColumn("H", sType)
        Dims.Columns.Add(col)
        col = Nothing
        col = New DataColumn("W", sType)
        Dims.Columns.Add(col)
        col = Nothing
        col = New DataColumn("V", sType)
        Dims.Columns.Add(col)
        col = Nothing
        col = New DataColumn("G", sType)
        Dims.Columns.Add(col)
        col = Nothing
        col = New DataColumn("Pad", sType)
        Dims.Columns.Add(col)
        col = Nothing
        Dim r As DataRow = Dims.NewRow
        r("Description") = " - Default - "
        r("Rows") = 8
        r("Cols") = 3
        r("TM") = 60
        r("LM") = 25
        r("H") = 150
        r("W") = 250
        r("V") = 0
        r("G") = 10
        r("Pad") = 10
        Dims.Rows.Add(r)
        dsLabels.Tables.Add(Dims)
        ' LastUsed and Alignment
        Dim Stg As New DataTable("Settings")
        col = New DataColumn("LastUsed", iType)
        Stg.Columns.Add(col)
        col = Nothing
        col = New DataColumn("Alignment", strType)
        Stg.Columns.Add(col)
        col = Nothing
        Dim sr As DataRow = Stg.NewRow
        sr.Item(0) = 0
        sr.Item(1) = "Left"
        Stg.Rows.Add(sr)
        dsLabels.Tables.Add(Stg)
        ' Font
        Dim Fnt As New DataTable("Font")
        col = New DataColumn("Name", strType)
        Fnt.Columns.Add(col)
        col = Nothing
        col = New DataColumn("Size", sType)
        Fnt.Columns.Add(col)
        col = Nothing
        col = New DataColumn("Bold", bType)
        Fnt.Columns.Add(col)
        col = Nothing
        col = New DataColumn("Italic", bType)
        Fnt.Columns.Add(col)
        col = Nothing
        Dim fr As DataRow = Fnt.NewRow
        fr("Name") = "Arial"
        fr("Size") = 14.25
        fr("Bold") = False
        fr("Italic") = False
        Fnt.Rows.Add(fr)
        dsLabels.Tables.Add(Fnt)
        dsLabels.AcceptChanges()
        Try
            Dim labelPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\FastAddress2013"
            If Not Directory.Exists(labelPath) then
                Directory.CreateDirectory(labelPath)
            End If
        dsLabels.WriteXml(LabelDataLocation, XmlWriteMode.WriteSchema)
        Catch ex As Exception
            Stop
        End try
    End Sub

    Private Function BuildEmptyLabelTable() As DataTable
        Dim workTable As DataTable = AddressSource.Contacts.Clone
        workTable.TableName = "LabelData"
        workTable.Columns.Remove("AddressId")
        workTable.Columns.Remove("Updated")
        ' Add The Address columns
        workTable.Columns.Add("ID", Type.GetType("System.String"))
        workTable.Columns.Add("AddressLine1", Type.GetType("System.String"))
        workTable.Columns.Add("AddressLine2", Type.GetType("System.String"))
        workTable.Columns.Add("PostTown", Type.GetType("System.String"))
        workTable.Columns.Add("County", Type.GetType("System.String"))
        workTable.Columns.Add("PostCode", Type.GetType("System.String"))
        workTable.Columns.Add("Country", Type.GetType("System.String"))
        workTable.Columns.Add("GroupID", Type.GetType("System.Int32"))
        Return workTable
    End Function

    Private Function fixsetting(setting As String) As String
        If setting.Trim = String.Empty Then
            setting = "0"
        ElseIf Microsoft.VisualBasic.Left(setting, 1) = "." Then
            setting = "0" & setting
        End If
        Return setting
    End Function

End Class