<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Actividades.aspx.cs" Inherits="Actividades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Actividades - Actividades Municipalidad Limón</title>
    <link href="Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    <!-- Important Owl stylesheet -->
    <link rel="stylesheet" href="http://owlgraphic.com/owlcarousel/owl-carousel/owl.carousel.css"/>
    <!-- Default Theme -->
    <link rel="stylesheet" href="http://owlgraphic.com/owlcarousel/owl-carousel/owl.theme.css"/>
    <!--  jQuery 1.7+  -->
    <script src="http://owlgraphic.com/owlcarousel/assets/js/jquery-1.9.1.min.js"></script>
    <!-- Include js plugin -->
    <script src="http://owlgraphic.com/owlcarousel/owl-carousel/owl.carousel.js"></script>
    <style>
        .Contenido{
            margin: 16px;
            top: 5px;
            left: 5px;
            right: 5px;
            bottom: 5px;
            background: #fff;
            overflow: hidden;
            -moz-box-shadow: 1px 1px 2px rgba(0,0,0,0.2);
            -webkit-box-shadow: 1px 1px 2px rgba(0,0,0,0.2);
            box-shadow: 1px 1px 2px rgba(0,0,0,0.2);
            padding-top: 19px;
            border: 1px solid #ddd;
        }
        .Imagenes{
            height: 180px;
        }
    </style>

    </head>
<body>
    <form id="form1" runat="server">
        <ul class="topnav1"></ul>
        <ul class="topnav2"></ul>
        <ul class="topnav">
            <asp:Label ID="Label9" runat="server" Text="Usuario Online: " Font-Size="Large"></asp:Label>
            <asp:Label ID="lblOnline" runat="server" Font-Size="Large"></asp:Label>
            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Sesión" Width="178px" OnClick="btnCerrar_Click" Font-Size="Medium" />

            <li><a href="Perfil.aspx">Perfil</a></li>
            <li><a href="CRUD_Sugerencias.aspx">Sugerencias</a></li>
            <li><a href="RD_Inscripciones.aspx">Inscripciones</a></li>
            <li><a href="READ_Noticias.aspx">Noticias</a></li>
            <li><a href="#">Actividades</a></li>
        </ul>
        <div style="margin-left: 40%; margin-bottom:30px">
            <asp:Label ID="Label5" runat="server" Text="Menú de Actividades" Font-Bold="True" Font-Names="Arial" Font-Size="XX-Large"></asp:Label>
        </div>
        <div id="Divi" style="padding-left:15%; width:80%; height:800px">
            <asp:Label ID="Label1" runat="server" Text="Tipos de Actividades Disponibles"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="listaTipos" AutoPostBack="true" runat="server" Height="45px" Width="210px" OnSelectedIndexChanged="listaTipos_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Actividades Disponibles"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="listaActividades" runat="server" Height="45px" Width="210px"></asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Ver Información" BackColor="#009400" Width="169px" ForeColor="White" Font-Bold="True" Font-Size="Small" OnClick="Button1_Click" />
            <br />
            <br />

            <div style="padding-left: 12%">
                <asp:Label ID="Error1" runat="server" Text="No hay Tipos de Actividades registradas." Visible="False" ForeColor="#FF3300"></asp:Label>
                <div style="padding-left: 35%">
                    <asp:Label ID="Error2" runat="server" Text="No se encuentran Actividades relacionadas a ese Tipo." Visible="False" ForeColor="#FF3300"></asp:Label>
                </div>
            </div>
            <fieldset style="margin-left: 150px; width: 700px; padding-left: 90px">
                <div style="padding-top: 5px; position: relative">
                    <div style="margin: 50px; position: absolute; top: 38%; left: 28%; margin-right: -38%; transform: translate(-38%,-38%)">
                        <asp:Image ID="ImagenA" runat="server" Width="500px" Height="200px" Visible="false" />
                    </div>
                </div>

                <div style="margin-top:90px; padding-top: 200px; position: relative;">
                    <div style="margin: 0px; position: absolute; top: 50%; left: 40%; margin-right: -40%; transform: translate(-40%,-40%)">
                        <asp:Label ID="lblNombreActividad" runat="server" Visible="False" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large"></asp:Label>
                    </div>
                </div>

                <div style="padding-top: 5px; position: relative">
                    <div style="margin: 0px; position: absolute; top: 48%; left: 38%; margin-right: -38%; transform: translate(-38%,-38%)">
                        <asp:Label ID="lbl1" runat="server" Text="Fecha de la Actividad: " Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <asp:Label ID="lblFechaActividad" runat="server" Visible="False" Font-Bold="True" Font-Italic="True" Font-Size="X-Large"></asp:Label>
                    </div>
                </div>

                <div style="text-align: justify; padding-top: 45px; padding-left: 130px; padding-right: 100px">
                    <asp:Label ID="lblDescripcion" runat="server" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
                </div>

                <div style="padding-top: 85px; position: relative">
                    <div style="margin: 0px; position: absolute; top: 48%; left: 38%; margin-right: -38%; transform: translate(-38%,-38%)">
                        <asp:Label ID="lbl2" runat="server" Text="Dirección: " Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <asp:Label ID="lblDireccion" runat="server" Visible="False" Font-Bold="True" Font-Italic="True" Font-Size="X-Large"></asp:Label>
                    </div>
                </div>

                <div style="padding-top: 45px; position: relative">
                    <div style="margin: 0px; position: absolute; top: 48%; left: 38%; margin-right: -38%; transform: translate(-38%,-38%)">
                        <asp:Label ID="lbl3" runat="server" Text="Cantidad de Cupos: " Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <asp:Label ID="lblCupos" runat="server" Font-Bold="True" Visible="False" Font-Italic="True" Font-Size="X-Large"></asp:Label>
                    </div>
                </div>

                <div style="padding-top: 100px; position: relative">
                    <div style="margin: 0px; position: absolute; top: 48%; left: 38%; margin-right: -38%; transform: translate(-38%,-38%)">
                        <asp:Button ID="Inscripcion" runat="server" Visible="False" BackColor="#009400" ForeColor="White" Text="Inscribirse" Font-Bold="True" Font-Italic="True" Font-Size="Large" Width="157px" OnClick="Inscripcion_Click" />
                    </div>
                </div>
            </fieldset>
        </div>
        <script>
            $(document).ready(function () {
                $("#owl-example").owlCarousel();
            });
        </script>
    </form>
</body>
</html>
