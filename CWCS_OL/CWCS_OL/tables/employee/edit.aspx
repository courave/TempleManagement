<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.employee.edit" validateRequest="false"%>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <style type="text/css">
    table
    {
        border:1px solid;
        border-collapse:collapse;
    }
    td
    {
        border:1px solid;
        text-align:center;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td  >
                    姓名：<br />
                    （身份证用名）</td>
                <td>
                    <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>
                </td>
                <td>
                    教（法、经）名：</td>
                <td>
                    <asp:TextBox ID="TextBox_fahao" runat="server"></asp:TextBox>
                </td>
                <td>
                    出生年月：</td>
                <td>
                    年：<asp:TextBox ID="TextBox_year" 
                        runat="server" Width="24%"></asp:TextBox>
                    月：<asp:TextBox ID="TextBox_month" runat="server" Width="24%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    头像：</td>
                <td>
                    <asp:FileUpload ID="FileUpload_headimg" runat="server" />
                </td>
                <td>
                    籍贯：</td>
                <td>
                    <asp:TextBox ID="TextBox_jiguan" runat="server"></asp:TextBox>
                </td>
                <td>
                    民族：</td>
                <td>
                    <asp:TextBox ID="TextBox_minzu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    昵称：</td>
                <td>
                    <asp:TextBox ID="TextBox_nickname" runat="server"></asp:TextBox>
                </td>
                <td>
                    出家日期：</td>
                <td>
                    <asp:TextBox ID="TextBox_chujiadate" runat="server"></asp:TextBox>
                </td>
                <td>
                    出家寺院：</td>
                <td>
                    <asp:TextBox ID="TextBox_chujiatemple" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    剃度师：</td>
                <td>
                    <asp:TextBox ID="TextBox_tidushi" runat="server"></asp:TextBox>
                </td>
                <td>
                    受戒日期：</td>
                <td>
                    <asp:TextBox ID="TextBox_shoujiedate" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
                <td>
                    受戒师：</td>
                <td>
                    <asp:TextBox ID="TextBox_shoujieshi" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    类型：</td>
                <td>
                    <asp:DropDownList ID="DropDownList_type" runat="server" AutoPostBack="True">
                        <asp:ListItem>法师</asp:ListItem>
                        <asp:ListItem>普通职工</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    国民教育学历：</td>
                <td>
                    <asp:DropDownList ID="DropDownList_degree" runat="server" AutoPostBack="True">
                        <asp:ListItem>初中</asp:ListItem>
                        <asp:ListItem>高中</asp:ListItem>
                        <asp:ListItem>中专</asp:ListItem>
                        <asp:ListItem>大专</asp:ListItem>
                        <asp:ListItem>本科</asp:ListItem>
                        <asp:ListItem>硕士</asp:ListItem>
                        <asp:ListItem>博士</asp:ListItem>
                        <asp:ListItem>未列出</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    身份证号码：</td>
                <td>
                    <asp:TextBox ID="TextBox_idno" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    性别：</td>
                <td>
                    <asp:DropDownList ID="DropDownList_sex" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    电话：</td>
                <td>
                    <asp:TextBox ID="TextBox_phone" runat="server"></asp:TextBox>
                </td>
                <td>
                    邮编：</td>
                <td>
                    <asp:TextBox ID="TextBox_zipcode" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    教内职务：</td>
                <td>
                    <asp:TextBox ID="TextBox_jiaonei" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
                <td>
                    社会职务：</td>
                <td>
                    <asp:TextBox ID="TextBox_shehui" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
                <td>
                    现在职务：</td>
                <td>
                    <asp:TextBox ID="TextBox_now" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    邮件地址：</td>
                <td>
                    <asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox>
                </td>
                <td>
                    户籍所在地：</td>
                <td>
                    <asp:TextBox ID="TextBox_addr" runat="server"></asp:TextBox>
                </td>
                <td>
                    入寺时间：</td>
                <td>
                    <asp:TextBox ID="TextBox_hire" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    兴趣爱好：</td>
                <td>
                    <asp:TextBox ID="TextBox_hobby" runat="server"></asp:TextBox>
                </td>
                <td>
                    特长：</td>
                <td>
                    <asp:TextBox ID="TextBox_ability" runat="server"></asp:TextBox>
                </td>
                <td>
                    离寺时间：</td>
                <td>
                    <asp:TextBox ID="TextBox_quit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    宗教教育学历：</td>
                <td>
                    <asp:DropDownList ID="DropDownList_zdegree" runat="server" AutoPostBack="True">
                        <asp:ListItem>初中</asp:ListItem>
                        <asp:ListItem>高中</asp:ListItem>
                        <asp:ListItem>中专</asp:ListItem>
                        <asp:ListItem>大专</asp:ListItem>
                        <asp:ListItem>本科</asp:ListItem>
                        <asp:ListItem>硕士</asp:ListItem>
                        <asp:ListItem>博士</asp:ListItem>
                        <asp:ListItem>未列出</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    曾用名：</td>
                <td>
                    <asp:TextBox ID="TextBox_oname" runat="server"></asp:TextBox>
                </td>
                <td>
                    教职人员证书号：</td>
                <td>
                    <asp:TextBox ID="TextBox_cert" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  >
                    个人简历：</td>
                <td colspan="5">

                    <FCKeditorV2:FCKeditor ID="FCKeditor_resume" runat="server" Width="100%" Height="320px">
                    </FCKeditorV2:FCKeditor>

                </td>
            </tr>
            <tr>
                <td  >
                    主要社会关系：</td>
                <td colspan="5">
                    <FCKeditorV2:FCKeditor ID="FCKeditor_mainsocial" runat="server" Width="100%" Height="320px">
                    </FCKeditorV2:FCKeditor></td>
            </tr>
            <tr>
                <td  >
                    奖惩情况：</td>
                <td colspan="5">

                    <FCKeditorV2:FCKeditor ID="FCKeditor_jiangcheng" runat="server" Width="100%" Height="320px">
                    </FCKeditorV2:FCKeditor></td>

            </tr>
            <tr>
                <td  >
                    身份证复印件：</td>
                <td>
                    正面：<asp:FileUpload ID="FileUpload_frontid" runat="server" />
                </td>
                <td>
                    反面：</td>
                <td>
                    <asp:FileUpload ID="FileUpload_backid" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td  >
                    备注：</td>
                <td colspan="5">
                    <FCKeditorV2:FCKeditor ID="FCKeditor_comment" runat="server" Width="100%" Height="320px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button_save" runat="server" onclick="Button_save_Click" 
                        Text="保存" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox_name" ErrorMessage="姓名不能为空"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
