Public Class BECadastro
    Private _id_escola As Integer
    Private _id_pessoa As Integer
    Private _flag_pessoa As Integer
    Private _status_avaliacao_escola As Integer
    Private _status_avaliacao_professor As String
    Private _nome As String
    Public Property Id_escola() As Integer
        Get
            Return _id_escola
        End Get
        Set(ByVal value As Integer)
            _id_escola = value
        End Set
    End Property
    Public Property Id_pessoa() As Integer
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Integer)
            _id_pessoa = value
        End Set
    End Property
    Public Property Flag_pessoa() As Integer
        Get
            Return _flag_pessoa
        End Get
        Set(ByVal value As Integer)
            _flag_pessoa = value
        End Set
    End Property
    Public Property Status_avaliacao_escola() As Integer
        Get
            Return _status_avaliacao_escola
        End Get
        Set(ByVal value As Integer)
            _status_avaliacao_escola = value
        End Set
    End Property
    Public Property Status_avaliacao_professor() As Integer
        Get
            Return _status_avaliacao_professor
        End Get
        Set(ByVal value As Integer)
            _status_avaliacao_professor = value
        End Set
    End Property
    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property
End Class
