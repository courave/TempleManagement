﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.wangsheng.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        法会名称：<asp:TextBox ID="TextBox_fahui_name" runat="server"></asp:TextBox>
        <br />
    字号：<asp:TextBox ID="TextBox_zihao" runat="server"></asp:TextBox>
        <br />
    座次：<asp:TextBox ID="TextBox_zuoci" runat="server"></asp:TextBox>
        <br />
    佛光接引一：<asp:TextBox ID="TextBox_jieyin1" runat="server"></asp:TextBox>
        <br />
    佛光接引二：<asp:TextBox ID="TextBox_jieyin2" runat="server"></asp:TextBox>
        <br />
    佛光接引三：<asp:TextBox ID="TextBox_jieyin3" runat="server"></asp:TextBox>
        <br />
    佛光接引四：<asp:TextBox ID="TextBox_jieyin4" runat="server"></asp:TextBox>
        <br />
    阳上一：<asp:TextBox ID="TextBox_yangshang1" runat="server"></asp:TextBox>
        <br />
    阳上二：<asp:TextBox ID="TextBox_yangshang2" runat="server"></asp:TextBox>
        <br />
    阳上三：<asp:TextBox ID="TextBox_yangshang3" runat="server"></asp:TextBox>
        <br />
    阳上四：<asp:TextBox ID="TextBox_yangshang4" runat="server"></asp:TextBox>
        <br />
    登记人：<asp:TextBox ID="TextBox_log_user" runat="server" 
            BackColor="#999999" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        <br />
    登记时间：<asp:TextBox ID="TextBox_log_time" runat="server" BackColor="#999999" 
            BorderStyle="None" ReadOnly="True"></asp:TextBox>
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
