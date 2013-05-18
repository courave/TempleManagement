<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="CWCS_OL.tables.employee.report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var hideToolBar = function () {
            document.getElementById("toolBar").style.display = "none";
        }
        var hideSummary = function () {
            var s = document.getElementById("summary");
            var a = document.getElementById("aSummary");
            if (a.innerText == "隐藏统计信息") {
                s.style.display = "none";
                a.innerText = "显示统计信息";
            }
            else {
                s.style.display = "inline";
                a.innerText = "隐藏统计信息";
            }
        }
        var hideHistory = function () {
            var h = document.getElementById("history");
            var a = document.getElementById("aHistory");
            if (a.innerText == "隐藏详细信息") {
                h.style.display = "none";
                a.innerText = "显示详细信息";
            }
            else {
                h.style.display = "inline";
                a.innerText = "隐藏详细信息";
            }
        }
    </script>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="toolBar">
        <asp:TextBox ID="TextBox_from" runat="server"></asp:TextBox>--
        <asp:TextBox ID="TextBox_to" runat="server"></asp:TextBox>
        <asp:Button ID="Button_get" runat="server" Text="生成报表" 
            onclick="Button_get_Click" />
        &nbsp;<a href="#" onclick="hideToolBar();">隐藏该行</a>
        &nbsp;<a href="#" onclick="hideSummary();" id="aSummary">隐藏统计信息</a>
        &nbsp;<a href="#" onclick="hideHistory();" id="aHistory">隐藏详细信息</a>
    </div>
    <div id="summary" runat="server">
    </div>
    <div id="history" runat="server">
    </div>
    </form>
</body>
</html>
