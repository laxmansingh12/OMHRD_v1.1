<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmBannerMaster.aspx.cs" Inherits="OMHRD.Admin.frmBannerMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowBanner(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(400)
                        .height(100);
                    };
                    reader.readAsDataURL(input.files[0]);
                    }
                }
            }
            function Upload(input) {

                if (typeof (input.files) != null) {
                    var size = parseFloat(input.files[0].size / 10244).toFixed(2);
                    if (size > 15000) {
                        alert("File size should be atmost 150 KB");
                        $get('<%= Image1.ClientID %>').src = '';
                        document.getElementById("<%= FileUpload1.ClientID %>").value = '';

                        return false;
                    }
                } else {
                    alert("This browser does not support HTML5.");
                    return false;
                }
                return true;
            }
    </script>
    <script type="text/javascript">
        function ShowFooter(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Image2.ClientID%>').prop('src', e.target.result)
                        .width(400)
                        .height(100);
                    };
                    reader.readAsDataURL(input.files[0]);
                    }
                }
            }
            function Upload(input) {

                if (typeof (input.files) != null) {
                    var size = parseFloat(input.files[0].size / 10244).toFixed(2);
                    if (size > 15000) {
                        alert("File size should be atmost 150 KB");
                        $get('<%= Image2.ClientID %>').src = '';
                        document.getElementById("<%= FileUpload2.ClientID %>").value = '';

                        return false;
                    }
                } else {
                    alert("This browser does not support HTML5.");
                    return false;
                }
                return true;
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h2><strong>Update User Detail</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div>
                        <label>Banner Heading first : </label>
                        <asp:TextBox ID="txtfirst" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>Banner Heading second  : </label>
                        <asp:TextBox ID="txtsecond" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>Banner Heading third </label>
                        <asp:TextBox ID="txtthird" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>Choose Banner Image </label>
                        <asp:Image ID="Image1" runat="server" Width="400px" Height="100px" CssClass="sf" />
                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="ShowBanner(this);" accept="image/*" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div>
                        <label>Footer Heading </label>
                        <asp:TextBox ID="txtFooter" runat="server" CssClass="form-control" required=""></asp:TextBox>
                    </div>
                    <div>
                        <label>Choose footer Image </label>
                        <asp:Image ID="Image2" runat="server" Width="400px" Height="100px" CssClass="sf" />
                        <asp:FileUpload ID="FileUpload2" runat="server" onchange="ShowFooter(this);" accept="image/*" />
                    </div>
                    <br />
                    <div>
                        <asp:Button ID="btnsub" runat="server" Text="Submit" CssClass="btn btn-success" Width="200px" OnClick="btnsub_Click" />
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
                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("FILE_ID") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="HEADING1" HeaderText="Heading 1" SortExpression="File" />
                    <asp:BoundField DataField="HEADING2" HeaderText="Heading 2" SortExpression="File" />
                    <asp:BoundField DataField="HEADING3" HeaderText="Heading 3" SortExpression="File" />

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkbtnEdit" runat="server" OnClick="linkbtnEdit_Click">Edit</asp:LinkButton>
                            <asp:LinkButton ID="linkbtnDelete" runat="server" OnClick="linkbtnDelete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
