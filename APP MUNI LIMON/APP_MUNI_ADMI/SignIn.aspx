<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro - Actividades Municipalidad Limón</title>
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
    <div style="margin-left: 38%; margin-top:10px">
        <asp:Label ID="Label5" runat="server" Text="Registro de Usuarios" Font-Bold="True" Font-Names="Arial" Font-Size="XX-Large"></asp:Label>
    </div>
    <form id="form1" runat="server" style="width: auto">
        <fieldset style="margin-left: 450px; margin-top: 50px; width: 600px; height: 436px; background: #EFEFEF">
            <h2 class="fs-title">Municipalidad de Limón</h2>
            <br />
            <asp:TextBox ID="nombre" runat="server" Width="350px" placeholder="Nombre y Apellidos"></asp:TextBox>
            <br />
            <asp:TextBox ID="correo" runat="server" Width="350px" placeholder="Correo electronico" TextMode="Email"></asp:TextBox>
            <br />
            <asp:TextBox ID="contraseña" runat="server" Width="350px" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
            <br />
            <asp:TextBox ID="telefono" runat="server" Width="350px" placeholder="Teléfono" TextMode="Phone"></asp:TextBox>
            <br />
            <asp:Button ID="btnIngresar" runat="server" Text="Registrarse" class="next action-button" OnClick="btnIngresar_Click" />
            <asp:Button ID="btnAtras" runat="server" Text="Volver" class="next action-button" OnClick="btnAtras_Click" />
            
            <div style="padding-top:10px; padding-left:59%; height:0px">
                <asp:Label ID="Label7" runat="server" Text="Actividades Municipalidad Limón" Font-Bold="True" Font-Size="Small"></asp:Label>
            </div>
        </fieldset>
    </form>
    <ul class="topnav2"></ul>
    <ul class="topnav1"></ul>
</body>
</html>
