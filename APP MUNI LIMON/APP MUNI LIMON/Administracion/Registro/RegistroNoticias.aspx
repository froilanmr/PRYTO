﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroNoticias.aspx.cs" Inherits="RegistroNoticias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Noticias</title>
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
           <h2 class="fs-title">Registro de Noticias</h2>
           <asp:TextBox ID="tituloNoticia" runat="server" placeholder="Titulo de Noticia"></asp:TextBox>
            <br />
           <asp:TextBox ID="descripcionNoticia" runat="server" placeholder="Descripción Noticia" Height="295px" TextMode="MultiLine" Width="724px"></asp:TextBox>
           <h4 class="fs-title">Galería</h4>
           <asp:FileUpload ID="galeriaNoticia" runat="server" placeholder="Galería" AllowMultiple="True" accept=".png,.jpg,.jpeg,.gif"></asp:FileUpload>
           <br />
           <asp:Button ID="registrarNoticia" runat="server" Text="Registrar" class="next action-button" width="300px" OnClick="registrarNoticia_Click"/>
       </fieldset>
    </form>
</body>
</html>
