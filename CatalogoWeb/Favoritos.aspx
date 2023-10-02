<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="CatalogoWeb.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mis favoritos:</h1>
    <br />
    <asp:GridView ID="gvFavoritos" runat="server" CssClass="table" AutoGenerateColumns="false" PageSize="5"
        OnSelectedIndexChanged="gvFavoritos_SelectedIndexChanged" DataKeyNames="IdArticulo" AllowPaging="true" 
        OnPageIndexChanging="gvFavoritos_PageIndexChanging" OnRowCommand="gvFavoritos_RowCommand">
        <columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:CommandField HeaderText="Acción" SelectText="Ver mas" ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary"/>
            <asp:ButtonField Text="Eliminar" ButtonType="Button" ControlStyle-CssClass="btn btn-danger"
                CommandName="eliminar"/>
        </columns>
    </asp:GridView>

</asp:Content>
