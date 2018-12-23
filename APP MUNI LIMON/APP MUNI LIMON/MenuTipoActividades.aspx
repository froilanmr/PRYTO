<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuTipoActividades.aspx.cs" Inherits="MenuTipoActividades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menú Principal</title>
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
        <asp:Table ID="Table1" runat="server" Width="1132px" HorizontalAlign="Center" Height="372px">
            <asp:TableRow HorizontalAlign="Center" TableSection="TableHeader" BackColor="#009400" Font-Bold="True">
                <asp:TableCell Text="Modulo"></asp:TableCell>
                <asp:TableCell Text="Registro"></asp:TableCell>
                <asp:TableCell Text="Actualización"></asp:TableCell>
                <asp:TableCell Text="Lectura"></asp:TableCell>
                <asp:TableCell Text="Borrado"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" TableSection="TableBody" Font-Italic="true">
                <asp:TableCell Text="Tipos de Actividades"></asp:TableCell>
                <asp:TableCell Text="Registrar un Tipo de Actividad"></asp:TableCell>
                <asp:TableCell Text="Actualizar un Tipo de Actividad"></asp:TableCell>
                <asp:TableCell Text="Visualizar los Tipos de Actividades"></asp:TableCell>
                <asp:TableCell Text="Eliminar un Tipo de Actividad"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" TableSection="TableBody" Font-Italic="true">
                <asp:TableCell Text="Actividades"></asp:TableCell>
                <asp:TableCell Text="Registrar una Actividad"></asp:TableCell>
                <asp:TableCell Text="Actualizar una Actividad"></asp:TableCell>
                <asp:TableCell Text="Visualizar las Actividades"></asp:TableCell>
                <asp:TableCell Text="Eliminar una actividad"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" TableSection="TableBody" Font-Italic="true">
                <asp:TableCell Text="Noticias"></asp:TableCell>
                <asp:TableCell Text="Registrar una Noticia"></asp:TableCell>
                <asp:TableCell Text="Actualizar una Noticia"></asp:TableCell>
                <asp:TableCell Text="Visualizar Noticias registradas"></asp:TableCell>
                <asp:TableCell Text="Eliminar una Noticia"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" TableSection="TableBody" Font-Italic="true">
                <asp:TableCell Text="Inscripciones"></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell ID="VerInscripciones" Text="Visualizar Inscripciones" ></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" TableSection="TableBody" Font-Italic="true">
                <asp:TableCell Text="Sugerencias"></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell Text="Visualizar Sugerencias" ></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" TableSection="TableBody" Font-Italic="true">
                <asp:TableCell Text="Estadisticas"></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell Text="Visualizar Estadisticas"></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </form>
</body>
</html>
