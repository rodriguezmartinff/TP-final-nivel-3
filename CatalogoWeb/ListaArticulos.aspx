<%@ Page Title="Lista" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="CatalogoWeb.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validar{
            color: red;
            font-size: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de articulos:</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Buscar por nombre" runat="server" />
                <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" />
            </div>
        </div>

        <div class="col-6">
            <br />
            <asp:CheckBox Text="Filtro avanzado" ID="cbFiltroAvanzado" runat="server" AutoPostBack="true"
                OnCheckedChanged="cbFiltroAvanzado_CheckedChanged" />
        </div>
    </div>

    <%if (FiltroAvanzado)
        { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo"
                    OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Categoria" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" ID="lblCriterio" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCriterio" />
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" ID="lblFiltro" runat="server" />
                <asp:TextBox ID="txtFiltroAvanzado" runat="server" CssClass="form-control" />
                <asp:Label Text="" ID="lblValidacion" runat="server" CssClass="validar"/>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <br />
                <asp:Button ID="btnBusquedaAvanzada" runat="server" CssClass="btn btn-primary"
                    Text="Buscar" OnClick="btnBusquedaAvanzada_Click" />
            </div>
        </div>
    </div>
    <%}
%>

    <%if (UsuarioTipo == TipoUsuario.ADMIN){ %>
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
            <a href="AgregarEditar.aspx" class="btn btn-primary">Agregar</a>

    <%}else{%>
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
    <%}%>
</asp:Content>
