<%@ Page Title="" Language="C#" MasterPageFile="~/PickUp/PickUp.Master" AutoEventWireup="true" CodeBehind="SaleProduct.aspx.cs" Inherits="OMHRD.PickUp.SaleProduct" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>Sale Form</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-4">
                        <div>
                            <label>User </label>
                            <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div>
                            <label>Products </label>
                            <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div>
                            <label>Item Code </label>
                            <asp:TextBox ID="txtItemCode" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-2">
                        <div>
                            <label>CGST </label>
                            <asp:TextBox ID="txtcgst" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div>
                            <label>SGST </label>
                            <asp:TextBox ID="txtsgst" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div>
                            <label>IGST </label>
                            <asp:TextBox ID="txtigst" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div>
                            <label>Rate </label>
                            <asp:TextBox ID="txtrate" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div>
                            <label>Quantity </label>
                            <asp:TextBox ID="numqty" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="col-md-2">
                        <div>
                            <asp:Button ID="btnsave" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnsave_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <asp:GridView ID="gdvNotice" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                <HeaderStyle BackColor="#003366" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <RowStyle BackColor="#DEDEDC" Height="20px" />
                <PagerStyle BackColor="#003366" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle ForeColor="White" BackColor="#A7CE54" />
                <Columns>
                    <asp:TemplateField HeaderText="SrNo">
                        <ItemTemplate>
                            <asp:Label ID="labelSrNo" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("INVOICE_ID") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ITEM_ID" HeaderText="Item Name " SortExpression="File" />
                    <asp:BoundField DataField="QUANTITY" HeaderText="Qty" SortExpression="File" />
                    <asp:BoundField DataField="RATE_PER" HeaderText="Rate" SortExpression="File" />
                    <asp:BoundField DataField="TOTAL" HeaderText="Total" SortExpression="File" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkbtnEdit" runat="server" OnClick="linkbtnEdit_Click">Edit</asp:LinkButton>
                            <asp:LinkButton ID="linkbtnDelete" runat="server" OnClick="linkbtnDelete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            <br />
            <asp:Panel runat="server" ID="Payment">
                <div class="row">
                    <div class="col-md-4">
                        <label>Payment Option</label>
                        <asp:RadioButton runat="server" ID="rdCash" GroupName="Payment" Text="Cash" CssClass="btn btn-success" AutoPostBack="true" OnCheckedChanged="rdCash_CheckedChanged" />
                        <asp:Button ID="btndallbill" runat="server" Text="Pay" CssClass="btn btn-success" OnClick="btndallbill_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:RadioButton runat="server" ID="rdWalllet" GroupName="Payment" Text="Walllet" CssClass="btn btn-success" AutoPostBack="true" OnCheckedChanged="rdWalllet_CheckedChanged" />
                        <asp:Button ID="btnOtp" runat="server" Text="Generate OTP" CssClass="btn btn-success" OnClick="btnOtp_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtComfirmotp" placeholder="Enter the OTP" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="btnWelletpay" runat="server" Text="Payment" CssClass="btn btn-success" OnClick="btnWelletpay_Click" />
                    </div>
                </div>
            </asp:Panel>
            <br />

            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="945px">
                <LocalReport ReportPath="Report/PickUpSale.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </div>

</asp:Content>
