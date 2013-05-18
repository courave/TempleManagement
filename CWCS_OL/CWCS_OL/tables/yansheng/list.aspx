<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.yansheng.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="searchBar">
    按列搜索：
        <asp:DropDownList ID="DropDownList_col" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <asp:TextBox ID="TextBox_searchText" runat="server"></asp:TextBox>
        <asp:Button ID="Button_searchCur" runat="server" Text="搜索当前列表" 
            onclick="Button_searchCur_Click" />
        <asp:Button ID="Button_searchAll" runat="server" Text="搜索所有数据" 
            onclick="Button_searchAll_Click" />
        <asp:Button ID="Button_getunprint" runat="server" Text="获取所有未打印数据" 
            onclick="Button_getunprint_Click" />
    </div>
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
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="FAHUI_NAME" HeaderText="法会名称" 
                    SortExpression="FAHUI_NAME" />
                <asp:BoundField DataField="ZIHAO" HeaderText="字号" SortExpression="ZIHAO" />
                <asp:BoundField DataField="ZUOCI" HeaderText="座次" SortExpression="ZUOCI" />
                <asp:BoundField DataField="ZHUZHAO1" HeaderText="佛光注照一" 
                    SortExpression="ZHUZHAO1" />
                <asp:BoundField DataField="ZHUZHAO2" HeaderText="佛光注照二" 
                    SortExpression="ZHUZHAO2" />
                <asp:BoundField DataField="ZHUZHAO3" HeaderText="佛光注照三" 
                    SortExpression="ZHUZHAO3" />
                <asp:BoundField DataField="ZHUZHAO4" HeaderText="佛光注照四" 
                    SortExpression="ZHUZHAO4" />
                <asp:BoundField DataField="LOG_USER" HeaderText="登记人" 
                    SortExpression="LOG_USER" />
                <asp:BoundField DataField="LOG_TIME" HeaderText="登记时间" 
                    SortExpression="LOG_TIME" />
                <asp:TemplateField HeaderText="是否打印" SortExpression="HAS_PRINT">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" 
                            Checked='<%# Convert.ToString(Eval("HAS_PRINT"))=="True" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
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
            SelectCommand="SELECT [ID], [LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO], [ZUOCI], [HAS_PRINT] FROM [tbYANSHENG] ORDER BY ZUOCI"
            DeleteCommand="DELETE FROM [tbYANSHENG] WHERE [ID] = @ID" 
            InsertCommand="INSERT INTO [tbYANSHENG] ([LOG_TIME], [LOG_USER], [FAHUI_NAME], [ZHUZHAO1], [ZHUZHAO2], [ZHUZHAO3], [ZHUZHAO4], [ZIHAO], [ZUOCI], [HAS_PRINT]) VALUES (@LOG_TIME, @LOG_USER, @FAHUI_NAME, @ZHUZHAO1, @ZHUZHAO2, @ZHUZHAO3, @ZHUZHAO4, @ZIHAO, @ZUOCI, @HAS_PRINT)" 
            UpdateCommand="UPDATE [tbYANSHENG] SET [LOG_TIME] = @LOG_TIME, [LOG_USER] = @LOG_USER, [FAHUI_NAME] = @FAHUI_NAME, [ZHUZHAO1] = @ZHUZHAO1, [ZHUZHAO2] = @ZHUZHAO2, [ZHUZHAO3] = @ZHUZHAO3, [ZHUZHAO4] = @ZHUZHAO4, [ZIHAO] = @ZIHAO, [ZUOCI] = @ZUOCI, [HAS_PRINT] = @HAS_PRINT WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="LOG_TIME" Type="DateTime" />
                <asp:Parameter Name="LOG_USER" Type="String" />
                <asp:Parameter Name="FAHUI_NAME" Type="String" />
                <asp:Parameter Name="ZHUZHAO1" Type="String" />
                <asp:Parameter Name="ZHUZHAO2" Type="String" />
                <asp:Parameter Name="ZHUZHAO3" Type="String" />
                <asp:Parameter Name="ZHUZHAO4" Type="String" />
                <asp:Parameter Name="ZIHAO" Type="String" />
                <asp:Parameter Name="ZUOCI" Type="Int32" />
                <asp:Parameter Name="HAS_PRINT" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="LOG_TIME" Type="DateTime" />
                <asp:Parameter Name="LOG_USER" Type="String" />
                <asp:Parameter Name="FAHUI_NAME" Type="String" />
                <asp:Parameter Name="ZHUZHAO1" Type="String" />
                <asp:Parameter Name="ZHUZHAO2" Type="String" />
                <asp:Parameter Name="ZHUZHAO3" Type="String" />
                <asp:Parameter Name="ZHUZHAO4" Type="String" />
                <asp:Parameter Name="ZIHAO" Type="String" />
                <asp:Parameter Name="ZUOCI" Type="Int32" />
                <asp:Parameter Name="HAS_PRINT" Type="Boolean" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
