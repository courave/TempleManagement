<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.stock.goods.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>货品列表</title>
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_select2" runat="server" CausesValidation="false"
                        CommandName="Select"
                        onclientclick='<%# "window.opener.selRec(\"" + Eval("GoodsNo") + "\",\""+Eval("Name")+"\",\""+Eval("BarCode")+"\",\""+Eval("Unit")+"\");window.close();return false;" %>'>选择</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="GoodsNo" HeaderText="货品编号" 
                    SortExpression="GoodsNo" />
                <asp:BoundField DataField="Name" HeaderText="货品名称" SortExpression="Name" />
                <asp:BoundField DataField="BarCode" HeaderText="条形码" 
                    SortExpression="BarCode" />
                <asp:BoundField DataField="Category" HeaderText="类别" 
                    SortExpression="Category" />
                <asp:BoundField DataField="Specification" HeaderText="规格" 
                    SortExpression="Specification" />
                <asp:BoundField DataField="Unit" HeaderText="单位" 
                    SortExpression="Unit" />
                <asp:BoundField DataField="Remark" HeaderText="备注" 
                    SortExpression="Remark" />
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
            SelectCommand="SELECT [ID], [GoodsNo], [Name], [BarCode], [Category], [Specification], [Unit], [Remark] FROM [Goods]"
            DeleteCommand="DELETE FROM [Goods] WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
