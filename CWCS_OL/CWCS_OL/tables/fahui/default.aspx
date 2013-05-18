<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CWCS_OL.tables.fahui._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>法会登记</title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript">
        function showNewFahui() {
            var newfahui = document.getElementById("newfahui");
            newfahui.style.display = "";
        }
        function confirmNewfahui() {
            var xinzengfahui = document.getElementById("xinzengfahui");
            xinzengfahui.style.display = "";
            var wangsheng = document.getElementById("wangsheng");
            var yansheng = document.getElementById("yansheng");
            var textbox_fahui = document.getElementById("TextBox_fahuiname");
            wangsheng.src = "../wangsheng/edit.aspx?fahui="+textbox_fahui.value;
            yansheng.src = "../yansheng/edit.aspx?fahui=" + textbox_fahui.value;
        }
        var SelectNav_onChange = function () {
            var nav = document.getElementById("SelectNav").value;
            window.location.href = nav;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
        <option value="../../tables/employee/list.aspx">员工管理</option>
        <option value="../../tables/changniangongwei/list.aspx">常年供位</option>
     </select><br />
        <script type="text/javascript">
            document.getElementsByTagName("option")(12).selected = true
        </script>
    <asp:DropDownList ID="DropDownList_year" runat="server" AutoPostBack="true" 
            onselectedindexchanged="DropDownList_year_SelectedIndexChanged">
        </asp:DropDownList>&nbsp;
        <asp:DropDownList ID="DropDownList_FAHUI" runat="server" AutoPostBack="true">
        </asp:DropDownList>
   
    
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button_view" runat="server" onclick="Button_view_Click" 
            Text="查看" />
   
    &nbsp;&nbsp;&nbsp;&nbsp;
        <input type="button" id="Button_new" value="新建法会" onclick="showNewFahui()" />
   
    <br />
    <div id="navBar" runat="server"></div><br />
    <div id="newfahui" runat ="server" style="display:none;">
    法会名：<input type="text" id="TextBox_fahuiname" />
    <br />

    <input type="button" id="Button_confirm" value="确定"
            onclick="confirmNewfahui()" />
    </div>
    <div id="xinzengfahui" runat="server" style="display:none;">
        <table style="width: 100%;">
            <tr>
                <td style="width:50%; text-align:center">
                    往生表
                </td>
                <td style="width:50%; text-align:center">
                    延生表
                </td>
            </tr>
            <tr>
                <td style="width:50%; text-align:center;">
                    <iframe id="wangsheng" frameborder="0" style="border:none; width:100%; height:400px;" runat="server"
                    src=""></iframe>
                </td>
                <td style="width:50%; text-align:center;">
                    <iframe id="yansheng" frameborder="0" style="border:none; width:100%; height:400px;" runat="server"
                    src=""></iframe>
                </td>
            </tr>
        </table>
    </div>
    </div>
    </form>
</body>
</html>
