<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.stock.instock.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../../Scripts/list.css" type="text/css" />
    <style type="text/css">
    .tbstyle
    {
        border:1px solid #000000;
        width:100%;
    }
    .tbstyle td
    {
        border:1px solid #000000;
        text-align:center;
    }
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
                    No.<asp:Label ID="Label_BillNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style=" width:33%;">
                    &nbsp;</td>
                <td style=" width:33%; text-align:center;">
                    <asp:Label ID="Label_EditTime" runat="server"></asp:Label>
                </td>
                <td style=" width:33%; text-align:right;">
                    连续号：<asp:Label 
                        ID="Label_lianxuhao" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="tbstyle">
            <tr>
                <td>
                    交货单位<br />
                    （部门）</td>
                <td>
                    <asp:Label ID="Label_FromTo" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    发票号码或<br />
                    生产单号码</td>
                <td>
                    <asp:Label ID="Label_fapiao" runat="server"></asp:Label>
                </td>
                <td>
                    仓库</td>
                <td>
                    <asp:Label ID="Label_StockId" runat="server"></asp:Label>
                </td>
                <td>
                    入库<br />
                    日期</td>
                <td>
                    <asp:Label ID="Label_rukudate" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
        <table class="tbstyle">
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
                    <asp:Label ID="Label_GoodsNo" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label_Name" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label_Specification" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label_Unit" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label_jiaokushu" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label_Amount" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label_danjia" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label_TotalPrice" runat="server"></asp:Label>
                </td>
                <td>
                    元</td>
                <td>
                    <asp:Label ID="Label_Remark" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td>
                    财会部门<br />
                    主管</td>
                <td>
                    <asp:Label ID="Label_caiwu" runat="server"></asp:Label>
                </td>
                <td>
                    记账</td>
                <td>
                    <asp:Label ID="Label_jizhang" runat="server"></asp:Label>
                </td>
                <td>
                    保管部门<br />
                    主管</td>
                <td>
                    <asp:Label ID="Label_baoguan" runat="server"></asp:Label>
                </td>
                <td>
                    验收</td>
                <td>
                    <asp:Label ID="Label_yanshou" runat="server"></asp:Label>
                </td>
                <td>
                    单位部门<br />
                    主管</td>
                <td>
                    <asp:Label ID="Label_Manager" runat="server"></asp:Label>
                </td>
                <td>
                    制单</td>
                <td>
                    <asp:Label ID="Label_Operator" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
    </div>
    <asp:Button ID="Button_edit" runat="server" onclick="Button_edit_Click" 
        Text="编辑(E)" AccessKey="e" />
    <br />
    <asp:Button ID="Button_prev" runat="server" AccessKey="p" Text="上一条(P)" />
    <asp:Button ID="Button_next" runat="server" AccessKey="t" Text="下一条(T)" />
    </form>
</body>
</html>
