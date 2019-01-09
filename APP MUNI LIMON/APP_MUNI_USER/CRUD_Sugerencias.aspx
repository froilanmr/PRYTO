<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRUD_Sugerencias.aspx.cs" Inherits="CRUD_Sugerencias" %>

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
    <title>Sugerencias - Actividades Municipalidad Limón</title>
    <link href="Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
        .auto-style2 {
            width: auto;
            height: 248px;
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
            <li><a href="Perfil.aspx">Perfil</a></li>
            <li><a href="#">Sugerencias</a></li>
            <li><a href="CRUD_Inscripciones.aspx">Inscripciones</a></li>
            <li><a href="READ_Noticias.aspx">Noticias</a></li>
            <li><a href="READ_Actividades.aspx">Actividades</a></li>
        </ul>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="dvGrid" style="padding-left:300px;padding-top: 50px" class="auto-style2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound"
                        DataKeyNames="Descripcion" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPaging"
                        OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="Todavía no ha realizado ninguna sugerencia."
                        Width="932px" Height="201px" CssClass="TablaGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Tipo de Tramite" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoTramite" runat="server" Text='<%# Eval("TipoTramite") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="txtTipoTramite" runat="server" Width="200">
                                        <asp:ListItem Text="Planilla"></asp:ListItem>
                                        <asp:ListItem Text="Patentes"></asp:ListItem>
                                        <asp:ListItem Text="Planilla"></asp:ListItem>
                                        <asp:ListItem Text="Ventanilla"></asp:ListItem>
                                        <asp:ListItem Text="Servicio al Cliente"></asp:ListItem>
                                        <asp:ListItem Text="Servicios Públicos"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de Valoración" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblAnonima" runat="server" Text='<%# ((int)Eval("isAnonima") ==1) ? "Valoración Anonima" : "Valoración Pública" %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="txtTipo" runat="server" Text="Valoración Anonima" Height="100" Width="200"></asp:CheckBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valoracion" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblValoracion" runat="server" Text='<%# Eval("Valoracion") + " Estrellas" %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:RadioButtonList ID="txtValoracion" runat="server" Width="150px">
                                        <asp:ListItem Text="  1 Estrella"></asp:ListItem>
                                        <asp:ListItem Text="2 Estrellas"></asp:ListItem>
                                        <asp:ListItem Text="3 Estrellas"></asp:ListItem>
                                        <asp:ListItem Text="4 Estrellas"></asp:ListItem>
                                        <asp:ListItem Text="5 Estrellas"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descripción de Experiencia" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblExperiencia" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtExperiencia" runat="server" Text='<%# Eval("Descripcion") %>' Height="100" Width="200" TextMode="MultiLine"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="registrarSugerencia" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <fieldset style="margin-left:450px; width:300px; padding:50px;">
           <h2 class="fs-title">Registro de Sugerencias</h2>
            <asp:Label ID="Label2" runat="server" Text="Teléfono"></asp:Label>
            <br />
           <asp:TextBox ID="telefono" runat="server" placeholder="Telefono" TextMode="Phone"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Correo Electrónico"></asp:Label>
            <br />
           <asp:TextBox ID="correo" runat="server" placeholder="Correo Electronico" TextMode="Email"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Tipo de Tramite"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="tipoTramite" runat="server">
                <asp:ListItem Text="Planilla"></asp:ListItem>
                <asp:ListItem Text="Patentes"></asp:ListItem>
                <asp:ListItem Text="Planilla"></asp:ListItem>
                <asp:ListItem Text="Ventanilla"></asp:ListItem>
                <asp:ListItem Text="Servicio al Cliente"></asp:ListItem>
                <asp:ListItem Text="Servicios Públicos"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:CheckBox ID="isAnonima" runat="server" Text="Valoración Anonima" Width="358px" OnCheckedChanged="anonimato" Height="23px"/>
            <br />
            <br />
            <br />
           <h2 class="fs-title">Valoración</h2>
            <br />
            <div style="padding-left:100px">
                <asp:RadioButtonList ID="valoraciones" runat="server" Width="226px">
                <asp:ListItem Text="  1 Estrella" ></asp:ListItem>
                <asp:ListItem Text="2 Estrellas" ></asp:ListItem>
                <asp:ListItem Text="3 Estrellas" ></asp:ListItem>
                <asp:ListItem Text="4 Estrellas" ></asp:ListItem>
                <asp:ListItem Text="5 Estrellas" ></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <br />
            <asp:TextBox ID="descripcion" runat="server" placeholder="Describe tu experiencia" TextMode="MultiLine" Height="173px" Width="509px"></asp:TextBox>
            <br />
            <br />
           <asp:Button ID="registrarSugerencia" runat="server" Text="Registrar" class="next action-button" width="300px" OnClick="registrarSugerencia_Click"/>
       </fieldset>
    </form>
    <ul class="topnav2"></ul>
    <ul class="topnav1"></ul>
</body>
</html>
