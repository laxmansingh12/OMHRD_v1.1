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
                <div class="col-md-6">
                    <div>
                        <label>Unit Name </label>
                        <asp:TextBox ID="txtname" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>Unit Code </label>
                        <asp:TextBox ID="txtcode" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div>
                        <label>Description</label>
                        <asp:TextBox ID="txtDes" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <div>
                        <center><asp:Button ID="btnsubmit" runat="server" Text="Submit" style="width:125px;" CssClass="btn btn-success" OnClick="btnsubmit_Click" /></center>
                    </div>
                </div>
            </div>
            <br />
            <asp:GridView ID="gdvNotice" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84"
                BorderStyle="None" BorderWidth="1px"
                CellSpacing="2" OnPageIndexChanging="gdvNotice_PageIndexChanging">
                <HeaderStyle BackColor="#003366" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <RowStyle BackColor="#DEDEDC" Height="20px" />
                <PagerStyle BackColor="#003366" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle ForeColor="White" BackColor="#A7CE54" />
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
            </asp:GridView>
        </div>
    </div>
</asp:Content>
