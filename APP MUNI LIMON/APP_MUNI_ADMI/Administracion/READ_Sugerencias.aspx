<%@ Page Language="C#" AutoEventWireup="true" CodeFile="READ_Sugerencias.aspx.cs" Inherits="Administracion_READ_Sugerencias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menú Principal - Buzón de Sugerencias</title>
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
        <ul class="topnav1"></ul>
        <ul class="topnav2"></ul>
        <ul class="topnav">
            <asp:Label ID="Label1" runat="server" Text="Usuario Online: " Font-Size="Large"></asp:Label>
            <asp:Label ID="lblOnline" runat="server" Font-Size="Large"></asp:Label>
            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Sesión" Width="178px" OnClick="btnCerrar_Click" Font-Size="Medium" />
            <li><a href="#">Buzón de Sugerencias</a></li>
            <li><a href="Estadisticas.aspx">Estadísticas</a></li>
            <li><a href="RD_Inscripciones.aspx">Inscripciones</a></li>
            <li><a href="CRUD_Noticias.aspx">Noticias</a></li>
            <li><a href="CRUD_Actividades.aspx">Actividades</a></li>
            <li><a href="CRUD_TipoActividad.aspx">Tipos de Actividades</a></li>
        </ul>
        <div style="margin-left: 40%">
            <asp:Label ID="Label5" runat="server" Text="Menú de Sugerencias" Font-Bold="True" Font-Names="Arial" Font-Size="XX-Large"></asp:Label>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="dvGrid" style="padding-left:300px;padding-top: 50px" class="auto-style2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="Descripcion" PageSize="5" AllowPaging="True" OnPageIndexChanging="OnPaging"
                        EmptyDataText="No hay sugerencias registradas."
                        Width="932px" Height="201px" CssClass="TablaGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Tipo de Tramite" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoTramite" runat="server" Text='<%# Eval("TipoTramite") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de Valoración" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblAnonima" runat="server" Text='<%# ((int)Eval("isAnonima") ==1) ? "Valoración Anonima" : "Valoración Pública" %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valoracion" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblValoracion" runat="server" Text='<%# Eval("Valoracion") + " Estrellas" %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descripción de Experiencia" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblExperiencia" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha y Hora" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaHora" runat="server" Text='<%# Eval("fechaEntrada") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="padding-top: 5px; padding-left: 58%; height: 0px">
                <asp:Label ID="Label7" runat="server" Text="Actividades Municipalidad Limón" Font-Bold="True" Font-Size="Small"></asp:Label>
            </div>
        </div>
    </form>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <ul class="topnav2"></ul>
    <ul class="topnav1"></ul>
</body>
</html>
