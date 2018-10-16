<%@ Page Title="" Language="C#" MasterPageFile="~/PickUp/PickUp.Master" AutoEventWireup="true" CodeBehind="OrderFrm.aspx.cs" Inherits="OMHRD.PickUp.OrderFrm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>Order Form</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-3">
                        <div>
                            <label>Products </label>
                            <asp:DropDownList ID="ddlItem" runat="server" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div>
                            <label>Item Code </label>
                            <asp:TextBox ID="txtItemCode" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
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
                    <div class="col-md-2">
                        <div>
                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnsubmit_Click" />
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
                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("OrderId") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemName" HeaderText="Item Name " SortExpression="File" />
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
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-3">
                        <div>
                            <label>Number Of Products </label>
                            <asp:TextBox ID="txtNOPro" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div>
                            <label>Extra Paid </label>
                            <asp:TextBox ID="txtextra" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div>
                            <label>Remark </label>
                            <asp:TextBox ID="txtremark" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div>
                            <asp:Button ID="txtOrderbill" runat="server" Text="Send Order" CssClass="btn btn-success" OnClick="txtOrderbill_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="935px">
            </rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>
