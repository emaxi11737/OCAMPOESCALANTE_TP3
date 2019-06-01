<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Datos.aspx.cs" Inherits="Escalante_TP3.Datos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group row">
        <label for="example-number-input" class="col-2 col-form-label">DNI</label>
        <div class="col-10">
            <asp:TextBox CssClass="form-control" ID="txtDNI" runat="server" OnTextChanged="txtDNI_TextChanged"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="txtNombre" class="col-2 col-form-label">Nombre</label>
        <div class="col-10">
            <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
        </div>
        <label for="txtApellido" class="col-2 col-form-label">Apellido</label>
        <div class="col-10">
            <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="txtEmail" class="col-2 col-form-label">Email</label>
        <div class="col-10">
            <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="txtDireccion" class="col-2 col-form-label">Direccion</label>
        <div class="col-10">
            <asp:TextBox CssClass="form-control" ID="txtDireccion" runat="server"></asp:TextBox>
        </div>
    </div>
    <div>
        <asp:Button id="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click" runat="server"/>
    </div>
    
</asp:Content>
