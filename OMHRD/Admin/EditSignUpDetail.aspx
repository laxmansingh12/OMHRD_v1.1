<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditSignUpDetail.aspx.cs" Inherits="OMHRD.Admin.EditSignUpDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h2><strong>Update User Detail</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div>
                        <label>First Name : </label>
                        <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>Last Name  : </label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>User Name  <span style="color: red; font-weight: bold">*</span></label>
                        <asp:TextBox ID="txtuseraname" runat="server" CssClass="form-control" Enabled="false" required=""></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div>
                        <label>Email ID </label>
                        <asp:TextBox ID="txtemail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>Contact No.</label>
                        <asp:TextBox ID="txtcontact" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>Reference ID</label>
                        <asp:TextBox ID="txtReferenceId" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <br />
                </div>
            </div>
            <center><asp:Button ID="btnSignUp" runat="server" Text="Submit Changes" CssClass="btn btn-success" OnClick="btnSignUp_Click" /></center>

        </div>
    </div>
</asp:Content>
