Public Class Form1

Private Sub Form1_Load( sender As System.Object,  e As System.EventArgs) Handles MyBase.Load
        Dim cont As New AddressLayer 
        Dim ds As List(Of Person)=cont.GetMembers 
        DataGridView1.DataSource=ds
End Sub
End Class
