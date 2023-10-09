<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CatalogoWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 13px;
        }
    </style>
    <script>
        function Validar() {
            //capturar el control
            const txtPass = document.getElementById("txtPass");
            const txtEmail = document.getElementById("txtEmail");
            var resultado = new Boolean(true);
            if (txtPass.value == "") {
                txtPass.classList.remove("is-valid");
                txtPass.classList.add("is-invalid");
                resultado = false;
            } else {
                txtPass.classList.remove("is-invalid");
                txtPass.classList.add("is-valid");
            }

            if (txtEmail.value == "") {
                txtEmail.classList.remove("is-valid");
                txtEmail.classList.add("is-invalid")
                resultado = false;
            } else {
                txtEmail.classList.remove("is-invalid");
                txtEmail.classList.add("is-valid");
            }

            return resultado;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ingresar</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label class="form-label">Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" ClientIDMode="Static" />
                <asp:RequiredFieldValidator ErrorMessage="Campo requerido" CssClass="validacion" ControlToValidate="txtEmail" runat="server" ValidationGroup="Uno"/>
                <asp:RegularExpressionValidator ErrorMessage="Formato email por favor" CssClass="validacion" ControlToValidate="txtEmail" ValidationGroup="Uno" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPass">Contraseña:</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" ClientIDMode="Static" TextMode="Password"/>
                <label class="valid-feedback">
                    Se ve bien!
                </label>
                <label class="invalid-feedback">
                    Ingrese contraseña
                </label>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" CssClass="btn btn-primary" runat="server" ID="btnAceptar" OnClientClick="return Validar()" OnClick="btnAceptar_Click" ValidationGroup="Uno"/>
                <asp:Button Text="Cancelar" CssClass="btn btn-secondary" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" />
                <asp:Label Text="" ID="lblMensaje" class="form-label" runat="server" />
            </div>
            <div>
                <a href="Registrarse.aspx">Nuevo usuario...</a>
            </div>
        </div>
    </div>
</asp:Content>
