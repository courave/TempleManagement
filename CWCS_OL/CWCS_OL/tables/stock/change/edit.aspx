<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.stock.change.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../../Scripts/list.css" type="text/css" />
    <script type="text/javascript">
        function selRec(gno, gname, gcode, gunit) {
            document.getElementById('TextBox_GoodsNo').value = gno;
            document.getElementById('Label_Name').innerHTML = gname;
            document.getElementById('Label_BarCode').innerHTML = gcode;
            document.getElementById('Label_Unit').innerHTML = gunit;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        仓库编号：<asp:TextBox ID="TextBox_StockId" runat="server"></asp:TextBox>
        <br />
        单号：<asp:TextBox ID="TextBox_BillNo" runat="server"></asp:TextBox>
        <br />
        货品编号：<asp:TextBox ID="TextBox_GoodsNo" runat="server"></asp:TextBox>
        <asp:Button ID="Button_select" runat="server" Text="选择" 
            onclientclick="window.open('../goods/list.aspx?sel=','newwindow','toolbar=no,menubar=no,location=no,status=no');return false;" />
        <br />
        货品名称：<asp:Label ID="Label_Name" runat="server"></asp:Label>
        <br />
        条形码：<asp:Label ID="Label_BarCode" runat="server"></asp:Label>
        <br />
        单位：<asp:Label ID="Label_Unit" runat="server"></asp:Label>
        <br />
        变更数量：<asp:TextBox ID="TextBox_Amount" runat="server"></asp:TextBox>
        <br />
        总价：<asp:TextBox ID="TextBox_TotalPrice" runat="server">0</asp:TextBox>
        <br />
        原因：<asp:TextBox ID="TextBox_FromTo" runat="server"></asp:TextBox>
        <br />
        负责人：<asp:TextBox ID="TextBox_Manager" runat="server"></asp:TextBox>
        <br />
        时间：<asp:TextBox ID="TextBox_EditTime" runat="server" BackColor="#999999" 
            BorderStyle="None" ReadOnly="True"></asp:TextBox>
        <br />
        登记人：<asp:TextBox ID="TextBox_Operator" runat="server" BackColor="#999999" 
            BorderStyle="None" ReadOnly="True"></asp:TextBox>
        <br />
        备注：<asp:TextBox ID="TextBox_Remark" runat="server"></asp:TextBox>
        <br />
    </div>
    <asp:Button ID="Button_save" runat="server" Text="保存(S)" 
        onclick="Button_save_Click" AccessKey="s" />
    &nbsp;&nbsp;
    <asp:Button ID="Button_cancel" runat="server" Text="取消(C)" 
        onclick="Button_cancel_Click" AccessKey="c" />
    <br />
    <asp:Button ID="Button_savenext" runat="server" AccessKey="d" 
        onclick="Button_savenext_Click" Text="保存并下一条(D)" />
    </form>
</body>
</html>
