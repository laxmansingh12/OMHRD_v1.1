<%@ Page Title="" Language="C#" MasterPageFile="~/PickUp/PickUp.Master" AutoEventWireup="true" CodeBehind="AllItemsList.aspx.cs" Inherits="OMHRD.PickUp.AllItemsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <div class="col-lg-1"></div>
            <div class="col-lg-4">
                <asp:TextBox ID="txtPname" CssClass="form-control" placeholder="Search By Product Name" runat="server" OnTextChanged="txtPname_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
            <div class="col-lg-4">
                <asp:TextBox ID="txtPcode" runat="server" CssClass="form-control" placeholder="Search By Product Code" OnTextChanged="txtPcode_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
            <div class="col-lg-3">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back To List</asp:LinkButton>
            </div>
        </div>
        <hr />
        <div class="col-lg-12">
            <asp:GridView ID="gdvNotice" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="4" OnPageIndexChanging="gdvNotice_PageIndexChanging" ForeColor="#333333" GridLines="None">
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" Height="20px" />
                <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                <SelectedRowStyle ForeColor="#333333" BackColor="#D1DDF1" Font-Bold="True" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="SrNo">
                        <ItemTemplate>
                            <asp:Label ID="labelSrNo" runat="server"
                                Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("ITEM_ID") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ITEMNAME" HeaderText="Name" SortExpression="File" />
                    <asp:BoundField DataField="CODE" HeaderText="Code" SortExpression="File" />
                    <asp:BoundField DataField="HSNCODE" HeaderText="HSNCODE" SortExpression="File" />
                    <asp:BoundField DataField="DiscountPrice" HeaderText="Discount Price" SortExpression="File" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="File" />
                </Columns>
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
