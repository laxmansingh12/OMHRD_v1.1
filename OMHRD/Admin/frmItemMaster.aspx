<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmItemMaster.aspx.cs" Inherits="OMHRD.AdminPanel.frmItemMaster" %>

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
    <script type="text/javascript">
        function ShowIMAGES1(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Image1.ClientID%>').prop('src', e.target.result)
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
                        $get('<%= Image1.ClientID %>').src = '';
                        document.getElementById("<%= fileImage1.ClientID %>").value = '';

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
        function ShowIMAGES2(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Image2.ClientID%>').prop('src', e.target.result)
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
                        $get('<%= Image2.ClientID %>').src = '';
                        document.getElementById("<%= fileImage2.ClientID %>").value = '';

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
                <h2><strong>Add Item</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div>
                        <label>Caterogy Name : </label>
                        <asp:DropDownList ID="dropCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="dropCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div>
                        <label>Sub Caterogy Name : </label>
                        <asp:DropDownList ID="dropSubCate" runat="server" CssClass="form-control" OnSelectedIndexChanged="dropSubCate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div>
                        <label>Item Name</label>
                        <asp:TextBox ID="txtitemName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>Item Code</label>
                        <asp:TextBox ID="txtitemCode" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>HSN Code</label>
                        <asp:TextBox ID="txthsnCode" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>Item Description</label>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>Unit And Color</label>
                        <asp:GridView ID="gvUnits" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Code" HeaderText="Unit" Visible="true" ControlStyle-CssClass="hide" />
                                <asp:BoundField DataField="Color_Code" HeaderText="Color" Visible="true" ControlStyle-CssClass="hide" />
                                <asp:BoundField DataField="Name" HeaderText="Unit" />
                                <asp:BoundField DataField="Color_NAME" HeaderText="Color" />
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtQty" Width="100px" placeholder="Quantity" Text='<%# Eval("Quantity")%>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtPrice" Width="100px" placeholder="Price" Text='<%# Eval("Price")%>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Discount Price">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtDiscount" Width="120px" placeholder="Discount Price" Text='<%# Eval("DisscountPrice")%>'></asp:TextBox>
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

                <div class="col-md-6">
                    <div>
                        <label>Tax Rate </label>
                        <asp:TextBox ID="txtCGST" runat="server" AutoPostBack="true" TextMode="Number" placeholder="CGST" CssClass="form-control" OnTextChanged="txtCGST_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtSGST" runat="server" TextMode="Number" placeholder="SGST" CssClass="form-control"></asp:TextBox>
                        <asp:TextBox ID="txtIGST" runat="server" TextMode="Number" placeholder="IGST" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <label>Opening Stock</label>
                        <asp:TextBox ID="txtstock" runat="server" TextMode="Number" Visible="false" Text="0" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <div>
                        <asp:Image ID="Image" runat="server" Width="120px" Height="140px" CssClass="sf" />
                        <asp:FileUpload ID="fileImage" runat="server" onchange="ShowIMAGES(this);" accept="image/*" />
                        <asp:Image ID="Image1" runat="server" Width="120px" Height="140px" CssClass="sf" />
                        <asp:FileUpload ID="fileImage1" runat="server" onchange="ShowIMAGES1(this);" accept="image/*" />
                        <asp:Image ID="Image2" runat="server" Width="120px" Height="140px" CssClass="sf" />
                        <asp:FileUpload ID="fileImage2" runat="server" onchange="ShowIMAGES2(this);" accept="image/*" />
                    </div>
                </div>
                <br />
                <center> <asp:Button ID="btnsubmit" runat="server" Text="Submit" Width="130px" CssClass="btn btn-success" OnClick="btnsubmit_Click" /></center>
            </div>
        </div>
    </div>
</asp:Content>
