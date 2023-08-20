<%@ Page Title="Lista" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="CatalogoWeb.ListaArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de articulos:</h1>
    <asp:Label Text="text" ID="lblPrueba" runat="server" />
    <asp:GridView ID="gvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false" PageSize="5" 
        OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" SelectText="Ver mas" ShowSelectButton="true"/>
        </Columns>
    </asp:GridView>

    <a href="AgregarEditar.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
