<%@ Page Title="" Language="C#" MasterPageFile="~/PickUp/PickUp.Master" AutoEventWireup="true" CodeBehind="frmProfileUpdate.aspx.cs" Inherits="OMHRD.PickUp.frmProfileUpdate" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <p>&nbsp;</p>
                <h1 style="float: left; color: #1292aa;">UPDATE PROFILE</h1>
                <br />
                <div>
                    <br />
                    <h2>
                        <font color="red"></font>
                    </h2>
                </div>

                <h2 style="font-size: 12px;">Update your information below, then click the Submit Changes button.</h2>
                <br />
                <h2 style="font-size: 12px;">You can change the information as often as you like. </h2>
                <h2 style="font-size: 12px;">The changes made here will be active immediately.  </h2>
                <br />
                <h2 style="font-size: 12px;">We recommend that you change your password often. </h2>
                <br />
            </div>
            <div class="col-md-6">
                <h2>Amount in wallet  <i class="fa fa-inr" style="font-size: 18px; color: red"></i>
                    <asp:Label runat="server" ID="lblWallet"></asp:Label></h2>
            </div>
        </div>

        <form id="Refresh" method="post">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="padding-right: 7px;">
                            <h2><strong>MY INFORMATION</strong> <a href="Default.aspx"><span class="glyphicon glyphicon-refresh"></span></a></h2>
                        </div>
                        <div class="col-md-6">
                            <label>First Name :</label>
                            <asp:TextBox ID="txtFname" runat="server" CssClass="form-control"></asp:TextBox>
                            <label>Last Name</label>
                            <asp:TextBox ID="txtLName" runat="server" CssClass="form-control"></asp:TextBox>
                            <label>User Name :</label>
                            <asp:Label ID="lblUsername" runat="server" CssClass="form-control"></asp:Label>
                            <label>Center Name :</label>
                            <asp:Label ID="lblCname" runat="server" CssClass="form-control"></asp:Label>
                            <label>Center  Code : </label>
                            <asp:Label ID="lblCCode" runat="server" CssClass="form-control"></asp:Label>
                            <label>Address :</label>
                            <asp:TextBox ID="txtadd" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <label>Pincode  :</label>
                            <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>State : </label>
                            <asp:DropDownList runat="server" ID="DropState" CssClass="form-control" OnSelectedIndexChanged="DropState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <label>City :</label>
                            <asp:DropDownList runat="server" ID="DropCity" CssClass="form-control"></asp:DropDownList>
                            <div class="col-md-4">
                                <label>Contact Number : </label>
                                <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Alternate No. : </label>
                                <asp:TextBox ID="txtAlternate1" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Other No. : </label>
                                <asp:TextBox ID="txtAlternate2" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <label>Gstin / Unique Id : </label>
                            <asp:TextBox ID="txtgst" runat="server" CssClass="form-control"></asp:TextBox>
                            <label>Registration Date :</label>
                            <asp:Label ID="lblRegdate" runat="server" CssClass="form-control"></asp:Label>
                            <label>Status :</label>
                            <asp:Label ID="lblstatus" runat="server" CssClass="form-control"></asp:Label>
                            <br />
                            <asp:Button runat="server" ID="btnUpdate" Text="Submit Changes" CssClass="btn btn-success" OnClick="btnUpdate_Click" /></td>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
