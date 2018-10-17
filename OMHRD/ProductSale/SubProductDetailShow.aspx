<%@ Page Title="" Language="C#" MasterPageFile="~/ProductSale/ProductSale.Master" AutoEventWireup="true" CodeBehind="SubProductDetailShow.aspx.cs" Inherits="OMHRD.ProductSale.SubProductDetailShow" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function addToCart(productId, Unitcode, Color) {
            var userid = $("#loggedinUserId").val();
            if (userid == null || userid == "" || userid == undefined) {
                $("#hdnreturnUrl").val(window.location.href);
                $('#myModal5').modal('toggle');
            }
            else {
                $.ajax({
                    url: "../Webservice.asmx/addtocart?productid=" + productId + "&userid=" + userid + "&quantity=1" + "&unitcode=" + Unitcode + "&Color=" + Color,
                    method: 'get',
                    success: function (response) {
                        alert("Product Add to Cart");
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="new-collections">
        <div class="container">
            <h3 class="animated wow zoomIn" data-wow-delay=".5s">New Collections</h3>
            <p class="est animated wow zoomIn" data-wow-delay=".5s">
                OM HRD New Collections
            </p>
            <div class="new-collections-grids">
                <asp:ListView ID="ListView1" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="col-sm-3">
                            <div class="new-collections-grid1 animated wow slideInUp" data-wow-delay=".5s">
                                <div class="new-collections-grid1-image">
                                    <a href='productdetail.aspx?st=<%# Eval("ITEM_ID") %>' class="product-image">
                                        <img src='<%# "../images/ItemImages/"+ Eval("Image") %>' style="height: 280px;" alt=" " class="img-responsive" /></a>
                                    <div class="new-collections-grid1-image-pos">
                                        <a href='productdetail.aspx?st=<%# Eval("ITEM_ID") %>'>Quick View</a>
                                    </div>
                                </div>
                                <h4><a href='productdetail.aspx?st=<%# Eval("ITEM_ID") %>'>
                                    <%# Eval("ITEMNAME").ToString().Length>10?Eval("ITEMNAME").ToString().Substring(0,10): Eval("ITEMNAME").ToString() %>
                                </a></h4>
                                <p><%# Eval("Description").ToString().Length>10?Eval("Description").ToString().Substring(0,10): Eval("Description").ToString() %></p>
                                <div class="new-collections-grid1-left simpleCart_shelfItem">
                                    <%--<p><span class="item_price">&#8377;<%# Eval("Price") %></span><a class="item_add" href="#">add to cart </a></p>--%>

                                  <p>
                                        <span class="item_price">&#8377;<%# DataBinder.Eval(Container.DataItem,"DisscountPrice") %></span>
                                        <a class="item_add" id="btnAdditem" onclick="addToCart(<%# DataBinder.Eval(Container.DataItem,"ITEM_ID") %>,<%# "'" + DataBinder.Eval(Container.DataItem,"UnitCode")+"'" %>,<%# "'" + DataBinder.Eval(Container.DataItem,"Color_Code")+"'" %>)" href="javascript:void(0)">add to cart </a>
                                    </p>
                          
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>
