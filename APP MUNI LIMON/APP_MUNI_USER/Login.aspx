<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bienvenido a las Actividades Municipalidad Limón</title>
    <link href="Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 158px;
        }

        .auto-style2 {
            width: auto;
            height: 210px;
        }
    </style>
</head>
<body>
    <ul class="topnav1">
        <!--<li><a href="MenuActividades">Menú</a></li>-->
    </ul>
    <ul class="topnav2">
        <!--<li><a href="MenuActividades">Menú</a></li>-->
    </ul>
    <form id="form1" runat="server" style="width: auto; height:462px">
        <fieldset style="margin-left: 470px; margin-top: 100px; width: 550px; height: 330px; background: #EFEFEF">
            <h2 class="fs-title">Municipalidad de Limón</h2>
            <br />
            <asp:TextBox ID="correoUsuario" runat="server" Width="350px" placeholder="Correo electronico" TextMode="Email"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtContraseña" runat="server" Width="350px" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="next action-button" OnClick="btnIngresar_Click" />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="next action-button" OnClick="btnRegistrar_Click" />
        </fieldset>
    </form>
    <ul class="topnav2"></ul>
    <ul class="topnav1"></ul>
</body>
</html>
