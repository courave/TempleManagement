<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.employee.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript">

        var SelectNav_onChange = function () {
            var nav = document.getElementById("SelectNav").value;
            window.location.href = nav;
        }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="toolbar">
    <select id="SelectNav" onchange="SelectNav_onChange()">
        <option value="../../admin/list.aspx">管理员表</option>
        <option value="../../print/PrintTemplate.aspx">打印模板</option>
        <option value="../../tables/yansheng/index.htm">延生表</option>
        <option value="../../tables/wangsheng/index.htm">往生表</option>
        <option value="../../tables/sanshi/index.htm">三时系列法会</option>
        <option value="../../tables/fahua/index.htm">法华法会</option>
        <option value="../../tables/shizhuinfo/index.htm">施主基本信息表</option>
        <option value="../../tables/gongde/index.htm">功德项目表</option>
        <option value="../../tables/stock/index.htm">库存管理</option>
        <option value="../../tables/filemgr/index.htm">档案管理</option>
        <option value="../../tables/fashiinfo/index.htm">法师信息表</option>
        <option value="../../tables/foshi/index.htm">佛事表</option>
        <option value="../../tables/fahui/default.aspx">法会管理</option>
        <option value="../../tables/employee/list.aspx">员工管理</option>
        <option value="../../tables/changniangongwei/list.aspx">常年供位</option>
     </select>
        <script type="text/javascript">
            document.getElementsByTagName("option")(13).selected = true
        </script>
        <a href="edit.aspx">新增</a>&nbsp;&nbsp;&nbsp;<a href="report.aspx" target="_blank">报表</a>
        </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
            EnableModelValidation="True" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            
                            NavigateUrl='<%# "detail.aspx?id="+Eval("ID")+"&type="+Server.UrlEncode(Eval("TYPE","{0}")) %>' 
                            Target="_blank">选择</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>                   
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            NavigateUrl='<%# "edit.aspx?id="+Eval("ID") %>' Target="_blank">编辑</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink3" runat="server" 
                            NavigateUrl='<%# "lorot.aspx?id="+Eval("ID")+"&type="+Server.UrlEncode(Eval("TYPE","{0}")) %>' Target="_blank">请假</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="编号" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="NATIVE_NAME" HeaderText="姓名" 
                    SortExpression="NATIVE_NAME" />
                <asp:BoundField DataField="TYPE" HeaderText="类别" SortExpression="TYPE" />
                <asp:BoundField DataField="NICK_NAME" HeaderText="昵称" 
                    SortExpression="NICK_NAME" />
                <asp:BoundField DataField="FAHAO" HeaderText="法号" SortExpression="FAHAO" />
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# ((bool)Eval("SEX"))?"女":"男" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="出生年月">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("BIRTH_YEAR")+"-"+Eval("BIRTH_MONTH") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PHONE" HeaderText="电话" SortExpression="PHONE" />
                <asp:BoundField DataField="HOME_ADDR" HeaderText="家庭住址" 
                    SortExpression="HOME_ADDR" />
                <asp:BoundField DataField="EMAIL" HeaderText="电子邮件" SortExpression="EMAIL" />
                <asp:BoundField DataField="ABILITY" HeaderText="特长" SortExpression="ABILITY" />
                <asp:BoundField DataField="HOBBY" HeaderText="兴趣爱好" SortExpression="HOBBY" />
                <asp:BoundField DataField="DEGREE" HeaderText="学历" SortExpression="DEGREE" />
                <asp:BoundField DataField="HIRE_DATE" HeaderText="入职日期" 
                    SortExpression="HIRE_DATE" />
                <asp:BoundField DataField="QUIT_DATE" HeaderText="离职日期" 
                    SortExpression="QUIT_DATE" />
                <asp:BoundField DataField="COMMENTS" HeaderText="备注" 
                    SortExpression="COMMENTS" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
                Wrap="False" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle Wrap="False" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [ID], [NATIVE_NAME], [TYPE], [SEX], [PHONE], [EMAIL], [STATUS], [BIRTH_MONTH], [FAHAO], [NICK_NAME], [COMMENTS], [ABILITY], [HOBBY], [DEGREE], [HOME_ADDR], [BIRTH_YEAR], [HIRE_DATE], [QUIT_DATE] FROM [EMPLOYEES] ORDER BY [NATIVE_NAME]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
