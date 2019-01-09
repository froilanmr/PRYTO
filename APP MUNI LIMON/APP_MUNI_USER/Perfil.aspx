<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Perfil - Actividades Municipalidad Limón</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</head>
<body>
    <form runat="server">
        <ul class="topnav1">
            <!--<li><a href="MenuActividades">Menú</a></li>-->
        </ul>
        <ul class="topnav2">
            <!--<li><a href="MenuActividades">Menú</a></li>-->
        </ul>
        <br />
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-3 ">
                    <div class="list-group ">
                        <a href="#" class="list-group-item list-group-item-action active">Información</a>
                        <a href="MENU.aspx" class="list-group-item list-group-item-action">Volver</a>
                    </div>
                </div>
                <div class="col-md-9">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h4>Mi Perfil - Municipalidad de Limón</h4>
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div>
                                        <div class="form-group row">
                                            <asp:Label ID="Label1" runat="server" CssClass="col-4 col-form-label" Text="Nombre"></asp:Label>
                                            <div class="col-8">
                                                <asp:TextBox ID="nombre" runat="server" CssClass="form-control here" TextMode="SingleLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <asp:Label ID="Label2" runat="server" CssClass="col-4 col-form-label" Text="Correo Electrónico"></asp:Label>
                                            <div class="col-8">
                                                <asp:TextBox ID="correo" runat="server" CssClass="form-control here" TextMode="Email"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <asp:Label ID="Label3" runat="server" CssClass="col-4 col-form-label" Text="Contraseña"></asp:Label>
                                            <div class="col-8">
                                                <asp:TextBox ID="contrasenna" runat="server" CssClass="form-control here"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <asp:Label ID="Label4" runat="server" CssClass="col-4 col-form-label" Text="Teléfono"></asp:Label>
                                            <div class="col-8">
                                                <asp:TextBox ID="telefono" runat="server" CssClass="form-control here" TextMode="Phone"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="offset-4 col-8">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="Button1_Click1" />
                                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger" Text="Eliminar Perfíl" OnClick="Button2_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <br /><br /><br /><br /><br /><br />
    <ul class="topnav2"></ul>
    <ul class="topnav1"></ul>
</body>
</html>
