<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ShoppingHistory.aspx.cs" Inherits="OMHRD.User.ShoppingHistory" %>

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
                    <div class="col-md-12 product-list">
                        <asp:ListView ID="ListView1" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1">
                            <LayoutTemplate>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="col-sm-12">
                                    <div class="new-collections-grid1 animated wow slideInUp product-detail" data-wow-delay=".5s">
                                        <div class="col-sm-2">
                                            <a href='productdetail.aspx?st=<%# Eval("ITEM_ID") %>'>
                                                <img src='<%# "../images/ItemImages/" +DataBinder.Eval(Container.DataItem, "Image")%>' style="height: 60px;" alt=" " class="img-responsive" /></a>
                                        </div>
                                        <div class="col-sm-5">
                                            <h4><a href='productdetail.aspx?st=<%#DataBinder.Eval(Container.DataItem, "ITEM_ID")%>'><%#DataBinder.Eval(Container.DataItem, "ITEMNAME")%> </a></h4>
                                            <p><%#DataBinder.Eval(Container.DataItem,"Description").ToString().Length>20?Eval("Description").ToString().Substring(0,20): Eval("Description").ToString() %></p>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="new-collections-grid1-left simpleCart_shelfItem">
                                                <p><span class="item_price">&#8377;<span> <%# DataBinder.Eval(Container.DataItem,"DisscountPrice") %> </span></span></p>
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
                                                                <asp:Label runat="server" ID="lblqty"><%# DataBinder.Eval(Container.DataItem,"Qty") %></asp:Label>
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
                    <b>
                        <asp:Label runat="server" ID="lblStatus" Style="font-size: 20px;"></asp:Label></b>
                    <br />
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
