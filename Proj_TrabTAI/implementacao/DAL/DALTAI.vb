Imports System.Data.SqlClient
Public Class DALTAI
    Private _erro As String
    Public ReadOnly Property Erro As String
        Get
            Return _erro
        End Get
    End Property

#Region "SELECTS"
    Public Function valida(login As String) As DataTable
        Try
            Dim s As New Text.StringBuilder
            Dim oBanco As New oBanco.CBanco
            Dim dt As DataTable

            s.AppendLine("SELECT id_pessoa,id_escola,flag_pessoa,status_avaliacao_escola,status_avaliacao_professor,nome FROM tbl_cadastro WHERE id_pessoa = @id_pessoa")
            oBanco.pCommand.Parameters.AddWithValue("@id_pessoa", login)
            dt = oBanco.mDataTableCriar(s.ToString)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function VerificaProfessor(login As String) As DataTable
        Try
            Dim s As New Text.StringBuilder
            Dim oBanco As New oBanco.CBanco
            Dim dt As DataTable

            s.AppendLine("SELECT id_ano FROM db_trabalho.tbl_ano_prof_aluno WHERE id_pessoa=@id_pessoa;")
            oBanco.pCommand.Parameters.AddWithValue("@id_pessoa", login)

            dt = oBanco.mDataTableCriar(s.ToString)

            Dim ano As Integer = CInt(dt.Rows(0)("id_ano"))
            dt = Nothing

            s.Clear()

            s.AppendLine("SELECT DISTINCT c.id_pessoa,c.nome,c.flag_pessoa,apa.id_ano FROM tbl_ano_prof_aluno apa")
            s.AppendLine("INNER JOIN tbl_cadastro c ON apa.id_pessoa=c.id_pessoa WHERE apa.id_ano=@id_ano AND c.flag_pessoa=1")
            oBanco.pCommand.Parameters.Clear()
            oBanco.pCommand.Parameters.AddWithValue("@id_ano", ano)

            dt = oBanco.mDataTableCriar(s.ToString)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function VerificaPerguntas(login As String, tipo_pergunta As Integer) As DataTable
        Try
            Dim s As New Text.StringBuilder
            Dim oBanco As New oBanco.CBanco
            Dim dt As DataTable

            s.Append("SELECT id_escola from db_trabalho.tbl_cadastro where id_pessoa=@id_pessoa")
            oBanco.pCommand.Parameters.AddWithValue("@id_pessoa", login)
            dt = oBanco.mDataTableCriar(s.ToString)

            Dim escola As Integer = CInt(dt.Rows(0)("id_escola"))
            dt = Nothing

            s.Clear()

            s.AppendLine("SELECT id_pergunta, pergunta from db_trabalho.tbl_pergunta where id_escola = @id_escola and flag_pgt = @flag_pgt")
            oBanco.pCommand.Parameters.Clear()
            oBanco.pCommand.Parameters.AddWithValue("@id_escola", escola)
            oBanco.pCommand.Parameters.AddWithValue("@flag_pgt", tipo_pergunta)
            dt = oBanco.mDataTableCriar(s.ToString)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function VerificaAvalicao(login As String, id_professor As Integer) As Boolean
        Dim s As New Text.StringBuilder
        Dim oBanco As New oBanco.CBanco
        Dim dt As New DataTable

        s.AppendLine("SELECT DISTINCT id_professor from db_trabalho.tbl_resposta where id_pessoa = @id_pessoa AND id_professor = @id_professor")
        oBanco.pCommand.Parameters.AddWithValue("@id_pessoa", login)
        oBanco.pCommand.Parameters.AddWithValue("@id_professor", id_professor)
        dt = oBanco.mDataTableCriar(s.ToString)

        If CInt(dt.Rows(0)("id_professor")) = id_professor Then
            Return True
        Else
            Return False
        End If

    End Function
#End Region

#Region "INSERT"
    Public Function InsertNoticia(id_empresa As Integer, titulo_noticia As String, dc_noticia As String, data As Date, id_usuario As Integer, tempo_exposicao As Integer) As Boolean
        Try
            Dim s As New Text.StringBuilder
            Dim oBanco As New oBanco.CBanco

            s.Append("INSERT INTO tbl_portal_noticias(id_empresa,dc_noticia,titulo_noticia,data,id_usuario,tempo_exposicao)")
            s.Append(" VALUES(@id_empresa,@dc_noticia,@titulo_noticia,@data,@id_usuario,@tempo_exposicao)")


            oBanco.pCommand.Parameters.AddWithValue("@id_empresa", id_empresa)
            'oBanco.pCommand.Parameters.AddWithValue("@dc_noticia", dc_noticia)
            'oBanco.pCommand.Parameters.AddWithValue("@titulo_noticia", titulo_noticia)
            'oBanco.pCommand.Parameters.AddWithValue("@data", data)
            'oBanco.pCommand.Parameters.AddWithValue("@id_usuario", id_usuario)
            'oBanco.pCommand.Parameters.AddWithValue("@tempo_exposicao", tempo_exposicao)

            oBanco.mIncluir(s.ToString)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    Public Function SalvaRespostas(dt As DataTable) As Boolean
        Try
            Dim s As New Text.StringBuilder
            Dim oBanco As New oBanco.CBanco

            For i As Integer = 0 To dt.Rows.Count - 1
                s.AppendLine("INSERT INTO tbl_resposta (id_pergunta, id_pessoa, resposta, id_professor) VALUES (" + dt.Rows(i)("id_pergunta").ToString + ",")
                s.AppendLine(dt.Rows(i)("id_pessoa").ToString + ", " + dt.Rows(i)("resposta").ToString + ", " + dt.Rows(i)("id_professor").ToString + ");")
            Next

            oBanco.mIncluir(s.ToString)

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

#Region "DELETE"

#End Region

#Region "UPDATE"

#End Region

End Class
