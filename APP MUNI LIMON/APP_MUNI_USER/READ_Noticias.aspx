<%@ Page Language="C#" AutoEventWireup="true" CodeFile="READ_Noticias.aspx.cs" Inherits="READ_Noticias" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>Noticias - Municipalidad de Limón</title>
    <link href="../Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 158px;
        }

        .auto-style2 {
            width: auto;
            height: 210px;
        }

        .Contenido{
            margin:16px;
            top: 5px;
            left: 5px;
            right: 5px;
            bottom: 5px;
            background: #fff;
            overflow: hidden;
            border: 1px solid #ddd;
        }
        .imagenes{
            height:250px;
            margin-top:0px;
        }
        .Descripcion{
            font-family:"Georgia", "Times New Roman", serif;
            font-style: italic;
            font-size: 17px;
            margin: 25px;
            height: 200px;
        }
        .Titulo{
            font-family: 'Courier New', sans-serif;
            text-transform: uppercase;
            color: #000;
            margin-bottom: 20px;
            font-size: 19px;
            text-align: center;
            text-shadow: 0px 1px 1px #e4ebe9
        }
    </style>

    <!-- Important Owl stylesheet -->
    <link rel="stylesheet" href="css/owl.carousel.css" />
    <!-- Default Theme -->
    <link rel="stylesheet" href="css/owl.theme.default.css" />
    <!--  jQuery 1.7+  -->
    <script src="js/jquery.min.js"></script>
    <!-- Include js plugin -->
    <script src="js/owl.carousel.min.js"></script>
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
            <li><a href="#">Noticias</a></li>
            <li><a href="Actividades.aspx">Actividades</a></li>
        </ul>
        <div style="margin-left: 45%">
            <asp:Label ID="Label5" runat="server" Text="Noticias" Font-Bold="True" Font-Names="Arial" Font-Size="XX-Large"></asp:Label>
        </div>
        <div style="margin-left: 30%; margin-top:20px">
            <asp:Label ID="Label1" runat="server" Text="Deslice hacia la izquierda para ver más noticias" Font-Size="X-Large"></asp:Label>
        </div>
        <div id="owl-example" class="owl-carousel" style="margin-left: auto; margin-right:auto; padding-top: 50px">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="Contenido">
                        <img class="imagenes" src="<%# DataBinder.Eval(Container.DataItem, "galeria") %>" />
                        <div style="margin-left:20px">
                            <div class="Titulo"> <strong> <%# DataBinder.Eval(Container.DataItem, "titulo") %> </strong></div>
                        </div>
                        <div style="width:auto">
                            <div class="Descripcion"><%# DataBinder.Eval(Container.DataItem, "descripcion") %></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".owl-carousel").owlCarousel();
        });
    </script>
</body>
</html>
