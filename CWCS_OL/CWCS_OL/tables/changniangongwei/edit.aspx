<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.changniangongwei.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript">
        function selFangwei(fangwei, row, col) {
            document.getElementById("TextBox_yuan").value = fangwei;
            document.getElementById("TextBox_pai").value = row;
            document.getElementById("TextBox_zuo").value = col;

        }
        function newSelector() {
            window.open('selector.aspx?type=changnian', 'newwindow', 'toolbar=no,menubar=no,location=no,status=no');
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; font-weight: bolder; font-size: x-large">
    
        常年供位登记单</div>
    <div style="text-align: center; font-size: large">&nbsp;类型：<asp:DropDownList 
            ID="DropDownList_type" runat="server" AutoPostBack="True">
        <asp:ListItem Value="yansheng">延生</asp:ListItem>
        <asp:ListItem Value="wangsheng">往生</asp:ListItem>
        </asp:DropDownList>
&nbsp; 登记日期：<asp:TextBox ID="TextBox_logdate" 
            runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp; 系统编号：<asp:TextBox ID="TextBox_bianhao" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox_yuan" runat="server"></asp:TextBox>
        苑&nbsp; 
        <asp:TextBox ID="TextBox_pai" runat="server"></asp:TextBox>
        排&nbsp; 
        <asp:TextBox ID="TextBox_zuo" runat="server"></asp:TextBox>
        座&nbsp; 
        <input id="Button_select" name="Button_select" type="button" value="选择" onclick="newSelector();" /></div>
        <div id="yansheng" runat="server">1、值福信：<asp:TextBox ID="TextBox_zhifuxin1" 
                runat="server"></asp:TextBox>
            <br />
            2、值福信：<asp:TextBox ID="TextBox_zhifuxin2" runat="server"></asp:TextBox>
            <br />
            3、值福信：<asp:TextBox ID="TextBox_zhifuxin3" runat="server"></asp:TextBox>
            <br />
            4、值福信：<asp:TextBox ID="TextBox_zhifuxin4" runat="server"></asp:TextBox>
        </div>
        <div id="wangsheng" runat="server">超荐：<asp:TextBox ID="TextBox_chaojian" 
                runat="server"></asp:TextBox>
            <br />
            副荐1：<asp:TextBox ID="TextBox_fujian1" runat="server"></asp:TextBox>
            <br />
            副荐2：<asp:TextBox ID="TextBox_fujian2" runat="server"></asp:TextBox>
            <br />
            副荐3：<asp:TextBox ID="TextBox_fujian3" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp; 阳上1：<asp:TextBox ID="TextBox_yangshang1" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp; 阳上2：<asp:TextBox ID="TextBox_yangshang2" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp; 阳上3：<asp:TextBox ID="TextBox_yangshang3" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp; 阳上4：<asp:TextBox ID="TextBox_yangshang4" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp; 阳上5：<asp:TextBox ID="TextBox_yangshang5" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp; 阳上6：<asp:TextBox ID="TextBox_yangshang6" runat="server"></asp:TextBox>
        </div>
        <div>联系人：<asp:TextBox ID="TextBox_lianxiren" runat="server"></asp:TextBox>
            <br />
            电话：<asp:TextBox ID="TextBox_dianhua" runat="server"></asp:TextBox>
            <br />
            手机：<asp:TextBox ID="TextBox_shouji" runat="server"></asp:TextBox>
            <br />
            邮编：<asp:TextBox ID="TextBox_youbian" runat="server"></asp:TextBox>
            <br />
            地址：<asp:TextBox ID="TextBox_dizhi" runat="server"></asp:TextBox>
        </div>
        <div id="shenhe" runat="server">审核签名：<asp:TextBox ID="TextBox_shenhe" 
                runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button_save" runat="server" onclick="Button_save_Click" 
                Text="保存" />
    </div>
    </form>
</body>
</html>
