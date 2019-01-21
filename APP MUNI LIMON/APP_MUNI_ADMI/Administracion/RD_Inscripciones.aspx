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
        <ul class="topnav1"></ul>
        <ul class="topnav2"></ul>
        <ul class="topnav">
            <asp:Label ID="Label9" runat="server" Text="Usuario Online: " Font-Size="Large"></asp:Label>
            <asp:Label ID="lblOnline" runat="server" Font-Size="Large"></asp:Label>
            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Sesión" Width="178px" OnClick="btnCerrar_Click" Font-Size="Medium" />
            <li><a href="READ_Sugerencias.aspx">Buzón de Sugerencias</a></li>
            <li><a href="Estadisticas.aspx">Estadísticas</a></li>
            <li><a href="#">Inscripciones</a></li>
            <li><a href="CRUD_Noticias.aspx">Noticias</a></li>
            <li><a href="CRUD_Actividades.aspx">Actividades</a></li>
            <li><a href="CRUD_TipoActividad.aspx">Tipos de Actividades</a></li>
        </ul>
        <div style="margin-left: 37%">
            <asp:Label ID="Label5" runat="server" Text="Menú de Inscripciones" Font-Bold="True" Font-Names="Arial" Font-Size="XX-Large"></asp:Label>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="dvGrid" style="padding-left: 300px; padding-top: 50px" class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Actividades Disponibles"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="listaTipos" AutoPostBack="true" runat="server" Height="45px" Width="210px" OnSelectedIndexChanged="listaTipos_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="OnRowCancelingEdit"
                        DataKeyNames="nombre" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPaging" OnRowEditing="OnRowEditing"
                        EmptyDataText="Actualmente no hay inscripciones para esa actividad."
                        Width="932px" Height="201px" CssClass="TablaGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre del Participante" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Correo del Participante" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblCorreo" runat="server" Text='<%# Eval("correo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Numero Telefónico" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblTelefono" runat="server" Text='<%# Eval("telefono") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="padding-top: 10px; padding-left: 65%; height: 0px">
            <asp:Label ID="Label7" runat="server" Text="Actividades Municipalidad Limón" Font-Bold="True" Font-Size="Small"></asp:Label>
        </div>
    </form>
</body>
</html>
