<%@ Page Title="" Language="C#" MasterPageFile="~/E_Commerce/E_Commerce.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OMHRD.E_Commerce.Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="about" id="about">
        <div class="container">
            <div class="w3-heading-all">
                <h3>About</h3>
            </div>
            <div class="about-grids">
                <div class="col-md-6 about-left">
                    <img src="images/about.jpg" alt="" />
                </div>
                <div class="col-md-6 about-right">
                    <h3>OM HRD Marketing Private Limited </h3>
                    <p>OM HRD Marketing Private Limited ( Herein " OM HRD"  or " Company" ) is a direct sell/ Promote / refer  ing company that markets its Products through independent Distributors. It is important to understand that each Distributor’s success depends on the integrity of the men and women who market OM HRD's Products and services. The Agreement (as defined below) is made to clearly define the relationship between OM HRD Marketing Private Limited and its independent Distributors, between the Distributors and their Customers, and between Distributors. </p>
                    <div class="more">
                        <a href="AboutUs.aspx">Read More</a>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <div class="modal about-modal fade" id="myModal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span class="span1" aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">OM HRD</h4>
                </div>
                <div class="modal-body">
                    <div class="agileits-w3layouts-info">
                        <img src="images/ab1.jpg" alt="" />
                        <p>OM HRD Marketing Private Limited ( Herein " OM HRD"  or " Company" ) is a direct sell/ Promote / refer  ing company that markets its Products through independent Distributors. It is important to understand that each Distributor’s success depends on the integrity of the men and women who market OM HRD's Products and services. The Agreement (as defined below) is made to clearly define the relationship between OM HRD Marketing Private Limited and its independent Distributors, between the Distributors and their Customers, and between Distributors. </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="services" id="services">
        <div class="w3-heading-all">
            <h3>services</h3>
        </div>
        <!-- container -->
        <div class="w3-services-grids">
            <div class="col-md-6 w3-services-grid-left">
            </div>
            <div class="col-md-6 w3-services-grid-right">
                <div class=" w3-services-grid-info">
                    <div class="col-md-2 w3-services-grid-left1">
                        <i class="fa fa-yoast" aria-hidden="true"></i>

                    </div>
                    <div class="col-md-10 w3-services-grid-right1">
                        <p>Start Helping the People of country.</p>
                    </div>
                    <div class="clearfix"></div>
                </div>

                <div class=" w3-services-grid-info">
                    <div class="col-md-2 w3-services-grid-left1">
                        <i class="fa fa-gitlab" aria-hidden="true"></i>


                    </div>
                    <div class="col-md-10 w3-services-grid-right1">
                        <p>Start to work upliftment of people of your society, city, state Or country.</p>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class=" w3-services-grid-info">
                    <div class="col-md-2 w3-services-grid-left1">
                        <i class="fa fa-sitemap" aria-hidden="true"></i>
                    </div>
                    <div class="col-md-10 w3-services-grid-right1">
                        <p>Starts to feel of be Indian by performing some noble task</p>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class=" w3-services-grid-info">
                    <div class="col-md-2 w3-services-grid-left1">
                        <i class="fa fa-hourglass-half" aria-hidden="true"></i>
                    </div>
                    <div class="col-md-10 w3-services-grid-right1">
                        <p>Directly connected to poor peoples manufactures.</p>
                        <p>Vision  to make India a super power</p>
                    </div>
                    <div class="clearfix"></div>
                </div>

                <div class="clearfix"></div>
            </div>

        </div>
        <!-- //container -->
    </div>
    <div class="blog_sec">
        <div class="w3-heading-all">
            <h3>Our Products</h3>
        </div>
        <asp:ListView ID="ListView1" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1">
            <LayoutTemplate>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
            </LayoutTemplate>
            <ItemTemplate>
                <div class="col-sm-3" style="background: #dca44b;">
                    <div class="new-collections-grid1 animated wow slideInUp" data-wow-delay=".5s">
                        <div class="new-collections-grid1-image">
                            <a href='../ProductSale/productdetail.aspx?st=<%# Eval("ITEM_ID") %>' class="product-image">
                                <img src='<%# "../images/ItemImages/"+ DataBinder.Eval(Container.DataItem,"Image") %>' style="height: 280px;" alt=" " class="img-responsive" /></a>
                        </div>
                        <h4><a href='../ProductSale/productdetail.aspx?st=<%# DataBinder.Eval(Container.DataItem,"ITEM_ID") %>' style="color: red;">
                            <%# DataBinder.Eval(Container.DataItem,"ITEMNAME").ToString().Length>25?DataBinder.Eval(Container.DataItem,"ITEMNAME").ToString().Substring(0,25): DataBinder.Eval(Container.DataItem,"ITEMNAME").ToString() %> </a></h4>

                        <h5 style="padding: 0px 0px 12px;"><%# DataBinder.Eval(Container.DataItem,"Description").ToString().Length>25?DataBinder.Eval(Container.DataItem,"Description").ToString().Substring(0,25):DataBinder.Eval(Container.DataItem,"Description").ToString() %></h5>

                        <div class="new-collections-grid1-left simpleCart_shelfItem">
                            <a href="../ProductSale/Default.aspx" class="blog-btn">Know More</a>
                        </div>
                        <br />
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="clearfix"></div>
    </div>
    <div class="testimonials" id="testimonials">
        <div class="container">
            <div class="w3_agile_team_grid">

                <div class="w3-heading-all">
                    <h3>What Our <span>Clients</span> Says</h3>

                </div>
                <div class="clearfix"></div>
            </div>
            <div class="w3ls_testimonials_grids">
                <section class="center slider">
                    <div class="agileits_testimonial_grid">
                        <div class="w3l_testimonial_grid">
                            <p>
                                In eu auctor felis, id eleifend dolor. Integer bibendum dictum erat, 
									non laoreet dolor.
                            </p>
                            <h4>Rosy Crisp</h4>
                            <h5>Student</h5>
                            <div class="w3l_testimonial_grid_pos">
                                <img src="images/t1.jpg" alt=" " class="img-responsive" />
                            </div>
                        </div>
                    </div>
                    <div class="agileits_testimonial_grid">
                        <div class="w3l_testimonial_grid">
                            <p>
                                In eu auctor felis, id eleifend dolor. Integer bibendum dictum erat, 
									non laoreet dolor.
                            </p>
                            <h4>Laura Paul</h4>
                            <h5>Student</h5>
                            <div class="w3l_testimonial_grid_pos">
                                <img src="images/t2.jpg" alt=" " class="img-responsive" />
                            </div>
                        </div>
                    </div>
                    <div class="agileits_testimonial_grid">
                        <div class="w3l_testimonial_grid">
                            <p>
                                In eu auctor felis, id eleifend dolor. Integer bibendum dictum erat, 
									non laoreet dolor.
                            </p>
                            <h4>Michael Doe</h4>
                            <h5>Student</h5>
                            <div class="w3l_testimonial_grid_pos">
                                <img src="images/t3.jpg" alt=" " class="img-responsive" />
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div class="subscribe">
        <div class="container">
            <h3 class="heading">Subscribe to get notifications</h3>
            <div class="subscribe-grid">
                <form action="#" method="post">
                    <input type="email" placeholder="Enter Your Email" name="email" required="">
                    <button class="btn1"><i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
