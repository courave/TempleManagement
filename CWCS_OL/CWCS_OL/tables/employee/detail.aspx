<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.employee.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <style type="text/css">

        table
        {
            border: 1px solid black;
            border-collapse:collapse;
        }
        th, td
        {
            border: 1px solid black;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="detail_fashi" runat="server">
    <table style=" width:100%;">
            <tr>
                <td  >
                    俗名：</td>
                <td >
                    <asp:Label ID="Labelf_name" runat="server"></asp:Label>
                </td>
                <td >
                    法名：</td>
                <td >
                    <asp:Label ID="Labelf_fahao" runat="server"></asp:Label>
                </td>
                <td colspan="2" rowspan="3" >
                    <asp:Image ID="Imagef_head" runat="server" />
                </td>
            </tr>
            <tr>
                <td  >
                    出生年月：</td>
                <td >
                    <asp:Label ID="Labelf_yearmonth" runat="server"></asp:Label>
                </td>
                <td >
                    籍贯：</td>
                <td >
                    <asp:Label ID="Labelf_jiguan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    民族：</td>
                <td >
                    <asp:Label ID="Labelf_minzu" runat="server"></asp:Label>
                </td>
                <td >
                    昵称：</td>
                <td >
                    <asp:Label ID="Labelf_nickname" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    出家日期：</td>
                <td >
                    <asp:Label ID="Labelf_chujiadate" runat="server"></asp:Label>
                </td>
                <td >
                    出家寺院：</td>
                <td >
                    <asp:Label ID="Labelf_chujiatemple" runat="server"></asp:Label>
                </td>
                <td >
                    剃度师：</td>
                <td >
                    <asp:Label ID="Labelf_tidushi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    受戒日期：</td>
                <td >
                    <asp:Label ID="Labelf_shoujiedate" runat="server"></asp:Label>
                </td>
                <td >
                    受戒师：</td>
                <td >
                    <asp:Label ID="Labelf_shoujieshi" runat="server"></asp:Label>
                </td>
                <td >
                    学历：</td>
                <td >
                    <asp:Label ID="Labelf_degree" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    身份证号码：</td>
                <td >
                    <asp:Label ID="Labelf_idno" runat="server"></asp:Label>
                </td>
                <td >
                    性别：</td>
                <td >
                    <asp:Label ID="Labelf_sex" runat="server"></asp:Label>
                </td>
                <td >
                    电话：</td>
                <td >
                    <asp:Label ID="Labelf_phone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    邮编：</td>
                <td >
                    <asp:Label ID="Labelf_zipcode" runat="server"></asp:Label>
                </td>
                <td >
                    教内职务：</td>
                <td >
                    <asp:Label ID="Labelf_jiaonei" runat="server"></asp:Label>
                </td>
                <td >
                    社会职务：</td>
                <td >
                    <asp:Label ID="Labelf_shehui" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    现在职务：</td>
                <td >
                    <asp:Label ID="Labelf_now" runat="server"></asp:Label>
                </td>
                <td >
                    邮件地址：</td>
                <td >
                    <asp:Label ID="Labelf_email" runat="server"></asp:Label>
                </td>
                <td >
                    户籍所在地：</td>
                <td >
                    <asp:Label ID="Labelf_huji" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    入寺时间：</td>
                <td >
                    <asp:Label ID="Labelf_hiredate" runat="server"></asp:Label>
                </td>
                <td >
                    兴趣爱好：</td>
                <td >
                    <asp:Label ID="Labelf_hobby" runat="server"></asp:Label>
                </td>
                <td >
                    特长：</td>
                <td >
                    <asp:Label ID="Labelf_ability" runat="server"></asp:Label>
                </td>
            </tr>
                        <tr>
                <td >
                    离寺时间：</td>
                <td >
                    <asp:Label ID="Labelf_quitdate" runat="server"></asp:Label>
                    </td>
                <td >
                    宗教教育学历：</td>
                <td >
                    <asp:Label ID="Labelf_zdegree" runat="server"></asp:Label>
                    </td>
                <td >
                    曾用名：</td>
                <td >
                    <asp:Label ID="Labelf_oname" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td >
                    教职人员证书号：</td>
                <td >
                    <asp:Label ID="Labelf_cert" runat="server"></asp:Label>
                    </td>
                <td >
                    </td>
                <td >
                    </td>
                <td >
                    </td>
                <td >
                    </td>
            </tr>
            <tr>
                <td  >
                    个人简历：</td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox_resume" runat="server" style="display:none;" 
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Labelf_resume" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    主要社会关系：</td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox_mainsocial" runat="server" TextMode="MultiLine" style="display:none;"></asp:TextBox>
                    <asp:Label ID="Labelf_mainsocial" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    奖惩情况：</td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox_jiangcheng" runat="server" TextMode="MultiLine" style="display:none;"></asp:TextBox>
                    <asp:Label ID="Labelf_jiangcheng" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td  >
                    身份证复印件：</td>
                <td colspan="5">
                    <asp:Image ID="Imagef_frontid" runat="server" />

                    <asp:Image ID="Imagef_backid" runat="server" />
                </td>
            </tr>
            <tr>
                <td  >
                    备注：</td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox_comment" runat="server" Width="100%" Height="60px"  style="display:none;"
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Labelf_comment" runat="server"></asp:Label>
                </td>
                </td>
            </tr>

        </table>
    </div>
    <div id="detail_zhigong" runat="server">
    <table style="width:100%;">
            <tr>
                <td  >
                    俗名：</td>
                <td>
                    <asp:Label ID="Labelz_name" runat="server"></asp:Label>
                </td>
                <td>
                    出生年月：</td>
                <td>
                    <asp:Label ID="Labelz_yearmonth" runat="server"></asp:Label>
                </td>
                <td colspan="2" rowspan="3">
                    <asp:Image ID="Imagez_head" runat="server" />
                </td>
            </tr>
            <tr>
                <td  >
                    籍贯：</td>
                <td>
                    <asp:Label ID="Labelz_jiguan" runat="server"></asp:Label>
                </td>
                <td>
                    性别：</td>
                <td>
                    <asp:Label ID="Labelz_sex" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    民族：</td>
                <td>
                    <asp:Label ID="Labelz_minzu" runat="server"></asp:Label>
                </td>
                <td>
                    学历：</td>
                <td>
                    <asp:Label ID="Labelz_degree" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    户籍所在地：</td>
                <td colspan="2">
                    <asp:Label ID="Labelz_huji" runat="server"></asp:Label>
                </td>
                <td>
                    身份证号码</td>
                <td colspan="2">
                    <asp:Label ID="Labelz_idno" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    邮编：</td>
                <td>
                    <asp:Label ID="Labelz_zipcode" runat="server"></asp:Label>
                </td>
                <td>
                    电话：</td>
                <td>
                    <asp:Label ID="Labelz_phone" runat="server"></asp:Label>
                </td>
                <td>
                    教内职务：</td>
                <td>
                    <asp:Label ID="Labelz_jiaonei" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    社会职务：</td>
                <td>
                    <asp:Label ID="Labelz_shehui" runat="server"></asp:Label>
                </td>
                <td>
                    现在职务：</td>
                <td>
                    <asp:Label ID="Labelz_now" runat="server"></asp:Label>
                </td>
                <td>
                    兴趣爱好：</td>
                <td>
                    <asp:Label ID="Labelz_hobby" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    到本寺工作时间：</td>
                <td colspan="2">
                    <asp:Label ID="Labelz_hiredate" runat="server"></asp:Label>
                </td>
                <td>
                    特长：</td>
                <td colspan="2">
                    <asp:Label ID="Labelz_ability" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    昵称：</td>
                <td>
                    <asp:Label ID="Labelz_nickname" runat="server"></asp:Label>
                </td>
                <td>
                    电子邮件：</td>
                <td>
                    <asp:Label ID="Labelz_email" runat="server"></asp:Label>
                </td>
                <td>
                    </td>
                <td>
                    </td>
            </tr>
                        <tr>
                <td >
                    离寺时间：</td>
                <td>
                    <asp:Label ID="Labelz_quitdate" runat="server"></asp:Label>
                    </td>
                <td>
                    曾用名：</td>
                <td>
                    <asp:Label ID="Labelz_oname" runat="server"></asp:Label>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td  >
                    个人简历：</td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox1" runat="server" style="display:none;" 
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Labelz_resume" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    主要社会关系：</td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" style="display:none;"></asp:TextBox>
                    <asp:Label ID="Labelz_mainsocial" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  >
                    奖惩情况：</td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" style="display:none;"></asp:TextBox>
                    <asp:Label ID="Labelz_jiangcheng" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td  >
                    身份证复印件：</td>
                <td colspan="5">
                    <asp:Image ID="Imagez_frontid" runat="server" />

                    <asp:Image ID="Imagez_backid" runat="server" />
                </td>
            </tr>
            <tr>
                <td  >
                    备注：</td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox4" runat="server" Width="100%" Height="60px"  style="display:none;"
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Labelz_comment" runat="server"></asp:Label>
                </td>
                </td>
            </tr>

            <tr>
                <td >
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
            </tr>
        </table>
    </div>
    <a href="edit.aspx?id=<%=Request.Params["id"] %>">编辑</a>
    </form>
</body>
</html>
