<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="principal.aspx.vb" Inherits="SOL_TAI.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="content/bootstrap.min.css" rel="stylesheet" />
    <link href="content/Site.css" rel="stylesheet" />

    <link href="../web/Pnotify/animate.css" rel="stylesheet" />
    <link href="../web/Pnotify/pnotify.custom.min.css" rel="stylesheet" />

    <link rel="icon" type="image/png" href="img/logoteste.png" />
    <title>InsightFlow</title>

</head>

<body class="text-black" style="background-color: #cacaca; padding-top: 100px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <header class="fixed-top" style="background-color: #212529">
            <nav class="navbar navbar-expand-lg navbar-dark px-3 py-4">
                <div class="container-fluid">
                    <div class="d-flex align-items-center">
                        <img class="me-2" width="70" height="55" src="img/logoteste.png" />
                        <h1 class="fs-1 fw-bold text-light" id="titulo">InsightFlow</h1>
                    </div>
                </div>
                <div class="d-flex">
                    <asp:Button ID="BtnEscola" runat="server" CssClass="btn btn-secondary fw-bold me-3 px-3 py-2" Text="Perguntas sobre Escola" />
                    <asp:Button ID="BtnProfessor" runat="server" CssClass="btn btn-secondary me-3 fw-bold" Text="Perguntas sobre Professor" />
                    <asp:Button ID="BtnSair" runat="server" CssClass="btn btn-secondary me-3 fw-bold" Text="Sair" />
                </div>
            </nav>
        </header>

        <!-- Pagina inicial pos login -->

        <div id="DivTexto" runat="server" class="container py-5">
            <div class="row">
                <div class="col md-6 mb-4">
                    <div class="card p-4 shadow-sm">
                        <h5 class="card-title fs-2 fw-bold">O que é o InsightFlow?</h5>
                        <h6 class="pt-2">Avaliação anônima para transformar a realidade escolar</h6>
                        <p class="card-text pt-3">
                            O InsightFlow é uma plataforma criada para dar voz à comunidade escolar de forma segura, simples e totalmente anônima.
                    Aqui, alunos e professores podem compartilhar suas percepções sobre a escola, contribuindo diretamente para um ambiente mais acolhedor, 
                    eficiente e justo.
                   
                    <br />
                            <br />
                            Nosso foco está em ouvir quem vive o dia a dia escolar:
                        </p>
                        <ul>
                            <li>Alunos podem avaliar tanto a infraestrutura da escola (salas, banheiros, pátios, segurança, etc.) quanto seus professores, 
                        com base em critérios como respeito, clareza nas aulas e dedicação.
                            </li>
                            <li class="mt-3">Professores também participam, avaliando a estrutura física da escola e apontando pontos fortes e necessidades de melhoria.
                            </li>
                        </ul>
                        <p>
                            As avaliações são feitas de forma 100% anônima. Nenhuma resposta é associada ao nome, e nenhum avaliador pode ser identificado.
                  
                    <br />
                            Acreditamos que só com liberdade para se expressar é possível construir melhorias reais.
                        </p>
                    </div>
                </div>



                <div class="col md-6 mb-4">
                    <div class="card p-4 shadow-sm">
                        <h5 class="card-title fs-2 fw-bold">Para que serve a avaliação?</h5>
                        <h6 class="pt-2">Resultados claros para quem toma decisões</h6>
                        <p class="card-text pt-3">
                            As respostas coletadas são organizadas automaticamente e transformadas em relatórios simples e visualmente intuitivos, 
                    voltados para a equipe gestora da escola — especialmente o diretor.
                    Esses relatórios não mostram respostas individuais, apenas dados consolidados e gráficos que indicam os pontos de atenção e os destaques positivos.
                   <br />
                            <br />
                            Dessa forma, a equipe diretiva pode:
                        </p>
                        <ul>
                            <li>Identificar áreas da infraestrutura que precisam de manutenção ou melhorias;</li>
                            <li>Compreender a percepção dos alunos sobre os professores;</li>
                            <li>Valorizar boas práticas e bons profissionais;</li>
                            <li>Priorizar ações com base em dados reais e confiáveis.</li>
                        </ul>
                        <p>
                            Nosso compromisso é com a privacidade, a transparência e a melhoria contínua do ambiente educacional.
                    O InsightFlow não apenas coleta dados — ele abre espaço para uma cultura de escuta, respeito e evolução.
                        </p>

                    </div>
                </div>
            </div>
        </div>

        <asp:Panel runat="server" ID="PnlAlunoProfessor" Visible="False">

            <!-- Panel Aluno / Professor -->

            <asp:Panel ID="PnlPerguntasProfessor" runat="server" Visible="False">
                <div class="container-fluid overflow-hidden">
                    <div class="row pt-5">
                        <div class="col md-6 mb-4">
                        </div>
                        <div class="col-lg-10">
                            <div class="card p-4 shadow-sm">
                                <h5 class="card-title fs-2 fw-bold">Avaliação sobre os professores</h5>
                                <hr />
                                <asp:UpdatePanel ID="UpPergProfessor" runat="server">
                                    <ContentTemplate>
                                        <p class="card-text pt-3">
                                            <asp:DropDownList ID="DpProfessorSelecionado" CssClass="form-select" runat="server" AutoPostBack="true"></asp:DropDownList>

                                            <!-- Perguntas Professor -->
                                            <asp:GridView ID="GridPerguntaProfessor" HorizontalAlign="Center" CssClass="table table-hover f-12" GridLines="None" AutoGenerateColumns="False"
                                                DataKeyNames="id_pergunta" runat="server">
                                                <Columns>

                                                    <asp:BoundField DataField="pergunta" ItemStyle-HorizontalAlign="left" />
                                                    <asp:TemplateField HeaderText="Muito Bom" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao1" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bom" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao2" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Regular" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao3" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ruim" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao4" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Muito Ruim" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao5" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                            <div class="d-flex justify-content-end mt-3">
                                                <asp:Button ID="BtnSalvarRespostasProfessor" Text="Salvar" CssClass="btn btn-success fw-bold me-3 px-3 py-2" Visible="false" runat="server" />
                                            </div>
                                        </p>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="BtnSalvarRespostasProfessor" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
            </asp:Panel>

            <!-- Perguntas Escola -->
            <asp:Panel ID="PnlPerguntasEscola" runat="server" Visible="False">

                <div class="container-fluid overflow-hidden">
                    <div class="row pt-5">
                        <div class="col md-6 mb-4">
                        </div>
                        <div class="col-lg-10">
                            <div class="card p-4 shadow-sm">
                                <h5 class="card-title fs-2 fw-bold">Avaliação sobre a infraestrutura da escola</h5>
                                <hr />
                                <asp:UpdatePanel ID="UpPergEscola" runat="server">
                                    <ContentTemplate>
                                        <p class="card-text pt-3">

                                            <asp:GridView ID="GridPerguntasEscola" HorizontalAlign="Center" CssClass="table table-hover f-12" GridLines="None" AutoGenerateColumns="False"
                                                DataKeyNames="id_pergunta" runat="server">
                                                <Columns>

                                                    <asp:BoundField DataField="pergunta" ItemStyle-HorizontalAlign="left" />
                                                    <asp:TemplateField HeaderText="Muito Bom" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao1" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bom" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao2" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Regular" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao3" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ruim" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao4" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Muito Ruim" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rbAvaliacao5" runat="server" GroupName="rbAspectoGeral" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                            <div class="d-flex justify-content-end mt-3">
                                                <asp:Button ID="BtnSalvarRespostasEscola" Text="Salvar" CssClass="btn btn-success fw-bold me-3 px-3 py-2" Visible="false" runat="server" />
                                            </div>
                                        </p>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="BtnSalvarRespostasEscola" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
            </asp:Panel>

        </asp:Panel>




        <!-- Panel Diretor -->

        <asp:Panel ID="PnlRespostasProfessor" runat="server" Visible="False">
            <!-- Respostas Professor -->
            <div class="container-fluid overflow-hidden">
                <div class="row pt-5">
                    <div class="col md-6 mb-4">
                    </div>
                    <div class="col-lg-10">
                        <div class="card p-4 shadow-sm">
                            <h5 class="card-title fs-2 fw-bold">Selecione um professor para verificar sua avaliação</h5>
                            <hr />
                            <asp:UpdatePanel ID="UpNomeProf" runat="server">
                                <ContentTemplate>

                                    <p class="card-text pt-3">
                                        <asp:GridView ID="GridNomesProfessor" HorizontalAlign="Center" CssClass="table table-hover f-12" GridLines="None" AutoGenerateColumns="False"
                                            DataKeyNames="id_pessoa" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="nome" ItemStyle-HorizontalAlign="left" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Button ID="BtnExibirProfessor" CommandName="exibir" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CssClass="btn btn-secondary fw-bold me-3 px-3 py-2" Text="Exibir" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </p>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>



        </asp:Panel>

        <asp:Panel ID="PnlRespostasEscola" runat="server" Visible="False">
            <!-- Respostas Escola -->
            <div class="container-fluid overflow-hidden">
                <div class="row pt-5">
                    <div class="col md-6 mb-4">
                    </div>
                    <div class="col-lg-10">
                        <div class="card p-4 shadow-sm">
                            <h5 class="card-title fs-2 fw-bold">Selecione uma escola para verificar sua avaliação</h5>
                            <hr />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <p class="card-text pt-3">
                                        <asp:GridView ID="GridNomeEscola" HorizontalAlign="Center" CssClass="table table-hover f-12" GridLines="None" AutoGenerateColumns="False"
                                            DataKeyNames="id_escola" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="nome" ItemStyle-HorizontalAlign="left" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Button ID="BtnExibirEscola" CommandName="exibir" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CssClass="btn btn-secondary fw-bold me-3 px-3 py-2" Text="Exibir" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </p>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
        </asp:Panel>

        <div class="modal fade" id="modalResultados" tabindex="-1" aria-labelledby="modalResultadosLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered custom-modal-size">
                <div class="modal-content shadow-lg">
                    <div class="modal-header">
                        <h5 class="modal-title" id="TituloModal">Resultado do Professor: </h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Fechar"></button>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="LblResultadoProfessor" runat="server" Text=""></asp:Label>
                        <div class="d-flex justify-content-center">
                            <canvas id="doughnutChartIndividual" width="120" height="120"></canvas>
                        </div>

                        <!-- Grid aqui -->
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <p class="card-text pt-3">
                                    <asp:GridView ID="GridExibirDados" HorizontalAlign="Center" CssClass="table table-hover f-12" GridLines="None" AutoGenerateColumns="False"
                                        DataKeyNames="percentual" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="dcresposta" HeaderText ItemStyle-HorizontalAlign="left" />
                                            <asp:BoundField DataField="totalNumerico" ItemStyle-HorizontalAlign="left" />
                                        </Columns>
                                    </asp:GridView>
                                </p>
                            </ContentTemplate>
                        </asp:UpdatePanel>



                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>

        <script src="scripts/bootstrap.js"></script>
        <script src="scripts/jquery-3.7.0.min.js"></script>

        <script src="../web/jquery-ui.min.js"></script>

        <script src="../web/Pnotify/pnotify.custom.min.js"></script>

        <script src="../web/Notify/pnotify.buttons.js"></script>
        <script src="../web/Notify/pnotify.core.js"></script>
        <script src="../web/Notify/pnotify.nonblock.js"></script>

        <script src="../web/JsLocal.js"></script>

        <script src="https://kit.fontawesome.com/3ebeb577ef.js" crossorigin="anonymous"></script>

        <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    </form>
</body>
</html>
