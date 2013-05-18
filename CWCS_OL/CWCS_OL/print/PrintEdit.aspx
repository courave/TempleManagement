<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintEdit.aspx.cs" Inherits="CWCS_OL.print.PrintEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑打印模板</title>

    <script type="text/javascript" src="printedit.js"></script>

    <style type="text/css">
        .rRightDown, .rLeftDown, .rLeftUp, .rRightUp, .rRight, .rLeft, .rUp, .rDown
        {
            position: absolute;
            background: #C00;
            width: 7px;
            height: 7px;
            z-index: 5;
            font-size: 0;
        }
        .rLeftDown, .rRightUp
        {
            cursor: ne-resize;
        }
        .rRightDown, .rLeftUp
        {
            cursor: nw-resize;
        }
        .rRight, .rLeft
        {
            cursor: e-resize;
        }
        .rUp, .rDown
        {
            cursor: n-resize;
        }
        .rLeftDown
        {
            left: -4px;
            bottom: -4px;
        }
        .rRightUp
        {
            right: -4px;
            top: -4px;
        }
        .rRightDown
        {
            right: -4px;
            bottom: -4px;
            background-color: #00F;
        }
        .rLeftUp
        {
            left: -4px;
            top: -4px;
        }
        .rRight
        {
            right: -4px;
            top: 50%;
            margin-top: -4px;
        }
        .rLeft
        {
            left: -4px;
            top: 50%;
            margin-top: -4px;
        }
        .rUp
        {
            top: -4px;
            left: 50%;
            margin-left: -4px;
        }
        .rDown
        {
            bottom: -4px;
            left: 50%;
            margin-left: -4px;
        }
        .section
        {
            border: 1px solid #666666;
            position: relative;
        }
        .field
        {
            border: 1px solid #000000;
            background: #fff;
            cursor: move;
            word-wrap:break-word;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        模板名称：
        <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>
    &nbsp; 模板类型：<asp:DropDownList ID="DropDownList_type" runat="server" Enabled="False">
            <asp:ListItem Value="yansheng">延生表</asp:ListItem>
            <asp:ListItem Value="yansheng_single">延生表（单）</asp:ListItem>
            <asp:ListItem Value="wangsheng">往生表</asp:ListItem>
            <asp:ListItem Value="wangsheng_single">往生表（单）</asp:ListItem>
            <asp:ListItem Value="sanshi">三时系列</asp:ListItem>
            <asp:ListItem Value="sanshi_single">三时系列（单）</asp:ListItem>
            <asp:ListItem Value="fahua">法华法会</asp:ListItem>
            <asp:ListItem Value="fahua_single">法华法会（单）</asp:ListItem>
            <asp:ListItem Value="fashi">法师信息表</asp:ListItem>
        </asp:DropDownList>
    &nbsp;
        <asp:CheckBox ID="CheckBox_default" runat="server" Text="默认模板" />
    </div>

    <hr />



    </form>
</body>
</html>
