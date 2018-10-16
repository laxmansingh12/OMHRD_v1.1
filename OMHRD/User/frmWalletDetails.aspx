<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="frmWalletDetails.aspx.cs" Inherits="OMHRD.User.frmWalletDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <p>&nbsp;</p>
                <h3 style="float: left; color: #1292aa;">MY AMOUNT DETAILS</h3>
                <br />
                <div>
                    <br />
                    <h2>
                        <font color="red"></font>
                    </h2>
                </div>
                <br />
            </div>
            <div class="col-md-6">
                <p>&nbsp;</p>
                <div>
                    <h2>Amount in wallet  <i class="fa fa-inr" style="font-size: 18px; color: red"></i>
                        <%-- <asp:Label runat="server" ID="lblWallet"></asp:Label>--%></h2>
                </div>
            </div>
        </div>

        <form id="Refresh" method="post">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="padding-right: 7px;">
                            <h3><strong>Amount in wallet</strong> <a href="Default.aspx"><span class="glyphicon glyphicon-refresh"></span></a></h3>
                        </div>
                        <div>
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <th>Amount in wallet : <i class="fa fa-inr" style="font-size: 18px; color: red"></i></th>
                                        <th>
                                            <asp:Label runat="server" ID="lblWallet"></asp:Label>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3><strong>Shopping Details</strong></h3>
                        </div>
                        <div class="table-responsive allowTextWrap">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <th>Total Shopping : </th>
                                        <th>
                                            <asp:Label runat="server" ID="lbltotal"></asp:Label>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <%--    <asp:Button runat="server" ID="btnUpdate" Text="Submit Changes" CssClass="btn btn-success" />--%>
                        <br />
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
