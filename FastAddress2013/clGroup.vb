
Class clGroup
    Private _Group As String
    Private _GroupID As Integer

    Public Sub New(ByVal GroupID As Integer, ByVal Group As String)
        _GroupID = GroupID
        _Group = Group
    End Sub

    Public Property Group() As String
        Get
            Return _Group
        End Get
        Set(ByVal value As String)
            _Group = value
        End Set
    End Property

    Public Property GroupID() As Integer
        Get
            Return _GroupID
        End Get
        Set(ByVal value As Integer)
            _GroupID = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _Group
    End Function
End Class
