
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Text

Public Class frmMain
    Private FillingTree As Boolean
    Private FillingForm As Boolean
    Friend GroupIndex As Integer = 0 ' Determines which tree view is used
    Private FirstNameFirst As Boolean = False
    Private RecordCount As Integer
    Private thisID As Integer ' ID of currently selected contact
    Private AddressSource As New AddressLayer

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Try
            ' Do data files exist? If not create the default data files (first use)
            'ToDo If no data use default
            If Not File.Exists(AddressDataLocation) Then
                AddressSource.CreateAddressBookDatabase()
            End If
            '    If Not Directory.Exists(DataPath) Then
            '        Directory.CreateDirectory(DataPath)
            '    End If
            '    File.Copy(Application.StartupPath & "\Data\AddressBook.xml", AddressDataLocation)
            'End If
            'If Not File.Exists(LabelDataLocation) Then
            '    If Not Directory.Exists(DataPath) Then
            '        Directory.CreateDirectory(DataPath)
            '    End If
            '    File.Copy(Application.StartupPath & "\Data\Labels.xml", LabelDataLocation)
            'End If
            'AddressData = AddressSource.GetMembers 
            'AddressData.ReadXml(AddressDataLocation) ' (Application.StartupPath & AddressDataLocation)
            'AddressData.AcceptChanges()
        Catch ex As Exception
            MessageBox.Show("Data File not found", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        InitializeViewMenuItems()
        FirstNameFirst = My.Settings.ViewByFirstName
        GroupIndex = My.Settings.ViewGroup
        FillTreeView()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' I fthere are unsaved remarks prompt for save
        If btnSaveRemarks.Enabled = True Then
            Dim reslt As DialogResult = MessageBox.Show("Remarks have unsaved chages. Do you want to save them now?", "Save Remarks?" _
                                                        , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case reslt
                Case DialogResult.Yes ' Save remarks
                    btnSaveRemarks_Click(sender, e)
                Case DialogResult.No ' Do nothing - just exit

                Case DialogResult.Cancel    ' Cancel the form close
                    e.Cancel = True
            End Select
        End If
    End Sub

    Friend Sub FillTreeView()
        ' If there are no records in the selected group this Sub exits half way through
        Dim Contacts = AddressSource.Contacts 
        Dim ContactGroup = AddressSource.Contact_Group
        Dim Groups = AddressSource.Groups 
        Dim dvContacts As New DataView(Contacts)
        Dim RecordCount As integer
        Try
            If FirstNameFirst Then
                dvContacts.Sort = "FirstName, Surname"
            Else
                dvContacts.Sort = "Surname, FirstName"
            End if 
                Select Case GroupIndex
                    Case 0   ' All records (except deleted)
                        dvContacts.RowFilter = "Deleted=False"
                    Case (-1) 'Deleted
                        dvContacts.RowFilter = "Deleted=True"
                    Case Else
                        Dim cgv As New DataView(ContactGroup)
                        If cgv.count > 0 then
                        cgv.Sort = "ContactID"
                        cgv.RowFilter = "GroupID = " & GroupIndex
                            If cgv.Count > 0 Then
                            ' Make a comma separated list of all the CUstomerIDs in that group
                                Dim s As New StringBuilder
                                For Each id As DataRowView In cgv
                                    s.Append(id("ContactID"))
                                    s.Append(",")
                                Next
                                s.Remove(s.Length - 1, 1)  ' Remove the last ','
                                ' Use the list in the rowfilter
                                dvContacts.RowFilter = "Deleted=False and ContactID IN ( " & s.ToString & ")"   ' and ParentID = Null 
                            End If 
                        Else
                            MessageBox.Show("There are currently no records in that Group", "Empty Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            ' Display All Records instead
                            GroupIndex = 0
                            dvContacts.RowFilter = "Deleted=False"
                        End If
                End Select
            RecordCount = dvContacts.Count
            If dvContacts.Count = 0 Then
                MessageBox.Show("There are currently no records in the selected Group", "Empty Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If GroupIndex = 0 then
                    tvMembers.Nodes.Clear 
                    FillingForm = False
                Else
                    GroupIndex = 0
                    dvContacts.RowFilter = "Deleted=False"
                    FillTreeView
                End If
                Exit Sub
            Else
                RecordCount = dvContacts.Count
                Dim FirstLetter As String
                Dim oldFirstLetter As String = ""
                FillingTree = True
                tvMembers.BeginUpdate()
                tvMembers.Nodes.Clear()
                For Each drv As DataRowView In dvContacts 'In qNames
                    'dtNames.Rows.Add(e.Surname, e.FirstName, e.ContactID)
                    Dim oneNode As New TreeNode
                    If FirstNameFirst  Then
                        oneNode.Text = String.Format("{0} {1}", drv("FirstName"), drv("Surname"))
                    Else
                        oneNode.Text = String.Format("{0}, {1}", drv("Surname"), drv("FirstName"))   ' e.Surname, e.FirstName)
                    End If

                    oneNode.Tag = drv("ContactID") 'e.ContactID
                    FirstLetter = oneNode.Text.Substring(0, 1).ToUpper
                    If FirstLetter <> oldFirstLetter Then
                        tvMembers.Nodes.Add(FirstLetter)
                        oldFirstLetter = FirstLetter
                    End If
                    tvMembers.Nodes(tvMembers.Nodes.Count - 1).Nodes.Add(oneNode)
                Next
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        ExpandActiveNode()
        ' Reset treeview refresh and cancel flag
        tvMembers.EndUpdate()
        ' Set status label to reflect the tree contents
        Dim GroupText(2) As String
        tsLabel.ForeColor = Color.Black
        Select Case GroupIndex
            Case -1
                GroupText(1) = "Deleted "
                GroupText(2) = ""
                tsLabel.ForeColor = Color.Red
            Case 0
                GroupText(1) = ""
                GroupText(2) = ""
            Case 1
                GroupText(1) = "Tagged "
                GroupText(2) = ""
            Case Else
                Dim qGroup = From cg In Groups.Rows Where cg("GroupID") = GroupIndex Select cg("Group")
                GroupText(1) = ""
                GroupText(2) = String.Format("in {0} Group", qGroup(0).Trim)
        End Select
        tsLabel.Text = String.Format("Tree contains all {0} {1}records {2}", RecordCount, GroupText(1), GroupText(2))
        FillingTree = False
    End Sub
    
    Private Sub ExpandActiveNode()
        If tvMembers.Nodes.Count > 0 Then
            If txtID.Text <> String.Empty Then
                For Each n As TreeNode In tvMembers.Nodes
                    For Each c As TreeNode In n.Nodes
                        If (Not IsDBNull(c.Tag)) andAlso c.Tag = txtID.Text Then
                            tvMembers.SelectedNode = c
                            c.Expand()
                        End If
                    Next
                Next
            Else
                tvMembers.Nodes(0).Expand()
                tvMembers.SelectedNode = tvMembers.Nodes(0).FirstNode
            End If
        End If
    End Sub

    Private Sub tvMembers_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMembers.AfterSelect 
        ' If previous selection has unsaved changes to remarks prompt to save
        If btnSaveRemarks.Enabled = True Then
            Dim reslt As DialogResult = MessageBox.Show("Remarks have unsaved chages. Do you want to save them now?", "Save Remarks?" _
                                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Select Case reslt
                Case DialogResult.Yes ' Save remarks
                    btnSaveRemarks_Click(sender, e)
                Case DialogResult.No ' Do nothing - just exit
            End Select
            btnSaveRemarks.Enabled = False
        End If

        ' Get the tables used in this Sub
        Dim Contacts = AddressSource.Contacts
        Dim Addresses = AddressSource.Addresses
        Dim CustGroup = AddressSource.Contact_Group
        Dim Groups = AddressSource.Groups

        ' Display details for selected person
        If Not e.Node.Parent Is Nothing Then
            FillDetails(e.Node.Tag)
        Else
            ClearDetails
            btnSaveRemarks.Enabled = False
        End If

    End Sub

    Private Sub mnuViewTagged_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewTagged.Click
        txtID.Text = String.Empty
        GroupIndex = sender.tag
        FillTreeView
    End Sub

    Private Sub mnuViewDeleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtID.Text = String.Empty
        GroupIndex = -1
        FillTreeView
    End Sub

    Private Sub mnuViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewAll.Click
        txtID.Text = String.Empty
        GroupIndex = 0
        FillTreeView
    End Sub

    Private Function BuildAddress(ByVal line As DataRowView) As String
        Dim sb As New System.Text.StringBuilder
        ' Populate Address Box
        Try
            If line("AddressLine1") & "" > "" And line("AddressLine2") & "" > "" Then         'House and Street
                sb.Append(line("AddressLine1") & ", " & line("AddressLine2"))
            ElseIf line("AddressLine1") & "" > "" Then
                sb.Append(line("AddressLine1"))
            ElseIf line("AddressLine2") & "" > "" Then
                sb.Append(line("AddressLine2"))
            End If
            If line("Town") & "" > "" Then                                'Town
                sb.Append(ControlChars.CrLf & line("Town"))
            End If
            If line("County") & "" > "" And line("PostCode") & "" > "" Then            'County and Postcode
                sb.Append(ControlChars.CrLf & line("County") & ", " & line("PostCode"))
            ElseIf line("County") & "" > "" Then
                sb.Append(ControlChars.CrLf & line("County"))
            ElseIf line("PostCode") & "" > "" Then
                sb.Append(ControlChars.CrLf & line("PostCode"))
            End If
            If line("Country") & "" > "" Then
                sb.Append(ControlChars.CrLf & line("Country"))
            End If
        Catch ex As Exception
            sb.Remove(0, sb.Length)
            sb.Append("Address Error")
        End Try
        Return (sb.ToString)

    End Function

    Private Sub chkTag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTag.CheckedChanged
        If Not FillingForm Then
            Dim CurrentID = Convert.ToInt32(txtID.Text)
            ' If checked update data to show tagged
            If sender.Checked = True then
            AddressSource.Tag(CurrentID)
            ' Else update data to show not tagged
            Else
            AddressSource.UnTag(CurrentID)
            End if

            'Dim CG As DataTable = AddressSource.Contact_Group
            'Dim CGview As DataView = CG.DefaultView

            'If chkTag.Checked = True Then
            '    Dim newrow As DataRowView = CGview.AddNew
            '    newrow("ContactID") = Convert.ToInt32(txtID.Text)
            '    newrow("GroupID") = 1
            '    newrow.EndEdit()
            'Else
            '    CGview.RowFilter = "ContactID = " & txtID.Text & " AND GroupID = 1"
            '    CGview.Delete(0)
            'End If
            ' ToDo Update the database
            'AddressData.AcceptChanges()
            'AddressData.WriteXml(AddressDataLocation, XmlWriteMode.WriteSchema)
        End If
    End Sub

    Private Sub mnuEditAddAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditAddAddress.Click, tsNew.Click
        ' New Contact
        frmDetails.txtID.Text = String.Empty
        frmDetails.lblName.Text = "Enter details then Save (or Cancel)"
        frmDetails.ShowDialog()
    End Sub

    Private Sub btnEditDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDetails.Click, EditSelectedRecordToolStripMenuItem.Click
        'Contact Details Edit
        Dim DetailsForm As New frmDetails
        DetailsForm.txtID.Text = txtID.Text
        DetailsForm.ShowDialog()
    End Sub

    Private Sub mnuEditDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditDelete.Click, tsDelete.Click
        ' If txtId is empty there is no record selected to delete
        If txtID.Text = String.Empty then
            MessageBox.Show("There is no record selected for deletion","No record selected",MessageBoxButtons.OK,MessageBoxIcon.Exclamation)
        Else
                ' Switch the Deleted fields to make records active or deleted
            Dim answer As DialogResult
            If mnuEditDelete.Tag = "Delete" Then ' Mark this record as deleted
                answer = MessageBox.Show("Are you sure you wish to Delete the currently selected person from your addresses?", _
                                "Delete Address", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                answer = MessageBox.Show("Are you sure you wish to Undelete the currently selected record?", _
                                "Undelete Address", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
            If answer = DialogResult.Yes Then
                AddressSource.MarkAsDeleted(Cint(txtID.text))
                'Dim dvCustomer As New DataView(AddressSource.Contacts)
                'dvCustomer.RowFilter = "ContactID=" & txtID.Text
                If mnuEditDelete.Tag = "Delete" Then
                    AddressSource.MarkAsDeleted(Cint(txtID.text))
                '    dvCustomer(0)("Deleted") = True
                '    ' Delete all associated groups (including Tagged)
                '    Dim CG As DataTable = AddressSource.Contact_Group
                '    Dim CGview As DataView = CG.DefaultView
                '    CGview.RowFilter = "ContactID=" & txtID.Text
                '    Do While CGview.Count > 0
                '        CGview(0).Delete 
                '    Loop
                Else
                '    dvCustomer(0)("Deleted") = False
                    AddressSource.UnDelete(Cint(txtID.text))
                End If
                txtID.Text = String.Empty
                FillTreeView
            End If
        End If
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        ' Change allocated groups 
        frmGroups.ShowDialog()
        ' Refresh on Completion
        FillDetails(Convert.ToInt32(txtID.text))
        ExpandActiveNode 
    End Sub

    Friend Sub InitializeViewMenuItems()
        ' Populate the View menu from the strings in the Groups array
        mnuView.DropDownItems.Clear

        Dim TSMI As ToolStripMenuItem 
        TSMI = New ToolStripMenuItem("View by &First Name")
        TSMI.Checked = My.Settings.ViewByFirstName
        TSMI.CheckOnClick=True
        TSMI.Tag = String.Empty
        TSMI.Name = "mnuViewByFirstName"
        AddHandler TSMI.Click, New System.EventHandler(AddressOf mnuViewByFirstName_Click)
        mnuView.DropDownItems.Add(TSMI)

        Dim Seperator As New System.Windows.Forms.ToolStripSeparator
        With Seperator
            mnuView.DropDownItems.Add(Seperator)
        End With        

        TSMI = New ToolStripMenuItem("&All Records")
        TSMI.Tag = 0
        AddHandler TSMI.Click, New System.EventHandler(AddressOf mnuViewAll_Click)
        mnuView.DropDownItems.Add(TSMI)

        TSMI = New ToolStripMenuItem("&Tagged Records")
        TSMI.Tag = 1
        AddHandler TSMI.Click, New System.EventHandler(AddressOf mnuViewTagged_Click)
        mnuView.DropDownItems.Add(TSMI)

        Dim Groups As DataTable = AddressSource.Groups
        If Not IsNothing(Groups) then
        Dim i As Integer = 1
        For Each dr As DataRow In Groups.Rows
            If dr("GroupID") > 1 Then ' 1 = Tagged - above
                Dim TMI As New System.Windows.Forms.ToolStripMenuItem
                With TMI
                    .Tag = dr("GroupID")
                    .Name = "ViewToolStripMenuItem" & i.ToString
                    .Size = New System.Drawing.Size(152, 22)
                    .Text = dr("Group")
                    AddHandler .Click, AddressOf ViewMenuItem_Click
                    mnuView.DropDownItems.Add(TMI)
                    i += 1
                End With
            End If
        Next
        End If
        Seperator = New System.Windows.Forms.ToolStripSeparator
        With Seperator
            mnuView.DropDownItems.Add(Seperator)
        End With   

        Dim DeletedToolStripMenuItem As New System.Windows.Forms.ToolStripMenuItem
        With DeletedToolStripMenuItem
            .Tag = -1
            .Name = "mnuViewDeleted"
            .Size = New System.Drawing.Size(152, 22)
            .Text = "&Deleted"
            AddHandler .Click, New System.EventHandler(AddressOf mnuViewDeleted_Click)
            mnuView.DropDownItems.Add(DeletedToolStripMenuItem)
        End With
    End Sub

    Private Sub ViewMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dvGroups As New DataView(AddressSource.Groups)
        dvGroups.RowFilter = "Group = '" & sender.ToString.Trim & "'"

        GroupIndex = dvGroups(0)("GroupID")
        FillTreeView
        If tvMembers.Nodes.Count > 1 Then
            Dim n As TreeNode = tvMembers.Nodes(0)
            n.Expand()
            tvMembers.SelectedNode = n.NextVisibleNode 'Click the first in the tree
        End If

    End Sub

    Private Sub PrintLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            
        ' Label Printing
        frmLabels.ShowDialog()
    End Sub

    Private Sub btnSaveRemarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRemarks.Click
        '' Save remarks to Remarks table
        ' First delete any existing remark for this person
        AddressSource.DeleteRemark(txtID.text)
        If txtRemarks.Text.Length > 0 then
            AddressSource.InsertRemark(txtRemarks.Text, txtID.text)
        End If
        btnSaveRemarks.Enabled = False
    End Sub

    Private Sub BackupAddressesOrSettings(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles mnuFileBackupAddresses.Click, mnuFileBackupSettings.Click, tsAddressBU.Click, tsLabelBU.Click 
        Dim Source As String 
        Dim Abbrev As String
        Dim FileFilter As string = String.empty
        Select Case sender.Name
            Case "mnuFileBackupAddresses", "tsAddressBU"
                Source = AddressDataLocation 
                Abbrev = "AddressBU_"
                FileFilter = "sdf files (*.sdf)|*.sdf|All files (*.*)|*.*"
            Case "mnuFileBackupSettings","tsLabelBU"
                Source = LabelDataLocation
                Abbrev = "LabelBU_"
                FileFilter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        End Select
        ' Save a copy of the data/settings file
        Dim destinationDirectory As String = DataPath  & "\Backup"
        If Not Directory.Exists(destinationDirectory) Then
            Directory.CreateDirectory(destinationDirectory)
        End If
        'Dim activeFile As String = Application.StartupPath & "\Data\" & Source
        Dim DateString As String = Format(Today, "yyy_MM_dd")
        ' Use file save dialog to prompt for a save location (default to Backup folder)
        With dlgFileSave
            .InitialDirectory = destinationDirectory
            .Filter = FileFilter
            .FileName = Abbrev & DateString
            Dim rslt As DialogResult = .ShowDialog()
            If rslt = DialogResult.OK Then
                ' If file exists already delete it
                If File.Exists(.FileName) Then
                    File.Delete(.FileName)
                End If
                ' Copy the file to the backup location
                File.Copy(Source, .FileName)
            End If
        End With
    End Sub

    Private Sub mnuFilePrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        ' ToDo Address List Printing
    End Sub

    Private Sub RestoreBackup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles mnuFileRestoreAddresses.Click,  mnuFileRestoreSettings.Click, RestoreLabelSettingsToolStripMenuItem.Click, tsRestoreAddress.Click, tsRestoreLabel.Click
        ' Recover a saved backup of the data file
        Dim Source As String = "AddressBook.xml"
        Dim Abbrev As String = "AddBU_"
        Dim Filter As String = String.Empty 
        Dim IsAddressBU As Boolean
        Dim ActiveFile As string
        Dim buDirectory As string
        Select Case sender.Name
            Case "mnuFileRestoreAddresses", "RestoreContactsToolStripMenuItem"
                Source = AddressDataLocation
                Abbrev = "AddressBU_"
                Filter = "sdf files (*.sdf)|*.sdf|All files (*.*)|*.*"
                IsAddressBU = True
            Case "mnuFileRestoreSettings", "RestoreLabelSettingsToolStripMenuItem"
                Source = "Labels.xml"
                Abbrev = "LabelBU_"
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
                IsAddressBU = False
        End Select
        activeFile = DataPath & "\AddressBook.sdf"
        buDirectory = Datapath & "\Backup\"
        ' First ask if the user wants to keep a copy of the current data
        Dim msgString As String = String.Format("Do you want to save the current {0} file before restoring the backup", Source)
        Dim result As DialogResult = MessageBox.Show(msgString, "Save First?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        ' If so back it up to Backup folder with a datatime stamp
        If result = DialogResult.Yes Then
            Dim FileName As String = buDirectory & Abbrev & Format(Today, "yyy_MM_dd") & ".xml"
            If File.Exists(FileName) Then
                File.Delete(FileName)
            End If
            File.Copy(activeFile, FileName)
        End If
        ' Now use file open dialog to point to the backup
        Dim GoodFile As Boolean = False
        With dlgFileOpen
            .InitialDirectory = buDirectory
            .Filter = Filter
            Dim rslt As DialogResult = .ShowDialog()
            If rslt = DialogResult.OK Then
                ' Test to be sure its the right type (Data or Settings)
                Dim strContents As String = GetFileContents(dlgFileOpen.FileName)
                If strContents = "Error" Then
                    GoodFile = False
                Else
                    If IsAddressBU Then
                        ' Address Data File will always contain "<xs:element name="Addresses">"
                        If dlgFileOpen.FileName.EndsWith(".sdf") Then
                            GoodFile = True
                        Else
                            MessageBox.Show("That is not a good Address backup file.", "Wrong File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        ' Settings file will always contain "<Dimensions>"
                        If strContents.Contains("<Dimensions>") Then
                            GoodFile = True
                        Else
                            MessageBox.Show("That is not a good Label Settings backup file.", "Wrong File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                If GoodFile Then
                    ' Copy the backup to the working directory
                    If File.Exists(activeFile) Then
                        File.Delete(activeFile)
                    End If
                    File.Copy(.FileName, AddressDataLocation)
                End If
            End If
        End With
        ' If data has changes clear the in memory dataset and start again
        If IsAddressBU And GoodFile Then
            'AddressData.Clear()
            frmMain_Load(sender, e)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub mnuToolsInvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsInvert.Click
        ' Invert Tags (GroupID for tag is 1)
        AddressSource.InvertTags
        FillDetails (Convert.ToInt32(txtID.text))
    End Sub

    Private Sub mnuToolsPurge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsPurge.Click
        ' Call Purge form
        frmPurge.ShowDialog()
    End Sub

    Private Sub mnuToolsGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsGroups.Click
        ' Call Group Names form (Manage groups)
        frmGroupNames.ShowDialog()
    End Sub

    Private Sub mnuToolsSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        ' Go to label setting tab of labels form
        frmLabels.TabControl1.SelectedIndex = 1
        frmLabels.StartPosition = FormStartPosition.CenterParent 
        frmLabels.ShowDialog 
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub mnuEditCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditCopy.Click, CopyToolStripButton.Click
        ' Copy address to clipboard
        If txtAddress.Text <> String.Empty then
            Clipboard.SetText(txtAddress.Text)
        Else
            MessageBox.Show("Please Select a contact before copying the address")
        End If

    End Sub

    Private Sub txtRemarks_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged
        If Not FillingForm Then
            btnSaveRemarks.Enabled = True
        End If
    End Sub

    Public Function GetFileContents(ByVal FullPath As String) As String
        Dim strContents As String
        Dim objReader As StreamReader
        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            Return "Error"
        End Try
    End Function

    Private Sub mnuViewByFirstName_Click( sender As System.Object,  e As System.EventArgs)
        mnuViewByFirstName.Checked = Not mnuViewByFirstName.Checked
        FirstNameFirst= Not FirstNameFirst 
        FillTreeView    '(TagIndex)        
    End Sub

    Private Sub FillDetails(currentContactId As Integer)
    ' Get the tables used in this Sub
    Dim Contacts = AddressSource.Contacts
    Dim Addresses = AddressSource.Addresses
    Dim CustGroup = AddressSource.Contact_Group
    Dim Groups = AddressSource.Groups
    Dim dvContacts As DataView = Contacts.DefaultView 
    dvContacts.Rowfilter = String.Format("ContactID = {0}", currentContactId)
    Dim addressID As Integer
    If IsDBNull(dvContacts(0).Item("AddressID")) then
        addressID = 0
    Else
        addressID = dvContacts(0).Item("AddressID")
    End If
    Dim dvAddresses As DataView = Addresses.DefaultView 
    dvAddresses.Rowfilter = String.Format("AddressID = {0}", addressID)

    FillingForm = True ' Flag to prevent change events
    Try
        If dvcontacts.Count > 0 Then
            Dim line As datarowview = dvContacts(0)
            ' If deleted change menu to Undelete
            If line("Deleted") = True Then
                mnuEditDelete.Text = "Un&delete this Record"
                mnuEditDelete.Tag = "Undelete"
            Else
                mnuEditDelete.Text = "&Delete this Record"
                mnuEditDelete.Tag = "Delete"
            End If
            ' Set main name caption
            lblName.Text = line("FirstName") & " " & line("Surname")
                ' Fill address box
            Dim sb As New StringBuilder       
            If line("Title") & "" > "" Then ' Title
                sb.Append(line("Title") & " " & line("Surname").Trim & ControlChars.CrLf)           ' Title and Last Name
            Else
                sb.Append(line("FirstName").Trim & " " & line("Surname").Trim & ControlChars.CrLf)   ' First and Last Name
            End If
            Dim PhoneAndEmail As String = String.empty
            If dvAddresses.Count>0 then
                sb.Append(BuildAddress(dvAddresses(0)))
                PhoneAndEmail = dvAddresses(0)("Telephone") & ControlChars.CrLf & dvAddresses(0)("Mobile")
                PhoneAndEmail &= ControlChars.CrLf & dvAddresses(0)("Email")
            End If
            txtAddress.Text = sb.ToString 
            txtPhone.Text = PhoneAndEmail 
            'Dates
            If IsDate(line("Updated")) Then
                txtUpdated.Text = Format(line("Updated"), "Short Date")
            Else
                txtUpdated.Text = String.Empty
            End If
            ' Member ID (Invisible textbox)
            txtID.Text = currentContactId
            ' Populate Tag and Group membership list
            Dim Tagged As Boolean = False
            lstGroups.Items.Clear()
            If CustGroup IsNot Nothing Then
                Dim dvCustGroup As New DataView(CustGroup)
                dvCustGroup.RowFilter = "ContactID = " & currentContactId
                If dvCustGroup.Count > 0 Then
                    Dim dvGroups As New DataView(Groups)
                    If dvGroups.Count > 0 Then
                        For Each r As DataRowView In dvCustGroup
                            If r("ContactID") = currentContactId Then
                                If r("GroupID") = 1 Then
                                    Tagged = True
                                Else
                                    dvGroups.RowFilter = "GroupID = " & r("GroupID")
                                    lstGroups.Items.Add(New clGroup(r("GroupID"), dvGroups(0)("Group")))
                                End If
                            End If
                        Next
                    End If
                End If
            End If
            chkTag.Checked = Tagged

            ' Populate remarks
            Dim tblRemarks As DataTable = AddressSource.Remarks
            Dim dvRemarks As DataView = tblRemarks.DefaultView
            dvRemarks.RowFilter = "ContactID = " & txtID.Text
            If dvRemarks.Count > 0 Then
                txtRemarks.Text = dvRemarks(0)("Remark")
            Else
                txtRemarks.Text = String.Empty
            End If
        End If
    Catch ex As Exception
        MsgBox(ex.ToString)
    End Try

    FillingForm = False ' Re-enable checkbox events
 End Sub 

    Private Sub ClearDetails()
        For Each ctl As Control In me.Controls 
            If TypeOf(ctl) is TextBox
                    ctl.Text = String.Empty 
            End If
            lstGroups.Items.Clear
            lblName.Text = "Select a Contact in the tree"
        Next
     End Sub 

    Private Sub mnuFilePrint_Click( sender As System.Object,  e As System.EventArgs) Handles mnuFilePrint.Click, tsPrint.Click, mnuPrintLabels.Click
        frmLabels.ShowDialog()
    End Sub

    Private Sub ImportToolStripMenuItem_Click( sender As System.Object,  e As System.EventArgs) Handles ImportToolStripMenuItem.Click
            frmImport.ShowDialog 
    End Sub

    Private Sub ContentsToolStripMenuItem_Click( sender As System.Object,  e As System.EventArgs) Handles ContentsToolStripMenuItem.Click, HelpToolStripButton.Click 
            ' ToDo Help
            frmHelp.showdialog
    End Sub

    Private Sub RemoveAllTagsToolStripMenuItem_Click(sender As System.Object,  e As System.EventArgs) Handles RemoveAllTagsToolStripMenuItem.Click
            ' Remove All Tags
            AddressSource.RemoveTags
            ' Refresh the view
            Filltreeview
    End Sub

End Class
