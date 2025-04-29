Public Class principal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Login") Is Nothing Then
                Response.Redirect("inicio.aspx", False)
            Else
                Dim objBE As New BE.BECadastro
                objBE = CType(Session("Login"), BE.BECadastro)

                Response.Write(objBE.Nome)

                If objBE.Flag_pessoa = 0 Then
                    PnlAlunoProfessor.Visible = True

                ElseIf objBE.Flag_pessoa = 1 Then

                    PnlAlunoProfessor.Visible = True
                    BtnProfessor.Visible = False


                Else
                    BtnEscola.Text = "Respostas sobre Escola"
                    BtnProfessor.Text = "Respostas sobre Professor"
                    PnlDiretor.Visible = True

                End If


            End If
        End If
    End Sub

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        Session.Remove("Login")
        Response.Redirect("inicio.aspx")
    End Sub

    Private Sub BtnProfessor_Click(sender As Object, e As EventArgs) Handles BtnProfessor.Click

        Dim objBE As New BE.BECadastro
        objBE = CType(Session("Login"), BE.BECadastro)

        If objBE.Flag_pessoa = 0 Then
            PnlPerguntasEscola.Visible = False
            PnlPerguntasProfessor.Visible = True


            Dim ObjBLL As New BLL.BLLTAI
            Dim dt As DataTable = ObjBLL.VerificaProfessor(objBE.Id_pessoa)


            DpProfessorSelecionado.DataValueField = dt.Columns(0).ColumnName
            DpProfessorSelecionado.DataTextField = dt.Columns(1).ColumnName
            DpProfessorSelecionado.DataSource = dt
            DpProfessorSelecionado.DataBind()
            DpProfessorSelecionado.Items.Insert(0, New ListItem("Selecione um Professor", 0))

            Dim dt1 As DataTable = ObjBLL.VerificaPerguntas(objBE.Id_pessoa, 0)
            'Response.Write(dt.Rows(0)("nome"))
            If dt1.Rows.Count > 0 Then
                GridPerguntaProfessor.DataSource = dt1
                GridPerguntaProfessor.DataBind()
                GridPerguntaProfessor.Visible = False
            Else
                GridPerguntaProfessor.Visible = False
            End If


        ElseIf objBE.Flag_pessoa = 1 Then

        Else
            PnlRespostasEscola.Visible = False
            PnlRespostasProfessor.Visible = True

        End If
    End Sub

    Private Sub BtnEscola_Click(sender As Object, e As EventArgs) Handles BtnEscola.Click

        Dim objBE As New BE.BECadastro
        objBE = CType(Session("Login"), BE.BECadastro)

        If objBE.Flag_pessoa = 0 Or objBE.Flag_pessoa = 1 Then
            PnlPerguntasProfessor.Visible = False
            PnlPerguntasEscola.Visible = True

            Dim ObjBLL As New BLL.BLLTAI
            Dim dt1 As DataTable = ObjBLL.VerificaPerguntas(objBE.Id_pessoa, 1)


        Else
            PnlRespostasProfessor.Visible = False
            PnlRespostasEscola.Visible = True
        End If
    End Sub

    Private Sub DpProfessorSelecionado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DpProfessorSelecionado.SelectedIndexChanged
        If DpProfessorSelecionado.SelectedValue = 0 Then
            GridPerguntaProfessor.Visible = False
        Else
            'verificar se existe na tabela
            'DpProfessorSelecionado.SelectedValue
            GridPerguntaProfessor.Visible = True
        End If
    End Sub
End Class