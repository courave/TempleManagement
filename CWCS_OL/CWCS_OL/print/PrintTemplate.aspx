<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintTemplate.aspx.cs" Inherits="CWCS_OL.print.PrintTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>打印模板列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="id" DataSourceID="SqlDataSource_template" ForeColor="#333333" 
            GridLines="None" onrowdeleting="GridView1_RowDeleting" 
            EmptyDataText="没有模板" onrowediting="GridView1_RowEditing">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="编号" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
                <asp:TemplateField HeaderText="类型" SortExpression="type">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList_type" runat="server" Enabled="False" 
                            SelectedValue='<%# Bind("type") %>'>
                            <asp:ListItem Value="yansheng">延生表</asp:ListItem>
                            <asp:ListItem Value="yansheng_single">延生表（单）</asp:ListItem>
                            <asp:ListItem Value="wangsheng">往生表</asp:ListItem>
                            <asp:ListItem Value="wangsheng_single">往生表（单）</asp:ListItem>
                            <asp:ListItem Value="sanshi">三时系列</asp:ListItem>
                            <asp:ListItem Value="sanshi_single">三时系列（单）</asp:ListItem>
                            <asp:ListItem Value="fahua">法华法会</asp:ListItem>
                            <asp:ListItem Value="fahua_single">法华法会（单）</asp:ListItem>
                            <asp:ListItem Value="fashi">法师信息表</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("type") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="名称" SortExpression="name" />
                <asp:CheckBoxField DataField="deftemplate" HeaderText="默认" 
                    SortExpression="deftemplate" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_template" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            DeleteCommand="DELETE FROM [PrintConfig] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [PrintConfig] ([type], [name], [deftemplate]) VALUES (@type, @name, @deftemplate)" 
            SelectCommand="SELECT [id], [type], [name], [deftemplate] FROM [PrintConfig]" 
            
            UpdateCommand="UPDATE [PrintConfig] SET [type] = @type, [name] = @name, [deftemplate] = @deftemplate WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="deftemplate" Type="Boolean" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="deftemplate" Type="Boolean" />
            </InsertParameters>
        </asp:SqlDataSource>


        <br />


    </div>
    <div>
        <asp:Panel ID="Panel_add" runat="server">
            <hr />
            新增打印模板：<asp:DropDownList ID="DropDownList_type" runat="server">
                <asp:ListItem Value="yansheng">延生表</asp:ListItem>
                <asp:ListItem Value="yansheng_single">延生表（单）</asp:ListItem>
                <asp:ListItem Value="wangsheng">往生表</asp:ListItem>
                <asp:ListItem Value="wangsheng_single">往生表（单）</asp:ListItem>
                <asp:ListItem Value="sanshi">三时系列</asp:ListItem>
                <asp:ListItem Value="sanshi_single">三时系列（单）</asp:ListItem>
                <asp:ListItem Value="fahua">法华法会</asp:ListItem>
                <asp:ListItem Value="fahua_single">法华法会（单）</asp:ListItem>
                <asp:ListItem Value="fashi">法师信息表</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button_add" runat="server" Text="新增" 
            onclick="Button_add_Click" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
