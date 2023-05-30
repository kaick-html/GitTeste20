<%@ Page Title="" Language="C#" MasterPageFile="~/user/DefaultUser.Master" AutoEventWireup="true" CodeBehind="ConsultaFilme.aspx.cs" Inherits="EnxamePhobos.UI.user.ConsultaFilme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" >
        <Columns>

            <asp:BoundField DataField="Id" HeaderText="Código" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo do filme" />
            <asp:BoundField DataField="Produtora" HeaderText="produtora" />
            <asp:BoundField DataField="UrlImg" HeaderText="URl da imagem"  />
            <asp:BoundField DataField="Genero_Id" HeaderText="Gênero" />
            <asp:BoundField DataField="Classificacao_Id" HeaderText="Classificação" />
            <asp:ImageField DataImageUrlField="UrlImg" HeaderText="imagem" />



        </Columns>
    </asp:GridView>







</asp:Content>
