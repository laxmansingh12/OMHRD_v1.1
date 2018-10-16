<%@ Page Title="" Language="C#" MasterPageFile="~/ProductSale/ProductSale.Master" AutoEventWireup="true" CodeBehind="frmAllProductShow.aspx.cs" Inherits="OMHRD.ProductSale.frmAllProductShow" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft" data-wow-delay=".5s">
                <li><a href="index.html"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a></li>
                <li class="active">Products</li>
            </ol>
        </div>
    </div>
    <div class="products">
        <div class="container">
            <div class="col-md-4 products-left">
                <div class="filter-price animated wow slideInUp" data-wow-delay=".5s">
                    <h3>Price</h3>
                    <asp:Label runat="server" ID="lbl00">0 to</asp:Label>
                    <asp:Label runat="server" ID="Label1">500</asp:Label><br />
                    <asp:Label runat="server" ID="Label2">500 to</asp:Label>
                    <asp:Label runat="server" ID="Label3">1000</asp:Label><br />
                    <asp:Label runat="server" ID="Label4">1000 to </asp:Label>
                    <asp:Label runat="server" ID="Label5">2000</asp:Label><br />
                    <asp:TextBox runat="server" ID="txtmin" placeholder="Min"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtmax" placeholder="Max"></asp:TextBox>
                    <asp:LinkButton runat="server" ID="linkfilter" Text="GO" OnClick="linkfilter_Click"></asp:LinkButton>
                </div>
                <br />
                <div class="new-products animated wow slideInUp" data-wow-delay=".5s">
                    <h3>New Products</h3>
                    <div class="new-products-grids">
                        <asp:ListView ID="ListView1" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1">
                            <LayoutTemplate>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="new-collections-grid1-image">
                                    <a href="productdetail.aspx" class="product-image">
                                        <a href='<%# "../images/ItemImages/"+ Eval("Image") %>' class="lsb-preview" data-lsb-group="header">
                                            <div class="agileit-folio_grid">
                                                <img src='<%# "../images/ItemImages/"+ Eval("Image") %>' class="img-responsive" style="width: 300px; height: 300px;" />
                                            </div>
                                        </a>
                                        <div class="new-collections-grid1-image-pos">
                                            <asp:LinkButton ID="btnQuickView" runat="server" CommandName="QuickView" CommandArgument='<%# Eval("ITEM_ID") %>'>QuickView</asp:LinkButton>
                                        </div>
                                </div>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("ITEM_ID") %>' Visible="false"></asp:Label>
                                <div class="agile-figcaption">
                                    <asp:Label ID="Label4" runat="server" ForeColor="Black" Text='<%# Eval("ITEMNAME") %>'></asp:Label><br />
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("Description") %>'></asp:Label>
                                </div>
                                <div class="new-collections-grid1-left simpleCart_shelfItem">
                                    <p>
                                        <i>
                                            <asp:Label ID="Label5" runat="server" Enabled="false" ForeColor="Black" Text='<%# Eval("Price") %>'></asp:Label></i>
                                        <span class="item_price">
                                            <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("DiscountPrice") %>'></asp:Label></span>
                                    </p>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <div class="men-position animated wow slideInUp" data-wow-delay=".5s">
                    <a href="single.html">
                        <img src="images/27.jpg" alt=" " class="img-responsive" /></a>
                    <div class="men-position-pos">
                        <h4>Summer collection</h4>
                        <h5><span>55%</span> Flat Discount</h5>
                    </div>
                </div>
            </div>
            <div class="col-md-8 products-right">
                <div class="products-right-grid">
                    <div class="products-right-grids animated wow slideInRight" data-wow-delay=".5s">
                        <div class="sorting">
                            <select id="country" onchange="change_country(this.value)" class="frm-field required sect">
                                <option value="null">Default sorting</option>
                                <option value="null">Sort by popularity</option>
                                <option value="null">Sort by average rating</option>
                                <option value="null">Sort by price</option>
                            </select>
                        </div>
                        <div class="sorting-left">
                            <select id="country1" onchange="change_country(this.value)" class="frm-field required sect">
                                <option value="null">Item on page 9</option>
                                <option value="null">Item on page 18</option>
                                <option value="null">Item on page 32</option>
                                <option value="null">All</option>
                            </select>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="products-right-grids-position animated wow slideInRight" data-wow-delay=".5s">
                        <img src="images/18.jpg" alt=" " class="img-responsive" />
                        <div class="products-right-grids-position1">
                            <h4>2016 New Collection</h4>
                            <p>
                                Temporibus autem quibusdam et aut officiis debitis aut rerum 
								necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae 
								non recusandae.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="products-right-grids-bottom">
                    <div class="col-md-4 products-right-grids-bottom-grid">
                        <div class="new-collections-grid1 products-right-grid1 animated wow slideInUp" data-wow-delay=".5s">
                            <asp:ListView ID="ListView2" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1" OnItemCommand="ListView2_ItemCommand">
                                <LayoutTemplate>
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <div class="new-collections-grid1-image">
                                        <a href="productdetail.aspx" class="product-image">
                                            <a href='<%# "../images/ItemImages/"+ Eval("Image") %>' class="lsb-preview" data-lsb-group="header">
                                                <div class="agileit-folio_grid">
                                                    <img src='<%# "../images/ItemImages/"+ Eval("Image") %>' class="img-responsive" style="width: 300px; height: 300px;" />
                                                </div>
                                            </a>
                                            <div class="new-collections-grid1-image-pos">
                                                <asp:LinkButton ID="btnQuickView" runat="server" CommandName="QuickView" CommandArgument='<%# Eval("ITEM_ID") %>'>QuickView</asp:LinkButton>
                                            </div>
                                    </div>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ITEM_ID") %>' Visible="false"></asp:Label>
                                    <div class="agile-figcaption">
                                        <asp:Label ID="Label4" runat="server" ForeColor="Black" Text='<%# Eval("ITEMNAME") %>'></asp:Label><br />
                                        <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("Description") %>'></asp:Label>
                                    </div>
                                    <div class="new-collections-grid1-left simpleCart_shelfItem">
                                        <p>
                                            <i>
                                                <asp:Label ID="Label5" runat="server" Enabled="false" ForeColor="Black" Text='<%# Eval("Price") %>'></asp:Label></i>
                                            <span class="item_price">
                                                <asp:Label ID="Label2" runat="server" ForeColor="Black" Text='<%# Eval("DiscountPrice") %>'></asp:Label></span>
                                        </p>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <nav class="numbering animated wow slideInRight" data-wow-delay=".5s">
                    <ul class="pagination paging">
                        <li>
                            <a href="#" aria-label="Previous">
                                <span aria-hidden="true">&laquo;</span>
                            </a>
                        </li>
                        <li class="active"><a href="#">1<span class="sr-only">(current)</span></a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#">4</a></li>
                        <li><a href="#">5</a></li>
                        <li>
                            <a href="#" aria-label="Next">
                                <span aria-hidden="true">&raquo;</span>
                            </a>
                        </li>
                    </ul>
                </nav>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>
