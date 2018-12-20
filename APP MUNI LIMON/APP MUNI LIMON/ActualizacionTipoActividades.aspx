<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActualizacionTipoActividades.aspx.cs" Inherits="ActualizacionTipoActividades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Actualización de Tipo de Actividad</title>
 <link href="Estilos/Navbar.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         <ul class="topnav">
           <!--<li><a href="MenuActividades">Menú</a></li>-->
            <li><a>Menú</a></li>
            <li><a>Noticias</a></li>
            <li><a>Actividades</a></li>
            <li><a>Estadisticas</a></li>
            <li><a>Sugerencias</a></li>
            <li><a>Inscripciones</a></li>
       </ul>
        <fieldset>
           <h2 class="fs-title">Actualizar Tipos de Actividades</h2>
             <asp:DropDownList ID="tipoActividades" runat="server" CssClass="mydropdownlist">
               <asp:ListItem>--Seleccione el tipo de actividad--</asp:ListItem>
               <asp:ListItem>Tipo de Actividad 1</asp:ListItem>
               <asp:ListItem>Tipo de Actividad 2</asp:ListItem>
           </asp:DropDownList>
           <asp:TextBox ID="nombreTipoActividad" runat="server" placeholder="Nombre del tipo de Actividad"></asp:TextBox>
            <asp:TextBox ID="descripcionTipoActividad" runat="server" placeholder="Descripción del tipo de actividad"></asp:TextBox>
           <br />
           <asp:Button ID="registrarTipoActividad" runat="server" Text="Registrar" class="next action-button" width="300px"/>
       </fieldset>
    </form>
</body>
</html>
</html>
