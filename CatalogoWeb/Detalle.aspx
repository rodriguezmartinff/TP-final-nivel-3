<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="CatalogoWeb.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalle del artículo:</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="lblId" class="form-label">Id articulo:</label>
                <asp:Label runat="server" Text="Label" ID="lblId" CssClass="form-control"></asp:Label>
            </div>
            <div class="mb-3">
                <label for="lblCodigo" class="form-label">Codigo:</label>
                <asp:Label runat="server" Text="Label" ID="lblCodigo" CssClass="form-control"></asp:Label>
            </div>
            <div class="mb-3">
                <label for="lblNombre" class="form-label">Nombre:</label>
                <asp:Label runat="server" Text="Label" ID="lblNombre" CssClass="form-control"></asp:Label>
            </div>
            <div class="mb-3">
                <label for="lblDescripcion" class="form-label">Descripcion:</label>
                <asp:Label runat="server" Text="Label" ID="lblDescripcion" CssClass="form-control"></asp:Label>
            </div>
            <div class="mb-3">
                <label for="lblMarca" class="form-label">Marca:</label>
                <asp:Label runat="server" Text="Label" ID="lblMarca" CssClass="form-control"></asp:Label>
            </div>
            <asp:Button Text="Agregar a favoritos" runat="server" CssClass="btn btn-primary" ID="btnAgregar" OnClick="btnAgregar_Click" />
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="lblCategoria" class="form-label">Categoria:</label>
                <asp:Label runat="server" Text="Label" ID="lblCategoria" CssClass="form-control"></asp:Label>
            </div>
            <div class="mb-3">
                <label for="lblPrecio" class="form-label">Precio:</label>
                <asp:Label runat="server" Text="Label" ID="lblPrecio" CssClass="form-control"></asp:Label>
            </div>
            <asp:Image runat="server" ID="imgImagen" Style="width: 350px; height: 350px; object-fit: contain;" onerror="this.src='https://wintechnology.co/wp-content/uploads/2021/11/imagen-no-disponible.jpg'"></asp:Image>
        </div>


    </div>
</asp:Content>
