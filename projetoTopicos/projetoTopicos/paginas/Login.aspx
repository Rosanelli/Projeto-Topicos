<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="projetoTopicos.paginas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <%--<link href="~/estilos/estilo.css" media="screen" rel="stylesheet" type="text/css" />--%>
    <link href="~/bootstrap_files/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/bootstrap_files/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="~/bootstrap_files/css/theme.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <div class="login">
            <h1>Sistema de Bonificação</h1>
            <div>
                <legend></legend>

                <asp:TextBox ID="txtUsuario" class="form-control" PlaceHolder="Usuário" Width="220px" runat="server" />
                <br />
                <asp:TextBox ID="txtSenha" class="form-control" PlaceHolder="Senha" Width="220px" TextMode="Password" runat="server" />
                <br />
                <br />
                <asp:Button ID="btnLogin" class="btn btn-lg btn-primary" Text="Acessar" OnClick="btnLogin_Click" runat="server" />
            </div>
        </div>

    </form>
</body>

</html>
