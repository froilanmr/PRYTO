<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRUD_Noticias.aspx.cs" Inherits="Administracion_CRUD_Noticias" %>

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
    <title>Menú Principal - Noticias Limón</title>
     <link href="../Estilos/Navbar.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 158px;
        }
        .auto-style2 {
            width: 924px;
            height: 616px;
        }
        .auto-style4 {
            width: 499px;
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="dvGrid" style="padding-left: 300px; padding-top:50px" class="auto-style2">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound"
                    DataKeyNames="Titulo" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize = "3" AllowPaging ="true" OnPageIndexChanging = "OnPaging"
                    OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="Todavía no se han agregado Noticias."
                    Width="932px" Height="201px">
                    <Columns>
                        <asp:TemplateField HeaderText="Titulo" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("Titulo") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitulo" runat="server" Text='<%# Eval("Titulo") %>' Height="100" Width="300" TextMode="MultiLine"></asp:TextBox>
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
                        <asp:TemplateField HeaderText="Galeria" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblGaleria" runat="server" Text='<%# Eval("Galeria") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:FileUpload ID="txtGaleria" runat="server" placeholder='<%# Eval("Galeria") %>'  Height="100" Width="400" AllowMultiple="True" accept=".png,.jpg,.jpeg,.gif"></asp:FileUpload>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                            ItemStyle-Width="150" />
                    </Columns>
                </asp:GridView>
                <div style="padding-left:200px">
                <table border="1" style="border-collapse: collapse;">
                    <tr>
                        <td style="padding-left:20px" class="auto-style4">
                            <asp:Label ID="Label2" runat="server" Text="Titulo de la Noticia" Width="261px"></asp:Label>
                            <asp:TextBox ID="txtTitulo" runat="server" Width="384px" Height="42px" TextMode="MultiLine" />
                    
                        </td>
                    </tr>
                    <caption>
                        &nbsp;&nbsp;&nbsp;
                        <tr>
                            <td style="padding-left:20px" class="auto-style4">
                                <asp:Label ID="Label1" runat="server" Text="Descripcion de la Noticia"></asp:Label>
                                <asp:TextBox ID="txtDescripcion" runat="server" Height="152px" TextMode="MultiLine" Width="448px" />
                            </td>
                        </tr>
                     </caption>
                     <tr>
                            <td style="padding-left:20px" class="auto-style4">
                                <asp:Label ID="Label3" runat="server" Text="Galería" Width="261px"></asp:Label>
                                <asp:FileUpload ID="txtGaleria" runat="server" placeholder="Galería" AllowMultiple="True" accept=".png,.jpg,.jpeg,.gif"></asp:FileUpload>
                            </td>
                        </tr>
                     <tr>
                         <td class="auto-style4">&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnAdd" runat="server" Height="55px" Text="Agregar" Width="443px" OnClick="Insert" />
                         </td>
                     </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
