<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroActividades.aspx.cs" Inherits="RegistroActividades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Actividades</title>
     <link href="../../Estilos/Navbar.css" rel="stylesheet" type="text/css" />
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
           <h2 class="fs-title">Registro de Actividades</h2>
           <asp:TextBox ID="nombreActividad" runat="server" placeholder="Nombre de la Actividad"></asp:TextBox>
            <asp:DropDownList ID="tipoActividades" runat="server" CssClass="mydropdownlist">
               <asp:ListItem>--Seleccione el tipo de actividad--</asp:ListItem>
               <asp:ListItem>Tipo de Actividad 1</asp:ListItem>
               <asp:ListItem>Tipo de Actividad 2</asp:ListItem>
           </asp:DropDownList>
            <asp:TextBox ID="fechaActividad" runat="server" placeholder="Fecha de actividad dd\mm\aaaa"></asp:TextBox>
            <asp:TextBox ID="direccionActividad" runat="server" placeholder="Dirección de la actividad"></asp:TextBox>
            <asp:TextBox ID="descripcionActividad" runat="server" placeholder="Descripción de actividad"></asp:TextBox>
            <asp:TextBox ID="cuposActividad" runat="server" placeholder="Cupos Disponibles"></asp:TextBox>
           <h4 class="fs-title">Galería</h4>
           <asp:FileUpload ID="galeriaActividades" runat="server" placeholder="Galería"></asp:FileUpload>
           <br />
           <asp:Button ID="registrarNoticia" runat="server" Text="Registrar" class="next action-button" width="300px"/>
       </fieldset>
    </form>
</body>
</html>
