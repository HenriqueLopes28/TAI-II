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

        Dim obj_bll As New BLL.BLLTAI
        If String.IsNullOrWhiteSpace(TextCodigo.Text) Then

        Else
            Dim dt As DataTable = obj_bll.valida(TextCodigo.Text)
            If dt.Rows.Count = 0 Then

            Else
                Dim ObjBE As New BE.BECadastro
                ObjBE.Id_escola = dt.Rows(0)("id_escola")
                ObjBE.Id_pessoa = dt.Rows(0)("id_pessoa")
                ObjBE.Flag_pessoa = dt.Rows(0)("flag_pessoa")
                ObjBE.Status_avaliacao_professor = dt.Rows(0)("status_avaliacao_professor")
                ObjBE.Status_avaliacao_escola = dt.Rows(0)("status_avaliacao_escola")
                ObjBE.Nome = dt.Rows(0)("nome")

                Session("Login") = ObjBE
                Response.Redirect("principal.aspx")

            End If
        End If

    End Sub
End Class