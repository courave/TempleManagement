<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CWCS_OL.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    /*顶部背景*/
#head_top{height:142px; width:100%; overflow:hidden}
#head_top_flash{position:relative; z-index:100; width:1002px; margin:0 auto; height:142px; z-index:100;
            top: 0px;
            left: 0px;
        }
#head_top_left{float:left; width:50%; height:142px; background:url(x_repeat.png) repeat-x 0px -150px; margin-top:-142px}
#head_top_right{float:right; width:50%; height:142px; background:url(x_repeat.png) repeat-x 0px 0px; margin-top:-142px}
#Login_Box{position:absolute;top:45%;left:50%;margin:-100px 0 0 -200px;
border:none;
font-size:16px;
text-align:center;
z-index:99; }
</style>
</head>
<body>
<div id="head_top">
	<div id="head_top_flash"><embed src="./top.swf" width="1002" height="142" wmode="transparent"></embed></div>
	<div id="head_top_left"></div>
	<div id="head_top_right"></div>
</div>
<div align="center">
<div>
    <form id="form1" runat="server">
    <div align="center">
    </div>
    <div align="center" id="Login_Box">

            <table >
            <tr>
            <td align="right">用户名：</td>
            <td><asp:TextBox ID="TextBox_username" runat="server" BorderStyle="Solid" 
                    BorderWidth="1px" TabIndex="1"></asp:TextBox></td>
            <td rowspan="2" align="justify">
                <asp:Button ID="Button_login" runat="server" onclick="Button_login_Click" 
            Text="登录" Height="55px" Width="78px" BorderStyle="Solid" BorderWidth="1px" 
                    TabIndex="3" /></td>
            </tr>
            <tr>
            <td align="right">密码：</td>
            <td><asp:TextBox ID="TextBox_password" runat="server" TextMode="Password" 
                    BorderStyle="Solid" BorderWidth="1px" TabIndex="2"></asp:TextBox></td>
            </tr>
            <tr>
            <td align="right" colspan="2"><asp:Label ID="Label_loginError" runat="server" ForeColor="Red"></asp:Label></td>
            <td></td>
            </tr>

            </table>
    </div>
    </form>
</div>
</div>
</body>
</html>
