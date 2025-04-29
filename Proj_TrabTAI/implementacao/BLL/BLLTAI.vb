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
#End Region

#Region "INSERT"

#End Region

#Region "DELETE"

#End Region

#Region "UPDATE"

#End Region
End Class
