﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MENU.aspx.cs" Inherits="MENU" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menú Principal - Actividades Municipalidad Limón</title>
    <link href="Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: -2147483648%;
            height: inherit;
            left: 0px;
            top: 0px;
        }
        .auto-style2 {
            width: 880px;
            margin-left: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="topnav1">
            <!--<li><a href="MenuActividades">Menú</a></li>-->
        </ul>
        <ul class="topnav2">
            <!--<li><a href="MenuActividades">Menú</a></li>-->
        </ul>
        <div style="margin-left:90%; margin-top:5px">
            <asp:Button ID="Button1" runat="server" Text="Cerrar Sesión" Width="112px" OnClick="Button1_Click" />
        </div>
        <fieldset style="padding-left: 170px; display:inline-block" class="auto-style1">
            <div style="border-radius:5px; display:flex; justify-content: space-around;" class="auto-style2">
                <div style="float:left;	margin: 10px;">
                    <asp:LinkButton ID="LinkButton1" runat="server" Width="100%" OnClick="LinkButton1_Click">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imgs/activities.png" BackColor="Transparent" Height="157px" Width="156px" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Ver Actividades"></asp:Label>
                    </asp:LinkButton>
                </div>
                <div style="float:left;	margin: 10px;">
                    <asp:LinkButton ID="LinkButton2" runat="server" Width="100%" OnClick="LinkButton2_Click">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/imgs/news.png" BackColor="Transparent" Height="157px" Width="156px" />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Ver Noticias"></asp:Label>
                    </asp:LinkButton>
                </div>
                <div style="float:left;	margin: 10px;">
                    <asp:LinkButton ID="LinkButton3" runat="server" Width="100%">
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/imgs/inscriptions.png" BackColor="Transparent" Height="157px" Width="156px" />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Ver mis Inscripciones"></asp:Label>
                    </asp:LinkButton>
                </div>
                <div style="float:left; margin:10px">
                    <asp:LinkButton ID="LinkButton5" runat="server" Width="100%" OnClick="LinkButton5_Click">
                        <asp:Image ID="Image6" runat="server" ImageUrl="~/imgs/suggest.png" BackColor="Transparent" Height="157px" Width="156px" />
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Menú de Sugerencias"></asp:Label>
                    </asp:LinkButton>
                </div>
                <div style="float:left; margin:10px">
                    <asp:LinkButton ID="LinkButton4" runat="server" Width="100%" OnClick="LinkButton4_Click">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/imgs/resume.png" BackColor="Transparent" Height="157px" Width="156px" />
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Perfíl"></asp:Label>
                    </asp:LinkButton>
                </div>
            </div>
        </fieldset>
    </form>
    <ul class="topnav2"></ul>
    <ul class="topnav1"></ul>
</body>
</html>
