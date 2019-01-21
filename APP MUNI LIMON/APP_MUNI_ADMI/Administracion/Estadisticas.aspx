<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Estadisticas.aspx.cs" Inherits="Administracion_Estadisticas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Estadistícas Generales - Actividades Limón</title>
     <link href="../Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
        <ul class="topnav1"></ul>
        <ul class="topnav2"></ul>
        <ul class="topnav">
            <asp:Label ID="Label1" runat="server" Text="Usuario Online: " Font-Size="Large"></asp:Label>
            <asp:Label ID="lblOnline" runat="server" Font-Size="Large"></asp:Label>
            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Sesión" Width="178px" OnClick="btnCerrar_Click" Font-Size="Medium" />
            <li><a href="READ_Sugerencias.aspx">Buzón de Sugerencias</a></li>
            <li><a href="#">Estadísticas</a></li>
            <li><a href="RD_Inscripciones.aspx">Inscripciones</a></li>
            <li><a href="CRUD_Noticias.aspx">Noticias</a></li>
            <li><a href="CRUD_Actividades.aspx">Actividades</a></li>
            <li><a href="CRUD_TipoActividad.aspx">Tipos de Actividades</a></li>
        </ul>
        <div style="margin-left: 38%">
            <asp:Label ID="Label5" runat="server" Text="Estadisticas del Sistema" Font-Bold="True" Font-Names="Arial" Font-Size="XX-Large"></asp:Label>
        </div>
        <div style="margin-left: 38%; margin-top:2%">
            <asp:Label ID="Label2" runat="server" Text="Filtro de Estadistica"></asp:Label>
            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" Height="50px" Width="186px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Tipos de Actividades</asp:ListItem>
                <asp:ListItem>Actividades</asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="dvGrid" style="padding-left:300px;padding-top: 50px" class="auto-style2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="Nueva"
                        PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPaging"
                        EmptyDataText="Todavía no se han agregado Actividades."
                        Width="932px" Height="201px" CssClass="TablaGrid">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblMas" runat="server" Text='<%# ((string) Eval("tipoActividad") == "") ?  
                                            "" :
                                            String.Format("{0} con {1} Actividades", Eval("tipoActividad"), Eval("Nueva")) %>'></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# ((string) Eval("actividad") == "") ? 
                                            "":
                                            String.Format("{0} con {1} Inscripciones", Eval("actividad"), Eval("NuevaAct")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblMenos" runat="server" Text='<%# ((string) Eval("tipoActividad") == "") ? 
                                            "" :
                                            String.Format("{0} con {1} Actividades", Eval("Tipo"), Eval("Nueva2")) %>'></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text='<%# ((string) Eval("actividad") == "") ? 
                                            "" :
                                            String.Format("{0} con {1} Inscripciones", Eval("actividad2"), Eval("NuevaAct2"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblViejo" runat="server" Text='<%# ((string) Eval("tipoActividad") == "") ? 
                                            "" :
                                            Eval("Viejo") %>'></asp:Label>
                                    <asp:Label ID="Label6" runat="server" Text='<%# ((string) Eval("nombre") == "") ? 
                                            "":
                                            String.Format("{0} se realiza el proximo {1} ", Eval("nombre"), Eval("fecha")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblNuevo" runat="server" Text='<%# ((string) Eval("tipoActividad") == "") ? 
                                            "" :
                                            Eval("Nuevo") %>'></asp:Label>
                                    <asp:Label ID="lblViejo" runat="server" Text='<%# ((string) Eval("actividad") == "") ? 
                                            "" :
                                            String.Format("{0} se realiza el {1} ", Eval("nombre2"), Eval("fecha2")) %>'></asp:Label>
                                </ItemTemplate>
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
</body>
</html>
