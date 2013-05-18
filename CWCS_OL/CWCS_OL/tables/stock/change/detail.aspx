<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.stock.change.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        仓库编号：<asp:Label ID="Label_StockId" runat="server"></asp:Label>
        <br />
        单号：<asp:Label ID="Label_BillNo" runat="server"></asp:Label>
        <br />
        货品编号：<asp:Label ID="Label_GoodsNo" runat="server"></asp:Label>
        <br />
        货品名称：<asp:Label ID="Label_Name" runat="server"></asp:Label>
        <br />
        条形码：<asp:Label ID="Label_BarCode" runat="server"></asp:Label>
        <br />
        类别：<asp:Label ID="Label_Category" runat="server"></asp:Label>
        <br />
        规格：<asp:Label ID="Label_Specification" runat="server"></asp:Label>
        <br />
        单位：<asp:Label ID="Label_Unit" runat="server"></asp:Label>
        <br />
        数量：<asp:Label ID="Label_Amount" runat="server"></asp:Label>
        <br />
        总价：<asp:Label ID="Label_TotalPrice" runat="server"></asp:Label>
        <br />
        原因：<asp:Label ID="Label_FromTo" runat="server"></asp:Label>
        <br />
        负责人：<asp:Label ID="Label_Manager" runat="server"></asp:Label>
        <br />
        时间：<asp:Label ID="Label_EditTime" runat="server"></asp:Label>
        <br />
        登记人：<asp:Label ID="Label_Operator" runat="server"></asp:Label>
        <br />
        备注：<asp:Label ID="Label_Remark" runat="server"></asp:Label>
        <br />
        <br />    </div>
    <asp:Button ID="Button_edit" runat="server" onclick="Button_edit_Click" 
        Text="编辑(E)" AccessKey="e" />
    <br />
    <asp:Button ID="Button_prev" runat="server" AccessKey="p" Text="上一条(P)" />
    <asp:Button ID="Button_next" runat="server" AccessKey="t" Text="下一条(T)" />
    </form>
</body>
</html>
