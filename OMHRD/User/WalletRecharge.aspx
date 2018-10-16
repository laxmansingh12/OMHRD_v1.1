<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="WalletRecharge.aspx.cs" Inherits="OMHRD.User.WalletRecharge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>Wallet Recharge</strong></h2>
            </div>
            <div class="col-md-4">
                <label>User </label>
                <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-control" required=""></asp:DropDownList>
            </div>
            <div class="col-md-4">
                <label>Amount </label>
                <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" required=""></asp:TextBox>
            </div>
            <br />
            <div class="col-md-4">
                <center><asp:Button ID="btnsubmit" runat="server" Text="Submit" style="width:125px;"  CausesValidation="False" CommandName="Transfer" OnClientClick="return confirm('Are you sure you want to transfer this Amount ?');" CssClass="btn btn-success" OnClick="btnsubmit_Click" /></center>
            </div>

            <br />
            <asp:GridView ID="gdvNotice" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84"
                BorderStyle="None" BorderWidth="1px"
                CellSpacing="2" >
                <HeaderStyle BackColor="#003366" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <RowStyle BackColor="#DEDEDC" Height="20px" />
                <PagerStyle BackColor="#003366" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle ForeColor="White" BackColor="#A7CE54" />
                <Columns>
                    <asp:TemplateField HeaderText="Sl.#">
                        <ItemTemplate>
                            <asp:Label ID="labelSrNo" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("Id") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="User_id" HeaderText="User Name" SortExpression="File" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="File" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="File" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
