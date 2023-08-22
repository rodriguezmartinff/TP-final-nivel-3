<%@ Page Title="Lista" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="CatalogoWeb.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de articulos:</h1>
    <%if (Session["usuario"] == null)
        { %>
    <asp:GridView ID="gvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false" PageSize="5"
        OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged" DataKeyNames="Id" AllowPaging="true" OnPageIndexChanging="gvArticulos_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" SelectText="Ver mas" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
    <%}
    else
    { %>
    <asp:GridView ID="gvArticulosLogin" runat="server" CssClass="table" AutoGenerateColumns="false" PageSize="5"
        OnSelectedIndexChanged="gvArticulosLogin_SelectedIndexChanged" DataKeyNames="Id" AllowPaging="true" OnPageIndexChanging="gvArticulosLogin_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" SelectText="Editar/Eliminar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
    <%} %>
    <a href="AgregarEditar.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
