<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmNewCollection.aspx.cs" Inherits="OMHRD.AdminPanel.frmNewCollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowIMAGES(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Image.ClientID%>').prop('src', e.target.result)
                        .width(120)
                        .height(130);
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
                        $get('<%= Image .ClientID %>').src = '';
                        document.getElementById("<%= fileImage.ClientID %>").value = '';

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
            <div class="panel-heading" style="padding-right: 7px;">
                <h2><strong>Add New Collection</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div>
                        <label>Caterogy Name : </label>
                        <asp:DropDownList ID="dropCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="dropCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div>
                        <label>Sub Caterogy Name : </label>
                        <asp:DropDownList ID="dropSubCate" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div>
                        <label>Item Name</label>
                        <asp:TextBox ID="txtitemName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>Item Description</label>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                    </div>

                </div>

                <div class="col-md-6">
                    <div>
                        <label>Discount Price</label>
                        <asp:TextBox ID="txtdiscountPrice" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>Price</label>
                        <asp:TextBox ID="txtprice" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div>
                        <asp:Image ID="Image" runat="server" Width="120px" Height="140px" CssClass="sf" />
                        <asp:FileUpload ID="fileImage" runat="server" onchange="ShowIMAGES(this);" accept="image/*" />
                    </div>
                </div>
            </div>
            <center><asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnsubmit_Click" /></center>
            <asp:GridView ID="gdvNotice" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84"
                BorderStyle="None" BorderWidth="1px"
                CellSpacing="2" OnPageIndexChanging="gdvNotice_PageIndexChanging">
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
                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("NewCollection_ID") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ITEMNAME" HeaderText="Caterogy Name" SortExpression="File" />
                    <asp:BoundField DataField="DiscountPrice" HeaderText="Remark" SortExpression="File" />
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
