<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.admin.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
    
        <asp:LinkButton ID="LinkButton_add" runat="server" OnClientClick="document.getElementById('detail').src='Edit.aspx';return false;">新增</asp:LinkButton>
&nbsp;
        <asp:TextBox ID="TextBox_search" runat="server"></asp:TextBox>
        <asp:LinkButton ID="LinkButton_search" runat="server" 
                onclick="LinkButton_search_Click">搜索</asp:LinkButton>&nbsp;&nbsp;
&nbsp;    <asp:LinkButton ID="LinkButton_clear" runat="Server" 
                onclick="LinkButton_clear_Click">清除搜索结果</asp:LinkButton>
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
            EnableModelValidation="True" PageSize="5" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            ForeColor="Black" GridLines="Vertical" DataKeyNames="ID">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_Select" runat="server" CausesValidation="False" 
                            CommandName="Select" 
                            onclientclick='<%# "document.getElementById(\"detail\").src=\"Detail.aspx?id="+Eval("ID")+"\";return false;" %>'>
                            选择</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField DeleteText="删除" SelectText="选择" ShowDeleteButton="True" />
                <asp:BoundField DataField="ID" HeaderText="编号" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="USERNAME" HeaderText="用户名" 
                    SortExpression="USERNAME" >
                <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="PERMISSION" HeaderText="权限" 
                    SortExpression="PERMISSION" >
                <ItemStyle Width="250px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerSettings Position="TopAndBottom" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [ID], [USERNAME], [PERMISSION] FROM [ADMIN] ORDER BY ID DESC"
            DeleteCommand="DELETE FROM [ADMIN] WHERE [ID] = @ID" >
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
    <iframe src="Detail.aspx" id="detail" 
        style="border-style: none; border-color: inherit; border-width: medium; width:100%; height: 326px;" frameborder="0"></iframe>
</body>
</html>
