﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="USerList.aspx.cs" Inherits="OMHRD.AdminPanel.USerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="col-lg-12">
                <div class="col-lg-1"></div>
                <div class="col-lg-3">
                    <asp:TextBox ID="txtUserName" placeholder="Search By UserName" runat="server" OnTextChanged="txtUserName_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="txtEmail" placeholder="Search By Email ID" runat="server" OnTextChanged="txtEmail_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="txtPhone" runat="server" placeholder="Search By Contact Number" OnTextChanged="txtPhone_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back To List</asp:LinkButton>
                </div>
            </div>
            <hr />
            <asp:GridView ID="gdvNotice" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84"
                BorderStyle="None" BorderWidth="1px"
                CellSpacing="2" OnPageIndexChanging="gdvNotice_PageIndexChanging">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#FFF7E7" Height="20px" ForeColor="#8C4510" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <SelectedRowStyle ForeColor="White" BackColor="#738A9C" Font-Bold="True" />
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
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="File" />
                    <asp:BoundField DataField="Email" HeaderText="Email ID" SortExpression="File" />
                    <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="File" />
                    <asp:BoundField DataField="Reference_Id" HeaderText="Reference Name" SortExpression="File" />
                    <asp:BoundField DataField="RegDate" HeaderText="Reg Date" SortExpression="File" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkbtnView" runat="server" OnClick="linkbtnView_Click">Edit Detail</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
