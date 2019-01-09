<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RD_Inscripciones.aspx.cs" Inherits="Administracion_RUD_Inscripciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="scripts/jquery.blockUI.js"></script>
<script type="text/javascript">
    $(function () {
        BlockUI("dvGrid");
        $.blockUI.defaults.css = {};
    });
    function BlockUI(elementID) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function () {
            $("#" + elementID).block({
                message: '<div align = "center">' + '<img src="imgs/loadingAnim.gif"/></div>',
                css: {},
                overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB' }
            });
        });
        prm.add_endRequest(function () {
            $("#" + elementID).unblock();
        });
    };
</script>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menú de Inscripciones - Actividades Municipalidad Limón</title>
    <link href="../Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 158px;
        }

        .auto-style2 {
            width: auto;
            height: 210px;
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
        <ul class="topnav">
            <!--<li><a href="MenuActividades">Menú</a></li>-->
            <li><a href="READ_Sugerencias.aspx">Buzón de Sugerencias</a></li>
            <li><a>Estadísticas</a></li>
            <li><a href="#">Inscripciones</a></li>
            <li><a href="CRUD_Noticias.aspx">Noticias</a></li>
            <li><a href="CRUD_Actividades.aspx">Actividades</a></li>
            <li><a href="CRUD_TipoActividad.aspx">Tipos de Actividades</a></li>
        </ul>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="dvGrid" style="padding-left: 300px; padding-top: 50px" class="auto-style2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="Actividad" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPaging"
                        OnRowDeleting="OnRowDeleting" EmptyDataText="Actualmente no posee inscripciones."
                        Width="932px" Height="201px" CssClass="TablaGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre de la Actividad" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblActividad" runat="server" Text='<%# Eval("Actividad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Link" ShowDeleteButton="true"
                                ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnAdd" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

    </form>
</body>
</html>
