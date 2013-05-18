<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.stock.goods.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        货品编号：<asp:TextBox ID="TextBox_GoodsNo" runat="server"></asp:TextBox>
        <br />
        货品名称：<asp:TextBox ID="TextBox_Name" runat="server"></asp:TextBox>
        <br />
        条形码：<asp:TextBox ID="TextBox_BarCode" runat="server"></asp:TextBox>
        <br />
        类别：<asp:TextBox ID="TextBox_Category" runat="server"></asp:TextBox>
        <br />
        规格：<asp:TextBox ID="TextBox_Specification" runat="server"></asp:TextBox>
        <br />
        单位：<asp:TextBox ID="TextBox_Unit" runat="server"></asp:TextBox>
        <br />
        备注：<asp:TextBox ID="TextBox_Remark" runat="server"></asp:TextBox>
        <br />
    </div>
    <asp:Button ID="Button_save" runat="server" Text="保存(S)" 
        onclick="Button_save_Click" AccessKey="s" />
    &nbsp;&nbsp;
    <asp:Button ID="Button_cancel" runat="server" Text="取消(C)" 
        onclick="Button_cancel_Click" AccessKey="c" />
    <br />
    <asp:Button ID="Button_savenext" runat="server" AccessKey="d" 
        onclick="Button_savenext_Click" Text="保存并下一条(D)" />
    </form>
</body>
</html>
