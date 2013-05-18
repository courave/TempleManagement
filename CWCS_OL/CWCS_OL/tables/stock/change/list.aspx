<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.stock.change.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="SqlDataSource1" EnableModelValidation="True" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_select" runat="server" CausesValidation="false"
                        CommandName="Select"
                        onclientclick='<%# "return parent.selRec(\"" + Eval("ID") + "\");" %>'>选择</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="StockId" HeaderText="仓库编号" 
                    SortExpression="StockId" />
                <asp:BoundField DataField="BillNo" HeaderText="单号" 
                    SortExpression="BillNo" />
                <asp:BoundField DataField="GoodsNo" HeaderText="货品编号" 
                    SortExpression="GoodsNo" />
                <asp:BoundField DataField="Name" HeaderText="货品名称" 
                    SortExpression="Name" />
                <asp:BoundField DataField="BarCode" HeaderText="条形码" 
                    SortExpression="BarCode" />
                <asp:BoundField DataField="Unit" HeaderText="单位" 
                    SortExpression="Unit" />
                <asp:BoundField DataField="Amount" HeaderText="数量" 
                    SortExpression="Amount" />
                <asp:BoundField DataField="TotalPrice" HeaderText="总价" 
                    SortExpression="TotalPrice" />
                <asp:BoundField DataField="FromTo" HeaderText="原因" 
                    SortExpression="FromTo" />
                <asp:BoundField DataField="Manager" HeaderText="负责人" 
                    SortExpression="Manager" />
                <asp:BoundField DataField="EditTime" HeaderText="时间" 
                    SortExpression="EditTime" />
                <asp:BoundField DataField="Operator" HeaderText="登记人" 
                    SortExpression="Operator" />
                <asp:BoundField DataField="Remark" HeaderText="备注" SortExpression="Remark" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
                Wrap="False" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle Wrap="False" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            
            
            SelectCommand="SELECT StockTrans.ID, StockTrans.StockId, StockTrans.BillNo, StockTrans.EditTime, StockTrans.Amount, StockTrans.TotalPrice, StockTrans.FromTo, StockTrans.Manager, StockTrans.Operator, StockTrans.Remark, Goods.GoodsNo, Goods.BarCode, Goods.Name, Goods.Unit FROM StockTrans INNER JOIN Goods ON StockTrans.GoodsId = Goods.ID WHERE (StockTrans.Type = 2)">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
