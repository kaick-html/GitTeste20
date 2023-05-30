<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="EnxamePhobos.UI.adm.ManageUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Label ID="lblMessage" runat="server" Text="Manage User" CssClass="lblTitulo" ></asp:Label>
    <%-- formulario --%>



    <ul>

         <li class="liCadastro"> 

            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by Name: " CssClass="barraSearch" ></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search"  OnClick="btnSearch_Click" CssClass="btnDefault" />
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>

        <li CssClass="liCadastro">
            <asp:TextBox ID="txtId" runat="server" placeholder="Id:" CssClass="txtBox" ></asp:TextBox>
        </li>

        <li CssClass="liCadastro" >
            <asp:TextBox ID="txtNome" runat="server" placeholder="Nome:" CssClass="txtBox" ></asp:TextBox>
            <asp:Label ID="lblNome" runat="server" Text="" CssClass="lbl" ></asp:Label>

        </li>

        <li CssClass="liCadastro" >
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email:" CssClass="txtBox" ></asp:TextBox>
            <asp:Label ID="lblEmail" runat="server" Text="" CssClass="lbl" ></asp:Label>

        </li>

        <li CssClass="liCadastro" >
            <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha:" MaxLength="6" CssClass="txtBox" ></asp:TextBox>
            <asp:Label ID="lblSenha" runat="server" Text="" CssClass="lbl" ></asp:Label>

        </li>

        <li CssClass="liCadastro" >
            <asp:TextBox ID="txtDtNasc" runat="server" placeholder="Data de Nascimento:" onkeypress="$(this).mask('00/00/0000')" CssClass="txtBox" ></asp:TextBox>
            <asp:Label ID="lblDtNasc" runat="server" Text="" CssClass="lbl" ></asp:Label>

        </li>

        <li>
            <asp:DropDownList 
                ID="ddl1" 
                runat="server" 
                width="160px" 
                Height="27px" 
                AutoPostBack="false" 
                DataValueField="Id" 
                DataTextField="Descricao" 
                CssClas="dropDown"
                >

            </asp:DropDownList>
        </li>

        <li>

            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" CssClass="btnDefault" />

            <asp:Button ID="btnLimpar" runat="server" Text="Clear"  OnClick="btnLimpar_Click" CssClass="btnDefault" />

            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja mesmo eliminar esse registro?'))return false" CssClass="btnDefault" />
        </li>

       

    </ul>



    <%-- gridView --%>
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gv1_SelectedIndexChanged" CssClass="gridView"  >
        <Columns >
            <asp:CommandField ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Código"/>
            <asp:BoundField DataField="Nome" HeaderText="Nome"/>
            <asp:BoundField DataField="Email" HeaderText="Email"/>
            <asp:BoundField DataField="Senha" HeaderText="Senha"/>
            <asp:BoundField DataField="DataNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissão"/>




        </Columns>
    </asp:GridView>



</asp:Content>
