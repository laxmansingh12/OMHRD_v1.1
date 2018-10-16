<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddGallery.aspx.cs" Inherits="OMHRD.Admin.AddGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowIMAGES(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=ImagePhoto.ClientID%>').prop('src', e.target.result)
                        .width(100)
                        .height(100);
                    };
                    reader.readAsDataURL(input.files[0]);
                    }
                }
            }
            function Upload(input) {
                USER:
                    if (typeof (input.files) != null) {
                        var size = parseFloat(input.files[0].size / 10244).toFixed(2);
                        if (size > 15000) {
                            alert("File size should be atmost 150 KB");
                            $get('<%= ImagePhoto.ClientID %>').src = '';
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
                <h2><strong>Add Gallery</strong></h2>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div>
                        <label>File : </label>
                        <asp:Image ID="ImagePhoto" runat="server" Width="120px" Height="140px" CssClass="sf" />
                        <asp:FileUpload ID="fileImage" runat="server" CssClass="form-control" onchange="ShowIMAGES(this);" accept="image/*" />
                    </div>
                    <div>
                        <label>Heading</label>
                        <asp:TextBox ID="txthesd" runat="server" CssClass="form-control"></asp:TextBox>
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
                            <asp:Label ID="labelNOTICE_ID" runat="server" Text='<%# Bind("Id") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Heading" HeaderText="Heading" SortExpression="File" />
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
