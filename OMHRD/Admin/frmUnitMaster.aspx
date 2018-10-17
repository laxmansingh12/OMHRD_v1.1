<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmUnitMaster.aspx.cs" Inherits="OMHRD.AdminPanel.frmUnitMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>Add Unit</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <label>Unit Name </label>
                    <asp:TextBox ID="txtname" runat="server" CssClass="form-control" required=""></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Unit Code </label>
                    <asp:TextBox ID="txtcode" runat="server" CssClass="form-control" required=""></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Description</label>
                    <asp:TextBox ID="txtDes" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <br />
                    <center><asp:Button ID="btnsubmit" runat="server" Text="Submit" style="width:125px;" CssClass="btn btn-success" OnClick="btnsubmit_Click" /></center>
                </div>
            </div>
        </div>
        <br />
        <asp:GridView ID="gdvNotice" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="4" OnPageIndexChanging="gdvNotice_PageIndexChanging" ForeColor="#333333" GridLines="None">
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
                        <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("UNIT_ID") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Unit Name" SortExpression="File" />
                <asp:BoundField DataField="Code" HeaderText="Unit Code" SortExpression="File" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="File" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkbtnEdit" runat="server" OnClick="linkbtnEdit_Click">Edit</asp:LinkButton>
                        <asp:LinkButton ID="linkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"
                            OnClientClick="return confirm('Are you certain you want to delete this ?');" OnClick="linkbtnDelete_Click">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
            </Columns>
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </div>
</asp:Content>
