<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.foshi.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript">
        var showSheng = function (id) {
            parent.document.getElementById("detail").src = "detail_sheng.aspx?id=" + id;
            if (!parent.isPrintHidden) {
                parent.document.getElementById("print").src = "print_sheng.aspx?id=" + id;
            } else {
                parent.lastSelRec = "";
            }
            return false;
        }
        var showFashi = function (id) {
            parent.document.getElementById("detail").src = "detail_fashi.aspx?id=" + id;
            if (!parent.isPrintHidden) {
                parent.document.getElementById("print").src = "print_fashi.aspx?id=" + id;
            } else {
                parent.lastSelRec = "";
            }
            return false;
        }
        var showJiesong = function (id) {
            parent.document.getElementById("detail").src = "detail_jiesong.aspx?id=" + id;
            if (!parent.isPrintHidden) {
                parent.document.getElementById("print").src = "print_jiesong.aspx?id=" + id;
            } else {
                parent.lastSelRec = "";
            }
            return false;
        }
    </script>
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
                        <asp:LinkButton ID="LinkButton_del" runat="server" CommandArgument='<%# Eval("ID") %>'
                        OnClick="LinkButton_del_Click" OnClientClick="return confirm('确实要删除吗？');">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" 
                    SortExpression="ID" InsertVisible="False" ReadOnly="True" />
                <asp:TemplateField HeaderText="斋主姓名" SortExpression="ZHAIZHU_NAME">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_sheng" runat="server" 
                            Text='<%# Bind("ZHAIZHU_NAME") %>'
                            OnClientClick='<%# "return showSheng(\"" + Eval("ID") + "\");" %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FOSHI_DATETIME" HeaderText="时间日期" 
                    SortExpression="FOSHI_DATETIME" />
                <asp:TemplateField HeaderText="法师数" SortExpression="FASHI_COUNT">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_fashi" runat="server" 
                            Text='<%# Bind("FASHI_COUNT") %>'
                            OnClientClick='<%# "return showFashi(\"" + Eval("ID") + "\");" %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="接送地址" SortExpression="JIESONG_ADDR">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_jiesong" runat="server" 
                            Text='<%# Bind("JIESONG_ADDR") %>'
                            OnClientClick='<%# "return showJiesong(\"" + Eval("ID") + "\");" %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TEL" HeaderText="联系电话" SortExpression="TEL" />
                <asp:BoundField DataField="LOG_USER" HeaderText="经办人" 
                    SortExpression="LOG_USER" />
                <asp:BoundField DataField="LOG_TIME" HeaderText="经办时间" 
                    SortExpression="LOG_TIME" />
                <asp:BoundField DataField="COMMENT" HeaderText="备注" 
                    SortExpression="COMMENT" />
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
            SelectCommand="SELECT [ID], [ZHAIZHU_NAME], [FOSHI_DATETIME], ISNULL([FCOUNT],0) AS FASHI_COUNT, [JIESONG_ADDR], [TEL], [LOG_USER], [LOG_TIME], [COMMENT] FROM [tbFOSHI] A LEFT JOIN (SELECT FOSHI_ID,COUNT(*) AS FCOUNT FROM [FASHI_FOSHI] GROUP BY FOSHI_ID) B ON A.ID=B.FOSHI_ID"
            DeleteCommand="DELETE FROM [tbFOSHI] WHERE [ID] = @ID" >
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
