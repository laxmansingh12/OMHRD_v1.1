<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmEditPickupDetail.aspx.cs" Inherits="OMHRD.Admin.frmEditPickupDetail" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Refresh" method="post">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="padding-right: 7px;">
                        <h2><strong>PICKUP  INFORMATION </strong><a href="Default.aspx"><span class="glyphicon glyphicon-refresh"></span></a></h2>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div>
                                <label>First Name  : </label>
                                <asp:Label ID="lblFname" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <div>
                                <label>Last Name  : </label>
                                <asp:Label ID="lblLName" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <div>
                                <label>User Name :</label>
                                <asp:TextBox ID="txtuser" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <label>Password : </label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div>
                                <label>Center Name :</label>
                                <asp:Label ID="lblCname" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <div>
                                <label>Center Code : </label>
                                <asp:Label ID="lblCCode" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <div>
                                <label>Address : </label>
                                <asp:Label ID="lblAdd" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <div>
                                <label>Unique / GSTIN Id : </label>
                                <asp:Label ID="lblId" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div>
                                <label>Contact Number :</label>
                                <asp:Label ID="lblContact" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <div>
                                <label>Registration Date : </label>
                                <asp:Label ID="lblRegdate" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                            <br />
                            <center><asp:Button runat="server" ID="btnUpdate" Text="Submit Changes" CssClass="btn btn-success" OnClick="btnUpdate_Click" /></center>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
