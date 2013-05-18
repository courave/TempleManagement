<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.shizhuinfo.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/My97DatePicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    施主编号：<asp:TextBox ID="TextBox_id" runat="server"></asp:TextBox><br />
    姓名：<asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox><br />
    性别：<asp:DropDownList ID="DropDownList_sex" runat="server">
            <asp:ListItem>男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:DropDownList>
        <br />
    家庭住址：<asp:TextBox ID="TextBox_addr" runat="server"></asp:TextBox><br />
    家庭邮编：<asp:TextBox ID="TextBox_zip" runat="server"></asp:TextBox><br />
    家庭电话：<asp:TextBox ID="TextBox_tel" runat="server"></asp:TextBox><br />
    手机：<asp:TextBox ID="TextBox_mobile" runat="server"></asp:TextBox><br />
    施主类型：<asp:DropDownList ID="DropDownList_type" runat="server">
        </asp:DropDownList>
        <br />
    电子邮件：<asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox><br />
    教育程度：<asp:DropDownList ID="DropDownList_edu" runat="server">
            <asp:ListItem>本科</asp:ListItem>
            <asp:ListItem>硕士</asp:ListItem>
            <asp:ListItem>博士</asp:ListItem>
            <asp:ListItem>大专</asp:ListItem>
            <asp:ListItem>职高</asp:ListItem>
        </asp:DropDownList>
        <br />
    国籍：<asp:TextBox ID="TextBox_nationality" runat="server"></asp:TextBox><br />
    省/市：<asp:TextBox ID="TextBox_city" runat="server"></asp:TextBox><br />
    区/县：<asp:TextBox ID="TextBox_district" runat="server"></asp:TextBox><br />
    身份证：<asp:TextBox ID="TextBox_idcode" runat="server"></asp:TextBox>
        <br />
    <asp:TextBox ID="TextBox_birthday" runat="server" style=" display:none;"></asp:TextBox>
    <br />
    日期类型：<asp:DropDownList ID="DropDownList_birthtype" runat="server">
            <asp:ListItem>公历</asp:ListItem>
            <asp:ListItem>农历</asp:ListItem>
        </asp:DropDownList>
        <br />
        月：<asp:TextBox ID="TextBox_month" runat="server"></asp:TextBox>
        日：<asp:TextBox ID="TextBox_day" runat="server"></asp:TextBox>
        <br />
   <asp:TextBox ID="TextBox_lunarday" runat="server" style=" display:none;"></asp:TextBox>
        <br />
    退信：<asp:DropDownList ID="DropDownList_tuixin" runat="server">
            <asp:ListItem>否</asp:ListItem>
            <asp:ListItem>是</asp:ListItem>
        </asp:DropDownList>
        <br />
    三皈：<asp:TextBox ID="TextBox_sangui" runat="server"></asp:TextBox><br />
    五戒：<asp:TextBox ID="TextBox_wujie" runat="server"></asp:TextBox><br />
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
