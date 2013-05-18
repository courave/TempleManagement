<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="type.aspx.cs" Inherits="CWCS_OL.tables.sanshi.type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        方位信息：<asp:TextBox ID="TextBox_fangwei" runat="server"></asp:TextBox>
        <br />
        行数：<asp:TextBox ID="TextBox_rows" runat="server"></asp:TextBox>
        <br />
        每行列数（用逗号分隔，如一共5行，每行列数）：<br />
        <asp:TextBox ID="TextBox_cols" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button_save" runat="server" onclick="Button_save_Click" 
            Text="保存" />
    </div>
    </form>
</body>
</html>
