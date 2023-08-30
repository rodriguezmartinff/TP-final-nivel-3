<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="CatalogoWeb.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi perfil:</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label>Id:</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Contraseña:</label>
                <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Apellido:</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>
            <%if (Editar)
                {%>
            <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" cssclass="btn btn-primary"/>
            <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />
            <%}
            else
            {%>
            <asp:Button Text="Editar" runat="server" ID="btnEditar" CssClass="btn btn-primary" OnClick="btnEditar_Click" />
            <%} %>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label>Url imagen de perfil:</label>
                <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control" OnTextChanged="txtImagen_TextChanged" AutoPostBack="true"/> 
            </div>
            <asp:Image runat="server" ID="imgImagen" Style="width: 350px; height: 350px; object-fit: contain;" onerror="this.src='https://wintechnology.co/wp-content/uploads/2021/11/imagen-no-disponible.jpg'"></asp:Image>
            <%--<img src="<%ImagenUrl%>" onerror="this.src='https://wintechnology.co/wp-content/uploads/2021/11/imagen-no-disponible.jpg'"/>--%>
            <%--<img src="<%ImagenUrl%>" onerror="this.src='https://wintechnology.co/wp-content/uploads/2021/11/imagen-no-disponible.jpg'" class="card-img-top" alt="..." Style="max-width: 325px; height: 325px; object-fit: contain;">--%>
        </div>
    </div>
</asp:Content>
