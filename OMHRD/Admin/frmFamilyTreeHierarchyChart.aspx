<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmFamilyTreeHierarchyChart.aspx.cs" Inherits="OMHRD.Admin.frmFamilyTreeHierarchyChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">

        google.load("visualization", "1", { packages: ["orgchart"] });
        $(document).ready(function () {

            google.setOnLoadCallback(drawChart);
        });

        function drawChart() {
            var userId = '<%=  HttpContext.Current.Session["loginid"].ToString() %>';
            $.ajax({
                type: "POST",
                url: "../Webservice.asmx/GetChartData",
                data: JSON.stringify({ userId: userId }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = new google.visualization.DataTable();
                    data.addColumn('string', 'Entity');
                    data.addColumn('string', 'ParentEntity');
                    data.addColumn('string', 'ToolTip');
                    for (var i = 0; i < r.d.length; i++) {
                        var Registration_ID = r.d[i][0].toString();
                        var User_Name = r.d[i][1];
                        var UserParentId = r.d[i][2] != null ? r.d[i][2].toString() : '';
                        data.addRows([[{
                            v: Registration_ID,
                            f: User_Name + '<div><img src = "../images/ProfileImages/' + User_Name + '.jpg" height="80px;" width="100px;" /></div>'
                        }, UserParentId, User_Name]]);
                    }

                    var chart = new google.visualization.OrgChart($("#chart")[0]);
                    chart.draw(data, { allowHtml: true });
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="chart">
    </div>

</asp:Content>
