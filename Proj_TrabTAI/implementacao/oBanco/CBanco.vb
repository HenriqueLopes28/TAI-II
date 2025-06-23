Imports MySql.Data.MySqlClient

''' <summary>
''' Classe responsavel pela comunicação APP x BANCO
''' </summary>
''' <remarks>
''' DATE (US) : 09/17/2015 By Nicollas Braga {Alterado construção da string de conexão}
''' 
''' </remarks>
Public Class CBanco

#Region "Definição de Variáveis"

    Public Const VERSAO As String = "1.0.0.1"
    Public Const DATA_VAZIA As Date = #1/1/2001#

    'Desenvolvimento FURNAS
    Public Const SERVIDOR As String = "127.0.0.1"  'Variavel para trabalhar offLine
    'Public Const SERVIDOR As String = "mysql16.kinghost.net"
    Private Const DBNAME As String = "db_trabalho"
    Private Const USER As String = "root" ' "eArp" '  
<<<<<<< HEAD
    Private Const PASSWORD As String = "##############"
=======
    Private Const PASSWORD As String = "###########"
>>>>>>> c620d5eb257e8680f8bf2914e65bce243bcfbe53

    Private strStringConexao_m As String = "server=" & SERVIDOR &
                                            "; user id=" & USER &
                                            "; password=" & PASSWORD &
                                            "; database=" & DBNAME

    'Private strStringConexao_m As String = "server=" & SERVIDOR & "; user id=eArp; password=naumsay; database=analise_preliminar_apr" 'String de conexao para trabalhar offLine
    'Private strStringConexao_m As String = "server=" & SERVIDOR & "; user id=artiz; password=naumsay; database=artiz"

    'Desenvolvimento LOCAL
    'Public Const SERVIDOR As String = "localhost"
    'Private strStringConexao_m As String = "server=" & SERVIDOR & "; user id=root; password=''; database=cadastroconsel"

    'Produção
    'Public Const SERVIDOR As String = "mysql01.cadastroconselhos.com.br"
    'Private strStringConexao_m As String = "server=" & SERVIDOR & "; user id=cadastroconsel; password=isaias; database=cadastroconsel"

    Private oConexao_m As New MySqlConnection

    Private strSetRole_m As String

    'Data adapter
    Private oDataAdapter_m As New MySqlDataAdapter

    'Command para execução de SQLs
    Private oComandoSql_m As New MySqlCommand

    'Objeto para controle de transações
    Private oTransacao_m As MySqlTransaction


    '"set role R_xxx identified by xxx"
    'Public Const SET_ROLE As String = ""

#End Region
    '#Region "Definição de Variáveis"

    '    'Controla conexão
    '    Private oConexao_m As MySqlConnection
    '    Private strStringConexao_m As String
    '    Private strSetRole_m As String

    '    'Data adapter
    '    Private oDataAdapter_m As MySqlDataAdapter

    '    'Command para execução de SQLs
    '    Private oComandoSql_m As MySqlCommand

    '    'Objeto para controle de transações
    '    Private oTransacao_m As MySqlTransaction

    '#End Region

#Region "Implementação de Propriedades"

    'Total de registros afetados
    Private lngTotRegistros_m As Long

    Public ReadOnly Property pTotalRegAfetados() As Long

        Get
            Return lngTotRegistros_m
        End Get

    End Property

    Public Property pCommand() As MySqlCommand
        Get
            Return oComandoSql_m
        End Get
        Set(ByVal value As MySqlCommand)
            oComandoSql_m = value
        End Set
    End Property

#End Region

#Region "Construtores e Destrutores"

    'Public Sub New(ByVal strStringConexao_p As String, _
    '               Optional ByVal strSetRole_p As String = "")

    '    'Guarda parâmetros
    '    strStringConexao_m = strStringConexao_p
    '    strSetRole_m = strSetRole_p

    '    'Instancia conexão, Data adapter e command
    '    oConexao_m = New MySqlConnection
    '    oDataAdapter_m = New MySqlDataAdapter
    '    oComandoSql_m = New MySqlCommand

    'End Sub

#End Region

#Region "Métodos Públicos"

    Public Function mABrir(Optional ByVal strStringConexao_p As String = "") As Boolean

        'Abre conexão com Banco de dados

        Try
            'Se string de conexão foi fornecida
            If strStringConexao_p.Trim <> "" Then

                'Se string de conexão informada é diferente da atual
                If strStringConexao_p <> strStringConexao_m Then

                    'Fecha conexão
                    mFechar()

                    'Guarda parâmetro fornecido
                    strStringConexao_m = strStringConexao_p
                End If
            End If

            If oConexao_m.State <> ConnectionState.Open Then

                'Abre conexão
                With oConexao_m

                    .ConnectionString = strStringConexao_m
                    .Open()

                End With

                With oComandoSql_m

                    'Seta role
                    If strSetRole_m <> "" Then


                        .CommandText = "set role R_IPS identified by IPS"
                        .CommandType = CommandType.Text
                        .Connection = oConexao_m
                        .ExecuteNonQuery()

                    Else
                        .CommandType = CommandType.Text
                        .Connection = oConexao_m

                    End If

                End With

            End If

            Return True

        Catch ex As Exception

            Throw New Exception("001" & ex.Message)
            Return False

        End Try

    End Function

    Public Function mAlterar(ByVal strSqlUpdate_p As String) As Boolean

        'Abre conexão
        If mABrir() Then

            Try
                'Configura(Command)
                With oComandoSql_m

                    .CommandText = strSqlUpdate_p
                    .CommandType = CommandType.Text
                    .Connection = oConexao_m

                    lngTotRegistros_m = .ExecuteNonQuery()

                End With

                'Se registro não existe...
                'If lngTotRegistros_m = 0 Then

                '    Throw New Exception("XXX")
                'Else
                Return True
                'End If

            Catch ex As MySql.Data.MySqlClient.MySqlException

                Dim strRet_p As String
                Dim intRet_p As Integer

                intRet_p = ex.ErrorCode

                If intRet_p = 1 Then 'Reg. já existe
                    strRet_p = "010"
                Else
                    strRet_p = "008" & ex.Message
                End If

                Throw New Exception(strRet_p)
                Return False

            Catch ex As Exception When ex.Message = "XXX"

                Throw New Exception("011")
                Return False

            Finally

                'Fecha conexão
                If oComandoSql_m.Transaction Is Nothing Then
                    mFechar()
                End If

            End Try
        Else
            Return False
        End If

    End Function

    Public Function mDataTableCriar(ByVal strSqlSelect_p As String) As System.Data.DataTable

        'Cria datatable
        Dim oDataTable_p As New DataTable

        'Abre conexão
        If mABrir() Then

            Try
                'Configura command
                With oComandoSql_m

                    .CommandText = strSqlSelect_p
                    .CommandType = CommandType.Text
                    '.Connection = oConexao_m 'Comentado por Dario

                End With

                'Configura adapter
                With oDataAdapter_m

                    .SelectCommand = oComandoSql_m
                    .Fill(oDataTable_p)

                End With

                'Guarda SQL que gerou o datatable
                oDataTable_p.ExtendedProperties.Add("SQL", strSqlSelect_p)

            Catch ex As Exception

                Throw New Exception("006" & ex.Message)
                oDataTable_p = Nothing

            Finally

                'Fecha conexão
                If oComandoSql_m.Transaction Is Nothing Then
                    mFechar()
                End If

            End Try
        End If

        Return oDataTable_p

    End Function

    Public Function mDataTableReCriar(ByRef oDataTableFonte_p As System.Data.DataTable) As System.Data.DataTable

        'Cria datatable
        Dim oDataTable_p As New DataTable
        Dim strSqlSelect_p As String

        'Abre conexão
        If mABrir() Then

            Try
                'Obtém comando SQL que originou o Datatable informado
                strSqlSelect_p = CType(oDataTableFonte_p.ExtendedProperties.Item("SQL"), String)

                'Configura command
                With oComandoSql_m

                    .CommandText = strSqlSelect_p
                    .CommandType = CommandType.Text
                    .Connection = oConexao_m

                End With

                'Configura adapter
                With oDataAdapter_m

                    .SelectCommand = oComandoSql_m
                    .Fill(oDataTable_p)

                End With

                'Guarda SQL que gerou o datatable
                oDataTable_p.ExtendedProperties.Add("SQL", strSqlSelect_p)

            Catch ex As Exception

                Throw New Exception("006" & ex.Message)
                oDataTable_p = Nothing

            Finally

                'Fecha conexão
                If oComandoSql_m.Transaction Is Nothing Then
                    mFechar()
                End If

            End Try
        End If

        Return oDataTable_p

    End Function
    Public Function mDataSetCriar(ByVal strSqlSelect_p As String) As System.Data.DataSet

        'Cria datatable
        Dim oDataSet_p As New DataSet
        Dim oDataTable_p As New DataTable

        'Abre conexão
        If mABrir() Then

            Try
                'Configura command
                With oComandoSql_m

                    .CommandText = strSqlSelect_p
                    .CommandType = CommandType.Text
                    '.Connection = oConexao_m 'Comentado por Dario

                End With

                'Configura adapter
                With oDataAdapter_m

                    .SelectCommand = oComandoSql_m
                    .Fill(oDataTable_p)

                End With

                'Guarda SQL que gerou o datatable
                oDataTable_p.ExtendedProperties.Add("SQL", strSqlSelect_p)
                oDataSet_p.Tables.Add(oDataTable_p)

            Catch ex As Exception

                Throw New Exception("006" & ex.Message)
                oDataTable_p = Nothing
                oDataSet_p = Nothing

            Finally

                'Fecha conexão
                If oComandoSql_m.Transaction Is Nothing Then
                    mFechar()
                End If

            End Try
        End If

        Return oDataSet_p

    End Function

    Public Function mExcluir(ByVal strSqlDelete_p As String) As Boolean

        'Abre conexão
        If mABrir() Then

            Try
                'Configura command
                With oComandoSql_m

                    .CommandText = strSqlDelete_p
                    .CommandType = CommandType.Text
                    .Connection = oConexao_m

                    lngTotRegistros_m = .ExecuteNonQuery()
                    Return True

                End With

            Catch ex As MySql.Data.MySqlClient.MySqlException

                Dim strRet_p As String
                Dim intRet_p As Integer

                intRet_p = ex.ErrorCode

                If intRet_p = 20001 Then 'Reg. referenciado em outra tabela (integridade)
                    strRet_p = "013"
                Else
                    strRet_p = "009" & ex.Message
                End If

                Throw New Exception(strRet_p)
                Return False

            Catch ex As Exception When ex.Message = "XXX"

                Throw New Exception("011")
                Return False

            Finally

                'Fecha conexão
                If oComandoSql_m.Transaction Is Nothing Then
                    mFechar()
                End If

            End Try
        Else
            Return False
        End If

    End Function

    Public Function mFechar() As Boolean

        'Fecha conexão com Banco de dados

        Try
            With oConexao_m

                .Close()
                .Dispose()

            End With

            Return True

        Catch ex As Exception

            Throw New Exception("002" & ex.Message)
            Return False

        End Try

    End Function

    Public Function mIncluir(ByVal strSqlInsert_p As String) As Boolean

        'Abre conexão

        If mABrir() Then

            Try
                'Configura command
                With oComandoSql_m

                    .CommandText = strSqlInsert_p
                    '.CommandType = CommandType.Text
                    '.Connection = oConexao_m
                    '.ExecuteScalar()
                    lngTotRegistros_m = .ExecuteNonQuery()

                End With

                Return True

            Catch ex As MySql.Data.MySqlClient.MySqlException

                Dim strRet_p As String
                Dim intRet_p As Integer

                intRet_p = ex.ErrorCode

                If intRet_p = 1 Then  'registro já existe...

                    strRet_p = "010"
                Else
                    strRet_p = "007" & ex.Message
                End If

                Throw New Exception(strRet_p)
                Return False

            Finally

                'Fecha conexão
                If oComandoSql_m.Transaction Is Nothing Then
                    mFechar()
                End If

            End Try
        Else
            Return False
        End If

    End Function
    Public Function mIncluirComRetorno(ByVal strSqlInsert_p As String) As Integer

        'Abre conexão

        If mABrir() Then

            Try
                'Configura command
                Dim id As Integer
                With oComandoSql_m

                    .CommandText = strSqlInsert_p
                    '.CommandType = CommandType.Text
                    '.Connection = oConexao_m
                    '.ExecuteScalar()
                    lngTotRegistros_m = .ExecuteNonQuery()
                    id = .ExecuteScalar
                End With

                Return id

            Catch ex As MySql.Data.MySqlClient.MySqlException

                Dim strRet_p As String
                Dim intRet_p As Integer

                intRet_p = ex.ErrorCode

                If intRet_p = 1 Then  'registro já existe...

                    strRet_p = "010"
                Else
                    strRet_p = "007" & ex.Message
                End If

                Throw New Exception(strRet_p)
                Return False

            Finally

                'Fecha conexão
                If oComandoSql_m.Transaction Is Nothing Then
                    mFechar()
                End If

            End Try
        Else
            Return False
        End If

    End Function
    Public Function mIncluirSemAbrirConexao(ByVal strSqlInsert_p As String) As Boolean
        Try
            'Configura command
            With oComandoSql_m

                .CommandText = strSqlInsert_p
                '.CommandType = CommandType.Text
                '.Connection = oConexao_m
                '.ExecuteScalar()
                lngTotRegistros_m = .ExecuteNonQuery()

            End With

            Return True

        Catch ex As MySql.Data.MySqlClient.MySqlException

            Dim strRet_p As String
            Dim intRet_p As Integer

            intRet_p = ex.ErrorCode

            If intRet_p = 1 Then  'registro já existe...

                strRet_p = "010"
            Else
                strRet_p = "007" & ex.Message
            End If

            Throw New Exception(strRet_p)
            Return False

        Finally

            'Fecha conexão
            'If oComandoSql_m.Transaction Is Nothing Then
            '    mFechar()
            'End If

        End Try


    End Function

    'Feita por Dario
    'Public Function mIncluir(ByVal strSqlInsert_p As String, ByRef oCommand_p As MySqlCommand) As Boolean

    '    'Abre conexão

    '    If mABrir() Then

    '        Try
    '            'Configura command
    '            With oCommand_p

    '                '.CommandText = strSqlInsert_p
    '                '.CommandType = CommandType.Text
    '                '.Connection = oConexao_m
    '                lngTotRegistros_m = .ExecuteNonQuery()

    '            End With

    '            Return True

    '        Catch ex As MySql.Data.MySqlClient.MySqlException

    '            Dim strRet_p As String
    '            Dim intRet_p As Integer

    '            intRet_p = ex.ErrorCode

    '            If intRet_p = 1 Then  'registro já existe...

    '                strRet_p = "010"
    '            Else
    '                strRet_p = "007" & ex.Message
    '            End If

    '            Throw New Exception(strRet_p)
    '            Return False

    '        Finally

    '            'Fecha conexão
    '            If oComandoSql_m.Transaction Is Nothing Then
    '                mFechar()
    '            End If

    '        End Try
    '    Else
    '        Return False
    '    End If

    'End Function

    Public Function mTrasacaoCancelar() As Boolean

        Try
            oTransacao_m.Rollback()
            oComandoSql_m.Transaction = Nothing

            Return True

        Catch ex As Exception

            Throw New Exception("005" & ex.Message)
            Return False

        Finally

            'Fecha conexão
            mFechar()

        End Try

    End Function

    Public Function mTrasacaoConfirmar() As Boolean

        Try
            oTransacao_m.Commit()
            oComandoSql_m.Transaction = Nothing

            Return True

        Catch ex As Exception

            Throw New Exception("004" & ex.Message)
            Return False

        Finally

            'Fecha conexão
            mFechar()

        End Try

    End Function

    Public Function mTrasacaoIniciar() As Boolean

        'Abre conexão
        If mABrir() Then

            Try
                oTransacao_m = oConexao_m.BeginTransaction
                oComandoSql_m.Transaction = oTransacao_m


                Return True

            Catch ex As Exception

                Throw New Exception("003" & ex.Message)
                Return False

            End Try
        Else
            Return False
        End If

    End Function

#End Region

#Region "Métodos Privados"

#End Region

    Public Sub New()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

