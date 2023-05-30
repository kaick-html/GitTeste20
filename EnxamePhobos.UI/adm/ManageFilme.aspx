<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageFilme.aspx.cs" Inherits="EnxamePhobos.UI.adm.ManageFilme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblMessage" runat="server" Text="Manage User" CssClass="lblTitulo"></asp:Label>



    <ul>
        <li class="liCadastro">

            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by Name: " CssClass="barraSearch"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btnDefault" />
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>

        <li class="liCadastro">

            <asp:TextBox ID="txtFiltro" runat="server" placeholder="Search by Gênero: " CssClass="barraSearch"></asp:TextBox>
            <asp:Button ID="btnFiltro" runat="server" Text="Search G" OnClick="btnFiltro_Click" CssClass="btnDefault" />
            <asp:Label ID="lblFiltro" runat="server" Text=""></asp:Label>
        </li>

        <li cssclass="liCadastro">
            <asp:TextBox ID="txtId" runat="server" placeholder="Id:" CssClass="txtBox"></asp:TextBox>
        </li>

        <li cssclass="liCadastro">
            <asp:TextBox ID="txtTitulo" runat="server" placeholder="Titulo:" CssClass="txtBox"></asp:TextBox>
            <asp:Label ID="lblTitulo" runat="server" Text="" CssClass="lbl"></asp:Label>

        </li>

        <li cssclass="liCadastro">
            <asp:TextBox ID="txtProdutora" runat="server" placeholder="Produtora:" CssClass="txtBox"></asp:TextBox>
            <asp:Label ID="lblProdutora" runat="server" Text="" CssClass="lbl"></asp:Label>

        </li>

        <li cssclass="liCadastro">
            <asp:FileUpload ID="fUp1" runat="server" Text="Selecione a imagem" CssClass="txtBox"></asp:FileUpload>
            <asp:Label ID="lblfUp1" runat="server" CssClass="lbl"></asp:Label>

        </li>

        <li>
            <asp:RadioButtonList ID="rbl1" runat="server">
                <asp:ListItem Value="1" Text="Livre" />
                <asp:ListItem Value="2" Text="+14"  />
                <asp:ListItem Value="3" Text="+18" />
            </asp:RadioButtonList>
            <asp:Label ID="lblClassificacao_Id" runat="server" Text="" ></asp:Label>
        </li>


        <li>
            <asp:DropDownList
                ID="ddl1"
                runat="server"
                Width="160px"
                Height="27px"
                AutoPostBack="false"
                DataValueField="Id"
                DataTextField="GeneroDescricao"
                CssClas="dropDown">
            </asp:DropDownList>
            <asp:Label ID="lblDDL" runat="server" Text="" ></asp:Label>
        </li>

        <li>

            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" CssClass="btnDefault" />

            <asp:Button ID="btnLimpar" runat="server" Text="Clear" OnClick="btnLimpar_Click" CssClass="btnDefault" />

            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja mesmo eliminar esse registro?'))return false" CssClass="btnDefault" />
        </li>

    </ul>


    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gv1_SelectedIndexChanged" CssClass="gridView">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo do filme" />
            <asp:BoundField DataField="Produtora" HeaderText="Produtora" />
            <asp:BoundField DataField="Genero_Id" HeaderText="Gênero" />
            <asp:BoundField DataField="Classificacao_Id" HeaderText="Classificação" />
            <asp:ImageField DataImageUrlField="UrlImg" HeaderText="Url da img" ControlStyle-Width="150" ControlStyle-Height="150" />






        </Columns>
    </asp:GridView>

</asp:Content>
