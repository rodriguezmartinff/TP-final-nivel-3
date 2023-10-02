<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="CatalogoWeb.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validar{
            color: red;
            font-size: 14px;
        }
    </style>
    <script>    
        function validar() {
            const txtEmail = document.getElementById("txtEmail");
            const txtPass = document.getElementById("txtPass");
            const txtRepPass = document.getElementById("txtRepPass");
            const lblMensaje = document.getElementById("lblMensaje");

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

            if (txtRepPass.value == "") {
                txtRepPass.classList.remove("is-valid");
                txtRepPass.classList.add("is-invalid");
                resultado = false;
            } else {
                txtRepPass.classList.remove("is-invalid");
                txtRepPass.classList.add("is-valid");
            }

            return resultado;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Nuevo usuario</h2>
    <br />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label>Ingrese e-mail:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" ClientIDMode="Static"/>
                <asp:RegularExpressionValidator ErrorMessage="Formato email porfavor" CssClass="validar" ControlToValidate="txtEmail" runat="server" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"/>
            </div>
            <div class="mb-3">
                <label>Ingrese contraseña:</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" ClientIDMode="Static" TextMode="Password"/>
            </div>
            <div class="mb-3">
                <label>Repita contraseña:</label>
                <asp:TextBox runat="server" ID="txtRepPass" CssClass="form-control" ClientIDMode="Static" TextMode="Password" />
            </div>
            <asp:Button Text="Aceptar" ID="btnAceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click" OnClientClick="return validar()"/>
            <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" CssClass="btn btn-secondary" OnClick="btnCancelar_Click"/>
            <asp:Label Text="" runat="server" id="lblMensaje" ClientIDMode="Static" CssClass="validar"/>
        </div>
    </div>

</asp:Content>
