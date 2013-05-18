<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.stock.instock.edit" %>

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
    <style type="text/css">

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <table style="border-style: none; width:100%;">
            <tr>
                <td style=" width:33%;">
                    &nbsp;</td>
                <td style=" width:33%; text-align:center; border-bottom-style: double; border-bottom-width: 1px; border-bottom-color: #000000;">
                    入 库 单</td>
                <td style=" width:33%; text-align:right;">
                    No.<asp:TextBox ID="TextBox_BillNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style=" width:33%;">
                    &nbsp;</td>
                <td style=" width:33%; text-align:center;">
                    <asp:TextBox ID="TextBox_EditTime" runat="server" BackColor="#999999" 
            BorderStyle="None" ReadOnly="True"></asp:TextBox>
                </td>
                <td style=" width:33%; text-align:right;">
                    连续号：<asp:TextBox ID="TextBox_lianxuhao" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td>
                    交货单位<br />
                    （部门）</td>
                <td>
                    <asp:TextBox ID="TextBox_FromTo" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
                <td>
                    发票号码或<br />
                    生产单号码</td>
                <td>
                    <asp:TextBox ID="TextBox_fapiao" runat="server"></asp:TextBox>
                </td>
                <td>
                    仓库</td>
                <td>
                    <asp:TextBox ID="TextBox_StockId" runat="server"></asp:TextBox>
                </td>
                <td>
                    入库<br />
                    日期</td>
                <td>
                    <asp:TextBox ID="TextBox_rukudate" runat="server"></asp:TextBox>
                </td>
            </tr>
            </table>
        <table style="width: 100%;">
            <tr>
                <td rowspan="2" style="text-align:center">
                    货号</td>
                <td rowspan="2" style="text-align:center">
                    名称及规格</td>
                <td rowspan="2" style="text-align:center">
                    单位</td>
                <td colspan="2" style="text-align:center">
                    数量</td>
                <td rowspan="2" style="text-align:center">
                    单价</td>
                <td colspan="2" rowspan="2" style="text-align:center">
                    金额</td>
                <td rowspan="2" style="text-align:center">
                    备注</td>
            </tr>
            <tr>
                <td>
                    交库数</td>
                <td>
                    实收数</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox_GoodsNo" runat="server"></asp:TextBox>
        <asp:Button ID="Button_select" runat="server" Text="选择" 
            onclientclick="window.open('../goods/list.aspx?sel=','newwindow','toolbar=no,menubar=no,location=no,status=no');return false;" />
                </td>
                <td>
                    <asp:Label ID="Label_Name" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label_BarCode" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label_Unit" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox_jiaokushu" runat="server" Width="46px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox_Amount" runat="server" Width="50px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox_danjia" runat="server" Width="55px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox_TotalPrice" runat="server" Width="71px">0</asp:TextBox>
                </td>
                <td>
                    元</td>
                <td>
                    <asp:TextBox ID="TextBox_Remark" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td>
                    财会部门<br />
                    主管</td>
                <td>
                    <asp:TextBox ID="TextBox_caiwu" runat="server"></asp:TextBox>
                </td>
                <td>
                    记账</td>
                <td>
                    <asp:TextBox ID="TextBox_jizhang" runat="server"></asp:TextBox>
                </td>
                <td>
                    保管部门<br />
                    主管</td>
                <td>
                    <asp:TextBox ID="TextBox_baoguan" runat="server"></asp:TextBox>
                </td>
                <td>
                    验收</td>
                <td>
                    <asp:TextBox ID="TextBox_yanshou" runat="server"></asp:TextBox>
                </td>
                <td>
                    单位部门<br />
                    主管</td>
                <td>
                    <asp:TextBox ID="TextBox_Manager" runat="server"></asp:TextBox>
                </td>
                <td>
                    制单</td>
                <td>
                    <asp:TextBox ID="TextBox_Operator" runat="server" BackColor="#999999" 
            BorderStyle="None" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            </table>
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
