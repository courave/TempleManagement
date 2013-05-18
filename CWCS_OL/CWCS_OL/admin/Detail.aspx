<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="CWCS_OL.admin.Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            编号：<asp:Label ID="Label_id" runat="server"></asp:Label>
        <br />
        姓名：<asp:Label ID="Label_name" runat="server"></asp:Label>
        <br />
        权限：<asp:Label ID="Label_permission" runat="server"></asp:Label>
        <br />
    </div>
        <asp:Button ID="Button_edit" runat="server" onclick="Button_edit_Click" 
        Text="编辑" />
    </form>
</body>
</html>
