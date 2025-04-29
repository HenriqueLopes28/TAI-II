<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="principal.aspx.vb" Inherits="SOL_TAI.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="content/bootstrap.min.css" rel="stylesheet" />
    <link href="content/Site.css" rel="stylesheet" />
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
                        <h1 class="fs-1 fw-bold text-light">InsightFlow</h1>
                    </div>
                </div>
                <div class="d-flex">
                    <asp:Button ID="BtnEscola" runat="server" CssClass="btn btn-secondary fw-bold me-3 px-3 py-2" Text="Perguntas sobre Escola" />
                    <asp:Button ID="BtnProfessor" runat="server" CssClass="btn btn-secondary me-3 fw-bold" Text="Perguntas sobre Professor" />
                    <asp:Button ID="BtnSair" runat="server" CssClass="btn btn-secondary me-3 fw-bold" Text="Sair" />
                </div>
            </nav>
        </header>

        <asp:Panel runat="server" ID="PnlAlunoProfessor" Visible="False">

            <!-- Panel Aluno / Professor -->

            <asp:Panel ID="PnlPerguntasProfessor" runat="server" Visible="False">

                <div class="row pt-5">
                    <div class="col md-6 mb-4">
                    </div>
                    <div class="col-lg-10">
                        <div class="card p-4 shadow-sm">
                            <h5 class="card-title fs-2 fw-bold">O que é o InsightFlow?</h5>
                            <h6 class="pt-2">Avaliação anônima para transformar a realidade escolar</h6>
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
                                                        <asp:RadioButton ID="rbAvaliacaoAspectoGeral1" runat="server" GroupName="rbAspectoGeral" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bom" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbAvaliacaoAspectoGeral2" runat="server" GroupName="rbAspectoGeral" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Regular" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbAvaliacaoAspectoGeral3" runat="server" GroupName="rbAspectoGeral" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ruim" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbAvaliacaoAspectoGeral4" runat="server" GroupName="rbAspectoGeral" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Muito Ruim" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbAvaliacaoAspectoGeral5" runat="server" GroupName="rbAspectoGeral" />
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
            </asp:Panel>

            <asp:Panel ID="PnlPerguntasEscola" runat="server" Visible="False">
                <!-- Perguntas Escola -->
                <p>teste perguntas escola</p>
            </asp:Panel>

        </asp:Panel>


        <asp:Panel runat="server" ID="PnlDiretor" Visible="False">

            <!-- Panel Diretor -->
            <asp:Panel ID="PnlRespostasProfessor" runat="server" Visible="False">
                <!-- Respostas Professor -->
                <p>teste diretor respostas professor</p>

            </asp:Panel>

            <asp:Panel ID="PnlRespostasEscola" runat="server" Visible="False">
                <!-- Respostas Escola -->
                <p>teste diretor respostas escola</p>
            </asp:Panel>

        </asp:Panel>

        <script src="scripts/bootstrap.js"></script>
        <script src="scripts/bootstrap.min.js"></script>
        <script src="scripts/jquery-3.7.0.min.js"></script>
        <script src="scripts/jquery-3.7.0.slim.js"></script>
    </form>
</body>
</html>
