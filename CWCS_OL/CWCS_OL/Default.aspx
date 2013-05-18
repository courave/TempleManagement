<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CWCS_OL._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label_welcome" runat="server" Text="Welcome"></asp:Label>
        <br />
        <br />
    <ul>
    <li><a href="tables/fahui/default.aspx" target="right">法会管理</a></li>
    
    <li><a href="admin/list.aspx" target="right">管理员表</a></li>
    
    <li><a href="print/PrintTemplate.aspx" target="right">打印模板</a></li>
    
    <li><a href="tables/yansheng/index.htm" target="right">延生表</a></li>
    
    <li><a href="tables/wangsheng/index.htm" target="right">往生表</a></li>
    
    <li><a href="tables/sanshi/index.htm" target="right">三时系列法会</a></li>
    
    <li><a href="tables/fahua/index.htm" target="right">法华法会</a></li>
    
    <li><a href="tables/shizhuinfo/index.htm" target="right">施主基本信息表</a></li>
    
    <li><a href="tables/gongde/index.htm" target="right">功德项目表</a></li>
    
    <li><a href="tables/stock/index.htm" target="right">库房管理</a></li>
    
    <li><a href="tables/filemgr/index.htm" target="right">档案管理</a></li>
    
    <li><a href="tables/fashiinfo/index.htm" target="right">法师信息表</a></li>
    
    <li><a href="tables/foshi/index.htm" target="right">佛事表</a></li>
    
    <li><a href="tables/employee/list.aspx" target="right">人事管理</a></li>
    
    <li><a href="tables/changniangongwei/list.aspx" target="right">常年供位</a></li>
    </ul>
    </div>
    <br />
    <br />
    -----------------------
    <br />
    <asp:Label ID="Label_alarm" runat="server" Text="Label"></asp:Label>
    <br />

    </form>
</body>
</html>
