<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="CWCS_OL.tables.shizhuinfo.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>施主信息</title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="toolbar" runat="server">
        <asp:DropDownList ID="DropDownList_month" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">一月</asp:ListItem>
            <asp:ListItem Value="2">二月</asp:ListItem>
            <asp:ListItem Value="3">三月</asp:ListItem>
            <asp:ListItem Value="4">四月</asp:ListItem>
            <asp:ListItem Value="5">五月</asp:ListItem>
            <asp:ListItem Value="6">六月</asp:ListItem>
            <asp:ListItem Value="7">七月</asp:ListItem>
            <asp:ListItem Value="8">八月</asp:ListItem>
            <asp:ListItem Value="9">九月</asp:ListItem>
            <asp:ListItem Value="10">十月</asp:ListItem>
            <asp:ListItem Value="11">十一月</asp:ListItem>
            <asp:ListItem Value="12">十二月</asp:ListItem>
        </asp:DropDownList>&nbsp;<asp:Button ID="Button_Getshouxin" runat="server" 
            Text="获取该月过生日的人" onclick="Button_Getshouxin_Click" />
        &nbsp;&nbsp;<a href="printcurrent.aspx" target="_blank">打印当前列表</a>

        
    </div>
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_select2" runat="server" CausesValidation="false"
                        CommandName="Select"
                        OnClientClick='<%# "window.opener.selRec(\"" + Eval("SHIZHU_ID") + "\",\""+Eval("SHIZHU_NAME")+"\",\""+Eval("SHIZHU_SEX")+"\",\""+Eval("SHIZHU_HOME_ADDR")+"\",\""+Eval("SHIZHU_HOME_ZIP")+"\",\""+Eval("SHIZHU_HOME_TEL")+"\",\""+Eval("SHIZHU_MOBILE")+"\",\""+Eval("SHIZHU_TYPE")+"\",\""+Eval("SHIZHU_EMAIL")+"\",\""+Eval("SHIZHU_BIRTHDAY")+"\",\""+Eval("SHIZHU_BIRTH_TYPE")+"\",\""+Eval("SHIZHU_LUNAR_DAY")+"\",\""+Eval("SHIZHU_TUIXIN")+"\");window.close();return false;" %>'>选择</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField DeleteText="删除" ShowDeleteButton="True" />
                <asp:BoundField DataField="SHIZHU_ID" HeaderText="编号" 
                    SortExpression="SHIZHU_ID" />
                <asp:BoundField DataField="SHIZHU_NAME" HeaderText="姓名" 
                    SortExpression="SHIZHU_NAME" />
                <asp:BoundField DataField="SHIZHU_SEX" HeaderText="性别" 
                    SortExpression="SHIZHU_SEX" />
                <asp:BoundField DataField="SHIZHU_HOME_ADDR" HeaderText="家庭住址" 
                    SortExpression="SHIZHU_HOME_ADDR" />
                <asp:BoundField DataField="SHIZHU_HOME_ZIP" HeaderText="家庭邮编" 
                    SortExpression="SHIZHU_HOME_ZIP" />
                <asp:BoundField DataField="SHIZHU_HOME_TEL" HeaderText="家庭电话" 
                    SortExpression="SHIZHU_HOME_TEL" />
                <asp:BoundField DataField="SHIZHU_MOBILE" HeaderText="手机" 
                    SortExpression="SHIZHU_MOBILE" />
                <asp:BoundField DataField="SHIZHU_TYPE" HeaderText="施主类型" 
                    SortExpression="SHIZHU_TYPE" />
                <asp:BoundField DataField="SHIZHU_EMAIL" HeaderText="电子邮件" 
                    SortExpression="SHIZHU_EMAIL" />
                <asp:BoundField DataField="SHIZHU_EDU" HeaderText="教育程度" 
                    SortExpression="SHIZHU_EDU" />
                <asp:BoundField DataField="SHIZHU_NATIONALITY" HeaderText="国籍" 
                    SortExpression="SHIZHU_NATIONALITY" />
                <asp:BoundField DataField="SHIZHU_CITY" HeaderText="省/市" 
                    SortExpression="SHIZHU_CITY" />
                <asp:BoundField DataField="SHIZHU_DISTRICT" HeaderText="区/县" 
                    SortExpression="SHIZHU_DISTRICT" />
                <asp:BoundField DataField="SHIZHU_IDCODE" HeaderText="身份证" 
                    SortExpression="SHIZHU_IDCODE" />
                <asp:BoundField DataField="SHIZHU_BIRTH_TYPE" HeaderText="生日类型" 
                    SortExpression="SHIZHU_BIRTH_TYPE" />
                <asp:BoundField DataField="BIRTH_MONTH" HeaderText="月" 
                    SortExpression="BIRTH_MONTH" />
                <asp:BoundField DataField="BIRTH_DAY" HeaderText="日" 
                    SortExpression="BIRTH_DAY" />
                <asp:BoundField DataField="SHIZHU_TUIXIN" HeaderText="退信" 
                    SortExpression="SHIZHU_TUIXIN" />
                <asp:BoundField DataField="SHIZHU_SANGUI" HeaderText="三皈" 
                    SortExpression="SHIZHU_SANGUI" />
                <asp:BoundField DataField="SHIZHU_WUJIE" HeaderText="五戒" 
                    SortExpression="SHIZHU_WUJIE" />
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
            
            
            SelectCommand="SELECT [SHIZHU_ID], [ID], [SHIZHU_NAME], [SHIZHU_SEX], [SHIZHU_HOME_ADDR], [SHIZHU_HOME_ZIP], [SHIZHU_CITY], [SHIZHU_NATIONALITY], [SHIZHU_EDU], [SHIZHU_EMAIL], [SHIZHU_TYPE], [SHIZHU_MOBILE], [SHIZHU_HOME_TEL], [SHIZHU_DISTRICT], [SHIZHU_IDCODE], [SHIZHU_BIRTHDAY], [SHIZHU_BIRTH_TYPE], [SHIZHU_LUNAR_DAY], [SHIZHU_TUIXIN], [SHIZHU_SANGUI], [SHIZHU_WUJIE], [BIRTH_DAY], [BIRTH_MONTH] FROM [SHIZHU_INFO]" 
            DeleteCommand="DELETE FROM SHIZHU_INFO WHERE ID=@ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" />
            </DeleteParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
