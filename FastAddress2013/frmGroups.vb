Public Class frmGroups

    Private ChangesMade As Boolean
    Private Source As ListBox       ' Used to hold the source of drag and drop
    Private id As Integer
    Private AddressSource As New AddressLayer

    Private Sub frmGroups_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmMain.txtID.Text = "" Then
            MessageBox.Show("Please select someone before trying to allocate groups!", "Nobody Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        Else
            id = Convert.ToInt32(frmMain.txtID.Text)
            Dim AllGroups As New Dictionary(Of Integer, String)
            ' Fill Availble list with all available groups
            Dim Groups As DataTable = AddressSource.Groups
            lstAvailable.Items.Clear()
            For Each gRow As DataRow In Groups.Rows
                If gRow("GroupID") <> 1 Then ' Dont include Tagged
                    AllGroups.Add(gRow("GroupID"), gRow("Group"))
                    Dim cl As New clGroup(gRow("GroupID"), gRow("Group"))
                    lstAvailable.Items.Add(cl)
                End If
            Next
            'Fill allocated list with currently allocated groups
            'removing them from available list
            Dim dvContactGroup As New DataView(AddressSource.Contact_Group)
            dvContactGroup.RowFilter = "ContactID = " & id
            lstAllocated.Items.Clear()
            For Each gRow As DataRowView In dvContactGroup
                Dim gID As Integer = gRow("GroupID")
                If gID <> 1 Then ' Dont include Tagged
                    Dim cl As New clGroup(gRow("GroupID"), AllGroups(gRow("GroupID")))
                    lstAllocated.Items.Add(cl)
                    'For Each l As clGroup In lstAvailable.Items
                    '    If l.GroupID = gRow("GroupID") Then
                    '        lstAvailable.Items.Remove(l)
                    '    End If
                    'Next
                    Dim idx As Integer = lstAvailable.FindString(AllGroups(gRow("GroupID")))
                    lstAvailable.Items.RemoveAt(idx)
                End If
            Next
            ChangesMade = False
        End If
    End Sub

    Private Sub frmGroups_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim AllowClose As dialogresult = Windows.Forms.DialogResult.Yes 
        If ChangesMade then
            AllowClose = MessageBox.Show("Are you sure you want to loose your changes?","Loose Changes?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
        End If
        If AllowClose=Windows.Forms.DialogResult.No then
            e.Cancel=True  
        Else
            ' Don't cancel - form closes
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lstAllocated.SelectedIndex <> -1 Then
            ChangesMade = True
            lstAvailable.Items.Add(lstAllocated.SelectedItem)
            lstAllocated.Items.Remove(lstAllocated.SelectedItem)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If lstAvailable.SelectedIndex <> -1 Then
            ChangesMade = True
            lstAllocated.Items.Add(lstAvailable.SelectedItem)
            lstAvailable.Items.Remove(lstAvailable.SelectedItem)
        End If
    End Sub

    Private Sub ListMouseDown(ByVal sender As Object, ByVal e _
    As System.Windows.Forms.MouseEventArgs) Handles lstAllocated.MouseDown, lstAvailable.MouseDown
        ' Begin dragging by calling the DoDragDrop method.
        ' OLEStartDrag is replaced by arguments on the method.
        If sender.selectedindex <> -1 Then
            Source = sender
            Dim dropEffect As DragDropEffects = sender.DoDragDrop(sender.SelectedItem.ToString, DragDropEffects.Move)
            ' If the drag operation was a move then remove the item.
            If (dropEffect = DragDropEffects.Move) Then
                sender.items.remove(sender.selecteditem)
                ChangesMade = True
            End If
        End If
    End Sub

    Private Sub ListDragEnter(ByVal sender As Object, ByVal e _
    As System.Windows.Forms.DragEventArgs) Handles lstAvailable.DragEnter, lstAllocated.DragEnter

        ' Make sure that the format is text and that source and destination are not the same
        If (e.Data.GetDataPresent(DataFormats.Text)) And Not Source Is sender Then
            ' Allow drop.
            e.Effect = DragDropEffects.Move
        Else
            ' Do not allow drop.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstAllocated_DragDrop(ByVal sender As Object, ByVal e _
    As System.Windows.Forms.DragEventArgs) Handles lstAllocated.DragDrop, lstAvailable.DragDrop
        ' Copy the item to the second TextBox.
        sender.Items.Add(Source.SelectedItem)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If ChangesMade Then
            ' Update the Groups for currently selected contact
            Dim MyGroups As New List(Of Integer)
            For Each gp As clGroup  In lstAllocated.Items
                MyGroups.Add(gp.GroupID)
            Next
            AddressSource.UpdateGroups(MyGroups, id)
            ChangesMade = False
        End If
        Me.Close()
    End Sub

Private Sub btnCancel_Click( sender As System.Object,  e As System.EventArgs) Handles btnCancel.Click
   Me.close
End Sub

End Class