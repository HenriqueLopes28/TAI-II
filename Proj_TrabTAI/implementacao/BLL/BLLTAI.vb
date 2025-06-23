Imports DAL

Public Class BLLTAI

#Region "SELECTS"
    Public Function valida(login As String) As DataTable
        Try
            Dim dal As New DAL.DALTAI
            Return dal.valida(login)
        Catch ex As Exception

        End Try
    End Function

    Public Function VerificaProfessor(login As String) As DataTable
        Try
            Dim dal As New DAL.DALTAI
            Return dal.VerificaProfessor(login)
        Catch ex As Exception

        End Try
    End Function

    Public Function VerificaPerguntas(login As String, tipo_pergunta As Integer) As DataTable
        Try
            Dim dal As New DAL.DALTAI
            Return dal.VerificaPerguntas(login, tipo_pergunta)
        Catch ex As Exception

        End Try
    End Function

    Public Function VerificaAvaliacao(login As String, id_professor As Integer) As Boolean
        Try
            Dim dal As New DAL.DALTAI
            Return dal.VerificaAvalicao(login, id_professor)
        Catch ex As Exception

        End Try
    End Function

    Public Function BuscaRespostas(id_professor As Integer, id_escola As Integer) As DataTable
        Try
            Dim dal As New DAL.DALTAI
            Return dal.BuscaRespostas(id_professor, id_escola)

        Catch ex As Exception

        End Try
    End Function

    Public Function BuscaPessoa(id_escola As Integer, flag_pessoa As Integer) As DataTable
        Try
            Dim dal As New DAL.DALTAI
            Return dal.BuscaPessoa(id_escola, flag_pessoa)
        Catch ex As Exception

        End Try
    End Function

    Public Function BuscaEscola(id_escola As Integer) As DataTable
        Try
            Dim dal As New DAL.DALTAI
            Return dal.BuscaEscola(id_escola)
        Catch ex As Exception

        End Try
    End Function

    Public Function RespostasTabela(id_escola As Integer, id_professor As Integer) As DataTable
        Try
            Dim dal As New DAL.DALTAI
            Return dal.RespostasTabela(id_escola, id_professor)
        Catch ex As Exception

        End Try
    End Function
#End Region

#Region "INSERT"
    Public Function SalvaRespostas(dt As DataTable) As Boolean
        Try
            Dim dal As New DAL.DALTAI
            Return dal.SalvaRespostas(dt)
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region "DELETE"

#End Region

#Region "UPDATE"

#End Region
End Class
