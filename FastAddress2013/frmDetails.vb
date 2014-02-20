Imports System.Linq

Public Class frmDetails
    Private FillingForm As Boolean = True        ' True while form is being filled programmatically
    Private ChangesMade As Boolean = False      ' True when data is changed but not yet saved
    Private NameChanged As Boolean = False      ' True when name data has been changed
    Private AddressChanged As Boolean = False   ' True when address data has been changed
    Private AddressSource As New AddressLayer

    Private Enum AddOrEdit
        Add
        Edit
    End Enum
    Private IsEdit As AddOrEdit

    Private Sub frmDetails_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ChangesMade Then ' There are unsaved changes
            Dim whatNext As DialogResult = MessageBox.Show("You have made changes that are not saved. Do you want to exit without saving?", _
                                                           "Changes Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If whatNext = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If txtID.Text = String.Empty Then  ' New address
            IsEdit = AddOrEdit.Add
            ' Empty all form fields
            FillingForm = True
            For Each c As Control In Me.Controls
                If TypeOf c Is TextBox Then
                    c.Text = String.Empty
                End If
            Next
            FillingForm = False
        Else 'Edit existing details
            IsEdit = AddOrEdit.Edit
            FillMemberDetails(Convert.ToInt32(txtID.Text))
        End If
        FillingForm = False
    End Sub

    Private Sub FillMemberDetails(ByVal thisID As Integer)
        ' Get the tables used in this Sub
        Dim Contacts = AddressSource.Contacts
        Dim Addresses = AddressSource.Addresses
        Dim CustGroup = AddressSource.Contact_Group
        Dim Groups = AddressSource.Groups
        ' Display details for selected person
        Dim dvContact as New DataView(Contacts)
        dvContact.RowFilter = "ContactID = " & thisID
        Dim dvAddress As New DataView(Addresses)
        Dim addressID As string = 0
        If Not IsDBNull(dvContact(0)("AddressID")) then
            addressID = dvContact(0)("AddressID")
        End If
        dvAddress.RowFilter = "AddressID = " & AddressID
        Try
            FillingForm = True ' Flag to prevent checkbox events
            If dvContact.Count > 0 Then
                Dim Contact As DataRowView = dvContact(0)
                txtTitle.Text = Contact("Title") & ""
                txtFirst.Text = Contact("FirstName") & ""
                txtLast.Text = Contact("Surname")
                If dvAddress.Count > 0 then
                    Dim Address As DataRowView = dvAddress(0)
                    txtAddressLine1.Text = Address("AddressLine1") & ""
                    txtStreet.Text = Address("AddressLine2") & ""
                    txtTown.Text = Address("Town") & ""
                    txtCounty.Text = Address("County") & ""
                    txtPostCode.Text = Address("PostCode") & ""
                    txtCountry.Text = Address("Country") & ""
                    txtTelephone.Text = Address("Telephone") & ""
                    txtMobile.Text = Address("Mobile") & ""
                    txtEmail.Text = Address("Email") & ""
                End If 
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            FillingForm = False ' Re-enable checkbox events
            ChangesMade = False
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not AllValid() Then
            MessageBox.Show("Please rectify Red entries before saving!", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf txtLast.Text = String.Empty Then
            MessageBox.Show("You must provide a Surname in the Green box!", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            ' Validation OK proceed with save
            Dim Contacts = AddressSource.Contacts
            Dim Addresses = AddressSource.Addresses
            Dim contID As Integer 
            If IsEdit = AddOrEdit.Edit Then
                ' Find Associated AddressID
                Dim dvCont as New DataView(Contacts)
                Dim AddressID As Integer = 0
                Dim newAddrID as integer = 0
                dvCont.RowFilter = "ContactID = " & CInt(txtID.text)
                If Not IsDBNull(dvCont(0)("AddressID"))
                    AddressID  = dvCont(0)("AddressID")
                End If
                ' If address data has been changed Update it
                If AddressChanged and AddressID > 0 Then
                    ' If there was old address data and it has changed then save it
                    AddressSource.UpdateAddress(txtAddressLine1.Text.Trim, txtStreet.Text.Trim, txtTown.Text.Trim, txtCounty.Text.Trim, _
                                                txtPostCode.Text.Trim, txtCountry.Text.Trim, txtTelephone.Text.Trim,txtMobile.Text.Trim, txtEmail.Text.Trim, AddressID)
                Else
                    ' If there wasn't any previous address data, but there is now add new
                    If AddressChanged And AddressID = 0 then ' there was no associated addess data - insert the new address
                        newAddrID = AddressSource.InsertAddress(txtAddressLine1.Text.Trim, txtStreet.Text.Trim, txtTown.Text.Trim, txtCounty.Text.Trim, _
                                                txtPostCode.Text.Trim, txtCountry.Text.Trim, txtTelephone.Text.Trim,txtMobile.Text.Trim, txtEmail.Text.Trim)
                    End If
                End If
                ' If we have a new address we need to save it's ID (even if Contact details have not changed)
                If newAddrID > 0 then
                    AddressSource.UpdateContact(txtTitle.Text.Trim, txtFirst.Text.Trim, txtLast.Text.Trim, newAddrID, CInt(txtID.text))
                ElseIf NameChanged then 'Contact Details have changed, but not Address
                    AddressSource.UpdateContact(txtTitle.Text.Trim, txtFirst.Text.Trim, txtLast.Text.Trim, CInt(txtID.text))
                End If

            Else ' Add new Contact and (if present) address
                Dim AddrID As integer = 0
                If AddressChanged  Then
                    ' There is address data, save it
                    AddrID = AddressSource.InsertAddress(txtAddressLine1.Text.Trim, txtStreet.Text.Trim, txtTown.Text.Trim, txtCounty.Text.Trim, _
                                            txtPostCode.Text.Trim, txtCountry.Text.Trim, txtTelephone.Text.Trim,txtMobile.Text.Trim, txtEmail.Text.Trim)
                    ' Now save the contact with the address ID
                contID = AddressSource.newContact(txtTitle.Text.Trim, txtFirst.Text.Trim,txtLast.Text.trim, AddrID)
                Else
                    ' Save contact with Null addressID (null)
                    contID = AddressSource.newContact(txtTitle.Text.Trim, txtFirst.Text.Trim,txtLast.Text.trim)
                End If
                txtID.Text = contID
            End If                                      
            ChangesMade = False
            ' Set Updated field to current date
            AddressSource.SetChangedDate(CInt(txtID.Text))
            frmMain.FillTreeView
            Me.Close()
        End If
    End Sub

    Private Function MandatoryFilled() As Boolean
        Dim MF As Boolean = True
        If txtFirst.Text.Length = 0 Then MF = False
        'If txtLast.Text.Length = 0 Then MF = False
        'If txtStreet.Text.Length = 0 Then MF = False
        'If txtTown.Text.Length = 0 Then MF = False
        'If txtCounty.Text.Length = 0 Then MF = False
        'If txtPostCode.Text.Length = 0 Then MF = False
        'If txtTelephone.Text.Length = 0 Then MF = False
        Return MF
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub anyTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitle.TextChanged, txtFirst.TextChanged, _
        txtLast.TextChanged
        ' Handles all textbox changes
        If Not FillingForm Then
            ChangesMade = True
            NameChanged = True
            lblWarn.Text = "Error: Entries highlighted in red are too long!"
            If Not FillingForm Then
                ' Validate change/entry against database field requirements
                Dim tx As TextBox = sender
                If AllValid then
                    lblWarn.Visible = False
                End If 
                Select Case tx.Name
                    Case "txtFirst", "txtLast"
                        If tx.Text.Length < 26 Then
                            tx.ForeColor = Color.Black
                        Else
                            tx.ForeColor = Color.Red
                            lblWarn.Visible = True
                        End If
                    Case "txtTitle"
                        If tx.Text.Length < 11 Then
                            tx.ForeColor = Color.Black
                        Else
                            tx.ForeColor = Color.Red
                            lblWarn.Visible = True
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub AddressTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddressLine1.TextChanged, _
         txtStreet.TextChanged, txtTown.TextChanged, txtCounty.TextChanged, txtPostCode.TextChanged, _
        txtCountry.TextChanged, txtTelephone.TextChanged, txtMobile.TextChanged, txtEmail.TextChanged
        ' Handles all textbox changes
        If Not FillingForm Then
            ChangesMade = True
            AddressChanged=True
            lblWarn.Text = "Error: Entries highlighted in red are too long!"
            If Not FillingForm Then
                ' Validate change/entry against database field requirements
                Dim tx As TextBox = sender
                If AllValid then
                    lblWarn.Visible = False
                End If 
                Select Case tx.Name
                    Case "txtAddressline1", "txtStreet", "txtTown"
                        If tx.Text.Length < 30 Then
                            tx.ForeColor = Color.Black
                        Else
                            tx.ForeColor = Color.Red
                            lblWarn.Visible = True
                        End If
                        AddressChanged = True
                    Case "txtCounty", "txtPostCode", "txtCountry", "txtTelephone", "txtMobile"
                        If tx.Text.Length < 20 Then
                            tx.ForeColor = Color.Black
                        Else
                            tx.ForeColor = Color.Red
                            lblWarn.Visible = True
                        End If
                        AddressChanged = True
                    Case "txtEmail"
                        If tx.Text.Length < 40 Then
                            tx.ForeColor = Color.Black
                        Else
                            tx.ForeColor = Color.Red
                            lblWarn.Visible = True
                        End If
                        AddressChanged = True
                End Select
            End If
        End If
    End Sub

    Private Function AllValid() As Boolean
        Dim AV As Boolean = True
        For Each c As Control In Me.Controls
            If TypeOf (c) Is TextBox Then
                If c.ForeColor.ToArgb = Color.Red.ToArgb Then
                    AV = False
                End If
            End If
        Next
        For Each c As Control In Me.gbAddress.Controls
            If TypeOf (c) Is TextBox Then
                If c.ForeColor.ToArgb = Color.Red.ToArgb Then
                    AV = False
                End If
            End If
        Next
        Return AV
    End Function

End Class