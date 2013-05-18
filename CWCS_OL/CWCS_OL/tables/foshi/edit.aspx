<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.foshi.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>佛事记录编辑</title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        var layout = function () {
            if (document.getElementById("wang") == null)
                return;
            var hh = window.innerHeight;
            if (!hh) {
                hh = document.documentElement.clientHeight;
            }

            hh = (hh - 100) / 2;
            hh = hh + "px";
            document.getElementById("wang").style.height = hh;
            document.getElementById("yan").style.height = hh;
            document.getElementById("fashi").style.height = hh;
            document.getElementById("jiesong").style.height = hh;
        }
        window.onresize = function () {
            layout();
        }
        window.onload = function () {
            layout();
        }
        var showNewFashi = function () {
            var ahref = document.getElementById("newFashi");
            if (ahref.value == "新增") {
                document.getElementById("DropDownList_fahao").style.display = "none";
                document.getElementById("TextBox_FAHAO").style.display = "inline";
                ahref.value = "选择";
            } else {
                document.getElementById("DropDownList_fahao").style.display = "inline";
                document.getElementById("TextBox_FAHAO").style.display = "none";
                ahref.value = "新增";
            }
        }
    </script>
    <style type="text/css">
    #GridView_wang,#GridView_yan,#GridView_fashi,#GridView_jiesong 
    {
    width: 100%;
    border: 1px solid #B0B0B0;
    }
    #GridView_wang,#GridView_yan,#GridView_fashi,#GridView_jiesong tbody {
    /* Kind of irrelevant unless your .css is alreadt doing something else */
    margin: 0;
    padding: 0;
    border: 0;
    outline: 0;
    font-size: 80%;
    font-family:微软雅黑;
    vertical-align:middle;
    }
    #GridView_wang,#GridView_yan,#GridView_fashi,#GridView_jiesong th {
    border: 1px solid #B0B0B0;
    color: #444;
    font-size: 12px;
    font-weight: bold;
    text-align:center;
    padding: 3px 10px;
    }
    #GridView_wang,#GridView_yan,#GridView_fashi,#GridView_jiesong td {
    padding: 3px 10px;
    }
    #GridView_wang,#GridView_yan,#GridView_fashi,#GridView_jiesong tr {
    background: #F2F2F2;
    }
    body
    {
        font-family:微软雅黑;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        斋主姓名：<asp:TextBox ID="TextBox_ZHAIZHU_NAME" runat="server"></asp:TextBox>&nbsp;
        日期时间：<asp:TextBox ID="TextBox_FOSHI_DATETIME" runat="server"></asp:TextBox>&nbsp;
        <img onclick="WdatePicker({el:'TextBox_FOSHI_DATETIME',dateFmt:'yyyy-MM-dd HH:mm:ss'})" src="../../Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" alt="datepicker" />
        <br />
        接送地址：<asp:TextBox ID="TextBox_JIESONG_ADDR" runat="server" Width="350px"></asp:TextBox>
        <br />
        联系电话：<asp:TextBox ID="TextBox_TEL" runat="server"></asp:TextBox>&nbsp; 备注：<asp:TextBox
            ID="TextBox_COMMENT" runat="server"></asp:TextBox>&nbsp;
        <asp:Button ID="Button_save" runat="server" Text="完成(S)" OnClick="Button_save_Click"
            AccessKey="s" />
        <asp:HiddenField ID="hf_id" runat="server" />
    </div>
    <br />
    <div id="wang" style="width: 55%; border: 1px solid #000000; float: left; overflow: auto;">
        <asp:Panel ID="Panel_wang" runat="server">
            往生：<asp:Button ID="Button_add_wang" runat="server" Text="添加" OnClick="Button_add_wang_Click" />
            <asp:GridView ID="GridView_wang" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_wang"
                EnableModelValidation="True" BackColor="White" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" />
                    <asp:BoundField DataField="JZ1" HeaderText="佛光接引一" SortExpression="JZ1" />
                    <asp:BoundField DataField="JZ2" HeaderText="佛光接引二" SortExpression="JZ2" />
                    <asp:BoundField DataField="JZ3" HeaderText="佛光接引三" SortExpression="JZ3" />
                    <asp:BoundField DataField="JZ4" HeaderText="佛光接引四" SortExpression="JZ4" />
                    <asp:BoundField DataField="YS1" HeaderText="阳上一" SortExpression="YS1" />
                    <asp:BoundField DataField="YS2" HeaderText="阳上二" SortExpression="YS2" />
                    <asp:BoundField DataField="YS3" HeaderText="阳上三" SortExpression="YS3" />
                    <asp:BoundField DataField="YS4" HeaderText="阳上四" SortExpression="YS4" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource_wang" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                DeleteCommand="DELETE FROM [FOSHI_SHENG] WHERE [ID] = @ID" SelectCommand="SELECT [ID], [JZ1], [JZ2], [JZ3], [JZ4], [YS1], [YS2], [YS3], [YS4] FROM [FOSHI_SHENG] WHERE [Type]=0 AND ([FoshiID] = @FoshiID)">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="hf_id" Name="FoshiID" PropertyName="Value" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="Panel_wang_new" runat="server" Visible="False">
            添加往生：<br />
            佛光接引一：<asp:TextBox ID="TextBox_JY1" runat="server"></asp:TextBox>
            <br />
            佛光接引二：<asp:TextBox ID="TextBox_JY2" runat="server"></asp:TextBox>
            <br />
            佛光接引三：<asp:TextBox ID="TextBox_JY3" runat="server"></asp:TextBox>
            <br />
            佛光接引四：<asp:TextBox ID="TextBox_JY4" runat="server"></asp:TextBox>
            <br />
            阳上一：<asp:TextBox ID="TextBox_YS1" runat="server"></asp:TextBox>
            <br />
            阳上二：<asp:TextBox ID="TextBox_YS2" runat="server"></asp:TextBox>
            <br />
            阳上三：<asp:TextBox ID="TextBox_YS3" runat="server"></asp:TextBox>
            <br />
            阳上四：<asp:TextBox ID="TextBox_YS4" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button_save_wang" runat="server" Text="添加" OnClick="Button_save_wang_Click" />
            &nbsp;<asp:Button ID="Button_cancel_wang" runat="server" Text="取消" OnClick="Button_cancel_wang_Click" />
        </asp:Panel>
    </div>
    <div id="yan" style="width: 44%; border: 1px solid #000000; float: right; overflow: auto;">
        <asp:Panel ID="Panel_yan" runat="server">
            延生：<asp:Button ID="Button_add_yan" runat="server" Text="添加" OnClick="Button_add_yan_Click" />
            <asp:GridView ID="GridView_yan" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_yan"
                EnableModelValidation="True" BackColor="White" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" />
                    <asp:BoundField DataField="JZ1" HeaderText="佛光注照一" SortExpression="JZ1" />
                    <asp:BoundField DataField="JZ2" HeaderText="佛光注照二" SortExpression="JZ2" />
                    <asp:BoundField DataField="JZ3" HeaderText="佛光注照三" SortExpression="JZ3" />
                    <asp:BoundField DataField="JZ4" HeaderText="佛光注照四" SortExpression="JZ4" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource_yan" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                DeleteCommand="DELETE FROM [FOSHI_SHENG] WHERE [ID] = @ID" SelectCommand="SELECT [ID], [JZ1], [JZ2], [JZ3], [JZ4] FROM [FOSHI_SHENG] WHERE [Type]=1 AND ([FoshiID] = @FoshiID)">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="hf_id" Name="FoshiID" PropertyName="Value" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="Panel_yan_new" runat="server" Visible="False">
            添加延生：<br />
            佛光注照一：<asp:TextBox ID="TextBox_ZZ1" runat="server"></asp:TextBox>
            <br />
            佛光注照二：<asp:TextBox ID="TextBox_ZZ2" runat="server"></asp:TextBox>
            <br />
            佛光注照三：<asp:TextBox ID="TextBox_ZZ3" runat="server"></asp:TextBox>
            <br />
            佛光注照四：<asp:TextBox ID="TextBox_ZZ4" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button_save_yan" runat="server" Text="添加" OnClick="Button_save_yan_Click" />
            &nbsp;<asp:Button ID="Button_cancel_yan" runat="server" Text="取消" OnClick="Button_cancel_yan_Click" />
        </asp:Panel>
    </div>
    <div id="fashi" style="width: 55%; border: 1px solid #000000; float: left; overflow: auto;">
        <asp:Panel ID="Panel_fashi" runat="server">
            法师：<asp:Button ID="Button_add_fashi" runat="server" Text="添加" OnClick="Button_add_fashi_Click" />
            <asp:GridView ID="GridView_fashi" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" DataSourceID="SqlDataSource_fashi" 
                EnableModelValidation="True" BackColor="White" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                GridLines="Vertical" DataKeyNames="ID">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                        ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="FAHAO" HeaderText="法号" SortExpression="FAHAO" />
                    <asp:BoundField DataField="POSITION" HeaderText="职位" 
                        SortExpression="POSITION" />
                    <asp:BoundField DataField="DANZI" HeaderText="单资" SortExpression="DANZI" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource_fashi" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                DeleteCommand="DELETE FROM [FASHI_FOSHI] WHERE [ID] = @ID" 
                
                SelectCommand="select ID,FAHAO,DANZI,POSITION from FASHI_FOSHI WHERE FOSHI_ID= @FOSHI_ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="hf_id" Name="FOSHI_ID" PropertyName="Value" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="Panel_fashi_new" runat="server" Visible="False">
            添加法师：<br />
            
            法号：<asp:TextBox ID="TextBox_FAHAO" runat="server" style="display:none;"></asp:TextBox>
            <asp:DropDownList ID="DropDownList_fahao" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList_fahao_SelectedIndexChanged">
            </asp:DropDownList><input id="newFashi" type="button" onclick="showNewFashi();" value="新增" />
            <br />
            职位：<asp:TextBox ID="TextBox_ZHIWEI" runat="server" style="display:none;"></asp:TextBox>
            <asp:DropDownList ID="DropDownList_position" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList_position_SelectedIndexChanged">
                <asp:ListItem>磬</asp:ListItem>
                <asp:ListItem>缶</asp:ListItem>
                <asp:ListItem>木鱼</asp:ListItem>
            </asp:DropDownList>
            <br />
            单资：<asp:TextBox ID="TextBox_DANZI" runat="server"></asp:TextBox>
            <br />
            <asp:HiddenField ID="hf_FASHI_ID" runat="server" />
            <asp:Button ID="Button_save_fashi" runat="server" Text="添加" OnClick="Button_save_fashi_Click" />
            &nbsp;<asp:Button ID="Button_cancel_fashi" runat="server" OnClick="Button_cancel_fashi_Click"
                Text="取消" />
        </asp:Panel>
    </div>
    <div id="jiesong" style="width: 44%; border: 1px solid #000000; float: right; overflow: auto;">
        <asp:Panel ID="Panel_jiesong" runat="server">
            接送：<asp:Button ID="Button_add_jiesong" runat="server" Text="添加" OnClick="Button_add_jiesong_Click" />
            <asp:GridView ID="GridView_jiesong" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" DataSourceID="SqlDataSource_jiesong" EnableModelValidation="True"
                DataKeyNames="ID" BackColor="White" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False"
                        ReadOnly="True" />
                    <asp:BoundField DataField="Driver" HeaderText="司机" SortExpression="Driver" />
                    <asp:BoundField DataField="LicPlate" HeaderText="车牌号" SortExpression="LicPlate" />
                    <asp:BoundField DataField="PeopleCount" HeaderText="人数" SortExpression="PeopleCount" />
                    <asp:BoundField DataField="Cost" HeaderText="接送费用" SortExpression="Cost" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource_jiesong" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                DeleteCommand="DELETE FROM [FOSHI_JIESONG] WHERE [ID] = @ID" SelectCommand="SELECT [ID], [FoshiID], [Driver], [LicPlate], [PeopleCount], [Cost] FROM [FOSHI_JIESONG] WHERE ([FoshiID] = @FoshiID)">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="hf_id" Name="FoshiID" PropertyName="Value" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="Panel_jiesong_new" runat="server" Visible="False">
            添加接送：<br />
            司机：<asp:TextBox ID="TextBox_Driver" runat="server"></asp:TextBox>
            <br />
            车牌号：<asp:TextBox ID="TextBox_LicPlate" runat="server"></asp:TextBox>
            <br />
            人数：<asp:TextBox ID="TextBox_PeopleCount" runat="server"></asp:TextBox>
            <br />
            接送费用：<asp:TextBox ID="TextBox_Cost" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button_save_jiesong" runat="server" Text="添加" OnClick="Button_save_jiesong_Click" />
            &nbsp;<asp:Button ID="Button_cancel_jiesong" runat="server" Text="取消" OnClick="Button_cancel_jiesong_Click" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
