
Imports System.Data.SqlServerCe
Imports System.Text

Public Class AddressLayer
    Private cn As New SqlCeConnection("Data Source=" & AddressDataLocation)  '"D:\DEVELOPER\FastAddress2013\FastAddress2013\App_Data\AddressBook.sdf")

    Public Function GetMembers() As List(Of Person)
        Dim p As New List(Of Person)
        Dim strSQL As String = "SELECT ContactID, FirstName, Surname, Title, Deleted, Updated, AddressID FROM Contacts"
        Dim cmd As New SqlCeCommand(strSQL, cn)
        Dim dr As SqlCeDataReader
        cn.Open()
        Try
            dr = cmd.ExecuteReader
            Do While dr.Read
                Dim thisOne As New Person
                With thisOne
                    .ContactID = dr("ContactID")
                    .FirstName = dr("FirstName") & ""
                    .Surname = dr("Surname") & ""
                    .Title = dr("Title") & ""
                    If IsDBNull(dr("Deleted")) Then
                        .Deleted = False
                    Else
                        .Deleted = dr("Deleted")
                    End If
                    If IsDBNull(dr("Updated")) Then
                        .Updated = "01/01/2013"
                    Else
                        .Updated = dr("Updated")
                    End If
                    .AddressID = dr("AddressID") + 0
                    p.Add(thisOne)
                End With
            Loop
            Return p
            cn.Close()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Contacts() As DataTable
        Dim strSQL As String = "SELECT ContactID, FirstName, Surname, Title, Deleted, Updated, AddressID FROM Contacts"
        Dim da As New SqlCeDataAdapter(strSQL, cn)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "Contacts")
            Dim dt As DataTable = ds.Tables("Contacts")
            Return dt
        Catch
            Return Nothing
        End Try
    End Function

    Public Function Contact_Group() As DataTable
        Dim strSQL As String = "SELECT ContactID, GroupID FROM Contact_Group"
        Dim da As New SqlCeDataAdapter(strSQL, cn)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "Contact_Group")
            Return ds.Tables("Contact_Group")
        Catch ex As exception
            Return Nothing
        End Try
    End Function

    Public Function Addresses() As DataTable
        Dim strSQL As String = "SELECT AddressID, AddressLine1, AddressLine2, Town, County, PostCode, Country, Telephone, Mobile, Email FROM Addresses"
        Dim da As New SqlCeDataAdapter(strSQL, cn)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "Addresses")
            Return ds.Tables("Addresses")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Remarks() As DataTable
        Dim strSQL As String = "SELECT RemarkID, ContactID, Remark FROM Remarks"
        Dim da As New SqlCeDataAdapter(strSQL, cn)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "Remarks")
            Return ds.Tables("Remarks")
        Catch
            Return Nothing
        End Try
    End Function

    Public Function Groups() As DataTable
        Dim strSQL As String = "SELECT GroupID, [Group] FROM Groups"
        Dim da As New SqlCeDataAdapter(strSQL, cn)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "Groups")
            Return ds.Tables("Groups")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub Tag(ID As Integer)
        Dim strSQl As String = String.Format("INSERT Contact_Group (ContactID, GroupID) VALUES ({0}, {1})", ID, 1)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub UnTag(ID As Integer)
        Dim strSQl As String = String.Format("DELETE FROM Contact_Group WHERE ContactID = {0} AND GroupID = {1}", ID, 1)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub NewGroup(newname As String)
        Dim strSQl As String = String.Format("INSERT Groups ([Group]) VALUES ('{0}')", newname)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub DeleteGroup(SelectedGroupID As Integer)
        Dim strSQl As String = String.Format("DELETE FROM Groups WHERE GroupID = {0}", SelectedGroupID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub ChangeGroup(newGroupName As String, SelectedGroupID As Integer)
        Dim strSQl As String = String.Format("UPDATE Groups SET [Group] = '{0}' WHERE GroupID = {1}", newGroupName, SelectedGroupID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub UpdateGroups(MyGroups As List(Of Integer), id As Integer)
        Dim strSQl As String = String.Format("SELECT GroupID FROM Contact_Group WHERE ContactID = {0}", id)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        Dim dr As SqlCeDataReader
        cn.Open()
        dr = cmd.ExecuteReader
        Do While dr.Read
            If MyGroups.Contains(dr("GroupID")) Then
                ' remove it from MyGroups (does not need amendment)
                MyGroups.Remove(dr("GroupID"))
            Else
                ' If this record is not in MyGroups delete it from the Contact_Group Table
                Dim strDelete As String = String.Format("DELETE FROM Contact_Group WHERE ContactID = {0} AND GroupID = {1}", id, dr("groupID"))
                Dim cmdDelete As New SqlCeCommand(strDelete, cn)
                cmdDelete.ExecuteNonQuery()
            End If
        Loop
        ' If any items remain in MyGroups add them to the Contact_Group Table
        For Each gpID As Integer In MyGroups
            Dim strInsert As String = String.Format("INSERT INTO Contact_Group (ContactID, GroupID) VALUES ({0}, {1})", id, gpID)
            Dim cmdInsert As New SqlCeCommand(strInsert, cn)
            cmdInsert.ExecuteNonQuery()
        Next
        cn.Close()
    End Sub

    Sub MarkAsDeleted(ContactID As Integer)
        Dim strSQl As String = String.Format("UPDATE Contacts SET [Deleted] = 1 WHERE ContactID = {0}", ContactID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub UnDelete(ContactID As Integer)
        Dim strSQl As String = String.Format("UPDATE Contacts SET [Deleted] = 0 WHERE ContactID = {0}", ContactID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub UpdateContact(Title As String, FirstName As String, Surname As String, ID As Integer)
        Dim strSQl As String = String.Format("UPDATE Contacts SET [Surname] = '{0}', [FirstName] = '{1}', [Title] = '{2}', [Updated] = '{3}' WHERE ContactID = {4}", _
                                             DC(Surname), DC(FirstName), Title, Format(Today, "MM/dd/yy"), ID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub UpdateContact(Title As String, FirstName As String, Surname As String, AddressID As Integer, ID As Integer)
        Dim strSQl As String = String.Format("UPDATE Contacts SET [Surname] = '{0}', [FirstName] = '{1}', [Title] = '{2}', [AddressID] = {3}, [Updated] = '{4}' WHERE ContactID = {5}", _
                                             DC(Surname), DC(FirstName), Title, AddressID, Format(Today, "MM/dd/yy"), ID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Function newContact(Title As String, FirstName As String, Surname As String, AddressID As Integer) As Integer
        Dim strSQl As String
        strSQl = String.Format("INSERT Contacts (Surname, FirstName, Title, Updated, AddressID) VALUES ('{0}','{1}','{2}','{3}',{4})", _
                                             DC(Surname), DC(FirstName), Title, Format(Today, "MM/dd/yy"), AddressID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SELECT Max(ContactID) FROM Contacts"
        Dim contID As Integer = cmd.ExecuteScalar
        cn.Close()
        Return contID
    End Function

    Function newContact(Title As String, FirstName As String, Surname As String) As Integer
        Dim strSQl As String
        strSQl = String.Format("INSERT Contacts (Surname, FirstName, Title, Updated) VALUES ('{0}','{1}','{2}','{3}')", _
                                         DC(Surname), DC(FirstName), Title, Format(Today, "MM/dd/yy"))
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SELECT Max(ContactID) FROM Contacts"
        Dim contID As Integer = cmd.ExecuteScalar
        cn.Close()
        Return contID
    End Function

    Sub UpdateAddress(AddressLine1 As String, AddressLine2 As String, Town As String, County As String, PostCode As String, Country As String, Telephone As String, Mobile As String, Email As String, ID As Integer)
        Dim strSQl As String = String.Format("UPDATE Addresses SET [AddressLine1] = '{0}', [AddressLine2] = '{1}', [Town] = '{2}', [County] = '{3}', [PostCode] = '{4}', [Country] = '{5}', [Telephone] = '{6}', [Mobile] = '{7}', [Email] = '{8}' WHERE AddressID = {9}", _
                                             DC(AddressLine1), DC(AddressLine2), Town, County, PostCode, Country, Telephone, Mobile, Email, ID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Function InsertAddress(AddressLine1 As String, AddressLine2 As String, Town As String, County As String, PostCode As String, Country As String, _
                       Telephone As String, Mobile As String, Email As String) As Integer
        Dim strSQl As String = String.Format("INSERT Addresses (AddressLine1, AddressLine2, Town, County, PostCode, Country, Telephone, Mobile, Email) " & _
                                             " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", _
                                             DC(AddressLine1), DC(AddressLine2), Town, County, PostCode, Country, Telephone, Mobile, Email)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SELECT Max(AddressID) FROM Addresses"
        Dim AddID As Integer = cmd.ExecuteScalar
        cn.Close()
        Return AddID
    End Function

    Sub SetAddressID(AddressID As Integer, ContactID As Integer)
        Dim strSQL As String = String.Format("UPDATE Contacts SET AddressID = {0} WHERE ContactID = {1}", AddressID, ContactID)
        Dim cmd As New SqlCeCommand(strSQL, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub DeleteAddress(aID As Integer)
        Dim strDelete As String = "DELETE FROM Addresses WHERE AddressID = " & aID
        Dim cmd As New SqlCeCommand(strDelete, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub DeleteGroupLinks(cID As Integer)
        Dim strDelete As String = "DELETE FROM Contact_Group WHERE ContactID = " & cID
        Dim cmd As New SqlCeCommand(strDelete, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub DeleteContact(cID As Integer)
        Dim strDelete As String = "DELETE FROM Contacts WHERE ContactID = " & cID
        Dim cmd As New SqlCeCommand(strDelete, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub InvertTags()
        ' Get a list off currently tagged Contacts
        Dim strFindtags As String = "SELECT ContactID FROM Contact_Group WHERE GroupID = 1"
        Dim cmd As New SqlCeCommand(strFindtags, cn)
        cn.Open()
        Dim dr As IDataReader = cmd.ExecuteReader
        Dim sb As New StringBuilder
        Do While dr.Read
            sb.Append(dr("ContactID") & ",")
        Loop
        sb.Remove(sb.Length-1, 1)
        ' Get a list off currently untagged Contacts
        Dim strFindUnTagged As String = String.Format("SELECT ContactID FROM Contacts WHERE ContactID Not IN ({0})", sb.ToString )
        cmd.CommandText = strFindUnTagged
        Dim dr2 As IDataReader = cmd.ExecuteReader
        Dim NewTags As new List(Of Integer)
        Do While dr2.Read
            NewTags.Add(dr2("ContactID"))
        Loop
        ' Delete all tagged
        Dim strDeleteTags As String = "DELETE FROM Contact_Group WHERE GroupID = 1"
        cmd.CommandText = strDeleteTags 
        cmd.ExecuteNonQuery 
        ' Insert tag for all contacts not in list
        Dim strTag As String
        For Each i As Integer In NewTags
            strTag= String.Format("INSERT Contact_Group (ContactID, GroupID) VALUES({0}, 1)", i)
            cmd.commandtext= strTag
            cmd.ExecuteNonQuery()
        Next
        cn.Close()
    End Sub

    Sub RemoveTags()
        Dim strDeleteTags As String = "DELETE FROM Contact_Group WHERE GroupID = 1"
        Dim cmd As New SqlCeCommand (strDeleteTags, cn)
        cn.Open
        cmd.ExecuteNonQuery
        cn.Close
    End Sub 

    Sub DeleteRemark(ContactID As String)
        Dim strDelete As String = "DELETE FROM Remarks WHERE ContactID = " & ContactID
        Dim cmd As New SqlCeCommand(strDelete, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub 

    Sub InsertRemark(Remark As String, ContactID As String)
        Dim strSQl As String = String.Format("INSERT Remarks (Remark, ContactID) " & _
                                                " VALUES ('{0}', {1})", Remark, ContactID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub 

    Sub SetChangedDate(ContactID As Integer)
        Dim strSQl As String = String.Format("UPDATE Contacts SET Updated = '{0}' WHERE ContactID = {1}",  _
                                            Format(Today, "MM/dd/yy"), ContactID)
        Dim cmd As New SqlCeCommand(strSQl, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Function CreateAddressBookDatabase()
        Dim DB As New SqlCeEngine(cn.ConnectionString)
        DB.CreateDatabase()
        Dim cmd As New SqlCeCommand
        cmd.Connection = cn
        Try
            cn.Open()
            cmd.CommandText = "CREATE TABLE [Remarks] ([RemarkID] int IDENTITY (1,1) NOT NULL, [ContactID] int NOT NULL, [Remark] nvarchar(1000) NULL);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE TABLE [Groups] ([GroupID] int IDENTITY (1,1) NOT NULL, [Group] nvarchar(20) NULL);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE TABLE [Contacts] ([ContactID] int IDENTITY (1,1) NOT NULL, [Surname] nvarchar(20) NOT NULL, [FirstName] nvarchar(20) NULL, [Title] nvarchar(200) NULL, [Deleted] bit DEFAULT 0 NULL, [Updated] datetime NULL, [AddressID] int NULL);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE TABLE [Contact_Group] ([ContactID] int NOT NULL, [GroupID] int NOT NULL);"

            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE TABLE [Addresses] ([AddressID] int IDENTITY (1,1) NOT NULL, [AddressLine1] nvarchar(40) NULL" & _
                ", [AddressLine2] nvarchar(40) NULL, [Town] nvarchar(30) NULL, [County] nvarchar(30) NULL, [PostCode] nvarchar(12) NULL" & _
                ", [Country] nvarchar(30) NULL, [Telephone] nvarchar(20) NULL, [Mobile] nvarchar(20) NULL, [Email] nvarchar(40) NULL);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "ALTER TABLE [Remarks] ADD CONSTRAINT [PK_Remarks] PRIMARY KEY [RemarkID]);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "ALTER TABLE [Groups] ADD CONSTRAINT [PK_Groups] PRIMARY KEY [GroupID]);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "ALTER TABLE [Contacts] ADD CONSTRAINT [PK_Contacts] PRIMARY KEY ([ContactID]);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "ALTER TABLE [Addresses] ADD CONSTRAINT [PK_Addresses] PRIMARY KEY ([AddressID]);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE UNIQUE INDEX [UQ__Remarks__0000000000000053] ON [Remarks] ([RemarkID] ASC);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE UNIQUE INDEX [UQ__Groups__0000000000000061] ON [Groups] ([GroupID] ASC);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE UNIQUE INDEX [UQ__Contacts__0000000000000012] ON [Contacts] ([ContactID] ASC);"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "CREATE UNIQUE INDEX [UQ__Addresses__0000000000000030] ON [Addresses] ([AddressID] ASC);"
            cn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function

End Class

Public Class Person
    Public Property ContactID As Integer
    Public Property FirstName As String
    Public Property Surname As String
    Public Property Title As String
    Public Property Deleted As Boolean
    Public Property Updated As Date
    Public Property AddressID As Integer
End Class
