<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuActividades.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menú de Actividades - Administración</title>
    <link href="Estilos/Diseño2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <ul class="topnav">
            <img src="https://drive.google.com/file/d/1AxX9h1QDphzGvVrFRXtiC4-_vrEwiFy4/view?usp=sharing" alt="Logo" style="width:125px;height:135px;">
            <li><a href="frmLogin.aspx">Registrar información de clientes</a></li>
            <li><a href="#contact">Registrar usuario</a></li>
            <li><a href="#contact">Mantenimiento de habitaciones</a></li>
            <li class="right"><a href="frmLogin.aspx">Cerrar sesión</a></li> 
       </ul>
       <fieldset>
           <h2 class="fs-title">Ingrese los datos del nuevo cliente</h2>
           <asp:TextBox ID="txtCedulaCliente" runat="server" placeholder="Cédula del cliente"></asp:TextBox>
           <asp:TextBox ID="txtNumReserva" runat="server" placeholder="Número de reserva"></asp:TextBox>
           <asp:DropDownList ID="ddlTipoCliente" runat="server" CssClass="mydropdownlist">
               <asp:ListItem>--Seleccione el tipo de cliente--</asp:ListItem>
               <asp:ListItem>Jurídico</asp:ListItem>
               <asp:ListItem>Físico</asp:ListItem>
           </asp:DropDownList>
           <asp:TextBox ID="txtNomCliente" runat="server" placeholder="Nombre del cliente/Empresa"></asp:TextBox>
           <asp:TextBox ID="txtTel1" runat="server" placeholder="Teléfono 1"></asp:TextBox>
           <asp:TextBox ID="txtTel2" runat="server" placeholder="Teléfono 2"></asp:TextBox>
           <asp:TextBox ID="txtCorreo" runat="server" placeholder="Correo electrónico"></asp:TextBox>
           <asp:TextBox ID="txtProcedencia" runat="server" placeholder="Lugar de procedencia"></asp:TextBox>
           <asp:DropDownList ID="ddlPreferencia" runat="server" CssClass="mydropdownlist">
               <asp:ListItem>--Seleccione el tipo de preferencia--</asp:ListItem>
               <asp:ListItem>Vegano</asp:ListItem>
               <asp:ListItem>Vegetariano</asp:ListItem>
               <asp:ListItem>No tiene problema</asp:ListItem>
           </asp:DropDownList>
           <br />
           <asp:Button ID="btnGuardar" runat="server" Text="Registrar cliente" class="next action-button" width="300px"/>
       </fieldset>
    </form>
</body>
</html>
