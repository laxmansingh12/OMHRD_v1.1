<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmChangePassword.aspx.cs" Inherits="OMHRD.AdminPanel.frmChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>Change Password</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div>
                        <label>Old Password : </label>
                        <asp:TextBox ID="txtOld" runat="server" TextMode="Password" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>New Password</label>
                        <asp:TextBox ID="txtnewpassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>confirm Password</label>
                        <asp:TextBox ID="txtcomformpassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <center><asp:Button ID="btnsubmit" runat="server" Text="Change Password" CssClass="btn btn-success" OnClick="btnsubmit_Click" /></center>
        </div>
    </div>
</asp:Content>
