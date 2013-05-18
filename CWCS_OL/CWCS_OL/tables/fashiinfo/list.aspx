<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.fashiinfo.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>法师信息</title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" EnableModelValidation="True" 
            style="margin-left: 0px" AllowSorting="True" DataKeyNames="ID" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_select" runat="server"
                         CausesValidation="false" CommandName="Select"
                          OnClientClick='<%# "return parent.selRec(\"" + Eval("ID") + "\");" %>'>选择</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_select2" runat="server" CausesValidation="false"
                        CommandName="Select"
                        onclientclick='<%# "window.opener.selRec(\"" + Eval("ID") + "\",\""+Eval("FAHAO")+"\",\""+Eval("ZHIWEI")+"\",\""+Eval("FASHI_NAME")+"\");window.close();return false;" %>'>选择</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" 
                    SortExpression="ID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="FAHAO" HeaderText="法号" 
                    SortExpression="FAHAO" />
                <asp:BoundField DataField="FASHI_NAME" HeaderText="姓名" 
                    SortExpression="FASHI_NAME" />
                <asp:BoundField DataField="ZHIWEI" HeaderText="职位" 
                    SortExpression="ZHIWEI" />
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
            SelectCommand="SELECT [ID], [FAHAO], [ZHIWEI], [FASHI_NAME] FROM [FASHI_INFO]"
            DeleteCommand="DELETE FROM [FASHI_INFO] WHERE [ID] = @ID" >
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
