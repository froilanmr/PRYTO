<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroTipoActividades.aspx.cs" Inherits="RegistroTipoActividades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Tipos de Actividad</title>
    <link href="Estilos/Navbar.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         <ul class="topnav1">
           <!--<li><a href="MenuActividades">Menú</a></li>-->
       </ul>
         <ul class="topnav2">
           <!--<li><a href="MenuActividades">Menú</a></li>-->
       </ul>
         <ul class="topnav">
           <!--<li><a href="MenuActividades">Menú</a></li>-->
            <li><a>Perfil</a></li>
            <li><a>Log in</a></li>
            <li><a>Actividades</a></li>
            <li><a>Estadisticas</a></li>
            <li><a>Sugerencias</a></li>
            <li><a>Inscripciones</a></li>
            <li><a>Noticias</a></li>
            <li><a>Menú</a></li>
            
       </ul>
        <fieldset>
           <h2 class="fs-title">Registro de Tipos de Actividades</h2>
           <asp:TextBox ID="nombreTipoActividad" runat="server" placeholder="Nombre del tipo de Actividad"></asp:TextBox>
            <br />
            <asp:TextBox ID="descripcionTipoActividad" runat="server" placeholder="Descripción del tipo de actividad" Height="165px" TextMode="MultiLine" Width="405px"></asp:TextBox>
            <br />
            <br />
           <br />
           <asp:Button ID="registrarTipoActividad" runat="server" Text="Registrar" class="next action-button" width="300px" OnClick="registrarTipoActividad_Click"/>
       </fieldset>
    </form>
</body>
</html>
