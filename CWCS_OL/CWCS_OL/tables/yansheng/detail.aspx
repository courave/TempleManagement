<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.yansheng.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    法会名称：<asp:Label ID="Label_fahui_name" runat="server"></asp:Label>
        <br />
    字号：<asp:Label ID="Label_zihao" runat="server"></asp:Label>
        <br />
    座次：<asp:Label ID="Label_zuoci" runat="server"></asp:Label>
        <br />
    佛光注照一：<asp:Label ID="Label_zhuzhao1" runat="server"></asp:Label>
        <br />
    佛光注照二：<asp:Label ID="Label_zhuzhao2" runat="server"></asp:Label>
        <br />
    佛光注照三：<asp:Label ID="Label_zhuzhao3" runat="server"></asp:Label>
        <br />
    佛光注照四：<asp:Label ID="Label_zhuzhao4" runat="server"></asp:Label>
        <br />
    登记人：<asp:Label ID="Label_log_user" runat="server"></asp:Label>
        <br />
    登记时间：<asp:Label ID="Label_log_time" runat="server"></asp:Label>
        <br />
    </div>
        <asp:Button ID="Button_edit" runat="server" onclick="Button_edit_Click" 
        Text="编辑(E)" AccessKey="e" />
    <br />
    <asp:Button ID="Button_prev" runat="server" AccessKey="p" Text="上一条(P)" />
    <asp:Button ID="Button_next" runat="server" AccessKey="t" Text="下一条(T)" />
    </form>
</body>
</html>
