<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CWCS_OL.admin.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    编号：<asp:Label ID="Label_id" runat="server"></asp:Label>
        <br />
        姓名：<asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>
        <br />
        密码：<asp:TextBox ID="TextBox_password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        权限：<asp:CheckBoxList ID="CheckBoxList_permission" 
            runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
            <asp:ListItem Value="00r">Admin表查看</asp:ListItem>
            <asp:ListItem Value="00c">Admin表增加</asp:ListItem>
            <asp:ListItem Value="00u">Admin表修改</asp:ListItem>
            <asp:ListItem Value="00d">Admin表删除</asp:ListItem>
            <asp:ListItem Value="00assign">Admin表权限授予</asp:ListItem>
            <asp:ListItem Value="ptr">打印模板查看</asp:ListItem>
            <asp:ListItem Value="ptu">打印模板增加/修改</asp:ListItem>
            <asp:ListItem Value="ptd">打印模板删除</asp:ListItem>
            <asp:ListItem Value="01r">延生表查看</asp:ListItem>
            <asp:ListItem Value="01c">延生表增加</asp:ListItem>
            <asp:ListItem Value="01u">延生表修改</asp:ListItem>
            <asp:ListItem Value="01d">延生表删除</asp:ListItem>
            <asp:ListItem Value="02r">往生表查看</asp:ListItem>
            <asp:ListItem Value="02c">往生表增加</asp:ListItem>
            <asp:ListItem Value="02u">往生表修改</asp:ListItem>
            <asp:ListItem Value="02d">往生表删除</asp:ListItem>
            
            <asp:ListItem Value="03r">三时系列查看</asp:ListItem>
            <asp:ListItem Value="03c">三时系列增加</asp:ListItem>
            <asp:ListItem Value="03u">三时系列修改</asp:ListItem>
            <asp:ListItem Value="03d">三时系列删除</asp:ListItem>
            <asp:ListItem Value="04r">法华法会查看</asp:ListItem>
            <asp:ListItem Value="04c">法华法会增加</asp:ListItem>
            <asp:ListItem Value="04u">法华法会修改</asp:ListItem>
            <asp:ListItem Value="04d">法华法会删除</asp:ListItem>
            <asp:ListItem Value="05r">施主基本信息表查看</asp:ListItem>
            <asp:ListItem Value="05c">施主基本信息表增加</asp:ListItem>
            <asp:ListItem Value="05u">施主基本信息表修改</asp:ListItem>
            <asp:ListItem Value="05d">施主基本信息表删除</asp:ListItem>
            <asp:ListItem Value="06r">功德项目表查看</asp:ListItem>
            <asp:ListItem Value="06c">功德项目表增加</asp:ListItem>
            <asp:ListItem Value="06u">功德项目表修改</asp:ListItem>
            <asp:ListItem Value="06d">功德项目表删除</asp:ListItem>

            <asp:ListItem Value="s0r">库存查看</asp:ListItem>
            <asp:ListItem Value="s1r">货品查看</asp:ListItem>
            <asp:ListItem Value="s1c">货品添加</asp:ListItem>
            <asp:ListItem Value="s1u">货品修改</asp:ListItem>
            <asp:ListItem Value="s2r">入库单查看</asp:ListItem>
            <asp:ListItem Value="s2c">入库单添加</asp:ListItem>
            <asp:ListItem Value="s2u">入库单修改</asp:ListItem>
            <asp:ListItem Value="s3r">出库单查看</asp:ListItem>
            <asp:ListItem Value="s3c">出库单添加</asp:ListItem>
            <asp:ListItem Value="s3u">出库单修改</asp:ListItem>
            <asp:ListItem Value="s4r">变更单查看</asp:ListItem>
            <asp:ListItem Value="s4c">变更单添加</asp:ListItem>
            <asp:ListItem Value="s4u">变更单修改</asp:ListItem>

            <asp:ListItem Value="fmr">档案管理查看</asp:ListItem>
            <asp:ListItem Value="fmc">档案管理添加</asp:ListItem>
            <asp:ListItem Value="fmu">档案管理修改</asp:ListItem>
            <asp:ListItem Value="fmd">档案管理删除</asp:ListItem>
            <asp:ListItem Value="fmp">档案管理上传</asp:ListItem>
            <asp:ListItem Value="fml">档案管理下载</asp:ListItem>

            <asp:ListItem Value="07r">法师信息表查看</asp:ListItem>
            <asp:ListItem Value="07c">法师信息表增加</asp:ListItem>
            <asp:ListItem Value="07u">法师信息表修改</asp:ListItem>
            <asp:ListItem Value="07d">法师信息表删除</asp:ListItem>

            <asp:ListItem Value="08r">佛事表查看</asp:ListItem>
            <asp:ListItem Value="08c">佛事表增加</asp:ListItem>
            <asp:ListItem Value="08u">佛事表修改</asp:ListItem>
            <asp:ListItem Value="08d">佛事表删除</asp:ListItem>

            <asp:ListItem Value="changnianshenhe">常年供位审核</asp:ListItem>
        </asp:CheckBoxList>
    </div>
        <asp:Button ID="Button_save" runat="server" Text="保存" 
        onclick="Button_save_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="Button_cancel" runat="server" Text="取消" 
        onclick="Button_cancel_Click" />
    </form>
</body>
</html>
