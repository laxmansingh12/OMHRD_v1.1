<%@ Page Title="" Language="C#" MasterPageFile="~/ProductSale/ProductSale.Master" AutoEventWireup="true" CodeBehind="productdetail.aspx.cs" Inherits="OMHRD.ProductSale.productdetail" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function addToCart() {
            var userid = $("#loggedinUserId").val();
            if (userid == null || userid == "" || userid == undefined) {
                $("#hdnreturnUrl").val(window.location.href);
                $('#myModal5').modal('toggle');
            }
            else {
                var productId = $("#hdnProductId").val();
                var qty = $("#lblQtyValue").text().trim();
                var Unitcode = $(".ddlSize").val().trim();
                var Color = $(".ddlcolor").val().trim();

                $.ajax({
                    url: "../Webservice.asmx/addtocart?productid=" + productId + "&userid=" + userid + "&quantity=" + qty + "&unitcode=" + Unitcode + "&Color=" + Color,
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
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft" data-wow-delay=".5s">
                <li><a href="Default.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a></li>
                <li class="active">Product Details</li>
            </ol>
        </div>
    </div>
    <!-- //breadcrumbs -->
    <!-- single -->
    <div class="single">
        <div class="container">

            <div class="col-md-12 single-right">
                <div class="col-md-5 single-right-left animated wow slideInUp" data-wow-delay=".5s">
                    <div class="flexslider">
                        <ul class="slides">
                            <li data-thumb='<%=ImageOneUrl %>'>
                                <div class="thumb-image">
                                    <img src='<%=ImageOneUrl %>' data-imagezoom="true" class="img-responsive" />
                                </div>
                            </li>
                            <li data-thumb='<%=ImageTwoUrl %>'>
                                <div class="thumb-image">
                                    <img src='<%=ImageTwoUrl %>' data-imagezoom="true" class="img-responsive" />
                                </div>
                            </li>
                            <li data-thumb='<%=ImageThreeUrl %>'>
                                <div class="thumb-image">
                                    <img src='<%=ImageThreeUrl %>' data-imagezoom="true" class="img-responsive" />
                                </div>
                            </li>
                        </ul>
                    </div>
                    <script defer src="js/jquery.flexslider.js"></script>
                    <link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />
                    <script>
                        $(window).load(function () {
                            $('.flexslider').flexslider({
                                animation: "slide",
                                controlNav: "thumbnails"
                            });
                        });
                    </script>
                </div>
                <div class="col-md-7 single-right-left simpleCart_shelfItem animated wow slideInRight" data-wow-delay=".5s">
                    <asp:Label ID="lblItemName" runat="server"></asp:Label>
                    <h4>
                        <asp:Label ID="lblprice" runat="server"></asp:Label></h4>
                    <div class="description">
                        <h5><i>Description</i></h5>
                        <p>
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div class="color-quality">
                        <div class="color-quality-left">
                            <h5>Color  </h5>
                            <asp:DropDownList runat="server" ID="dropcolor" CssClass="ddlcolor" OnSelectedIndexChanged="dropcolor_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                        </div>
                        <div class="color-quality-right">
                            <h5>Quantity </h5>
                            <div class="invert">
                                <div class="quantity">
                                    <div class="quantity-select">
                                        <div class="entry value-minus">&nbsp;</div>
                                        <div class="entry value" id="lblQtyValue">
                                            <asp:Literal runat="server" ID="litQty" Text="1"></asp:Literal>
                                        </div>
                                        <div class="entry value-plus active">&nbsp;</div>
                                    </div>
                                </div>
                            </div>
                            <script>
                                $('.value-plus').on('click', function () {
                                    var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) + 1;
                                    divUpd.text(newVal);
                                });

                                $('.value-minus').on('click', function () {
                                    var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) - 1;
                                    if (newVal >= 1) divUpd.text(newVal);
                                });
                            </script>
                            <div class="clearfix"></div>
                        </div>
                        <div class="occasional">
                            <h5>Size </h5>
                            <asp:DropDownList runat="server" ID="dropSize" CssClass="ddlSize" OnSelectedIndexChanged="dropSize_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <div id="div_Fname" style="color: #EA0000;"></div>
                        </div>
                        <a class="item_add" id="btnAdditem" onclick="addToCart()" style="background-color: #d8703f; color: white; padding: 3px 40px 3px;" href="#">Add to cart </a>&nbsp;&nbsp;
                    
                        <%-- <a class="item_add" href="AddtoCart.aspx">Add to cart </a>--%>
                        <div class="social">
                            <div class="social-left">
                                <p>Share On </p>
                            </div>
                            <div class="social-right">
                                <ul class="social-icons">
                                    <li><a href="#" class="facebook"></a></li>
                                    <li><a href="#" class="twitter"></a></li>
                                    <li><a href="#" class="g"></a></li>
                                    <li><a href="#" class="instagram"></a></li>
                                </ul>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="bootstrap-tab animated wow slideInUp" data-wow-delay=".5s">
                        <div class="bs-example bs-example-tabs" role="tabpanel" data-example-id="togglable-tabs">
                            <ul id="myTab" class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active"><a href="#home" id="home-tab" role="tab" data-toggle="tab" aria-controls="home" aria-expanded="true">Description</a></li>
                                <li role="presentation"><a href="#profile" role="tab" id="profile-tab" data-toggle="tab" aria-controls="profile">Reviews(2)</a></li>
                                <li role="presentation" class="dropdown">
                                    <a href="#" id="myTabDrop1" class="dropdown-toggle" data-toggle="dropdown" aria-controls="myTabDrop1-contents">Information <span class="caret"></span></a>
                                    <ul class="dropdown-menu" role="menu" aria-labelledby="myTabDrop1" id="myTabDrop1-contents">
                                        <li><a href="#dropdown1" tabindex="-1" role="tab" id="dropdown1-tab" data-toggle="tab" aria-controls="dropdown1">cleanse</a></li>
                                        <li><a href="#dropdown2" tabindex="-1" role="tab" id="dropdown2-tab" data-toggle="tab" aria-controls="dropdown2">fanny</a></li>
                                    </ul>
                                </li>
                            </ul>
                            <div id="myTabContent" class="tab-content">
                                <div role="tabpanel" class="tab-pane fade in active bootstrap-tab-text" id="home" aria-labelledby="home-tab">
                                    <h5>Product Brief Description</h5>
                                    <p>
                                        Raw denim you probably haven't heard of them jean shorts Austin. Nesciunt tofu stumptown aliqua, retro synth master cleanse. Mustache cliche tempor, williamsburg carles vegan helvetica. Reprehenderit butcher retro keffiyeh dreamcatcher synth. Cosby sweater eu banh mi, qui irure terry richardson ex squid. Aliquip placeat salvia cillum iphone. Seitan aliquip quis cardigan american apparel, butcher voluptate nisi qui.
									<span>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</span>
                                    </p>
                                </div>
                                <div role="tabpanel" class="tab-pane fade bootstrap-tab-text" id="profile" aria-labelledby="profile-tab">
                                    <div class="bootstrap-tab-text-grids">
                                        <div class="bootstrap-tab-text-grid">
                                            <div class="bootstrap-tab-text-grid-left">
                                                <img src="images/4.png" alt=" " class="img-responsive" />
                                            </div>
                                            <div class="bootstrap-tab-text-grid-right">
                                                <ul>
                                                    <li><a href="#">Admin</a></li>
                                                    <li><a href="#"><span class="glyphicon glyphicon-share" aria-hidden="true"></span>Reply</a></li>
                                                </ul>
                                                <p>
                                                    Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis 
												suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem 
												vel eum iure reprehenderit.
                                                </p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="bootstrap-tab-text-grid">
                                            <div class="bootstrap-tab-text-grid-left">
                                                <img src="images/5.png" alt=" " class="img-responsive" />
                                            </div>
                                            <div class="bootstrap-tab-text-grid-right">
                                                <ul>
                                                    <li><a href="#">Admin</a></li>
                                                    <li><a href="#"><span class="glyphicon glyphicon-share" aria-hidden="true"></span>Reply</a></li>
                                                </ul>
                                                <p>
                                                    Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis 
												suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem 
												vel eum iure reprehenderit.
                                                </p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="add-review">
                                            <h4>add a review</h4>
                                            <form>
                                                <input type="text" value="Name" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Name';}" required="" />
                                                <input type="email" value="Email" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Email';}" required="" />
                                                <input type="text" value="Subject" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Subject';}" required="" />
                                                <textarea type="text" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Message...';}" required="">Message...</textarea>
                                                <input type="submit" value="Send" />
                                            </form>
                                        </div>
                                    </div>
                                </div>
                                <div role="tabpanel" class="tab-pane fade bootstrap-tab-text" id="dropdown1" aria-labelledby="dropdown1-tab">
                                    <p>Etsy mixtape wayfarers, ethical wes anderson tofu before they sold out mcsweeney's organic lomo retro fanny pack lo-fi farm-to-table readymade. Messenger bag gentrify pitchfork tattooed craft beer, iphone skateboard locavore carles etsy salvia banksy hoodie helvetica. DIY synth PBR banksy irony. Leggings gentrify squid 8-bit cred pitchfork. Williamsburg banh mi whatever gluten-free, carles pitchfork biodiesel fixie etsy retro mlkshk vice blog. Scenester cred you probably haven't heard of them, vinyl craft beer blog stumptown. Pitchfork sustainable tofu synth chambray yr.</p>
                                </div>
                                <div role="tabpanel" class="tab-pane fade bootstrap-tab-text" id="dropdown2" aria-labelledby="dropdown2-tab">
                                    <p>Trust fund seitan letterpress, keytar raw denim keffiyeh etsy art party before they sold out master cleanse gluten-free squid scenester freegan cosby sweater. Fanny pack portland seitan DIY, art party locavore wolf cliche high life echo park Austin. Cred vinyl keffiyeh DIY salvia PBR, banh mi before they sold out farm-to-table VHS viral locavore cosby sweater. Lomo wolf viral, mustache readymade thundercats keffiyeh craft beer marfa ethical. Wolf salvia freegan, sartorial keffiyeh echo park vegan.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <!-- single-related-products -->
    <%--  <div class="single-related-products">
        <div class="container">
            <h3 class="animated wow slideInUp" data-wow-delay=".5s">Related Products</h3>
            <p class="est animated wow slideInUp" data-wow-delay=".5s">
                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia 
				deserunt mollit anim id est laborum.
            </p>
            <div class="new-collections-grids">
                <div class="col-md-3 new-collections-grid">
                    <div class="new-collections-grid1 animated wow slideInLeft" data-wow-delay=".5s">
                        <div class="new-collections-grid1-image">
                            <a href="single.html" class="product-image">
                                <img src="images/8.jpg" alt=" " class="img-responsive"></a>
                            <div class="new-collections-grid1-image-pos">
                                <a href="single.html">Quick View</a>
                            </div>
                            <div class="new-collections-grid1-right">
                                <div class="rating">
                                    <div class="rating-left">
                                        <img src="images/2.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="rating-left">
                                        <img src="images/2.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="rating-left">
                                        <img src="images/1.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="rating-left">
                                        <img src="images/1.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="rating-left">
                                        <img src="images/1.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <h4><a href="single.html">Running Shoes</a></h4>
                        <p>Vel illum qui dolorem eum fugiat.</p>
                        <div class="new-collections-grid1-left simpleCart_shelfItem">
                            <p><i>$280</i> <span class="item_price">$150</span><a class="item_add" href="#">add to cart </a></p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 new-collections-grid">
                    <div class="new-collections-grid1-sub">
                        <div class="new-collections-grid1 animated wow slideInLeft" data-wow-delay=".6s">
                            <div class="new-collections-grid1-image">
                                <a href="single.html" class="product-image">
                                    <img src="images/6.jpg" alt=" " class="img-responsive"></a>
                                <div class="new-collections-grid1-image-pos">
                                    <a href="single.html">Quick View</a>
                                </div>
                                <div class="new-collections-grid1-right">
                                    <div class="rating">
                                        <div class="rating-left">
                                            <img src="images/2.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="rating-left">
                                            <img src="images/2.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="rating-left">
                                            <img src="images/2.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="rating-left">
                                            <img src="images/2.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="rating-left">
                                            <img src="images/2.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                            <h4><a href="single.html">Wall Lamp</a></h4>
                            <p>Vel illum qui dolorem eum fugiat.</p>
                            <div class="new-collections-grid1-left simpleCart_shelfItem">
                                <p><i>$480</i> <span class="item_price">$400</span><a class="item_add" href="#">add to cart </a></p>
                            </div>
                        </div>
                    </div>
                    <div class="new-collections-grid1-sub">
                        <div class="new-collections-grid1 animated wow slideInLeft" data-wow-delay=".7s">
                            <div class="new-collections-grid1-image">
                                <a href="single.html" class="product-image">
                                    <img src="images/9.jpg" alt=" " class="img-responsive"></a>
                                <div class="new-collections-grid1-image-pos">
                                    <a href="single.html">Quick View</a>
                                </div>
                                <div class="new-collections-grid1-right">
                                    <div class="rating">
                                        <div class="rating-left">
                                            <img src="images/2.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="rating-left">
                                            <img src="images/1.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="rating-left">
                                            <img src="images/1.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="rating-left">
                                            <img src="images/1.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="rating-left">
                                            <img src="images/1.png" alt=" " class="img-responsive">
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                            <h4><a href="single.html">Wall Lamp</a></h4>
                            <p>Vel illum qui dolorem eum fugiat.</p>
                            <div class="new-collections-grid1-left simpleCart_shelfItem">
                                <p><i>$280</i> <span class="item_price">$150</span><a class="item_add" href="#">add to cart </a></p>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="col-md-3 new-collections-grid">
                    <div class="new-collections-grid1 animated wow slideInLeft" data-wow-delay=".8s">
                        <div class="new-collections-grid1-image">
                            <a href="single.html" class="product-image">
                                <img src="images/11.jpg" alt=" " class="img-responsive"></a>
                            <div class="new-collections-grid1-image-pos">
                                <a href="single.html">Quick View</a>
                            </div>
                            <div class="new-collections-grid1-right">
                                <div class="rating">
                                    <div class="rating-left">
                                        <img src="images/2.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="rating-left">
                                        <img src="images/2.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="rating-left">
                                        <img src="images/2.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="rating-left">
                                        <img src="images/2.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="rating-left">
                                        <img src="images/1.png" alt=" " class="img-responsive">
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <h4><a href="single.html">Stones Bangles</a></h4>
                        <p>Vel illum qui dolorem eum fugiat.</p>
                        <div class="new-collections-grid1-left simpleCart_shelfItem">
                            <p><i>$340</i> <span class="item_price">$257</span><a class="item_add" href="#">add to cart </a></p>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>--%>
    <asp:HiddenField runat="server" ID="hdnProductId" ClientIDMode="Static" />
</asp:Content>
