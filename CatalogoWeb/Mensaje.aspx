<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="CatalogoWeb.Mensaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label Text="" runat="server" id="lblMensaje"/>
    <asp:Button Text="Aceptar" runat="server" id="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary"/>
</asp:Content>
