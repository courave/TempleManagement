﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print.aspx.cs" Inherits="CWCS_OL.tables.wangsheng.print" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        打印模板：<asp:DropDownList ID="DropDownList_template" runat="server" AutoPostBack="true"
            onselectedindexchanged="DropDownList_template_SelectedIndexChanged"></asp:DropDownList>

        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" ToolPanelView="None" />
    
    </div>
    </form>
</body>
</html>
