<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EnxamePhobos.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<%-- meuCSS --%>
    <link rel="stylesheet" href="resource/css/styleBack.css" />
    <title>login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divLogin">

            <ul >
                <li>
                    <asp:Label ID="lblMessage" runat="server" Text="EnxamePhobos" CssClass="lblTitulo">


                    </asp:Label>
                </li>

                <li>
                    <asp:TextBox ID="txtNome" runat="server" placeholder="Nome: " CssClass="txtBoxLogin" >

                    </asp:TextBox>

                </li>

                <li>
                    <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha: " CssClass="txtBoxLogin">

                    </asp:TextBox>

                </li>
                <li>
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" CssClass="btnDefaultLogin" />
                </li>

            </ul>

        </div>
    </form>
</body>
</html>
