<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminWalletRecharge.aspx.cs" Inherits="OMHRD.Admin.AdminWalletRecharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>My Wallet Recharge</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <label>Amount </label>
                    <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" required=""></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <br />
                    <center><asp:Button ID="btnsubmit" runat="server" Text="Submit" style="width:125px;"  CssClass="btn btn-success" OnClick="btnsubmit_Click" /></center>
                </div>
                <br />
                <div class="col-md-6">
                    <asp:GridView ID="gdvNotice" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="4" OnPageIndexChanging="gdvNotice_PageIndexChanging" ForeColor="#333333" GridLines="None" PageSize="5">
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <RowStyle BackColor="#EFF3FB" Height="20px" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle ForeColor="#333333" BackColor="#D1DDF1" Font-Bold="True" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.#">
                                <ItemTemplate>
                                    <asp:Label ID="labelSrNo" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("Id") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="File" />
                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="File" />
                        </Columns>
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
