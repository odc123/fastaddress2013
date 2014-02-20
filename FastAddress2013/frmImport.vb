Imports System.IO
Imports System.Text

Public Class frmImport
    'ToDo Complete revision (Menu Item currently invisible)
    Private ImportFile As String
    Private FieldCount As Integer
    Private FieldsSelected As List(Of Integer)
    Private labelColour As Color
    Private AddressSource As New AddressLayer

    Private Shared Function GetContactFields() As String()
        Dim contactFields() As String = {"Surname", "FirstName", "Title"}
        Return contactFields
    End Function

    Private Sub btnFindFile_Click(sender As System.Object, e As System.EventArgs) Handles btnFindFile.Click
        Dim OneLine As String
        Dim OneFieldItem As FieldItem

        dialogGet.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        dialogGet.Filter = "CSV Files|*.csv|All files (*.*)|*.*"
        dialogGet.FilterIndex = 1
        dialogGet.DefaultExt = "csv"
        If dialogGet.ShowDialog() = DialogResult.OK Then
            Dim SR As StreamReader
            Try
            ImportFile = dialogGet.FileName
            SR = New StreamReader(ImportFile)
            Catch ex As Exception
                MessageBox.Show("File Error - Check it is not in use and try again","File Error",MessageBoxButtons.OK)
                Exit Sub
            End try
            ' Read first line (headings) into string array
            ' Note: BEWARE there may be commas and apostophes in the data
            OneLine = SR.ReadLine
            Dim FieldNames() As String = OneLine.Split(",")
            FieldCount = FieldNames.Count
            ' Display list if field names
            CheckedListBox1.Items.Clear()
            For Each Field As String In FieldNames
                OneFieldItem = New FieldItem(Field)
                CheckedListBox1.Items.Add(OneFieldItem)
            Next
        End If
        lblSelect.BackColor = Color.White
        lblSelect.BorderStyle = BorderStyle.FixedSingle
        btnMap.Enabled = True
        CheckedListBox1.Focus 
    End Sub

    Private Sub btnMap_Click(sender As System.Object, e As System.EventArgs) Handles btnMap.Click

        For Each d As string In GetContactFields 
                frmMap.lstDataField.Items.Add(d)
        Next
        For Each d As DataColumn In AddressSource.Addresses.Columns
            If d.ColumnName <> "AddressID" then
                frmMap.lstDataField.Items.Add(d.ColumnName)
            End If
        Next
        For Each f As FieldItem In CheckedListBox1.CheckedItems
            frmMap.lblCSV.Text = f.CSVFieldName
            frmMap.ShowDialog()
            f.DataFieldName = frmMap.lstDataField.CheckedItems(0)
            CheckedListBox1.Refresh()
            frmMap.lstDataField.SetItemChecked(frmMap.lstDataField.CheckedIndices(0), False)
        Next
        FieldsSelected = New List(Of Integer)
        For Each i As Integer In CheckedListBox1.CheckedIndices
            FieldsSelected.Add(i)
        Next
        lblSelect.BackColor = labelColour 
        lblSelect.BorderStyle = BorderStyle.None 
        btnMap.Enabled = False
        btnImport.Enabled = True
        btnImport.Focus 
    End Sub


    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        Dim oneLine As String ' One line of csv data
        Dim contactFields As String() = GetContactFields()
        Dim sbError As new StringBuilder
        ' *ToDo - Add or Replace

        ' *ToDo - If replace then delete existing data


        ' Read the input line by line (reject first line - headings)
        Dim SR As New StreamReader(ImportFile)
        ' Read first line (headings) into string array
        ' Note: BEWARE there may be commas and apostophes in the data
        Dim FirstLine As Boolean = True
        Dim FieldValues() As String
        Do Until SR.EndOfStream
            If FirstLine Then
                SR.ReadLine()
                FirstLine = False
            Else
                oneLine = SR.ReadLine
                FieldValues = oneLine.Split(",")
                If FieldValues.count > FieldCount then
                    sbError.Append("Error - Too many fields: " & oneline & ControlChars.CrLf)
                End If
                ' *ToDo If FieldValues.Count <> Mapping.Count - bad line
                ' *ToDo Will this work??
                Dim CRow As DataRow = AddressSource.Contacts.NewRow
                Dim ARow As DataRow = AddressSource.Addresses.NewRow
                For i = 0 To FieldValues.Count - 1
                    ' Is this field being imported?
                    If CheckedListBox1.CheckedIndices.Contains(i) Then
                        ' Is the mapped field of this field in the Contacts Table?
                        If contactFields.Contains(CheckedListBox1.Items(i).DataFieldName) Then
                            CRow.Item(CheckedListBox1.Items(i).DataFieldName) = FieldValues(i)
                        Else
                            ARow.Item(CheckedListBox1.Items(i).DataFieldName) = FieldValues(i)
                        End If
                    End If

                Next
                ' Get New AddressID and ContactID
                Try
                    Dim dvC As New DataView(AddressSource.Contacts)
                    dvC.Sort = "ContactID DESC"
                    Dim NewContactID As Integer = dvC(0)("ContactID") + 1
                    Dim dvA As New DataView(AddressSource.Addresses)
                    dvA.Sort = "AddressID DESC"
                    Dim NewAddressID As Integer = dvC(0)("AddressID") + 1

                    CRow("ContactID") = NewContactID
                    CRow("AddressID") = NewAddressID
                    CRow("Entered") = Now.ToShortDateString 
                    CRow("Updated") = Now.ToShortDateString
                    CRow("Deleted") = False
                    ARow("AddressID") = NewAddressID
                    ' *ToDo Is this OK ??
                    AddressSource.Contacts.Rows.Add(CRow)
                    AddressSource.Addresses.Rows.Add(ARow)
                Catch ex As Exception
                    sbError.Append("Error - NOT imported: " & oneline & ControlChars.CrLf)
                End Try
            End If
        Loop
        If sbError.Length > 0 then
            MessageBox.Show("There was a problem with the import, some records may not have been imported" & vbCrLf & _
                             "Full details are in the file 'FailedImport.csv' in your Documents folder ","Import Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            sbError.Remove(sbError.Length-1, 1)
            Using outfile As New StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\FailedImport.txt")
                outfile.Write(sbError.ToString())
            End Using
        End If
        ' *ToDo Save Data
        'AddressData.WriteXml(AddressDataLocation, XmlWriteMode.WriteSchema)
        Me.close
    End Sub

Private Sub frmImport_Load( sender As System.Object,  e As System.EventArgs) Handles MyBase.Load
        btnMap.Enabled = False 
        btnImport.Enabled = False
        labelColour = lblSelect.BackColor 
End Sub

End Class

Public Class FieldItem
    Public Property CSVFieldName As String
    Public Property DataFieldName As String

    Public Sub New(FieldName As String)
        CSVFieldName = FieldName
    End Sub

    Public Sub New(OldField As String, NewField As String)
        CSVFieldName = OldField
        DataFieldName = NewField
    End Sub

    Public Overrides Function ToString() As String
        If DataFieldName = String.Empty Then
            Return CSVFieldName
        Else
            Return CSVFieldName & "  ---->  " & DataFieldName
        End If
    End Function
End Class