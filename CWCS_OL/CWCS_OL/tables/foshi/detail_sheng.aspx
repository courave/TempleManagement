<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail_sheng.aspx.cs" Inherits="CWCS_OL.tables.foshi.detail_sheng" %>

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
        往生：<asp:GridView ID="GridView_wang" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="SqlDataSource_wang" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="JZ1" HeaderText="佛光接引一" SortExpression="JZ1" />
                <asp:BoundField DataField="JZ2" HeaderText="佛光接引二" SortExpression="JZ2" />
                <asp:BoundField DataField="JZ3" HeaderText="佛光接引三" SortExpression="JZ3" />
                <asp:BoundField DataField="JZ4" HeaderText="佛光接引四" SortExpression="JZ4" />
                <asp:BoundField DataField="YS1" HeaderText="阳上一" SortExpression="YS1" />
                <asp:BoundField DataField="YS2" HeaderText="阳上二" SortExpression="YS2" />
                <asp:BoundField DataField="YS3" HeaderText="阳上三" SortExpression="YS3" />
                <asp:BoundField DataField="YS4" HeaderText="阳上四" SortExpression="YS4" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_wang" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [ID], [JZ1], [JZ2], [JZ3], [JZ4], [YS1], [YS2], [YS3], [YS4] FROM [FOSHI_SHENG] WHERE [Type]=0 AND ([FoshiID] = @FoshiID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="FoshiID" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
            延生：<asp:GridView ID="GridView_yan" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="SqlDataSource_yan" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="JZ1" HeaderText="佛光注照一" SortExpression="JZ1" />
                <asp:BoundField DataField="JZ2" HeaderText="佛光注照二" SortExpression="JZ2" />
                <asp:BoundField DataField="JZ3" HeaderText="佛光注照三" SortExpression="JZ3" />
                <asp:BoundField DataField="JZ4" HeaderText="佛光注照四" SortExpression="JZ4" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_yan" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [ID], [JZ1], [JZ2], [JZ3], [JZ4] FROM [FOSHI_SHENG] WHERE [Type]=1 AND ([FoshiID] = @FoshiID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="FoshiID" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
    </div>
    <asp:Button ID="Button_edit" runat="server" Text="编辑(E)" AccessKey="e" />
    <br />
    </form>
</body>
</html>
