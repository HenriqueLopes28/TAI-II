<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="inicio.aspx.vb" Inherits="SOL_TAI.inicio" %>

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
                        <h1 class="fs-1 fw-bold text-light">InsightFlow</h1>
                    </div>
                </div>
                <div class="d-flex">
                    <asp:Button ID="BtnInicio" runat="server" CssClass="btn btn-secondary fw-bold me-3 px-3 py-2" Text="Inicio" />
                    <asp:Button ID="BtnQuemSomos" runat="server" CssClass="btn btn-secondary me-3 fw-bold" Text="Quem Somos" />
                    <asp:Button ID="BtnLogin" runat="server" CssClass="btn btn-secondary me-3 fw-bold" Text="Login" />
                </div>
            </nav>
        </header>


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


        <!-- Tela de Login -->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="PnlLogin" runat="server" Visible="false">
                    <div class="min-vh-80 d-flex justify-content-center">
                        <div class="d-flex align-items-center" style="height: 80vh;">
                            <div class="bg-white p-5 rounded shadow" style="width: 400px;">
                                <h4 class="text-center">Faça o Login</h4>
                                <div class="mt-5 text-center">
                                    <asp:TextBox ID="TextCodigo" runat="server" CssClass="form-control mb-3 mx-auto" placeholder="Digite seu código" Style="max-width: 300px;" />
                                </div>
                                <div class="text-center">
                                    <asp:Button ID="BtnLogar" runat="server" CssClass="btn btn-outline-dark rounded mx-auto" Text="Logar" Style="width: 150px;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>




        <!-- Tela de Quem Somos -->
        <asp:Panel ID="PnlQuemSomos" runat="server" Visible="false">
            <div class="m-4">
                <div class="row mb-4">
                    <div class="col-md-6">
                        <div class="card">
                            <img src="img/lipe.png" class="card-img img-fluid w-50 mx-auto mt-4" width="300" alt="Luiz Felipe Loro Piva" />
                            <div class="card-body">
                                <h5 class="card-title">Luiz Felipe Loro Piva</h5>
                                <p class="card-text">Estudante do Quinto período de Ciência da Computação na Pontifícia Universidade Católica em Poços de Caldas (PUC-MG).</p>
                                <h6 class="card-text fw-bold">Contato:</h6>
                                <a href="https://www.linkedin.com/in/luiz-felipe-loro-piva">https://www.linkedin.com/in/luiz-felipe-loro-piva</a>
                                <p>luizfelipepiva@gmail.com</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card">
                            <img src="img/flavio.png" class="card-img img-fluid w-50 mx-auto mt-4" width="300" alt="Flavio de Carvalho Cury" />
                            <div class="card-body">
                                <h5 class="card-title">Flavio de Carvalho Cury</h5>
                                <p class="card-text">Estudante do Quinto período de Ciência da Computação na Pontifícia Universidade Católica em Poços de Caldas (PUC-MG).</p>
                                <h6 class="card-text fw-bold">Contato:</h6>
                                <a href="https://www.linkedin.com/in/flavio-cury-2a31bb261/">https://www.linkedin.com/in/flavio-cury</a>
                                <p>flavioccury@gmail.com</p>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-6">
                        <div class="card">
                            <img src="img/henrique.png" class="card-img img-fluid w-50 mx-auto mt-4" width="300" alt="Henrique Luiz de Almeida Lopes" />
                            <div class="card-body">
                                <h5 class="card-title">Henrique Luiz de Almeida Lopes</h5>
                                <p class="card-text">Estudante do Quinto período de Ciência da Computação na Pontifícia Universidade Católica em Poços de Caldas (PUC-MG).</p>
                                <h6 class="card-text fw-bold">Contato:</h6>
                                <a href="https://www.linkedin.com/in/henrique-luiz-almeida-lopes/">https://www.linkedin.com/in/henrique-luiz-almeida-lopes</a>
                                <p>henriquelopes28@outlook.com</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card">
                            <img src="img/caio.png" class="card-img img-fluid w-50 mx-auto mt-4" width="300" alt="Caio Henrique de Paiva" />
                            <div class="card-body">
                                <h5 class="card-title">Caio Henrique de Carvalho Paiva</h5>
                                <p class="card-text">Estudante do Quinto período de Ciência da Computação na Pontifícia Universidade Católica em Poços de Caldas (PUC-MG).</p>
                                <h6 class="card-text fw-bold">Contato:</h6>
                                <a href="https://www.linkedin.com/in/caio-henrique-carvalho-de-paiva-133097230/">https://www.linkedin.com/in/caio-henrique-carvalho-de-paiva</a>
                                <p>caio.c.paiva07@gmail.com</p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>


        </asp:Panel>

        <script src="scripts/bootstrap.js"></script>
        <script src="scripts/jquery-3.7.0.min.js"></script>

        <script src="../web/Pnotify/pnotify.custom.min.js"></script>

        <script src="../web/Notify/pnotify.buttons.js"></script>
        <script src="../web/Notify/pnotify.core.js"></script>
        <script src="../web/Notify/pnotify.nonblock.js"></script>

        <script src="../web/JsLocal.js"></script>

        <script src="https://kit.fontawesome.com/3ebeb577ef.js" crossorigin="anonymous"></script>
    </form>
</body>
</html>
