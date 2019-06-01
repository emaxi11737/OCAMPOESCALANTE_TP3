<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaError.aspx.cs" Inherits="Escalante_TP3.PaginaError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ERROR</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>UPS!</h1>
        <div>
    <p>Ha ocurrido un error..</p>
    <asp:Button ID="Volver" class="btn btn-danger" runat="server" Text="Página principal" OnClick="Volver_Click" />
        </div>
    </form>
    
</body>
</html>
