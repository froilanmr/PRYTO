<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActualizacionNoticias.aspx.cs" Inherits="ActualizacionNoticias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Actualización de Noticias</title>
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
           <h2 class="fs-title">Registro de Noticias</h2>
             <asp:DropDownList ID="noticias" runat="server" CssClass="mydropdownlist">
               <asp:ListItem>--Seleccione la noticia a actualizar--</asp:ListItem>
               <asp:ListItem>Noticia 1</asp:ListItem>
               <asp:ListItem>Noticia 2</asp:ListItem>
           </asp:DropDownList>
           <asp:TextBox ID="tituloNoticia" runat="server" placeholder="Titulo de Noticia"></asp:TextBox>
           <asp:TextBox ID="descripcionNoticia" runat="server" placeholder="Descripción Noticia"></asp:TextBox>
           <h4 class="fs-title">Galería</h4>
           <asp:FileUpload ID="galeriaNoticia" runat="server" placeholder="Galería"></asp:FileUpload>
           <br />
           <asp:Button ID="registrarNoticia" runat="server" Text="Actualizar" class="next action-button" width="300px"/>
       </fieldset>
    </form>
</body>
</html>
