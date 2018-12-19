<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Estilos/Diseño.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 306px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
        <h2 class="fs-title">Hotel montaña</h2>
        <h3 class="fs-subtitle">Login</h3>
        <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario"></asp:TextBox>
        <asp:TextBox type="password" ID="txtContraseña" runat="server" placeholder="Contraseña" ></asp:TextBox>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="next action-button"/>
    </fieldset>
    </form>
</body>
</html>
