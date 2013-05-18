<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.gongde.detail" %>

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
    出生日期：<asp:Label ID="Label_birthday" runat="server"></asp:Label><br />
    日期类型：<asp:Label ID="Label_birthtype" runat="server"></asp:Label><br />
    农历日期：<asp:Label ID="Label_lunarday" runat="server"></asp:Label><br />
    退信：<asp:Label ID="Label_tuixin" runat="server"></asp:Label><br />
    捐赠编号：<asp:Label ID="Label_donate_no" runat="server"></asp:Label><br />
    捐赠类别：<asp:Label ID="Label_donate_type" runat="server"></asp:Label><br />
    捐赠金额：<asp:Label ID="Label_donate_money" runat="server"></asp:Label><br />
    发票号码：<asp:Label ID="Label_invoice_no" runat="server"></asp:Label><br />
    捐赠日期：<asp:Label ID="Label_donate_date" runat="server"></asp:Label><br />
    经办人：<asp:Label ID="Label_log_user" runat="server"></asp:Label><br />
    经办日期：<asp:Label ID="Label_log_time" runat="server"></asp:Label><br />
    功德芳名：<asp:Label ID="Label_gongde_fangming" runat="server"></asp:Label><br />
    捐赠说明：<asp:Label ID="Label_donate_description" runat="server"></asp:Label><br />
    备注：<asp:Label ID="Label_donate_comments" runat="server"></asp:Label><br />
    </div>
    <asp:Button ID="Button_edit" runat="server" onclick="Button_edit_Click" 
        Text="编辑(E)" AccessKey="e" />
    <br />
    <asp:Button ID="Button_prev" runat="server" AccessKey="p" Text="上一条(P)" />
    <asp:Button ID="Button_next" runat="server" AccessKey="t" Text="下一条(T)" />
    </form>
</body>
</html>
