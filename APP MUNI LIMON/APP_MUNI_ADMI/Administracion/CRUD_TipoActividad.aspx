<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRUD_TipoActividad.aspx.cs" Inherits="MenuTipoActividades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="../scripts/jquery.blockUI.js"></script>
<script type="text/javascript">
    $(function () {
        BlockUI("dvGrid");
        $.blockUI.defaults.css = {};
    });
    function BlockUI(elementID) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function () {
            $("#" + elementID).block({ message: '<div align = "center">' + '<img src="../imgs/loadingAnim.gif"/></div>',
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
    <title>Menú Principal - Tipos de Actividades</title>
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
            <asp:Label ID="Label3" runat="server" Text="Usuario Online: " Font-Size="Large"></asp:Label>
            <asp:Label ID="lblOnline" runat="server" Font-Size="Large"></asp:Label>
            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Sesión" Width="178px" OnClick="btnCerrar_Click" Font-Size="Medium" />
            <li><a href="READ_Sugerencias.aspx">Buzón de Sugerencias</a></li>
            <li><a href="Estadisticas.aspx">Estadísticas</a></li>
            <li><a href="RD_Inscripciones.aspx">Inscripciones</a></li>
            <li><a href="CRUD_Noticias.aspx">Noticias</a></li>
            <li><a href="CRUD_Actividades.aspx">Actividades</a></li>
            <li><a href="#">Tipos de Actividades</a></li>
       </ul>
        <div style="margin-left: 35%">
            <asp:Label ID="Label5" runat="server" Text="Menú de Tipos de Actividades" Font-Bold="True" Font-Names="Arial" Font-Size="XX-Large"></asp:Label>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="dvGrid" style="padding-left: 300px; padding-top: 50px" class="auto-style2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound"
                        DataKeyNames="Nombre" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPaging"
                        OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="Todavía no se han agregado Tipo de Actividades."
                        Width="932px" Height="201px" CssClass="TablaGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNombre" runat="server" Text='<%# Eval("Nombre") %>' Height="100" Width="300" TextMode="MultiLine"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descripcion" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Eval("Descripcion") %>' Height="100" Width="400" TextMode="MultiLine"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnAdd" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <fieldset style="margin-left: 380px; width: 350px; padding: 50px;">
            <div style="padding: 50px">
                <table border="1" style="border-collapse: collapse;">
                    <tr>
                        <td style="padding: 20px; width: 150px">
                            <asp:Label ID="Label2" runat="server" Text="Nombre del Tipo de Actividad" Width="261px"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" Width="384px" Height="42px" TextMode="MultiLine" />

                        </td>
                    </tr>
                    <caption>
                        &nbsp;&nbsp;&nbsp;
                        <tr>
                            <td style="padding: 20px; width: 400px">
                                <asp:Label ID="Label1" runat="server" Text="Descripcion del Tipo de Actividad"></asp:Label>
                                <asp:TextBox ID="txtDescripcion" runat="server" Height="152px" TextMode="MultiLine" Width="448px" />
                            </td>
                        </tr>
                    </caption>
                    <tr>
                        <td style="padding-top: 10px" class="auto-style1">&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnAdd" class="next action-button" runat="server" Height="55px" OnClick="Insert" Text="Agregar" Width="443px" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="padding-top:20px; padding-left:48%; height:0px">
                <asp:Label ID="Label7" runat="server" Text="Actividades Municipalidad Limón" Font-Bold="True" Font-Size="Small"></asp:Label>
            </div>
        </fieldset>
    </form>
</body>
</html>
