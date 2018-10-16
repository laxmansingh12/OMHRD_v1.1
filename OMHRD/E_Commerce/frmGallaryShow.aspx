<%@ Page Title="" Language="C#" MasterPageFile="~/E_Commerce/E_Commerce.Master" AutoEventWireup="true" CodeBehind="frmGallaryShow.aspx.cs" Inherits="OMHRD.E_Commerce.frmGallaryShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="gallery">
        <div class="container">
            <div class="w3-heading-all">
                <h3>Gallery</h3>
            </div>
            <div class="inner_w3l_agile_grids-1">

                <asp:ListView ID="ListView1" runat="server" Visible="true" ItemPlaceholderID="PlaceHolder1">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="col-md-3 gallery-grid gallery1">

                            <a href='<%# "../images/Gallery/"+ Eval("FileName") %>' class="swipebox">
                                <img src='<%# "../images/Gallery/"+ Eval("FileName") %>' class="img-responsive" style="width: 370px; height: 338px;" />

                                <div class="textbox">
                                    <h4>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Heading") %>'></asp:Label>
                                    </h4>
                                </div>
                                <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>
