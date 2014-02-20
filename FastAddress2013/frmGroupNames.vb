Public Class frmGroupNames

    Dim Groups As DataTable
    Dim ChangesMade As Boolean
    Private AddressSource As New AddressLayer

    Private Sub frmGroupNames_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Fill Availble list with all available groups
        FillList(0)
        txtNew.Text = String.Empty 
        btnChange.Enabled = False 
        btnNew.Enabled=False
    End Sub

    Private Sub lstAvailable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAvailable.SelectedIndexChanged
        txtChange.Text = lstAvailable.SelectedItem.ToString
    End Sub

    Private Sub FillList(ByVal selectItem As Integer)
        lstAvailable.Items.Clear()
        Groups = AddressSource.Groups
        Dim dv As new DataView(Groups,String.Empty,String.empty,DataViewRowState.CurrentRows)
        For Each gRow As DataRowView In dv
            If gRow("GroupID") <> 1 Then ' Dont include Tagged
                Dim cl As New clGroup(gRow("GroupID"), gRow("Group"))
                lstAvailable.Items.Add(cl)
            End If
        Next
        If dv.Count > 1 then
            lstAvailable .SelectedIndex = selectItem
        End If 
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close 
    End Sub

    Private Sub btnNew_Click( sender As System.Object,  e As System.EventArgs) Handles btnNew.Click
        AddressSource.NewGroup(txtNew.Text)
        FillList(0)
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click 
        Dim SelectedGroupID As integer = lstAvailable.SelectedItem.GroupID
        AddressSource.Changegroup(txtChange.Text, SelectedGroupID)
        FillList(0)
    End Sub

    Private Sub btnDelete_Click( sender As System.Object,  e As System.EventArgs) handles btnDelete.Click
        Dim SelectedGroupID As integer = lstAvailable.SelectedItem.GroupID
        AddressSource.DeleteGroup(SelectedGroupID)
        FillList(0)
    End Sub

    Private Sub txtChange_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtChange.KeyDown 
        btnChange.enabled=true
    End Sub

    Private Sub txtNew_TextChanged( sender As System.Object,  e As System.EventArgs) Handles txtNew.TextChanged 
        btnNew.Enabled = True 
    End Sub

End Class