<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="Escalante_TP3.Premios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table width="1000" border="0" cellpadding="5">


        <tr>

            <td align="center" valign="center">
                <img src="./Imagenes/1.jpg" width="1000" height="600" alt="Silla Gamer">
                <asp:Button ID="Silla" class="btn btn-primary" runat="server" Text="Quiero la silla" OnClick="Silla_Click" />
            </td>

            <td align="center" valign="center">
                <img src="./Imagenes/4.jpg" width="1000" height="600" alt="GTX 1080 TI">
                <asp:Button ID="Placa" class="btn btn-primary" runat="server" Text="Quiero la placa de video" OnClick="Placa_Click" />
            </td>
            <td align="center" valign="center">
                <img src="./Imagenes/3.jpg" width="1000" height="600" alt="AMD Threadripper">
                <asp:Button ID="Procesador" class="btn btn-primary" runat="server" Text="Quiero el procesador" OnClick="Procesador_Click" />
            </td>

        </tr>




    </table>






</asp:Content>
