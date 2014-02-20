Imports System.Data


Module Globals

    '    Public AddressData As New DataSet
    Public dsLabels As DataSet
    '    Public DetailsFormStatus As DetailsFormType

    Public Const InToCm As Single = 2.54

    Public Structure LabelData
        Public Name As String
        Public NoAcross As Integer
        Public NoDown As Integer
        Public TM As Integer
        Public LM As Integer
        Public H As Integer
        Public W As Integer
        Public V As Integer
        Public G As Integer
        Public Pad As Integer
    End Structure

    '    Public Enum DetailsFormType
    '        EditDetails
    '        NewAddress
    '    End Enum

    Public Function DataPath() As String
        'Return System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\FastAddress"
        Return Application.StartupPath & "\App_Data"
    End Function

    Public Function AddressDataLocation() As String
        Return DataPath() & "\AddressBook.sdf"
    End Function

    Public Function LabelDataLocation() As String
        Dim labelPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\FastAddress2013"
        labelPath &= "\Labels.xml"
        Return labelPath
    End Function

    Public Function DC(Inputstring As String) As String
        Return Inputstring.Replace("'", "''")
    End Function

End Module
