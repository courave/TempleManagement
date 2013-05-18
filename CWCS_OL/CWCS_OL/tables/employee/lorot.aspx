<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lorot.aspx.cs" Inherits="CWCS_OL.tables.employee.lorot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../Scripts/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:DropDownList ID="DropDownList_lorot" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList_lorot_SelectedIndexChanged">
        <asp:ListItem Value="l">请假</asp:ListItem>
        <asp:ListItem Value="ot">加班</asp:ListItem>
    </asp:DropDownList>
    <div id="leave" runat="server">
    

    <div id="leave_summary" runat="server"></div>

                    请假事由：<asp:TextBox ID="TextBox_reason" runat="server" Width="70%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBox_reason" ErrorMessage="*"></asp:RequiredFieldValidator>
<br />
                    请假类型：<asp:DropDownList ID="DropDownList_type" runat="server" 
                        AutoPostBack="True">
                        <asp:ListItem>事假</asp:ListItem>
                        <asp:ListItem>年假</asp:ListItem>
                        <asp:ListItem>病假</asp:ListItem>
                        <asp:ListItem>工差价</asp:ListItem>
                    </asp:DropDownList>
 <br />
                    请假时间：<span id="zg_time" runat="server">从 
                    <asp:TextBox ID="TextBox_from" runat="server"></asp:TextBox>
                    <img onclick="WdatePicker({el:'TextBox_from',dateFmt:'yyyy-MM-dd HH:mm:ss'})" src="../../Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" alt="datepicker" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TextBox_from" ErrorMessage="*"></asp:RequiredFieldValidator>
到 
                    <asp:TextBox ID="TextBox_to" runat="server"></asp:TextBox>
                    <img onclick="WdatePicker({el:'TextBox_to',dateFmt:'yyyy-MM-dd HH:mm:ss'})" src="../../Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" alt="datepicker" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TextBox_to" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </span>
                        <span id="fs_time" runat="server">
                            <asp:TextBox ID="TextBox_fsday" runat="server"></asp:TextBox>天
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
            runat="server" ErrorMessage="*" ControlToValidate="TextBox_fsday"></asp:RequiredFieldValidator>
                        </span>
                        <br />
                    <asp:Button ID="Button_submit" runat="server" onclick="Button_submit_Click" 
                        Text="提交" />
 
                    <div id="leave_history" runat="server"></div>

    </div>

    <div id="overtime" runat="server">
    

    <div id="ot_summary" runat="server"></div>
        加班事由：<asp:TextBox ID="TextBoxj_reason" runat="server" Width="70%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBoxj_reason" ErrorMessage="*"></asp:RequiredFieldValidator>
<br />
                    加班类型：<asp:DropDownList ID="DropDownListj_type" runat="server" 
                        AutoPostBack="True">
                        <asp:ListItem>普通</asp:ListItem>
                        <asp:ListItem>节假日</asp:ListItem>
                        <asp:ListItem>补休</asp:ListItem>
                    </asp:DropDownList>
 <br />
                    加班时间：从 
                    <asp:TextBox ID="TextBoxj_from" runat="server"></asp:TextBox>
                    <img onclick="WdatePicker({el:'TextBoxj_from',dateFmt:'yyyy-MM-dd HH:mm:ss'})" src="../../Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" alt="datepicker" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TextBoxj_from" ErrorMessage="*"></asp:RequiredFieldValidator>
到 
                    <asp:TextBox ID="TextBoxj_to" runat="server"></asp:TextBox>
                    <img onclick="WdatePicker({el:'TextBoxj_to',dateFmt:'yyyy-MM-dd HH:mm:ss'})" src="../../Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" alt="datepicker" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="TextBoxj_to" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <br />
                    <asp:Button ID="Buttonj_submit" runat="server" onclick="Buttonj_submit_Click" 
                        Text="提交" />
 
                    <div id="ot_history" runat="server"></div>

    </div>
    </form>
</body>
</html>
