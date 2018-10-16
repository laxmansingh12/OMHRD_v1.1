<%@ Page Title="" Language="C#" MasterPageFile="~/E_Commerce/E_Commerce.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="OMHRD.E_Commerce.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact" id="contact">
        <div class="container">
            <div class="agile-contact-grids">
                <div class="col-md-5 address">
                    <h4>Contact Info</h4>
                    <div class="address-row">
                        <div class="col-md-2 w3-agile-address-left">
                            <span class="glyphicon glyphicon-home" aria-hidden="true"></span>
                        </div>
                        <div class="col-md-10 w3-agile-address-right">
                            <h5>Visit Us</h5>
                            <p>
                                N.S-16, 3rd floor, Mianwali Nagar
                                <br>
                                New Delhi-110087 
                            </p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="address-row">
                        <div class="col-md-2 w3-agile-address-left">
                            <span class="glyphicon glyphicon-envelope" aria-hidden="true"></span>
                        </div>
                        <div class="col-md-10 w3-agile-address-right">
                            <h5>Mail Us</h5>
                            <p><a href="mailto:admin@omhrd.com">admin@omhrd.com</a></p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="address-row">
                        <div class="col-md-2 w3-agile-address-left">
                            <span class="glyphicon glyphicon-phone" aria-hidden="true"></span>
                        </div>
                        <div class="col-md-10 w3-agile-address-right">
                            <h5>Call Us</h5>
                            <p>+011-45072882</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="col-md-7 contact-form">
                    <form action="#" method="post">
                        <input type="text" name="First Name" placeholder="First Name" required="">
                        <input class="email" name="Last Name" type="text" placeholder="Last Name" required="">
                        <input type="text" name="Number" placeholder="Mobile Number" required="">
                        <input class="email" name="Email" type="text" placeholder="Email" required="">
                        <textarea name="Message" placeholder="Message" required=""></textarea>
                        <input type="submit" value="SUBMIT">
                    </form>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <!-- //contact -->
    <!-- map -->
    <div class="agileits-w3layouts-map">
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3500.439396912265!2d77.08230871468139!3d28.676499882400403!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x390d046b9d52f05b%3A0x3501a4cdbe022aa0!2sRashtriya+Gramin+Jan+Vikas+Yojna!5e0!3m2!1sen!2sin!4v1532043964281" width="600" height="450" frameborder="0" style="border: 0" allowfullscreen></iframe>
    </div>
</asp:Content>
