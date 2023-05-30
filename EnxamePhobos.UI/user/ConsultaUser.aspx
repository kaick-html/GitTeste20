<%@ Page Title="" Language="C#" MasterPageFile="~/user/DefaultUser.Master" AutoEventWireup="true" CodeBehind="ConsultaUser.aspx.cs" Inherits="EnxamePhobos.UI.user.ConsultaUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" >
        <Columns>

            <asp:BoundField DataField="Id" HeaderText="Código" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Senha" HeaderText="Senha" DataFormatString="******" />
            <asp:BoundField DataField="DataNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissão" />




        </Columns>
    </asp:GridView>

</asp:Content>
