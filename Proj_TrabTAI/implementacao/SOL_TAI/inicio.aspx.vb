Public Class inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If

    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        DivTexto.Visible = False
        PnlLogin.Visible = True
        PnlQuemSomos.Visible = False


    End Sub
    Private Sub BtnInicio_Click(sender As Object, e As EventArgs) Handles BtnInicio.Click
        DivTexto.Visible = True
        PnlLogin.Visible = False
        PnlQuemSomos.Visible = False

    End Sub
    Private Sub BtnQuemSomos_Click(sender As Object, e As EventArgs) Handles BtnQuemSomos.Click
        DivTexto.Visible = False
        PnlQuemSomos.Visible = True
        PnlLogin.Visible = False

    End Sub
    Private Sub BtnLogar_Click(sender As Object, e As EventArgs) Handles BtnLogar.Click
        Dim titulo, texto As String
        Dim tempo As Integer


        Dim obj_bll As New BLL.BLLTAI
        If String.IsNullOrWhiteSpace(TextCodigo.Text) Then
            titulo = "ERRO"
            texto = "Digite seu Login!"
            tempo = 3000
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','error','<b>" & texto & "</b>'," & tempo & ",'350px','fa fa-solid fa-exclamation-circle');", True)

        Else
            Dim dt As DataTable = obj_bll.valida(TextCodigo.Text)
            If dt.Rows.Count = 0 Then
                titulo = "ERRO"
                texto = "Login não foi encontrado!"
                tempo = 3000
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','error','<b>" & texto & "</b>'," & tempo & ",'350px','fa fa-solid fa-exclamation-circle');", True)

            Else
                titulo = "SUCESSO"
                texto = "Login efetuado com sucesso!"
                tempo = 3000
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','success','<b>" & texto & "</b>'," & tempo & ",'350px','fa fa-solid fa-circle-check');", True)

                Dim ObjBE As New BE.BECadastro
                ObjBE.Id_escola = dt.Rows(0)("id_escola")
                ObjBE.Id_pessoa = dt.Rows(0)("id_pessoa")
                ObjBE.Flag_pessoa = dt.Rows(0)("flag_pessoa")
                ObjBE.Nome = dt.Rows(0)("nome")

                Session("Login") = ObjBE

                Dim delay As String = "setTimeout(function() { window.location.href = 'principal.aspx'; }, 1500);"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "delayRedirect", delay, True)

            End If
        End If

    End Sub
End Class