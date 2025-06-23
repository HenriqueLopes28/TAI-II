Imports System.Runtime.InteropServices

Public Class principal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Session("Login") Is Nothing Then
                Response.Redirect("inicio.aspx", False)
            Else
                Dim objBE As New BE.BECadastro
                objBE = CType(Session("Login"), BE.BECadastro)


                If objBE.Flag_pessoa = 0 Then

                    PnlAlunoProfessor.Visible = True
                    LblUsuario.Text = "Aluno"


                ElseIf objBE.Flag_pessoa = 1 Then

                    PnlAlunoProfessor.Visible = True
                    BtnProfessor.Visible = False
                    LblUsuario.Text = "Professor"

                Else
                    BtnEscola.Text = "Respostas sobre Escola"
                    BtnProfessor.Text = "Respostas sobre Professor"
                    LblUsuario.Text = "Coordenador"


                End If


            End If
        End If
    End Sub

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        Session.Remove("Login")
        Response.Redirect("inicio.aspx")
    End Sub

    Private Sub BtnProfessor_Click(sender As Object, e As EventArgs) Handles BtnProfessor.Click

        Dim ObjBLL As New BLL.BLLTAI

        Dim objBE As New BE.BECadastro
        objBE = CType(Session("Login"), BE.BECadastro)

        DivTexto.Visible = False

        If objBE.Flag_pessoa = 0 Then
            PnlPerguntasEscola.Visible = False
            PnlPerguntasProfessor.Visible = True



            Dim dt As DataTable = ObjBLL.VerificaProfessor(objBE.Id_pessoa)

            DpProfessorSelecionado.DataValueField = dt.Columns(0).ColumnName
            DpProfessorSelecionado.DataTextField = dt.Columns(1).ColumnName
            DpProfessorSelecionado.DataSource = dt
            DpProfessorSelecionado.DataBind()
            DpProfessorSelecionado.Items.Insert(0, New ListItem("Selecione um Professor", 0))

            Dim dt1 As DataTable = ObjBLL.VerificaPerguntas(objBE.Id_pessoa, 0)
            If dt1.Rows.Count > 0 Then
                GridPerguntaProfessor.DataSource = dt1
                GridPerguntaProfessor.DataBind()
                GridPerguntaProfessor.Visible = False
            Else
                GridPerguntaProfessor.Visible = False
            End If


        ElseIf objBE.Flag_pessoa = 1 Then

        Else

            Dim dt2 As DataTable = ObjBLL.BuscaPessoa(objBE.Id_escola, 1)
            GridNomesProfessor.DataSource = dt2
            GridNomesProfessor.DataBind()
            GridNomesProfessor.Visible = True

            PnlRespostasEscola.Visible = False
            PnlRespostasProfessor.Visible = True

        End If
    End Sub

    Private Sub BtnEscola_Click(sender As Object, e As EventArgs) Handles BtnEscola.Click

        Dim objBE As New BE.BECadastro
        Dim ObjBLL As New BLL.BLLTAI

        objBE = CType(Session("Login"), BE.BECadastro)
        DivTexto.Visible = False
        PnlPerguntasProfessor.Visible = False

        If objBE.Flag_pessoa = 0 Or objBE.Flag_pessoa = 1 Then
            Dim EscolaAvaliada As Boolean = ObjBLL.VerificaAvaliacao(objBE.Id_pessoa, 0)

            If EscolaAvaliada = False Then

                PnlPerguntasProfessor.Visible = False
                PnlPerguntasEscola.Visible = True
                BtnSalvarRespostasEscola.Visible = True


                Dim dt1 As DataTable = ObjBLL.VerificaPerguntas(objBE.Id_pessoa, 1)


                If dt1.Rows.Count > 0 Then

                    GridPerguntasEscola.DataSource = dt1
                    GridPerguntasEscola.DataBind()

                Else
                    GridPerguntasEscola.Visible = False
                End If

            Else
                DivTexto.Visible = True
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & "ERRO" & "</b>','error','<b>" & "A escola já foi avaliada" & "</b>'," & 2000 & ",'350px','fa fa-solid fa-exclamation-circle');", True)

            End If


        Else

            Dim dt2 As DataTable = ObjBLL.BuscaEscola(objBE.Id_escola)
            GridNomeEscola.DataSource = dt2
            GridNomeEscola.DataBind()
            GridNomeEscola.Visible = True

            PnlRespostasProfessor.Visible = False
            PnlRespostasEscola.Visible = True
        End If
    End Sub

    Private Sub DpProfessorSelecionado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DpProfessorSelecionado.SelectedIndexChanged

        Dim objBE As New BE.BECadastro
        objBE = CType(Session("Login"), BE.BECadastro)
        Dim objBLL As New BLL.BLLTAI

        If DpProfessorSelecionado.SelectedValue = 0 Then
            GridPerguntaProfessor.Visible = False
        Else

            Dim ProfessorAvaliado As Boolean = objBLL.VerificaAvaliacao(objBE.Id_pessoa, DpProfessorSelecionado.SelectedValue)
            If ProfessorAvaliado = True Then

                GridPerguntaProfessor.Visible = False
            Else
                GridPerguntaProfessor.Visible = True
                BtnSalvarRespostasProfessor.Visible = True
            End If

        End If
    End Sub

    Private Sub BtnSalvarRespostasProfessor_Click(sender As Object, e As EventArgs) Handles BtnSalvarRespostasProfessor.Click

        Dim ObjBE As New BE.BECadastro
        ObjBE = CType(Session("Login"), BE.BECadastro)
        Dim ObjBLL As New BLL.BLLTAI


        Dim dt As New DataTable
        Dim dr As Data.DataRow = dt.NewRow
        Dim dc1 As New Data.DataColumn("id_pergunta")
        Dim dc2 As New Data.DataColumn("id_pessoa")
        Dim dc3 As New Data.DataColumn("resposta")
        Dim dc4 As New Data.DataColumn("id_professor")
        Dim dc5 As New Data.DataColumn("id_escola")

        dt.Columns.Add(dc1)
        dt.Columns.Add(dc2)
        dt.Columns.Add(dc3)
        dt.Columns.Add(dc4)
        dt.Columns.Add(dc5)

        For Each row As GridViewRow In GridPerguntaProfessor.Rows

            Dim rbEducador1 As RadioButton = TryCast(row.Cells(1).FindControl("rbAvaliacao1"), RadioButton)
            Dim rbEducador2 As RadioButton = TryCast(row.Cells(2).FindControl("rbAvaliacao2"), RadioButton)
            Dim rbEducador3 As RadioButton = TryCast(row.Cells(3).FindControl("rbAvaliacao3"), RadioButton)
            Dim rbEducador4 As RadioButton = TryCast(row.Cells(4).FindControl("rbAvaliacao4"), RadioButton)
            Dim rbEducador5 As RadioButton = TryCast(row.Cells(5).FindControl("rbAvaliacao5"), RadioButton)
            dr = dt.NewRow

            If rbEducador1.Checked = True Then
                dr("resposta") = 1
            ElseIf rbEducador2.Checked = True Then
                dr("resposta") = 2
            ElseIf rbEducador3.Checked = True Then
                dr("resposta") = 3
            ElseIf rbEducador4.Checked = True Then
                dr("resposta") = 4
            ElseIf rbEducador5.Checked = True Then
                dr("resposta") = 5
            End If


            dr("id_pergunta") = GridPerguntaProfessor.DataKeys(row.RowIndex).Item("id_pergunta")
            dr("id_pessoa") = ObjBE.Id_pessoa
            dr("id_professor") = DpProfessorSelecionado.SelectedValue
            dr("id_escola") = ObjBE.Id_escola
            dt.Rows.Add(dr)

        Next
        Dim x As Integer = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i)("resposta").ToString = "" Then
                x = +1
            End If
        Next

        Dim titulo, frase As String
        Dim tempo As Integer
        Dim ProfessorAvaliado As Boolean = ObjBLL.VerificaAvaliacao(ObjBE.Id_pessoa, DpProfessorSelecionado.SelectedValue)

        If ProfessorAvaliado = True Then

            titulo = "ERRO"
            frase = "O professor ja foi avaliado!"
            tempo = 2000
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','error','<b>" & frase & "</b>'," & tempo & ",'350px','fa fa-solid fa-exclamation-circle');", True)

        Else
            If x = 0 Then

                ObjBLL.SalvaRespostas(dt)

                titulo = "SUCESSO"
                frase = "As respostas foram enviadas!"
                tempo = 2000
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','success','<b>" & frase & "</b>'," & tempo & ",'350px','fa fa-solid fa-circle-check');", True)


            Else

                titulo = "ERRO"
                frase = "Responda todas as perguntas!"
                tempo = 2000
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','error','<b>" & frase & "</b>'," & tempo & ",'350px','fa fa-solid fa-exclamation-circle');", True)

            End If

        End If
    End Sub

    Private Sub BtnSalvarRespostasEscola_Click(sender As Object, e As EventArgs) Handles BtnSalvarRespostasEscola.Click

        Dim ObjBE As New BE.BECadastro
        ObjBE = CType(Session("Login"), BE.BECadastro)
        Dim ObjBLL As New BLL.BLLTAI


        Dim dt As New DataTable
        Dim dr As Data.DataRow = dt.NewRow
        Dim dc1 As New Data.DataColumn("id_pergunta")
        Dim dc2 As New Data.DataColumn("id_pessoa")
        Dim dc3 As New Data.DataColumn("resposta")
        Dim dc4 As New Data.DataColumn("id_professor")
        Dim dc5 As New Data.DataColumn("id_escola")

        dt.Columns.Add(dc1)
        dt.Columns.Add(dc2)
        dt.Columns.Add(dc3)
        dt.Columns.Add(dc4)
        dt.Columns.Add(dc5)

        For Each row As GridViewRow In GridPerguntasEscola.Rows

            Dim rbEducador1 As RadioButton = TryCast(row.Cells(1).FindControl("rbAvaliacao1"), RadioButton)
            Dim rbEducador2 As RadioButton = TryCast(row.Cells(2).FindControl("rbAvaliacao2"), RadioButton)
            Dim rbEducador3 As RadioButton = TryCast(row.Cells(3).FindControl("rbAvaliacao3"), RadioButton)
            Dim rbEducador4 As RadioButton = TryCast(row.Cells(4).FindControl("rbAvaliacao4"), RadioButton)
            Dim rbEducador5 As RadioButton = TryCast(row.Cells(5).FindControl("rbAvaliacao5"), RadioButton)
            dr = dt.NewRow

            If rbEducador1.Checked = True Then
                dr("resposta") = 1
            ElseIf rbEducador2.Checked = True Then
                dr("resposta") = 2
            ElseIf rbEducador3.Checked = True Then
                dr("resposta") = 3
            ElseIf rbEducador4.Checked = True Then
                dr("resposta") = 4
            ElseIf rbEducador5.Checked = True Then
                dr("resposta") = 5
            End If


            dr("id_pergunta") = GridPerguntasEscola.DataKeys(row.RowIndex).Item("id_pergunta")
            dr("id_pessoa") = ObjBE.Id_pessoa
            dr("id_professor") = "0"
            dr("id_escola") = ObjBE.Id_escola
            dt.Rows.Add(dr)

        Next
        Dim x As Integer = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i)("resposta").ToString = "" Then
                x = +1
            End If
        Next

        Dim titulo, frase As String
        Dim tempo As Integer
        Dim EscolaAvaliada As Boolean = ObjBLL.VerificaAvaliacao(ObjBE.Id_pessoa, 0)

        If EscolaAvaliada = True Then

            titulo = "ERRO"
            frase = "A escola ja foi avaliada!"
            tempo = 2000
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','error','<b>" & frase & "</b>'," & tempo & ",'350px','fa fa-solid fa-exclamation-circle');", True)

        Else

            If x = 0 Then

                ObjBLL.SalvaRespostas(dt)

                titulo = "SUCESSO"
                frase = "As respostas foram enviadas!"
                tempo = 2000
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','success','<b>" & frase & "</b>'," & tempo & ",'350px','fa fa-solid fa-circle-check');", True)



            Else

                titulo = "ERRO"
                frase = "Responda todas as perguntas!"
                tempo = 2000
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','error','<b>" & frase & "</b>'," & tempo & ",'350px','fa fa-solid fa-exclamation-circle');", True)

            End If
        End If

    End Sub

    Private Sub GridNomesProfessor_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridNomesProfessor.RowCommand
        Dim index As Integer = e.CommandArgument
        Dim nomeProfessor As String = GridNomesProfessor.Rows(index).Cells(0).Text
        Dim id_professor As Integer = GridNomesProfessor.DataKeys(index).Value

        If e.CommandName = "exibir" Then
            nomeProfessor = HttpUtility.HtmlDecode(nomeProfessor)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "atualizaTitulo", "document.getElementById('TituloModal').innerText = 'Resultado do Professor: " & nomeProfessor.Replace("'", "\'") & "';", True)
            GeraGrafico(id_professor, "Nao existe resposta sobre esse professor(a)!")
        End If

        If e.CommandName = "exibirTabelaProfessor" Then
            nomeProfessor = HttpUtility.HtmlDecode(nomeProfessor)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "atualizaTitulo", "document.getElementById('TituloModalTabela').innerText = 'Resultado do Professor: " & nomeProfessor.Replace("'", "\'") & "';", True)
            GeraTabela(id_professor, "Nao existe resposta sobre esse professor(a)!")
        End If

    End Sub
    Private Sub GridNomeEscola_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridNomeEscola.RowCommand

        Dim index As Integer = e.CommandArgument
        Dim nomeEscola As String = GridNomeEscola.Rows(index).Cells(0).Text
        Dim id_escola As Integer = GridNomeEscola.DataKeys(index).Value

        If e.CommandName = "exibir" Then
            nomeEscola = HttpUtility.HtmlDecode(nomeEscola)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "atualizaTitulo", "document.getElementById('TituloModal').innerText = 'Resultado da Escola: " & nomeEscola.Replace("'", "\'") & "';", True)
            GeraGrafico(0, "Nao existe resposta sobre a escola!")
        End If

        If e.CommandName = "exibirTabelaEscola" Then
            nomeEscola = HttpUtility.HtmlDecode(nomeEscola)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "atualizaTitulo", "document.getElementById('TituloModalTabela').innerText = 'Resultado da Escola: " & nomeEscola.Replace("'", "\'") & "';", True)
            GeraTabela(0, "Nao existe resposta sobre a escola!")
        End If


    End Sub

    Private Sub GeraTabela(id_professor As Integer, frase As String)

        Dim objBLL As New BLL.BLLTAI
        Dim s As New Text.StringBuilder
        Dim dt As DataTable
        Dim ObjBE As New BE.BECadastro
        ObjBE = CType(Session("Login"), BE.BECadastro)
        Dim id_escola = ObjBE.Id_escola

        dt = objBLL.RespostasTabela(id_escola, id_professor)
        GridTabelaRespostas.DataSource = dt
        GridTabelaRespostas.DataBind()

        If dt.Rows.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "abrirModal", "$('#modalTabela').modal('show');", True)

        Else
            Dim titulo As String
            Dim tempo As Integer

            titulo = "ERRO"

            tempo = 2000
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','error','<b>" & frase & "</b>'," & tempo & ",'350px','fa fa-solid fa-exclamation-circle');", True)

        End If

    End Sub

    Private Sub GeraGrafico(id_professor As Integer, frase As String)

        Dim objBLL As New BLL.BLLTAI
        Dim s As New Text.StringBuilder
        Dim dt As DataTable
        Dim ObjBE As New BE.BECadastro
        ObjBE = CType(Session("Login"), BE.BECadastro)
        Dim id_escola = ObjBE.Id_escola


        dt = objBLL.BuscaRespostas(id_professor, id_escola)
        GridExibirDados.DataSource = dt
        GridExibirDados.DataBind()



        If dt.Rows.Count > 0 Then

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "abrirModal", "$('#modalResultados').modal('show');", True)

            s.Clear()
            s.AppendLine("$(function () {")
            s.AppendLine("var doughnutData = {")
            s.Append("labels: [")

            For i As Integer = 0 To dt.Rows.Count - 1
                s.Append("'" & dt.Rows(i)("dcresposta") & "(%)'")
                If i < dt.Rows.Count - 1 Then
                    s.Append(",")
                End If
            Next
            s.AppendLine("],")

            s.AppendLine("datasets: [{")

            s.Append("data: [")

            For i As Integer = 0 To dt.Rows.Count - 1
                s.Append(dt.Rows(i)("percentual").ToString.Replace(",", "."))
                If i < dt.Rows.Count - 1 Then
                    s.Append(",")
                End If
            Next

            s.AppendLine("],")
            s.Append("backgroundColor: [")

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("dcresposta") = "Muito Bom" Then
                    s.Append("'#ED4C67'")
                ElseIf dt.Rows(i)("dcresposta") = "Bom" Then
                    s.Append("'#19B5FE'")
                ElseIf dt.Rows(i)("dcresposta") = "Regular" Then
                    s.Append("'#9CAAB9'")
                ElseIf dt.Rows(i)("dcresposta") = "Ruim" Then
                    s.Append("'#9B59B6'")
                ElseIf dt.Rows(i)("dcresposta") = "Muito Ruim" Then
                    s.Append("'#47EBE0'")
                End If

                If i < dt.Rows.Count - 1 Then
                    s.Append(",")
                End If

            Next

            s.AppendLine("]")

            s.AppendLine("}]")
            s.AppendLine("};")

            s.AppendLine("var doughnutOptions = { responsive: true };")
            s.AppendLine("var ctx1 = document.getElementById('doughnutChartIndividual').getContext('2d');")
            s.AppendLine("new Chart(ctx1, {type: 'doughnut', data: doughnutData, options: doughnutOptions});")
            s.AppendLine("});")


            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "graficoChart", s.ToString(), True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "escondeGrafico", "$('#doughnutChartIndividual').show();", True)

        Else

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "escondeGrafico", "$('#doughnutChartIndividual').hide();", True)

            Dim titulo As String
            Dim tempo As Integer

            titulo = "ERRO"

            tempo = 2000
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "congratz", "mensagem('<b>" & titulo & "</b>','error','<b>" & frase & "</b>'," & tempo & ",'350px','fa fa-solid fa-exclamation-circle');", True)
        End If

    End Sub


End Class