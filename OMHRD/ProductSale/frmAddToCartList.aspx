<%@ Page Title="" Language="C#" MasterPageFile="~/ProductSale/ProductSale.Master" AutoEventWireup="true" CodeBehind="frmAddToCartList.aspx.cs" Inherits="OMHRD.ProductSale.frmAddToCartList" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.value-plus').on('click', function () {
                var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) + 1;
                divUpd.text(newVal);
                var productid = $(this).parent().find('.lbl-productid').text();
                var unitcode = $(this).parent().find('.lbl-unit-code').text();
                var colorcode = $(this).parent().find('.lbl-color-code').text();
                var Price = $(this).parent().find('.lbl-Price').text();
                var Total = Price * newVal;
                $(this).closest(".product-detail").find('.item_price span').text(Total);
                updateTotal();
                addToCart(productid, newVal, unitcode, colorcode);
            });
            $('.value-minus').on('click', function () {
                var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) - 1;
                if (newVal >= 1) {
                    divUpd.text(newVal);
                    var productid = $(this).parent().find('.lbl-productid').text();
                    var unitcode = $(this).parent().find('.lbl-unit-code').text();
                    var colorcode = $(this).parent().find('.lbl-color-code').text();
                    var Price = $(this).parent().find('.lbl-Price').text();
                    var Total = Price * newVal;
                    $(this).closest(".product-detail").find('.item_price span').text(Total);
                    updateTotal();
                    addToCart(productid, newVal, unitcode, colorcode);
                };
            });
            updateTotal();
        });

        function updateTotal() {
            var items = $(".product-list").find('.item_price span');
            var total = 0;
            for (var i = 0; i < items.length; i++) {
                total = total + parseFloat($(items[i]).text());
            }
            $(".total-price").text(total);
            $(".total-Item").text(items.length);
        }

        function addToCart(productId, qty, unitcode, colorcode) {
            var userid = $("#loggedinUserId").val();
            var ProductDetail = {};
            $.ajax({
                url: "../Webservice.asmx/addtocart?productid=" + productId + "&userid=" + userid + "&quantity=" + qty + "&unitcode=" + unitcode + "&Color=" + colorcode,
                method: 'get',
                //contentType: "application/json; charset=utf-8",
                success: function (response) {

                },
                error: function (err) {
                    alert(err);
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft" data-wow-delay=".5s">
                <li><a href="Default.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a></li>
                <li class="active">Shopping Cart</li>
            </ol>
        </div>
    </div>
    <div class="checkout">
        <div class="container">
            <div class="col-md-12">
                <asp:Panel ID="AddtoCardDetail" runat="server">
                    <div class="col-md-9 product-list">
                        <asp:ListView ID="ListView1" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1" OnItemCommand="ListView1_ItemCommand">
                            <LayoutTemplate>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="col-sm-12">
                                    <div class="product-detail" data-wow-delay=".5s">
                                        <div class="col-sm-2">
                                            <a href='productdetail.aspx?st=<%# Eval("ItemId") %>'>
                                                <img src='<%# "../images/ItemImages/" +DataBinder.Eval(Container.DataItem, "Image")%>' style="height: 60px;" alt=" " class="img-responsive" /></a>
                                        </div>
                                        <div class="col-sm-5">
                                            <h4><a href='productdetail.aspx?st=<%#DataBinder.Eval(Container.DataItem, "ItemId")%>'><%#DataBinder.Eval(Container.DataItem, "ITEMNAME")%> </a></h4>
                                            <p><%#DataBinder.Eval(Container.DataItem,"Description").ToString().Length>20?Eval("Description").ToString().Substring(0,20): Eval("Description").ToString() %></p>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="new-collections-grid1-left simpleCart_shelfItem">
                                                <p><span class="item_price">&#8377;<span> <%# DataBinder.Eval(Container.DataItem,"TotalAmount") %> </span></span></p>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="color-quality-right">
                                                <h5></h5>
                                                <div class="invert">
                                                    <div class="quantity">
                                                        <div class="quantity-select">
                                                            <label class="lbl-productid" style="display: none;"><%# DataBinder.Eval(Container.DataItem,"ItemId") %></label>
                                                            <label class="lbl-unit-code" style="display: none;"><%# DataBinder.Eval(Container.DataItem,"UnitCode") %></label>
                                                            <label class="lbl-color-code" style="display: none;"><%# DataBinder.Eval(Container.DataItem,"Color_Code") %></label>
                                                            <label class="lbl-Price" style="display: none;"><%# DataBinder.Eval(Container.DataItem,"DisscountPrice") %></label>
                                                            <div class="entry value-minus">&nbsp;</div>
                                                            <div class="entry value">
                                                                <asp:Label runat="server" ID="lblqty"><%# DataBinder.Eval(Container.DataItem,"Quantity") %></asp:Label>
                                                            </div>
                                                            <div class="entry value-plus active">&nbsp;</div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <asp:LinkButton ID="btnViewDetail" runat="server" CommandName="Remove" CommandArgument='<%# Eval("ItemId") %>' ForeColor="Red">Delete</asp:LinkButton>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <br />
                    <div class="col-md-3" style="border: inset">
                        <p style="margin: 15px;">Subtotal (<span class="total-Item"></span> items):&nbsp;   &#8377;<span class="total-price"></span></p>
                        <br />
                        <center> <a class="item_add" id="btnadd" href="ShoppingAddress.aspx" style="background-color: #f3cf76; color: black; padding: 4px;">Proceed to checkout</a></center>
                        <br />
                    </div>
                </asp:Panel>
                <br />
                <b>
                    <asp:Label runat="server" ID="lblStatus" Style="font-size: 20px;"></asp:Label></b>
            </div>
            <br />
        </div>
    </div>

</asp:Content>
