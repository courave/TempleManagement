<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="CWCS_OL.tables.filemgr.detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        档案编号：<asp:Label ID="Label_FileNo" runat="server"></asp:Label>
        <br />
        档案标题：<asp:Label ID="Label_FileTitle" runat="server"></asp:Label>
        <br />
        录入人：<asp:Label ID="Label_LogUser" runat="server"></asp:Label>
        <br />
        录入时间：<asp:Label ID="Label_LogTime" runat="server"></asp:Label>
        <br />
        文件列表：<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="SqlDataSource1" EnableModelValidation="True" 
            EmptyDataText="没有文件">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:TemplateField HeaderText="文件名" SortExpression="FileName">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink_download" runat="server" 
                            NavigateUrl='<%# "file.aspx?id="+Eval("ID") %>' Text='<%# Eval("FileName") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FileName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [ID], [FileName] FROM [File] WHERE ([MgrId] = @MgrId)">
            <SelectParameters>
                <asp:QueryStringParameter Name="MgrId" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        信息：<br />
        <asp:Label ID="Label_Info" runat="server"></asp:Label>
        <br />    </div>
    <asp:Button ID="Button_edit" runat="server" onclick="Button_edit_Click" 
        Text="编辑(E)" AccessKey="e" />
    <br />
    <asp:Button ID="Button_prev" runat="server" AccessKey="p" Text="上一条(P)" />
    <asp:Button ID="Button_next" runat="server" AccessKey="t" Text="下一条(T)" />
    </form>
</body>
</html>
