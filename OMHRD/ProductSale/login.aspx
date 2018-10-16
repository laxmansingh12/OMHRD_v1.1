<%@ Page Title="" Language="C#" MasterPageFile="~/ProductSale/ProductSale.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OMHRD.ProductSale.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- breadcrumbs -->
    <div class="breadcrumbs">
        <div class="container">
            <ol class="breadcrumb breadcrumb1 animated wow slideInLeft" data-wow-delay=".5s">
                <li><a href="Default.aspx"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Home</a></li>
                <li class="active">Login Page</li>
            </ol>
        </div>
    </div>
    <!-- //breadcrumbs -->
    <!-- login -->
    <div class="login">
        <div class="container">
            <h3 class="animated wow zoomIn" data-wow-delay=".5s">Login Form</h3>
            <p class="est animated wow zoomIn" data-wow-delay=".5s">
                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia 
				deserunt mollit anim id est laborum.
            </p>
            <div class="login-form-grids animated wow slideInUp" data-wow-delay=".5s">
                <form method="post">
                    <div class="styled-input agile-styled-input-top">
                        <asp:TextBox ID="txtluser" runat="server" required=""></asp:TextBox>
                        <label>User Name</label>
                        <span></span>
                    </div>
                    <div class="styled-input">
                        <asp:TextBox ID="txtLpassword" runat="server" TextMode="Password" required=""></asp:TextBox>
                        <label>Password</label>
                        <span></span>
                    </div>
                    <center><asp:Button ID="btnLog" runat="server" Text="Log In" OnClick="btnLog_Click"/></center>
                </form>
            </div>
            <h4 class="animated wow slideInUp" data-wow-delay=".5s">For New People</h4>
            <p class="animated wow slideInUp" data-wow-delay=".5s"><a href="register.aspx">Register Here</a> (Or) go back to <a href="Default.aspx">Home<span class="glyphicon glyphicon-menu-right" aria-hidden="true"></span></a></p>
        </div>
    </div>
    <!-- //login -->
</asp:Content>
