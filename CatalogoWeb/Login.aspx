<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CatalogoWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ingresar</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label class="form-label">Email:</label>
                <asp:TextBox runat="server" id="txtEmail" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña:</label>
                <asp:TextBox runat="server" id="txtPass" CssClass="form-control"/>
            </div>
            <asp:Button Text="Aceptar" cssclass="btn btn-primary" runat="server" id="btnAceptar" OnClick="btnAceptar_Click"/>
            <asp:Button Text="Cancelar" CssClass="btn btn-secondary" runat="server" id="btnCancelar" OnClick="btnCancelar_Click"/>
            <asp:Label Text="" ID="lblMensaje" class="form-label" runat="server" />
        </div>
    </div>
</asp:Content>
