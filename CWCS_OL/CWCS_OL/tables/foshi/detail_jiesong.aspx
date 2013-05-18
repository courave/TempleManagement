<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail_jiesong.aspx.cs" Inherits="CWCS_OL.tables.foshi.detail_jiesong" %>

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
        接送地址：<asp:Label ID="Label_JIESONG_ADDR" runat="server"></asp:Label>
        <br />
        司机：<asp:GridView ID="GridView_jiesong" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource_jiesong" EnableModelValidation="True" 
            DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" 
                    InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="Driver" HeaderText="司机" 
                    SortExpression="Driver" />
                <asp:BoundField DataField="LicPlate" HeaderText="车牌号" 
                    SortExpression="LicPlate" />
                <asp:BoundField DataField="PeopleCount" HeaderText="人数" 
                    SortExpression="PeopleCount" />
                <asp:BoundField DataField="Cost" HeaderText="接送费用" SortExpression="Cost" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_jiesong" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            
            SelectCommand="SELECT [ID], [Driver], [LicPlate], [PeopleCount], [Cost] FROM [FOSHI_JIESONG] WHERE ([FoshiID] = @FoshiID)" >
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
