<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.changniangongwei.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

    <p style="text-align: center; font-weight: bolder; font-size: x-large">
    
        常年供位登记单</p>
    <p style="text-align: center; font-size: large"><asp:Label 
            ID="Label_type" runat="server" style="display:none;"></asp:Label>
&nbsp; 登记日期：<asp:Label ID="Label_logdate" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp; 系统编号：<asp:Label ID="Label_bianhao" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label_yuan" runat="server"></asp:Label>
        苑&nbsp; 
        <asp:Label ID="Label_pai" runat="server"></asp:Label>
        排&nbsp; 
        <asp:Label ID="Label_zuo" runat="server"></asp:Label>
        座&nbsp; 
        </p>
        <div id="yansheng" runat="server" style="text-align: center">1、值福信：<asp:Label ID="Label_zhifuxin1" 
                runat="server"></asp:Label>
            <br />
            2、值福信：<asp:Label ID="Label_zhifuxin2" runat="server"></asp:Label>
            <br />
            3、值福信：<asp:Label ID="Label_zhifuxin3" runat="server"></asp:Label>
            <br />
            4、值福信：<asp:Label ID="Label_zhifuxin4" runat="server"></asp:Label>
        </div>
        <div id="wangsheng" runat="server" style="text-align: center">超荐：<asp:Label ID="Label_chaojian" runat="server"></asp:Label>
            <br />
            副荐1：<asp:Label ID="Label_fujian1" runat="server"></asp:Label>
            <br />
            副荐2：<asp:Label ID="Label_fujian2" runat="server"></asp:Label>
            <br />
            副荐3：<asp:Label ID="Label_fujian3" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp; 阳上1：<asp:Label ID="Label_yangshang1" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp; 阳上2：<asp:Label ID="Label_yangshang2" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp; 阳上3：<asp:Label ID="Label_yangshang3" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp; 阳上4：<asp:Label ID="Label_yangshang4" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp; 阳上5：<asp:Label ID="Label_yangshang5" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp; 阳上6：<asp:Label ID="Label_yangshang6" runat="server"></asp:Label>
        </div>
        <div style="text-align: center">联系人：<asp:Label ID="Label_lianxiren" runat="server"></asp:Label>
            <br />
            电话：<asp:Label ID="Label_dianhua" runat="server"></asp:Label>
            <br />
            手机：<asp:Label ID="Label_shouji" runat="server"></asp:Label>
            <br />
            邮编：<asp:Label ID="Label_youbian" runat="server"></asp:Label>
            <br />
            地址：<asp:Label ID="Label_dizhi" runat="server"></asp:Label>
        </div>
        <div id="shenhe" runat="server" style="text-align: center">审核签名：<asp:Label ID="Label_shenhe" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
