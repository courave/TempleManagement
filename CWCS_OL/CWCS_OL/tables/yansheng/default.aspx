﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CWCS_OL.tables.yansheng._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>延生表</title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/list.js"></script>
</head>
<body>
<div id="toolbar">
    <select id="SelectNav" onchange="SelectNav_onChange()">
        <option value="../../admin/list.aspx">管理员表</option>
        <option value="../../print/PrintTemplate.aspx">打印模板</option>
        <option value="../../tables/yansheng/index.htm">延生表</option>
        <option value="../../tables/wangsheng/index.htm">往生表</option>
        <option value="../../tables/sanshi/index.htm">三时系列法会</option>
        <option value="../../tables/fahua/index.htm">法华法会</option>
        <option value="../../tables/shizhuinfo/index.htm">施主基本信息表</option>
        <option value="../../tables/gongde/index.htm">功德项目表</option>
        <option value="../../tables/stock/index.htm">库存管理</option>
        <option value="../../tables/filemgr/index.htm">档案管理</option>
        <option value="../../tables/fashiinfo/index.htm">法师信息表</option>
        <option value="../../tables/foshi/index.htm">佛事表</option>
        <option value="../../tables/fahui/default.aspx">法会管理</option>
     </select>
        <script type="text/javascript">
            document.getElementsByTagName("option")(2).selected = true
        </script>
        <input type="button" value="新增(N)" onclick="return addNewRec('<%=Request.Params["fahui"] ==null ? "":Request.Params["fahui"] %>');" accesskey="n" />
&nbsp;从第<input type="text" id="printFrom" style="width:40px;" />座到第<input type="text" id="printTo" style="width:40px;"/>座
        <a href="#" onclick="return printPage();">全部打印</a>
&nbsp;
        <input type="text" id="search" />
        <a href="#" onclick="return searchKey();">搜索</a>
    
    &nbsp;<a href="#" onclick="return toggleList();">显示/隐藏列表</a>
    &nbsp;<a href="#" onclick="return togglePrint();">显示/隐藏打印预览</a>
    <br />
    <a href="#" onclick="return printCurrent();">打印当前列表</a>
</div>
<div id="frameSet" runat="server">
    <iframe src="list.aspx" id="list" width="100%" style="border:none;" frameborder="0"></iframe>
</div>
    <iframe src="about:blank" id="detail" width="50%" style="border:none;float:left;" frameborder="0"></iframe>
    <iframe src="about:blank" id="print" width="49%" style="border:none;float:right" frameborder="0"></iframe>
</body>
</html>
