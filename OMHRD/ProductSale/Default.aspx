<%@ Page Title="" Language="C#" MasterPageFile="~/ProductSale/ProductSale.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OMHRD.ProductSale.Default" EnableEventValidation="false" %>

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
    <div class="banner">
        <div class="container">
            <div class="banner-info animated wow zoomIn" data-wow-delay=".5s">
                <asp:Repeater ID="rptSlider" runat="server">
                    <HeaderTemplate>
                        <ul class="rslides" id="slider4">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="wmuSlider example1">
                            <div class="wmuSliderWrapper">
                                <div class="slider-img <%#Eval("SliderCSSClass") %>">
                                    <article style="position: absolute; width: 100%; opacity: 0;">
                                        <div class="banner-wrap">
                                            <div class="banner-info1">
                                                <p>
                                                    <%#Eval("HEADING1") %>
                                                </p>
                                            </div>
                                        </div>
                                    </article>
                                    <article style="position: absolute; width: 100%; opacity: 0;">
                                        <div class="banner-wrap">
                                            <div class="banner-info1">
                                                <p>
                                                    <%#Eval("HEADING2") %>
                                                </p>
                                            </div>
                                        </div>
                                    </article>
                                    <article style="position: absolute; width: 100%; opacity: 0;">
                                        <div class="banner-wrap">
                                            <div class="banner-info1">
                                                <p>
                                                    <%#Eval("HEADING3") %>
                                                </p>
                                            </div>
                                        </div>
                                    </article>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <script src="js/jquery.wmuSlider.js"></script>
                <script>
                    $('.example1').wmuSlider();
                </script>
            </div>
        </div>
    </div>
    <br />
    <div class="banner-bottom">
        <div class="container">
            <div class="banner-bottom-grids">
                <div class="banner-bottom-grid-left animated wow slideInLeft" data-wow-delay=".5s">
                    <div class="grid">
                        <figure class="effect-julia">
                            <img src="images/4.jpg" alt=" " class="img-responsive" />
                            <figcaption>
                                <h3>Best <span>Store</span><i> in online shopping</i></h3>
                                <div>
                                    <p>Cupidatat non proident, sunt</p>
                                    <p>Officia deserunt mollit anim</p>
                                    <p>Laboris nisi ut aliquip consequat</p>
                                </div>
                            </figcaption>
                        </figure>
                    </div>
                </div>
                <div class="banner-bottom-grid-left1 animated wow slideInUp" data-wow-delay=".5s">
                    <div class="banner-bottom-grid-left-grid left1-grid grid-left-grid1">
                        <div class="banner-bottom-grid-left-grid1">
                            <img src="images/1.jpg" alt=" " class="img-responsive" />
                        </div>
                        <div class="banner-bottom-grid-left1-pos">
                            <p>Discount 45%</p>
                        </div>
                    </div>
                    <div class="banner-bottom-grid-left-grid left1-grid grid-left-grid1">
                        <div class="banner-bottom-grid-left-grid1">
                            <img src="images/2.jpg" alt=" " class="img-responsive" />
                        </div>
                        <div class="banner-bottom-grid-left1-position">
                            <div class="banner-bottom-grid-left1-pos1">
                                <p>Latest New Collections</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="banner-bottom-grid-right animated wow slideInRight" data-wow-delay=".5s">
                    <div class="banner-bottom-grid-left-grid grid-left-grid1">
                        <div class="banner-bottom-grid-left-grid1">
                            <img src="images/3.jpg" alt=" " class="img-responsive" />
                        </div>
                        <div class="grid-left-grid1-pos">
                            <p>top and classic designs <span>2016 Collection</span></p>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <br />
    <div class="new-collections">
        <div class="container">
            <h3 class="animated wow zoomIn" data-wow-delay=".5s">New Collections</h3>
            <p class="est animated wow zoomIn" data-wow-delay=".5s">
                OM HRD New Collections
            </p>
            <div class="new-collections-grids">
                <asp:ListView ID="ListView1" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1" OnPagePropertiesChanging="ListView1_PagePropertiesChanging" mmand="ListView1_ItemCommand">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                    ShowNextPageButton="false" />
                                <asp:NumericPagerField ButtonType="Link" />
                                <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>

                    <ItemTemplate>
                        <div class="col-sm-3">
                            <div class="new-collections-grid1 animated wow slideInUp" data-wow-delay=".5s">
                                <div class="new-collections-grid1-image">
                                    <a href='productdetail.aspx?st=<%# Eval("ITEM_ID") %>' class="product-image">
                                        <img src='<%# "../images/ItemImages/"+ DataBinder.Eval(Container.DataItem,"Image") %>' style="height: 280px;" alt=" " class="img-responsive" /></a>
                                    <div class="new-collections-grid1-image-pos">
                                        <a href='productdetail.aspx?st=<%# DataBinder.Eval(Container.DataItem,"ITEM_ID") %>'>Quick View</a>
                                    </div>
                                </div>
                                <h4><a href='productdetail.aspx?st=<%# DataBinder.Eval(Container.DataItem,"ITEM_ID") %>'>
                                    <%# DataBinder.Eval(Container.DataItem,"ITEMNAME").ToString().Length>15?DataBinder.Eval(Container.DataItem,"ITEMNAME").ToString().Substring(0,15): DataBinder.Eval(Container.DataItem,"ITEMNAME").ToString() %> </a></h4>
                                <%--<asp:Label ID="lblUnitcode<%# Eval("ITEM_ID") %>" CssClass="UnitCode" runat="server" Text='<%# Eval("UnitCode") %>' ClientIDMode="Static"></asp:Label>--%>
                                <%--<asp:Label ID="lblUnitcode" CssClass="UnitCode" runat="server" Text='<%# Eval("UnitCode") %>' ClientIDMode="Static"></asp:Label>--%>
                                <p><%# DataBinder.Eval(Container.DataItem,"Description").ToString().Length>15?DataBinder.Eval(Container.DataItem,"Description").ToString().Substring(0,15):DataBinder.Eval(Container.DataItem,"Description").ToString() %></p>
                                <div class="new-collections-grid1-left simpleCart_shelfItem">
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
    <br />
  

    <div class="collections-bottom">
        <div class="container">
            <div class="collections-bottom-grids">
                <div class="collections-bottom-grid animated wow slideInLeft" data-wow-delay=".5s">
                    <asp:Repeater ID="Repeater2" runat="server">
                        <HeaderTemplate>
                            <ul class="rslides" id="slider4">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="wmuSlider example1">
                                <div class="wmuSliderWrapper">
                                    <div class="slider-img <%#Eval("FILE_NAME1") %>">
                                        <div class="container">
                                            <div class="slider-info text-left">
                                                <p style="color: white;">
                                                    <%#Eval("FooterHeading") %>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="newsletter animated wow slideInUp" data-wow-delay=".5s">
                <h3>Newsletter</h3>
                <p>Join us now to get all news and special offers.</p>
                <form>
                    <span class="glyphicon glyphicon-envelope" aria-hidden="true"></span>
                    <input type="email" value="Enter your email address" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Enter your email address';}" required="">
                    <input type="submit" value="Join Us">
                </form>
            </div>
        </div>
    </div>
</asp:Content>
