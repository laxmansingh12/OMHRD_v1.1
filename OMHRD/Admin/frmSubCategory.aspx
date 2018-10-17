<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmSubCategory.aspx.cs" Inherits="OMHRD.AdminPanel.frmSubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>Add Sub Caterogy</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div>
                        <label>Caterogy</label>
                        <asp:DropDownList ID="dropCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div>
                        <label>Sub Caterogy Name : </label>
                        <asp:TextBox ID="txtcategory" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>Unit</label>
                        <div>
                            <asp:CheckBoxList ID="chkUnitList" runat="server" CssClass="table" RepeatDirection="Horizontal" RepeatColumns="3" RepeatLayout="Table" class=""></asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div>
                        <label>Color</label>
                        <div>
                            <asp:CheckBoxList ID="chkUnitColor" runat="server" CssClass="table" RepeatDirection="Horizontal" RepeatColumns="3" RepeatLayout="Table" class=""></asp:CheckBoxList>
                        </div>
                    </div>
                    <div>
                        <label>Remark</label>
                        <asp:TextBox ID="txtremark" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <div>
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
                    <asp:TemplateField HeaderText="SrNo">
                        <ItemTemplate>
                            <asp:Label ID="labelSrNo" runat="server"
                                Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("SubCategory_ID") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Category_Name" HeaderText="Caterogy" SortExpression="File" />
                    <asp:BoundField DataField="SubCategory_NAME" HeaderText="Sub Category" SortExpression="File" />
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
