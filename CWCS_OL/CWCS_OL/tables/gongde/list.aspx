<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.gongde.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" EnableModelValidation="True" 
            style="margin-left: 0px" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
            DataKeyNames="ID" AllowSorting="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_select" runat="server"
                         CausesValidation="false" CommandName="Select"
                          OnClientClick='<%# "return parent.selRec(\"" + Eval("ID") + "\");" %>'>选择</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField DeleteText="删除" ShowDeleteButton="True" />
                <asp:BoundField DataField="DONATE_NO" HeaderText="捐赠编号" 
                    SortExpression="DONATE_NO" />
                <asp:BoundField DataField="DONATE_TYPE" HeaderText="捐赠类型" 
                    SortExpression="DONATE_TYPE" />
                <asp:BoundField DataField="DONATE_MONEY" HeaderText="捐赠金额" 
                    SortExpression="DONATE_MONEY" />
                <asp:BoundField DataField="INVOICE_NO" HeaderText="发票号码" 
                    SortExpression="INVOICE_NO" />
                <asp:BoundField DataField="DONATE_DATE" HeaderText="捐赠日期" 
                    SortExpression="DONATE_DATE" />
                <asp:BoundField DataField="LOG_USER" HeaderText="经办人" 
                    SortExpression="LOG_USER" />
                <asp:BoundField DataField="LOG_TIME" HeaderText="经办日期" 
                    SortExpression="LOG_TIME" />
                <asp:BoundField DataField="GONGDE_FANGMING" HeaderText="功德芳名" 
                    SortExpression="GONGDE_FANGMING" />
                <asp:BoundField DataField="DONATE_DESCRIPTION" HeaderText="捐赠说明" 
                    SortExpression="DONATE_DESCRIPTION" />
                <asp:BoundField DataField="DONATE_COMMENTS" HeaderText="备注" 
                    SortExpression="DONATE_COMMENTS" />
                <asp:BoundField DataField="SHIZHU_ID" HeaderText="编号" 
                    SortExpression="SHIZHU_ID" />
                <asp:BoundField DataField="SHIZHU_NAME" HeaderText="姓名" 
                    SortExpression="SHIZHU_NAME" />
                <asp:BoundField DataField="SHIZHU_SEX" HeaderText="性别" 
                    SortExpression="SHIZHU_SEX" />
                <asp:BoundField DataField="SHIZHU_TYPE" HeaderText="施主类型" 
                    SortExpression="SHIZHU_TYPE" />
                <asp:BoundField DataField="SHIZHU_HOME_ADDR" HeaderText="家庭住址" 
                    SortExpression="SHIZHU_HOME_ADDR" />
                <asp:BoundField DataField="SHIZHU_HOME_ZIP" HeaderText="家庭邮编" 
                    SortExpression="SHIZHU_HOME_ZIP" />
                <asp:BoundField DataField="SHIZHU_HOME_TEL" HeaderText="家庭电话" 
                    SortExpression="SHIZHU_HOME_TEL" />
                <asp:BoundField DataField="SHIZHU_MOBILE" HeaderText="手机" 
                    SortExpression="SHIZHU_MOBILE" />
                <asp:BoundField DataField="SHIZHU_EMAIL" HeaderText="电子邮件" 
                    SortExpression="SHIZHU_EMAIL" />
                <asp:BoundField DataField="SHIZHU_BIRTH_TYPE" HeaderText="生日类型" 
                    SortExpression="SHIZHU_BIRTH_TYPE" />
                <asp:BoundField DataField="SHIZHU_BIRTHDAY" HeaderText="公历生日" 
                    SortExpression="SHIZHU_BIRTHDAY" />
                <asp:BoundField DataField="SHIZHU_LUNAR_DAY" HeaderText="农历生日" 
                    SortExpression="SHIZHU_LUNAR_DAY" />
                <asp:BoundField DataField="SHIZHU_TUIXIN" HeaderText="退信" 
                    SortExpression="SHIZHU_TUIXIN" />
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
            DeleteCommand="DELETE FROM [SHIZHU_GONGDE] WHERE [ID] = @ID"
            SelectCommand="select b.ID,a.SHIZHU_ID,a.SHIZHU_NAME,a.SHIZHU_SEX,a.SHIZHU_TYPE,
a.SHIZHU_HOME_ADDR,a.SHIZHU_HOME_ZIP,a.SHIZHU_HOME_TEL,a.SHIZHU_MOBILE,
a.SHIZHU_EMAIL,a.SHIZHU_BIRTH_TYPE,a.SHIZHU_BIRTHDAY,a.SHIZHU_LUNAR_DAY,
a.SHIZHU_TUIXIN,b.DONATE_NO,b.DONATE_TYPE,b.DONATE_MONEY,b.INVOICE_NO,
b.DONATE_DATE,b.LOG_USER,b.LOG_TIME,b.GONGDE_FANGMING,DONATE_DESCRIPTION,
b.DONATE_COMMENTS from SHIZHU_INFO a,SHIZHU_GONGDE b WHERE a.SHIZHU_ID=b.SHIZHU_ID ORDER BY b.ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
