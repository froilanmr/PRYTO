<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRUD_Actividades.aspx.cs" Inherits="Administracion_CRUD_Actividades" %>

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
            $("#" + elementID).block({
                message: '<div align = "center">' + '<img src="../imgs/loadingAnim.gif"/></div>',
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
    <title>Menú Principal - Actividades Limón</title>
     <link href="../Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style2 {
            width: auto;
            height: 255px;
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
            <li><a>Buzón de Sugerencias</a></li>
            <li><a>Estadísticas</a></li>
            <li><a>Inscripciones</a></li>
            <li><a href="CRUD_Noticias.aspx">Noticias</a></li>
            <li><a href="#">Actividades</a></li>
            <li><a href="CRUD_TipoActividad.aspx">Tipos de Actividades</a></li>
        </ul>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="dvGrid" style="padding-left:300px;padding-top: 50px" class="auto-style2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound"
                        DataKeyNames="Nombre" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPaging"
                        OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="Todavía no se han agregado Actividades."
                        Width="932px" Height="201px" CssClass="TablaGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNombre" runat="server" Text='<%# Eval("Nombre") %>' Height="100" Width="200" TextMode="MultiLine"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de Actividad" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipo" runat="server" Text='<%# Eval("TipoActividad") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ListBox ID="txtTipo" runat="server" Height="100" Width="200"></asp:ListBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de la Actividad" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("Fecha") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFecha" runat="server" Text='<%# Eval("Fecha") %>' Height="100" Width="150" TextMode="Date"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dirección de la Actividad" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblDireccion" runat="server" Text='<%# Eval("Direccion") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDireccion" runat="server" Text='<%# Eval("Direccion") %>' Height="100" Width="200" TextMode="MultiLine"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descripción de la Actividad" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Eval("Descripcion") %>' Height="100" Width="200" TextMode="MultiLine"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cupos" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblCupos" runat="server" Text='<%# Eval("Cupos") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCupos" runat="server" Text='<%# Eval("Cupos") %>' Height="100" Width="150" TextMode="Number"></asp:TextBox>
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
        <fieldset style="margin-left:350px; width:300px; padding:50px;">
            <div style="padding:50px">
                <table border="1" style="border-collapse: collapse;">
                    <tr>
                        <td style="padding: 20px">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre de la Actividad" Width="261px"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtNombre" runat="server" Width="260px" Height="42px" TextMode="MultiLine" />
                            <br />
                            <br />
                            <asp:Label ID="lblTipo" runat="server" Text="Tipo de Actividad"></asp:Label>
                            <br />
                            <asp:ListBox ID="txtTipo" runat="server" Height="42px" Width="260px" />
                        </td>
                        <td style="padding: 20px">
                            <asp:Label ID="lblDireccion" runat="server" Text="Dirección de la Actividad"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtDireccion" runat="server" Height="152px" TextMode="MultiLine" Width="260px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 20px">
                            <asp:Label ID="lblCupos" runat="server" Text="Numero de Cupos (Inscripciones)"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCupos" runat="server" Height="42px" TextMode="Number" Width="260px" />
                        </td>
                        <td style="padding: 20px">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha de la Actividad"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtFecha" runat="server" Height="42px" TextMode="Date" Width="260px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 20px">
                            <asp:Label ID="lblGaleria" runat="server" Text="Galería" Width="261px"></asp:Label>
                            <br />
                            <asp:FileUpload Width="288px" ID="fileGaleria" runat="server" AllowMultiple="True" accept=".png,.jpg,.jpeg,.gif"></asp:FileUpload>
                        </td>
                        <td style="padding: 20px">
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción de la Actividad"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtDescripcion" runat="server" Height="152px" TextMode="MultiLine" Width="260px" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Button ID="btnAdd" runat="server" class="next action-button" Height="55px" OnClick="Insert" Text="Agregar" Width="212px" />
        </fieldset>
    </form>
</body>
</html>
