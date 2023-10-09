<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="CatalogoWeb.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validar {
            color: red;
            font-size: 13px;
        }
    </style>
    <script>
        function validar() {
            const txtEmail = document.getElementById("txtEmail");
            const txtPass = document.getElementById("txtContraseña");
            var resultado = new Boolean(true);

            if (txtEmail.value == "") {
                txtEmail.classList.remove("is-valid");
                txtEmail.classList.add("is-invalid");
                resultado = false;
            } else {
                txtEmail.classList.remove("is-invalid");
                txtEmail.classList.add("is-valid");
            }

            if (txtPass.value == "") {
                txtPass.classList.remove("is-valid");
                txtPass.classList.add("is-invalid");
                resultado = false;
            } else {
                txtPass.classList.remove("is-invalid");
                txtPass.classList.add("is-valid");
            }

            return resultado;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Mi perfil:</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label>Id:</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" />
            </div>
            <div>
                <label>Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" ClientIDMode="Static" />
                <asp:RegularExpressionValidator ErrorMessage="Formato email por favor" CssClass="validar" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <label>Contraseña:</label>
                <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" ClientIDMode="Static" />
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
            <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" OnClientClick="return validar()" />
            <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />
            <%}
                else
                {%>
            <asp:Button Text="Editar" runat="server" ID="btnEditar" CssClass="btn btn-primary" OnClick="btnEditar_Click" />
            <%} %>
        </div>

        <div class="col-6">

            <div class="mb-3">
                <label>Imagen de perfil:</label>
                <input type="file" id="txtImagenLocal" class="form-control" runat="server" />
            </div>

            <asp:Image runat="server" ID="imgImagen" Style="width: 350px; height: 350px; object-fit: contain;" onerror="this.src='https://wintechnology.co/wp-content/uploads/2021/11/imagen-no-disponible.jpg'"></asp:Image>


        </div>
    </div>
</asp:Content>
