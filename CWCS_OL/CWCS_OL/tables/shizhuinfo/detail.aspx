<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.shizhuinfo.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    施主编号：<asp:Label ID="Label_id" runat="server"></asp:Label><br />
    姓名：<asp:Label ID="Label_name" runat="server"></asp:Label><br />
    性别：<asp:Label ID="Label_sex" runat="server"></asp:Label><br />
    家庭住址：<asp:Label ID="Label_addr" runat="server"></asp:Label><br />
    家庭邮编：<asp:Label ID="Label_zip" runat="server"></asp:Label><br />
    家庭电话：<asp:Label ID="Label_tel" runat="server"></asp:Label><br />
    手机：<asp:Label ID="Label_mobile" runat="server"></asp:Label><br />
    施主类型：<asp:Label ID="Label_type" runat="server"></asp:Label><br />
    电子邮件：<asp:Label ID="Label_email" runat="server"></asp:Label><br />
    教育程度：<asp:Label ID="Label_edu" runat="server"></asp:Label><br />
    国籍：<asp:Label ID="Label_nationality" runat="server"></asp:Label><br />
    省/市：<asp:Label ID="Label_city" runat="server"></asp:Label><br />
    区/县：<asp:Label ID="Label_district" runat="server"></asp:Label><br />
    身份证：<asp:Label ID="Label_idcode" runat="server"></asp:Label><br />
    出生日期：<asp:Label ID="Label_birth" runat="server"></asp:Label><br />
    <asp:Label ID="Label_birthday" runat="server" style="display:none"></asp:Label>
    <asp:Label ID="Label_birthtype" runat="server" style="display:none"></asp:Label>
    <asp:Label ID="Label_lunarday" runat="server" style="display:none"></asp:Label>
    退信：<asp:Label ID="Label_tuixin" runat="server"></asp:Label><br />
    三皈：<asp:Label ID="Label_sangui" runat="server"></asp:Label><br />
    五戒：<asp:Label ID="Label_wujie" runat="server"></asp:Label><br />
    功德汇总：<div id="gongde" runat="server"></div><br />
    </div>
    <asp:Button ID="Button_edit" runat="server" onclick="Button_edit_Click" 
        Text="编辑(E)" AccessKey="e" />
    <br />
    <asp:Button ID="Button_prev" runat="server" AccessKey="p" Text="上一条(P)" />
    <asp:Button ID="Button_next" runat="server" AccessKey="t" Text="下一条(T)" />
    </form>
</body>
</html>