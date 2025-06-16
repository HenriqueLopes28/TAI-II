<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="SOL_TAI.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="content/bootstrap.min.css" rel="stylesheet" />
    <link href="content/Site.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <asp:UpdatePanel ID="UpPagina" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-lg-6 col-sm-12">
                        <div class="alert alert-danger">
                            <asp:TextBox ID="TxtUser" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                    <div class="col-lg-6 col-sm-12">
                        <div class="alert alert-success">
                            <asp:Button ID="BtnLogin" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Login" />
                            Teste1
                        </div>
                    </div>
                   <%-- <div class="card" style="width: 18rem;">
                        <img src="..." class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">Card title</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>--%>
                    <asp:Panel ID="PnlEscola" runat="server">
                        teste
                teste
                teste
                tes

                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <script src="scripts/bootstrap.js"></script>
        <script src="scripts/bootstrap.min.js"></script>
        <script src="scripts/jquery-3.7.0.min.js"></script>
        <script src="scripts/jquery-3.7.0.slim.js"></script>
        <%--    <script src="scripts/modernizr-2.8.3.js"></script>
        <script src="scripts/bootstrap.bundle.js"></script>--%>
    </form>
</body>
</html>
