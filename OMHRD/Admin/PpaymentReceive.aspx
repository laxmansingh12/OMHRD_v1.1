<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PpaymentReceive.aspx.cs" Inherits="OMHRD.AdminPanel.PpaymentReceive" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>Payment Receive Form</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>User Name :</label>
                            <asp:DropDownList ID="ddlUserName" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Amount in Wallet :</label>
                            <asp:TextBox ID="txtamount" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Remark :</label>
                            <asp:TextBox ID="txtremark" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <center> <asp:Button runat="server" ID="btnPayment" Text="Submit" Width="100px" CssClass="btn btn-primary" OnClick="btnPayment_Click" /></center>
                    </div>
                </div>
            </div>


            <asp:GridView ID="gdvNotice" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84"
                BorderStyle="None" BorderWidth="1px"
                CellSpacing="2">
                <HeaderStyle BackColor="#003366" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <RowStyle BackColor="#DEDEDC" Height="20px" />
                <PagerStyle BackColor="#003366" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle ForeColor="White" BackColor="#A7CE54" />
                <Columns>
                    <asp:TemplateField HeaderText="SrNo">
                        <ItemTemplate>
                            <asp:Label ID="labelSrNo" runat="server"
                                Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("Paymemt_ID") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="User_Name" HeaderText="User Name" SortExpression="File" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="File" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkbtnEdit" runat="server" OnClick="linkbtnEdit_Click">Edit</asp:LinkButton>
                            <asp:LinkButton ID="linkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"
                                OnClientClick="return confirm('Are you certain you want to delete this ?');" OnClick="linkbtnDelete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
