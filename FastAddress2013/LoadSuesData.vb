Imports System.Data.SqlServerCe
Imports System.Data.OleDb

Public Class LoadSuesData
    Dim OldData As New DataTable
    Private AddressSource As New AddressLayer

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MessageBox.Show ("This is disabled!")
        STOP
        Dim connAccess As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='F:\SuesAddresses\Sue Addresses.mdb'; User ID=admin; Password=;")
        Dim strSelect As String = "SELECT LastName, FirstNames, Salutation, House, Street, Town, County, PostCode, Country, Telephone, Xmas, BookClub, HouseGroup, College, Councelling, Tag, Remarks FROM Address"
        Dim CmdAccess as New OleDbCommand(strSelect, connAccess)
        connAccess.Open 
        Dim daAccess As New OleDbDataAdapter(CmdAccess)
     '    Do While drAccess.Read
        '        InsertCE(drAccess("LastName"), drAccess("FirstNames") & "", drAccess("Salutation") & "", drAccess("House") & "", drAccess("Street") & "", drAccess("Town") & "", drAccess("County") & "", drAccess("PostCode") & "", drAccess("Country") & "", drAccess("Telephone") & "")
        '    Loop

        'End If
        daAccess.Fill(OldData)
        For Each r As DataRow In OldData.rows
            InsertCE(r("LastName"), r("FirstNames") & "", r("Salutation") & "", r("House") & "", r("Street") & "", r("Town") & "", r("County") & "", r("PostCode") & "", r("Country") & "", r("Telephone") & "", _
                     r("Xmas"), r("BookClub"), r("HouseGroup"), r("College"), r("Councelling"), r("Tag"), r("Remarks") & "")
        Next
        connAccess.close
    End Sub
    Private Sub InsertCE(LastName As String, FirstNames As String, Salutation As String, House As String, Street As String, Town As String, County As String, PostCode As String, Country As String, Telephone As String, _
                         Xmas As Boolean , BookClub As Boolean, HouseGroup As Boolean, College As Boolean, Councelling As Boolean, Tag As Boolean, Remarks As string) 
        Dim connCe As New SqlCeConnection("Data Source=D:\DEVELOPER\FastAddress2013\FastAddress2013\App_Data\AddressBook.sdf")
        Dim CmdCE As New SqlCeCommand
        CmdCE.Connection=connCE
        Dim AddressID As Integer
        Dim ContactID As Integer
        
        ' Address
        AddressID = AddressSource.InsertAddress(House, Street, Town, County, PostCode, Country, Telephone,"","")
        'Dim strInsert As String = String.format("INSERT Addresses (AddressLine1, AddressLine2, Town, County, PostCode, Country, Telephone) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", _
        '                                       DC(House), DC(Street), Town, County, PostCode, Country, Telephone)
        'Dim cmdCE As New SqlCeCommand (strInsert, connCE )
        'connCe.Open
        'cmdCE.ExecuteNonQuery
        'cmdCE.CommandText="SELECT Max(AddressID) FROM Addresses"
        'AddressID = cmdCE.ExecuteScalar 
        ContactID = AddressSource.newContact(Salutation, FirstNames, LastName, AddressID)
        'Dim strInsert2 As String = String.format("INSERT Contacts (Surname, FirstName, Title, AddressID) VALUES ('{0}','{1}','{2}','{3}')", DC(LastName), DC(FirstNames), Salutation, maxID)
        'cmdCE.CommandText=strInsert2 
        'cmdCE.ExecuteNonQuery
        connCe.Open 
        If Tag Then
            cmdCE.CommandText=String.Format("INSERT Contact_Group Values ({0}, {1})", ContactID, 1)
            CmdCE.ExecuteNonQuery 
        End If
        If Xmas Then
            cmdCE.CommandText=String.Format("INSERT Contact_Group Values ({0}, {1})", ContactID, 2)
            CmdCE.ExecuteNonQuery 
        End If
        If BookClub then
            cmdCE.CommandText=String.Format("INSERT Contact_Group Values ({0}, {1})", ContactID, 3)
            CmdCE.ExecuteNonQuery 
        End If
        If HouseGroup Then
            cmdCE.CommandText=String.Format("INSERT Contact_Group Values ({0}, {1})", ContactID, 4)
            CmdCE.ExecuteNonQuery 
        End If
        If Councelling  then
            cmdCE.CommandText=String.Format("INSERT Contact_Group Values ({0}, {1})", ContactID, 5)
            CmdCE.ExecuteNonQuery 
        End If
        If College  Then
            cmdCE.CommandText=String.Format("INSERT Contact_Group Values ({0}, {1})", ContactID, 6)
            CmdCE.ExecuteNonQuery 
        End If
        If Remarks.Length > 0 then
            cmdCE.CommandText=String.Format("INSERT Remarks (ContactID, Remark) Values ({0}, '{1}')", ContactID, DC(Remarks))
            CmdCE.ExecuteNonQuery
        End If

        connCe.close
    End Sub

Private Sub LoadSuesData_Load( sender As System.Object,  e As System.EventArgs) Handles MyBase.Load

End Sub
End Class