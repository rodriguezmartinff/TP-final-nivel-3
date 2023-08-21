<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarEditar.aspx.cs" Inherits="CatalogoWeb.AgregarEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <h1>Agregar nuevo articulo:</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id Articulo</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo:</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca:</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria:</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio:</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click"/>
            <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click"/>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion:</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url imagen:</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            OnTextChanged="txtImagenUrl_TextChanged" AutoPostBack="true" />
                    </div>
                    <asp:Image ImageUrl="https://wintechnology.co/wp-content/uploads/2021/11/imagen-no-disponible.jpg"
                        ID="imgArticulo" runat="server" Style="width: 350px; height: 350px; object-fit: contain;" />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
