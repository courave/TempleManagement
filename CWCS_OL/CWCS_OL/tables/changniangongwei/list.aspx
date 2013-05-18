<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.changniangongwei.list" %>

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
    <div>
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
            document.getElementsByTagName("option")(14).selected = true
        </script>
        <a href="edit.aspx">新增</a>
        &nbsp;&nbsp;<a href="type.aspx">新增苑</a>
        </div>
        <p style="font-weight: bolder; font-size: x-large">延生</p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" EnableModelValidation="True" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# "detail.aspx?id="+Eval("ID") %>' Target="_blank">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            NavigateUrl='<%# "edit.aspx?id="+Eval("ID") %>' Target="_blank">编辑</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BIANHAO" HeaderText="系统编号" 
                    SortExpression="BIANHAO" />
                <asp:BoundField DataField="YUAN" HeaderText="苑" SortExpression="YUAN" />
                <asp:BoundField DataField="PAI" HeaderText="排" SortExpression="PAI" />
                <asp:BoundField DataField="ZUO" HeaderText="座" SortExpression="ZUO" />
                <asp:BoundField DataField="ZHIFUXIN1" HeaderText="值福信1" 
                    SortExpression="ZHIFUXIN1" />
                <asp:BoundField DataField="ZHIFUXIN2" HeaderText="值福信2" 
                    SortExpression="ZHIFUXIN2" />
                <asp:BoundField DataField="ZHIFUXIN3" HeaderText="值福信3" 
                    SortExpression="ZHIFUXIN3" />
                <asp:BoundField DataField="ZHIFUXIN4" HeaderText="值福信4" 
                    SortExpression="ZHIFUXIN4" />
                <asp:BoundField DataField="LIANXIREN" HeaderText="联系人" 
                    SortExpression="LIANXIREN" />
                <asp:BoundField DataField="DIANHUA" HeaderText="电话" SortExpression="DIANHUA" />
                <asp:BoundField DataField="SHOUJI" HeaderText="手机" SortExpression="SHOUJI" />
                <asp:BoundField DataField="YOUBIAN" HeaderText="邮编" SortExpression="YOUBIAN" />
                <asp:BoundField DataField="DIZHI" HeaderText="地址" SortExpression="DIZHI" />
                <asp:BoundField DataField="SHEHE" HeaderText="审核" SortExpression="SHEHE" />
                <asp:BoundField DataField="LOG_USER" HeaderText="登记人" 
                    SortExpression="LOG_USER" />
                <asp:BoundField DataField="LOD_DATE" HeaderText=" 登记时间" 
                    SortExpression="LOD_DATE" />
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
            
            SelectCommand="SELECT [ID],[LOD_DATE], [BIANHAO], [YUAN], [PAI], [ZUO], [ZHIFUXIN1], [ZHIFUXIN2], [ZHIFUXIN3], [ZHIFUXIN4], [LIANXIREN], [DIANHUA], [SHOUJI], [YOUBIAN], [DIZHI], [SHEHE], [LOG_USER] FROM [CAHNGNIAN_GONGWEI] WHERE ([TYPE] = @TYPE) ORDER BY [LOD_DATE] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="yansheng" Name="TYPE" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <p style="font-weight: bolder; font-size: x-large">往生</p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource2" EnableModelValidation="True" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink3" runat="server" 
                            NavigateUrl='<%# "detail.aspx?id="+Eval("ID") %>' Target="_blank">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink4" runat="server" 
                            NavigateUrl='<%# "edit.aspx?id="+Eval("ID") %>' Target="_blank">编辑</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BIANHAO" HeaderText="系统编号" 
                    SortExpression="BIANHAO" />
                <asp:BoundField DataField="YUAN" HeaderText="苑" SortExpression="YUAN" />
                <asp:BoundField DataField="PAI" HeaderText="排" SortExpression="PAI" />
                <asp:BoundField DataField="ZUO" HeaderText="座" SortExpression="ZUO" />
                <asp:BoundField DataField="CHAOJIAN" HeaderText="超荐" 
                    SortExpression="CHAOJIAN" />
                <asp:BoundField DataField="FUJIAN1" HeaderText="副荐1" SortExpression="FUJIAN1" />
                <asp:BoundField DataField="FUJIAN2" HeaderText="副荐2" SortExpression="FUJIAN2" />
                <asp:BoundField DataField="FUJIAN3" HeaderText="副荐3" SortExpression="FUJIAN3" />
                <asp:BoundField DataField="YANGSHANG1" HeaderText="阳上1" 
                    SortExpression="YANGSHANG1" />
                <asp:BoundField DataField="YANGSHANG2" HeaderText="阳上2" 
                    SortExpression="YANGSHANG2" />
                <asp:BoundField DataField="YANGSHANG3" HeaderText="阳上3" 
                    SortExpression="YANGSHANG3" />
                <asp:BoundField DataField="YANGSHANG4" HeaderText="阳上4" 
                    SortExpression="YANGSHANG4" />
                <asp:BoundField DataField="YANGSHANG5" HeaderText="阳上5" 
                    SortExpression="YANGSHANG5" />
                <asp:BoundField DataField="YANGSHANG6" HeaderText="阳上6" 
                    SortExpression="YANGSHANG6" />
                <asp:BoundField DataField="LIANXIREN" HeaderText="联系人" 
                    SortExpression="LIANXIREN" />
                <asp:BoundField DataField="DIANHUA" HeaderText="电话" SortExpression="DIANHUA" />
                <asp:BoundField DataField="SHOUJI" HeaderText="手机" SortExpression="SHOUJI" />
                <asp:BoundField DataField="YOUBIAN" HeaderText="邮编" SortExpression="YOUBIAN" />
                <asp:BoundField DataField="DIZHI" HeaderText="地址" SortExpression="DIZHI" />
                <asp:BoundField DataField="SHEHE" HeaderText="审核" SortExpression="SHEHE" />
                <asp:BoundField DataField="LOG_USER" HeaderText="登记人" 
                    SortExpression="LOG_USER" />
                <asp:BoundField DataField="LOD_DATE" HeaderText="登记时间" 
                    SortExpression="LOD_DATE" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
                Wrap="False" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle Wrap="False" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            
            SelectCommand="SELECT [ID],[LOD_DATE], [BIANHAO], [YUAN], [PAI], [ZUO], [LIANXIREN], [DIANHUA], [SHOUJI], [YOUBIAN], [DIZHI], [SHEHE], [CHAOJIAN], [FUJIAN2], [FUJIAN1], [FUJIAN3], [YANGSHANG1], [YANGSHANG2], [YANGSHANG3], [LOG_USER], [YANGSHANG6], [YANGSHANG5], [YANGSHANG4] FROM [CAHNGNIAN_GONGWEI] WHERE ([TYPE] = @TYPE) ORDER BY [LOD_DATE] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="wangsheng" Name="TYPE" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
