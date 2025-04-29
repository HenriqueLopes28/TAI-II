Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim objBLL As New BLL.BLLTAI

        End If
    End Sub

#Region "DADOS DA PAGINA"
    Private Sub Dados()

    End Sub



    Private Function Dados1() As DataTable

    End Function
#End Region

#Region "AÇÕES"
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        PnlEscola.Visible = False
    End Sub
#End Region

End Class