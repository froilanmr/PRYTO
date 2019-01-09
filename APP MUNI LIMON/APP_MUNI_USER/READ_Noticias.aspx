<%@ Page Language="C#" AutoEventWireup="true" CodeFile="READ_Noticias.aspx.cs" Inherits="READ_Noticias" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Carousel Slider</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/dataTables.bootstrap4.min.css" />
    <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript">  
        $(document).ready(function () {
            $("#GridView1").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
    <style>
        .carousel-inner img {
            width: 100%;
            height: 350px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h4 class="text-capitalize text-center">Bootstrap Carousel Image Slider with database in asp.net</h4>
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner" role="listbox">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="carousel-item <%#GetActiveClass(Container.ItemIndex) %>">
                                <img alt="<%#Eval("ImageName")%>" src="<%#Eval("ImagePath")%>" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <a class="carousel-control-prev" href="#myCarousel" data-slide="prev" role="button">
                    <span class="carousel-control-prev-icon"></span>
                </a>
                <a class="carousel-control-next" href="#myCarousel" data-slide="next" role="button">
                    <span class="carousel-control-next-icon"></span>
                </a>
            </div>
        </div>
        <div class="container">
            <div class="card" style="margin-bottom: 15px">
                <div class="card-header bg-primary">
                    <strong class="card-title text-uppercase text-white">carousel Slider Images</strong>
                </div>
                <div class="card-body">
                    <asp:Button ID="Button1" CssClass="btn btn-primary rounded-0" runat="server" Text="Agregar Imagen" OnClick="Button1_Click" />
                    <div class="modal fade" id="AddImage">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">Modal Heading</h4>
                                    <button type="button" class="close" data-dismiss="modal">×</button>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="form-group">
                                                <label>Choose Slider Image</label>
                                                <div class="custom-file">
                                                    <asp:FileUpload ID="SliderFileUpload" runat="server" CssClass="custom-file-input" />
                                                    <label class="custom-file-label"></label>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary rounded-0" OnClick="btnUpload_Click" />
                                    <button type="button" class="btn btn-danger rounded-0" data-dismiss="modal">Cancel</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="true" HeaderStyle-CssClass="bg-primary text-white" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" />
                            <asp:BoundField DataField="ImageName" HeaderText="Image Name" />
                            <asp:ImageField DataImageUrlField="ImagePath" ControlStyle-CssClass="img-thumbnail" ControlStyle-Width="100" ControlStyle-Height="60" HeaderText="Image" />
                        </Columns>
                        <EmptyDataTemplate>No Record Available <b>Click Add New Image to add Record</b></EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
