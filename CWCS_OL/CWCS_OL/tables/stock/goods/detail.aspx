<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.stock.goods.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
