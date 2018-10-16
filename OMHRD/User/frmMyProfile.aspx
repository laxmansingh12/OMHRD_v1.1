<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="frmMyProfile.aspx.cs" Inherits="OMHRD.User.frmMyProfile" EnableEventValidation="false" %>

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
    <script type="text/javascript">
        function ShowAdhar(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(100)
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
                        document.getElementById("<%= fileAdhar.ClientID %>").value = '';

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
        function ShowPan(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Image2.ClientID%>').prop('src', e.target.result)
                        .width(100)
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
                        document.getElementById("<%= filePan.ClientID %>").value = '';

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
        function ShowCheque(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Image3.ClientID%>').prop('src', e.target.result)
                        .width(100)
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
                        $get('<%= Image3.ClientID %>').src = '';
                        document.getElementById("<%= fileCheque.ClientID %>").value = '';

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
        function ShowVoter(input) {
            if (Upload(input) == true) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Image4.ClientID%>').prop('src', e.target.result)
                        .width(100)
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
                        $get('<%= Image4.ClientID %>').src = '';
                        document.getElementById("<%= fileAdd.ClientID %>").value = '';

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
        function CopyText() {
            var tb1 = $('<%= "#" + txtFname.ClientID%>').val();
            var tb2 = $('<%= "#" + txtLName.ClientID%>').val();
            var tb3 = $('<%= "#" + txtAddress.ClientID%>').val();
            var tb4 = $('<%= "#" + txtAddressline2.ClientID%>').val();
            var tb5 = $('<%= "#" + txtZipCode.ClientID%>').val();
            var tb11 = $('<%= "#" + txtShipFname.ClientID%>').val();
            var tb12 = $('<%= "#" + txtShipLname.ClientID%>').val();
            var tb13 = $('<%= "#" + txtShipAdd.ClientID%>').val();
            var tb14 = $('<%= "#" + txtShipAdd2.ClientID%>').val();
            var tb15 = $('<%= "#" + txtShipZipCode.ClientID%>').val();
            if ($('<%="#"+checkAddress.ClientID%>').is(":checked")) {
                $('<%= "#" + txtShipFname.ClientID%>').val(tb1);
                $('<%= "#" + txtShipLname.ClientID%>').val(tb2);
                $('<%= "#" + txtShipAdd.ClientID%>').val(tb3);
                $('<%= "#" + txtShipAdd2.ClientID%>').val(tb4);
                $('<%= "#" + txtShipZipCode.ClientID%>').val(tb5);
            }
            else {
                $('<%= "#" + txtShipFname.ClientID%>').val('');
                $('<%= "#" + txtShipLname.ClientID%>').val('');
                $('<%= "#" + txtShipAdd.ClientID%>').val('');
                $('<%= "#" + txtShipAdd2.ClientID%>').val('');
                $('<%= "#" + txtShipZipCode.ClientID%>').val('');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <p>&nbsp;</p>
                <h1 style="float: left; color: #1292aa;">UPDATE MY PROFILE</h1>
                <br />
                <div>
                    <br />
                    <h2>
                        <font color="red"></font>
                    </h2>
                </div>

                <h2 style="font-size: 12px;">Update your information below, then click the Submit Changes button.</h2>
                <br />
                <h2 style="font-size: 12px;">You can change the information as often as you like. </h2>
                <h2 style="font-size: 12px;">The changes made here will be active immediately.  </h2>
                <br />
                <h2 style="font-size: 12px;">We recommend that you change your password often. </h2>
                <br />
            </div>
            <div class="col-md-6">
                <p>&nbsp;</p>
                <div>
                    <h2>Print <a href="#">ID Card</a></h2>
                    <br />
                    <h2>Amount in wallet  <i class="fa fa-inr" style="font-size: 18px; color: red"></i>
                        <asp:Label runat="server" ID="lblWallet"></asp:Label></h2>
                </div>
            </div>
        </div>

        <form id="Refresh" method="post">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="padding-right: 7px;">
                            <h2><strong>MY INFORMATION</strong> <a href="Default.aspx"><span class="glyphicon glyphicon-refresh"></span></a></h2>
                        </div>
                        <asp:UpdatePanel ID="updatepnl" runat="server">
                            <ContentTemplate>
                                <table class="table">
                                    <tbody>
                                        <tr>
                                            <th>User Name : </th>
                                            <th>
                                                <asp:Label ID="lblUsername" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>User ID : </th>
                                            <th>
                                                <asp:Label ID="lblUSerId" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Individual/Company:</th>
                                            <th>
                                                <asp:TextBox ID="txtIndividual" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Identification Type : </th>
                                            <th>
                                                <asp:Label ID="lblIdentiType" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Tax Exempt : </th>
                                            <th>
                                                <asp:Label ID="lblTaxExempt" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Commission WithHolding Exempt : </th>
                                            <th>
                                                <asp:Label ID="lblCommHoldExempt" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>XXX : </th>
                                            <th>
                                                <asp:Label ID="lblW9File" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Signup Date : </th>
                                            <th>
                                                <asp:Label ID="lblSignupDate" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Anniversary Date(dd/MM/yyyy) : </th>
                                            <th>
                                                <asp:TextBox ID="txtAnniversaryDate" runat="server" TextMode="DateTime" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Re Purchase Date : </th>
                                            <th>
                                                <asp:Label ID="lblSmartDeliveryDate" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Status : </th>
                                            <th>
                                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Sponsor User Name : </th>
                                            <th>
                                                <asp:Label ID="lblSponsorUserName" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>First Name(English) :</th>
                                            <th>
                                                <asp:TextBox ID="txtFname" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Last Name : </th>
                                            <th>
                                                <asp:TextBox ID="txtLName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>DOB (dd/MM/yyyy) :</th>
                                            <th>
                                                <asp:TextBox ID="txtDOB" runat="server" TextMode="DateTime" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Contact Number : </th>
                                            <th>
                                                <asp:TextBox ID="txtHomePhone" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Alternate Contact Number : </th>
                                            <th>
                                                <asp:TextBox ID="txtAlternetContact" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Name on Website : </th>
                                            <th>
                                                <asp:TextBox ID="txtwebsite" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Address (Line 1) : </th>
                                            <th>
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Address (Line 2) : </th>
                                            <th>
                                                <asp:TextBox ID="txtAddressline2" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>State/Province : </th>
                                            <th>
                                                <asp:DropDownList runat="server" ID="DropState" CssClass="form-control" OnSelectedIndexChanged="DropState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>City : </th>
                                            <th>
                                                <asp:DropDownList runat="server" ID="DropCity" CssClass="form-control"></asp:DropDownList>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>If Other:
                                            </th>
                                            <th>
                                                <asp:TextBox ID="txtStateOther" runat="server" CssClass="form-control"></asp:TextBox></th>
                                        </tr>
                                        <tr>
                                            <th>Zip Code : </th>
                                            <th>
                                                <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Country : </th>
                                            <th>
                                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Shipping Same As Above : </th>
                                            <th>
                                                <asp:CheckBox runat="server" ID="checkAddress" Text="Same as above" onclick="CopyText()" />
                                                <%--  <asp:CheckBox ID="checkAddress" runat="server" />--%>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Shipping First Name : </th>
                                            <th>
                                                <asp:TextBox ID="txtShipFname" runat="server" CssClass="form-control"></asp:TextBox></th>
                                        </tr>
                                        <tr>
                                            <th>Shipping Last Name :</th>
                                            <th>
                                                <asp:TextBox ID="txtShipLname" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Shipping Address (Line 1) : </th>
                                            <th>
                                                <asp:TextBox ID="txtShipAdd" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Shipping Address (Line 2) : </th>
                                            <th>
                                                <asp:TextBox ID="txtShipAdd2" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Shipping State/Province: </th>
                                            <th>
                                                <asp:DropDownList runat="server" ID="dropShipstate" CssClass="form-control" OnSelectedIndexChanged="dropShipstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Shipping City : </th>
                                            <th>
                                                <asp:DropDownList runat="server" ID="dropShipCity" CssClass="form-control"></asp:DropDownList>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>If Other:
                                            </th>
                                            <th>
                                                <asp:TextBox ID="txtShipStateOther" runat="server" CssClass="form-control"></asp:TextBox></th>
                                        </tr>
                                        <tr>
                                            <th>Shipping Zip Code : </th>
                                            <th>
                                                <asp:TextBox ID="txtShipZipCode" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Shipping Country : </th>
                                            <th>
                                                <asp:Label ID="lblShipCountry" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Email Address : </th>
                                            <th>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Fax Number : </th>
                                            <th>
                                                <asp:TextBox ID="txtFaxNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>Co-Applicant Name :</td>
                                            <td>
                                                <asp:Label ID="lblCoApplicantName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="panel-heading" style="padding-right: 7px;">
                            <h2><strong>NEW USER POSITION</strong></h2>
                        </div>
                        <div class="table-responsive allowTextWrap">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <th>USER :</th>
                                        <th>
                                            <asp:DropDownList runat="server" ID="dropNewUser" CssClass="form-control"></asp:DropDownList>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>Parent USER :</th>
                                        <th>
                                            <asp:DropDownList runat="server" ID="dropParentUser" CssClass="form-control"></asp:DropDownList>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="padding-right: 7px;">
                            <h2><strong>MY REFERENCE DTEAILS</strong> <a href="frmMyProfile.aspx"><span class="glyphicon glyphicon-refresh"></span></a></h2>
                        </div>
                        <div class="table-responsive allowTextWrap">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <th>MY REFERENCE PERSONS :</th>
                                        <th>
                                            <asp:DropDownList runat="server" ID="dropMyRef" CssClass="form-control"></asp:DropDownList>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="panel-heading">
                            <h2><strong>BANK DETAILS</strong></h2>
                        </div>
                        <div class="table-responsive allowTextWrap">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <td>Bank Name :</td>
                                        <td>
                                            <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Account Number :</td>
                                        <td>
                                            <asp:TextBox ID="txtaccount" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>IFSC Code :</td>
                                        <td>
                                            <asp:TextBox ID="txtifsc" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Branch :</td>
                                        <td>
                                            <asp:TextBox ID="txtbranch" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="panel-heading">
                            <h2><strong>COMMUNICATIONS PROFILE</strong></h2>
                        </div>
                        <div class="table-responsive allowTextWrap">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <th>Language : </th>
                                        <th>
                                            <asp:DropDownList runat="server" ID="dropLanguage" CssClass="form-control"></asp:DropDownList>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>Do you wish to receive Emails ?  : </th>
                                        <th>
                                            <asp:RadioButton ID="RadioButton3" runat="server" Text="Yes" />
                                            <asp:RadioButton ID="RadioButton1" runat="server" Text="No(I will check BackOffice for Online Versions) " />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>Do you wish to receive Emails ?  : </th>
                                        <th>
                                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Yes" />
                                            <asp:RadioButton ID="RadioButton4" runat="server" Text="No(I will check BackOffice for Online Versions) " />
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>Skype Account :</td>
                                        <td>
                                            <asp:TextBox ID="txtSkype" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Twitter(ex. @Name) :</td>
                                        <td>
                                            <asp:TextBox ID="txtTwitter" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Facebook page/URL :</td>
                                        <td>
                                            <asp:TextBox ID="txtFacebook" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="panel-heading" style="padding-right: 7px;">
                            <h2><strong>SECURITY QUESTIONS</strong> <a href="Default.aspx"><span class="glyphicon glyphicon-refresh"></span></a></h2>
                        </div>
                        <div class="table-responsive allowTextWrap">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <th>Shipping Same As Above : </th>
                                        <th>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="panel-heading" style="padding-right: 7px;">
                            <h2><strong>ID/CERTIFICATE</strong> <a href="Default.aspx"><span class="glyphicon glyphicon-refresh"></span></a></h2>
                        </div>
                        <div class="table-responsive allowTextWrap">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <th>Aadhar Card Number : </th>
                                        <th>
                                            <asp:TextBox ID="txtadhar" runat="server" CssClass="form-control" placeholder="Aadhar Card Number"></asp:TextBox>
                                            <asp:Image ID="Image1" runat="server" Width="220px" Height="100px" CssClass="sf" />
                                            <asp:FileUpload ID="fileAdhar" runat="server" onchange="ShowAdhar(this);" accept="image/*" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>Pan Card Number (Optional) : </th>
                                        <th>
                                            <asp:TextBox ID="txtPancard" runat="server" CssClass="form-control" placeholder="Pan Card Number"></asp:TextBox>
                                            <asp:Image ID="Image2" runat="server" Width="220px" Height="100px" CssClass="sf" />
                                            <asp:FileUpload ID="filePan" runat="server" onchange="ShowPan(this);" accept="image/*" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>Cancelled   : </th>
                                        <th>
                                            <asp:TextBox ID="txtCheque" runat="server" CssClass="form-control" placeholder="Cheque Number"></asp:TextBox>
                                            <asp:Image ID="Image3" runat="server" Width="220px" Height="100px" CssClass="sf" />
                                            <asp:FileUpload ID="fileCheque" runat="server" onchange="ShowCheque(this);" accept="image/*" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>GSTIN/VAT Number (Optional) : </th>
                                        <th>
                                            <asp:TextBox ID="txtgst" runat="server" CssClass="form-control" placeholder="GSTIN Number"></asp:TextBox>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>Proof of Address DL/Voter ID Card: </th>
                                        <th>
                                            <asp:TextBox ID="txtaddProof" runat="server" CssClass="form-control" placeholder=" DL / Voter ID Card Number"></asp:TextBox>
                                            <asp:Image ID="Image4" runat="server" Width="220px" Height="100px" CssClass="sf" />
                                            <asp:FileUpload ID="fileAdd" runat="server" onchange="ShowVoter(this);" accept="image/*" />
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="panel-heading" style="padding-right: 7px;">
                            <h2><strong>LOCK PLACEMENT</strong> <a href="Default.aspx"><span class="glyphicon glyphicon-refresh"></span></a></h2>
                        </div>
                        <div class="table-responsive allowTextWrap">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <th>Lock Placement : </th>
                                        <th>
                                            <asp:DropDownList runat="server" ID="droplockPlace" CssClass="form-control"></asp:DropDownList>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="panel-heading" style="padding-right: 7px;">
                            <h2><strong>PROFILE IMAGE</strong> <a href="Default.aspx"><span class="glyphicon glyphicon-refresh"></span></a></h2>
                        </div>
                        <div class="table-responsive allowTextWrap">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <th>Image : </th>
                                        <th>
                                            <asp:Image ID="ImagePhoto" runat="server" Width="120px" Height="140px" CssClass="sf" />
                                            <asp:FileUpload ID="fileImage" runat="server" CssClass="form-control" onchange="ShowIMAGES(this);" accept="image/*" />
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <asp:Button runat="server" ID="btnUpdate" Text="Submit Changes" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                        <br />
                    </div>
                </div>
            </div>
        </form>
    </div>
    <asp:HiddenField runat="server" ID="hdnUserprentId" />
</asp:Content>
