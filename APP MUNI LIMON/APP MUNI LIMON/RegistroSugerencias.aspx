<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroSugerencias.aspx.cs" Inherits="RegistroSugerencias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Sugerencias</title>
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
           <h2 class="fs-title">Registro de Sugerencias</h2>
           <asp:TextBox ID="telefono" runat="server" placeholder="Telefono" TextMode="Phone"></asp:TextBox>
            <br />
            <br />
           <asp:TextBox ID="correo" runat="server" placeholder="Correo Electronico" TextMode="Email"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Tipo de Tramite"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="tipoTramite" runat="server">
                <asp:ListItem Text="Planilla"></asp:ListItem>
                <asp:ListItem Text="Patentes"></asp:ListItem>
                <asp:ListItem Text="Planilla"></asp:ListItem>
                <asp:ListItem Text="Ventanilla"></asp:ListItem>
                <asp:ListItem Text="Servicio al Cliente"></asp:ListItem>
                <asp:ListItem Text="Servicios Públicos"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:CheckBox ID="isAnonima" runat="server" Text="Valoración Anonima" Width="350px" OnCheckedChanged="anonimato"/>
            <br />
            <br />
            <br />
           <h2 class="fs-title">Valoración</h2>
            <br />
            <div style="padding-left:350px">
                <asp:RadioButtonList ID="valoraciones" runat="server" Width="226px">
                <asp:ListItem Text="  1 Estrella" ></asp:ListItem>
                <asp:ListItem Text="2 Estrellas" ></asp:ListItem>
                <asp:ListItem Text="3 Estrellas" ></asp:ListItem>
                <asp:ListItem Text="4 Estrellas" ></asp:ListItem>
                <asp:ListItem Text="5 Estrellas" ></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <br />
            <asp:TextBox ID="descripcion" runat="server" placeholder="Describe tu experiencia" TextMode="MultiLine" Height="173px" Width="509px"></asp:TextBox>
            <br />
            <br />
           <asp:Button ID="registrarSugerencia" runat="server" Text="Registrar" class="next action-button" width="300px" OnClick="registrarSugerencia_Click"/>
       </fieldset>
    </form>
</body>
</html>
