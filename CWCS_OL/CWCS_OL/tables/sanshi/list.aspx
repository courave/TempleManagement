<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.sanshi.list" %>

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
&nbsp;<asp:Button ID="Button_today" runat="server" Text="获取当天数据" 
                onclick="Button_today_Click" />
&nbsp;<asp:Button ID="Button_getunprint" runat="server" Text="获取所有未打印数据" 
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
                        <asp:LinkButton ID="LinkButton_select" runat="server"
                         CausesValidation="false" CommandName="Select"
                          OnClientClick='<%# "return parent.selRec(\"" + Eval("ID") + "\");" %>'>选择</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" DeleteText="删除" >
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:BoundField DataField="SANSHI_NO" HeaderText="编号" InsertVisible="False" 
                    ReadOnly="True" SortExpression="SANSHI_NO" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="FAHUI_NAME" HeaderText="法会名称" 
                    SortExpression="FAHUI_NAME" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="施主编号">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# "../shizhuinfo/detail.aspx?shizhuid="+Eval("SHIZHU_BIANHAO") %>' 
                            Target="_blank" Text='<%# Eval("SHIZHU_BIANHAO", "{0}") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle ForeColor="White" Wrap="False"  />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:BoundField DataField="ZIHAO" HeaderText="字号" SortExpression="ZIHAO" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ZUOCI" HeaderText="座次" SortExpression="ZUOCI" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="FANGWEI" HeaderText="方位" SortExpression="FANGWEI">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ROW" HeaderText="排" SortExpression="ROW">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="COL" HeaderText="座" SortExpression="COL">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="JIEYIN1" HeaderText="佛光接引一" 
                    SortExpression="JIEYIN1" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="JIEYIN2" HeaderText="佛光接引二" 
                    SortExpression="JIEYIN2" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="JIEYIN3" HeaderText="佛光接引三" 
                    SortExpression="JIEYIN3" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="JIEYIN4" HeaderText="佛光接引四" 
                    SortExpression="JIEYIN4" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="YANGSHANG1" HeaderText="阳上一" 
                    SortExpression="YANGSHANG1" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="YANGSHANG2" HeaderText="阳上二" 
                    SortExpression="YANGSHANG2" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="YANGSHANG3" HeaderText="阳上三" 
                    SortExpression="YANGSHANG3" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="YANGSHANG4" HeaderText="阳上四" 
                    SortExpression="YANGSHANG4" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="EXPIRED_TIME" HeaderText="过期时间" 
                    SortExpression="EXPIRED_TIME" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="LOG_USER" HeaderText="登记人" 
                    SortExpression="LOG_USER" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="LOG_TIME" HeaderText="登记时间" 
                    SortExpression="LOG_TIME" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="YANGSHANG5" HeaderText="阳上五" 
                    SortExpression="YANGSHANG5" Visible="False" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="YANGSHANG6" HeaderText="阳上六" 
                    SortExpression="YANGSHANG6" Visible="False" >
                    <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
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
            
            
            
            SelectCommand="SELECT [ID], [SANSHI_NO], [LOG_USER], [LOG_TIME], [FAHUI_NAME], [ZUOCI], [ZIHAO], [JIEYIN1], [YANGSHANG6], [YANGSHANG5], [YANGSHANG4], [YANGSHANG3], [YANGSHANG2], [YANGSHANG1], [JIEYIN4], [JIEYIN3], [JIEYIN2], [EXPIRED_TIME], [SHIZHU_BIANHAO], [FANGWEI], [ROW], [COL], [HAS_PRINT] FROM [tbSANSHI]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
