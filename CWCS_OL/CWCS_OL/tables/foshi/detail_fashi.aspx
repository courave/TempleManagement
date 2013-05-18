<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail_fashi.aspx.cs" Inherits="CWCS_OL.tables.foshi.detail_fashi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        斋主姓名：<asp:Label ID="Label_ZHAIZHU_NAME" runat="server"></asp:Label>
        <br />
        法师：<asp:GridView ID="GridView_fashi" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource_fashi" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="FAHAO" HeaderText="法号" SortExpression="FAHAO" />
                <asp:BoundField DataField="POSITION" HeaderText="职位" 
                    SortExpression="POSITION" />
                <asp:BoundField DataField="DANZI" HeaderText="单资" 
                    SortExpression="DANZI" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_fashi" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            
            SelectCommand="select FAHAO,DANZI,POSITION from FASHI_FOSHI WHERE FOSHI_ID= @FOSHI_ID" >
            <SelectParameters>
                <asp:QueryStringParameter Name="FOSHI_ID" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        
    </div>
    <asp:Button ID="Button_edit" runat="server" Text="编辑(E)" AccessKey="e" />
    <br />
    </form>
</body>
</html>
