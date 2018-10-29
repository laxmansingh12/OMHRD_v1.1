<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmpayout.aspx.cs" Inherits="OMHRD.AdminPanel.frmpayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmAlreadyExist() {
            var isGenerated = parseInt($("#hdnPayoutGenerated").val()) > 0;
            if (isGenerated) {
                return confirm("Payout is already generated for this month, do you want to regerate ?");
            }
            else {
                return true;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>Payout Detail</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="col-md-6">
                            <label>Payout Date : </label>
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <label>Total Amount : </label>
                            <asp:TextBox ID="txttotalAmount" runat="server" CssClass="form-control" required=""></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <label>TDS : </label>
                            <asp:CheckBox runat="server" ID="chkTDS" Text="Please tick if TDS in percentage" />
                            <asp:TextBox ID="txtTds" runat="server" CssClass="form-control" required="" OnTextChanged="txtTds_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <label>Welfare : </label>
                            <asp:CheckBox runat="server" ID="chkWel" Text="Please tick if Welfare in percentage" />
                            <asp:TextBox ID="txtwelfare" runat="server" CssClass="form-control" required="" OnTextChanged="txtwelfare_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <label>Charity : </label>
                            <asp:CheckBox runat="server" ID="chkCharity" Text="Please tick if Charity in percentage" />
                            <asp:TextBox ID="txtCharity" runat="server" CssClass="form-control" required="" OnTextChanged="txtCharity_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <label>Miscell : </label>
                            <asp:CheckBox runat="server" ID="chkMiscell" Text="Please tick if Miscell in percentage" />
                            <asp:TextBox ID="txtMiscell" runat="server" CssClass="form-control" required="" OnTextChanged="txtMiscell_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <label>Other Amount : </label>
                            <asp:TextBox ID="txtOtherAmount" runat="server" CssClass="form-control" required="" OnTextChanged="txtOtherAmount_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="col-md-6">
                            <div>
                                <label>Qualifier User</label>
                                <asp:DropDownList ID="dropActive" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropActive_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Payment in %</label>
                            <asp:DropDownList ID="ddlPayPercent" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPayPercent_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-12">
                            <label>Active User</label>
                            <asp:GridView ID="gdvActiveUser" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
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
                                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("Registration_ID") %>'
                                                Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="First_Name" HeaderText="Name" SortExpression="File" />
                                    <asp:BoundField DataField="User_Name" HeaderText="User Name" SortExpression="File" />
                                    <asp:BoundField DataField="ContactNumber" HeaderText="Contact" SortExpression="File" />
                                    <asp:BoundField DataField="Payout" HeaderText="Amount" SortExpression="File" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <center><asp:Button ID="btnsubmit" runat="server" OnClientClick="return confirmAlreadyExist()" Width="150px" Text="Submit" CssClass="btn btn-success" OnClick="btnsubmit_Click" /></center>

                    </div>

                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnPayoutGenerated" ClientIDMode="Static" Value="0" runat="server" />
</asp:Content>
