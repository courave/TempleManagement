<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.fashiinfo.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    法号：<asp:Label ID="Label_FAHAO" runat="server"></asp:Label><br />
    姓名：<asp:Label ID="Label_NAME" runat="server"></asp:Label><br />
    职位：<asp:Label ID="Label_ZHIWEI" runat="server"></asp:Label><br />
    </div>
    <asp:Button ID="Button_edit" runat="server" onclick="Button_edit_Click" 
        Text="编辑(E)" AccessKey="e" />
    <br />
    <asp:Button ID="Button_prev" runat="server" AccessKey="p" Text="上一条(P)" />
    <asp:Button ID="Button_next" runat="server" AccessKey="t" Text="下一条(T)" />
    </form>
</body>
</html>
