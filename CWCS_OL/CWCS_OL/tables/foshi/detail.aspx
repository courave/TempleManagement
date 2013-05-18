<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.foshi.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    斋主姓名：<asp:LinkButton ID="LinkButton_ZHAIZHU_NAME" runat="server"></asp:LinkButton>
        <br />
    日期时间：<asp:Label ID="Label_FOSHI_DATETIME" runat="server"></asp:Label><br />
    法师数：<asp:LinkButton ID="LinkButton_FASHI_COUNT" runat="server"></asp:LinkButton><br />
    接送地址：<asp:LinkButton ID="LinkButton_JIESONG_ADDR" runat="server"></asp:LinkButton><br />
    联系电话：<asp:Label ID="Label_TEL" runat="server"></asp:Label><br />
    经办人：<asp:Label ID="Label_LOG_USER" runat="server"></asp:Label><br />
    经办时间：<asp:Label ID="Label_LOG_TIME" runat="server"></asp:Label><br />
    备注：<asp:Label ID="Label_COMMENT" runat="server"></asp:Label><br />
    </div>
    <asp:Button ID="Button_edit" runat="server" Text="编辑(E)" AccessKey="e" />
    <br />
    <asp:Button ID="Button_prev" runat="server" AccessKey="p" Text="上一条(P)" />
    <asp:Button ID="Button_next" runat="server" AccessKey="t" Text="下一条(T)" />
    </form>
</body>
</html>
