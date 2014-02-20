Public Class frmMap


    Private Sub lstDataField_ItemCheck(sender As Object, e As System.Windows.Forms.ItemCheckEventArgs) Handles lstDataField.ItemCheck
        If e.NewValue = CheckState.Checked then
            For Each i In lstDataField.CheckedItems 
                If i.index <> e.Index
                        i.checked = false
                Else
                        i.checked = true
                End If
            Next
        End If
    End Sub

    Private Sub frmMap_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If lstDataField.CheckedItems.Count < 1 then
            messagebox.show("Select a field to import " & lblCSV.Text & "into", "Select Destination Field",MessageBoxButtons.OK,MessageBoxIcon.Asterisk)
            e.Cancel = True 
        End If
    End Sub

Private Sub frmMap_Load( sender As System.Object,  e As System.EventArgs) Handles MyBase.Load

End Sub

Private Sub Button1_Click( sender As System.Object,  e As System.EventArgs) Handles Button1.Click
        Me.close
End Sub
End Class