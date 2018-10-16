<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ShoppingHistory.aspx.cs" Inherits="OMHRD.Admin.ShoppingHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h4>Your Orders&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <strong>My Total Shopping : &#8377;<asp:Label runat="server" ID="lbltotal"></asp:Label></strong></h4>
            </div>

            <div class="row">
                <div class="col-md-12">

                    <asp:ListView ID="ListView1" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1">
                        <LayoutTemplate>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div class="col-sm-12">
                                <div class="new-collections-grid1 animated wow slideInUp product-detail" data-wow-delay=".5s">
                                    <div class="col-sm-2">
                                        <div class="new-collections-grid1-left simpleCart_shelfItem">
                                            <asp:Label runat="server" ID="Label1"><%# DataBinder.Eval(Container.DataItem,"Qty") %></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <a href='../ProductSale/productdetail.aspx?st=<%# Eval("ITEM_ID") %>'>
                                            <img src='<%# "../images/ItemImages/" +DataBinder.Eval(Container.DataItem, "Image")%>' style="height: 60px;" alt=" " class="img-responsive" /></a>
                                    </div>
                                    <div class="col-sm-4">
                                        <h4><a href='../ProductSale/productdetail.aspx?st=<%#DataBinder.Eval(Container.DataItem, "ITEM_ID")%>'><%#DataBinder.Eval(Container.DataItem, "ITEMNAME")%> </a></h4>
                                        <p><%#DataBinder.Eval(Container.DataItem,"Description").ToString().Length>20?Eval("Description").ToString().Substring(0,20): Eval("Description").ToString() %></p>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="new-collections-grid1-left simpleCart_shelfItem">
                                            <p><span class="item_price">&#8377;<span> <%# DataBinder.Eval(Container.DataItem,"DisscountPrice") %> </span></span></p>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="new-collections-grid1-left simpleCart_shelfItem">
                                            <asp:Label runat="server" ID="Label2"><%# DataBinder.Eval(Container.DataItem,"PaymentDate","{0:dd/MM/yyyy}") %></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
