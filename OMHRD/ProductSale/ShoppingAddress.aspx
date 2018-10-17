<%@ Page Title="" Language="C#" MasterPageFile="~/ProductSale/ProductSale.Master" AutoEventWireup="true" CodeBehind="ShoppingAddress.aspx.cs" Inherits="OMHRD.ProductSale.ShoppingAddress" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="typo-grids">
            <div class="col-md-12">
                <div class="panel-heading">
                    <center> <h2><u><strong>Select a delivery address</strong></u></h2></center>
                </div>
                <br />
                <div class="col-md-6" style="border: inset">
                    <h3>Billing address</h3>
                    <asp:ListView ID="ListView1" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1">
                        <LayoutTemplate>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="new-collections-grid1 animated wow slideInUp" data-wow-delay=".5s">
                                <h4><b><%# Eval("First_Name") %> &nbsp;<%# Eval("Last_Name") %></b></h4>
                                <h4><%# Eval("Address") %></h4>
                                <h4><%# Eval("AddressLine2") %></h4>
                                <h4><%# Eval("CityName") %></h4>
                                <h4><%# Eval("StateName") %></h4>
                                <h4><%# Eval("ZipCode") %></h4>
                                <h4><%# Eval("ContactNumber") %></h4>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:LinkButton runat="server" ID="lnkedit" CssClass="btn btn-success" Text="Edit" OnClick="lnkedit_Click" />
                    <asp:LinkButton runat="server" ID="btndeliver" CssClass="btn btn-success" Text="Deliver to this address" OnClick="btndeliver_Click" />
                </div>
                <div class="col-md-6" style="border: inset">
                    <h3>Shipping address</h3>
                    <asp:ListView ID="gvdShippingAdd" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1">
                        <LayoutTemplate>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="new-collections-grid1 animated wow slideInUp" data-wow-delay=".5s">
                                <h4><b><%# Eval("ShippingFirstName") %> &nbsp;<%# Eval("ShippingLastName") %></b></h4>
                                <h4><%# Eval("ShippingAddress") %></h4>
                                <h4><%# Eval("ShippingAddressLine2") %></h4>
                                <h4><%# Eval("ShipCityName") %></h4>
                                <h4><%# Eval("ShippStateName") %></h4>
                                <h4><%# Eval("ShippingZip") %></h4>
                                <h4><%# Eval("ContactNumber") %></h4>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:LinkButton runat="server" ID="lnkedit2" CssClass="btn btn-success" Text="Edit" OnClick="lnkedit2_Click" />
                    <asp:LinkButton runat="server" ID="btndeliver2" CssClass="btn btn-success" Text="Deliver to this address" OnClick="btndeliver2_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
