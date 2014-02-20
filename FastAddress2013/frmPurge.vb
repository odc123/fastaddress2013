Public Class frmPurge

    Dim SelectedDate As Date
    Dim InvokePurge As Boolean = False
    Private AddressSource As New AddressLayer

    Private Sub PurgeCalendar_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles PurgeCalendar.DateChanged
        SelectedDate = e.Start
    End Sub

    Private Sub btnPurge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurge.Click
        InvokePurge = True 
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmPurge_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If InvokePurge Then
            ' Purge entries flagged as deleted 
            ' Get Contacts with deleted set and deleted date before chosen date

            Dim dvContacts As DataView = AddressSource.Contacts.DefaultView
            Dim dvAddresses As DataView = AddressSource.Addresses.DefaultView
            Dim dvContact_Group As DataView = AddressSource.Contact_Group.DefaultView
            dvContacts.RowFilter = String.Format("Deleted = True and Updated < '{0}'", SelectedDate.ToString)
            For Each r As DataRowView In dvContacts
                Dim cID As Integer = r("ContactID")
                Dim aID As Integer 
                If Not IsDBNull(r("AddressID"))
                    aID = r("AddressID")              
                    ' Delete associated Addresses
                    AddressSource.DeleteAddress(aID)                    
                End If
                ' Delete associated group links
                AddressSource.DeleteGroupLinks(cID)
                ' Delete Contact
                AddressSource.DeleteContact(cID)
            Next
        End If
    End Sub

    Private Sub frmPurge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelectedDate = Today
    End Sub
End Class