<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarEditar.aspx.cs" Inherits="CatalogoWeb.AgregarEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Agregar nuevo articulo:</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id Articulo</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo:</label>
                <asp:TextBox runat="server" ID="txtCodigo" cssclass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" cssclass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label" >Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" cssclass="form-select">
                    <asp:ListItem Text="text1" />
                    <asp:ListItem Text="text2" />
                    <asp:ListItem Text="text3" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select">
                    <asp:ListItem Text="text1" />
                    <asp:ListItem Text="text2" />
                </asp:DropDownList>
            </div>
            <br />
            <asp:Button Text="Aceptar" runat="server" id="btnAceptar" CssClass="btn btn-primary"/>
            <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-secondary" />
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" cssclass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <asp:Image ImageUrl="https://wintechnology.co/wp-content/uploads/2021/11/imagen-no-disponible.jpg" id="imgArticulo" runat="server" style="width: 350px; height: 350px; object-fit:contain;"/>
        </div>
    </div>
</asp:Content>
