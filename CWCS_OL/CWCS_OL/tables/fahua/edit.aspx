<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.fahua.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/My97DatePicker/WdatePicker.js"></script>
        <script type="text/javascript">
            function selRec(gid, gname, gsex, gaddr, gzip, gtel, gmobile, gtype, gemail, gbirthday, gbirth_type, glunar_date, gtuixin) {
                document.getElementById('TextBox_shizhubianhao').value = gid;
                document.getElementById('TextBox_name').value = gname;
                document.getElementById('TextBox_addr').value = gaddr;
                document.getElementById('TextBox_zip').value = gzip;
                document.getElementById('TextBox_tel').value = gtel;
                document.getElementById('TextBox_mobile').value = gmobile;
                //
                document.getElementById('DropDownList_isnew').value = "否";
                document.getElementById('TextBox_addr').readOnly = true;
                document.getElementById('TextBox_zip').readOnly = true;
                document.getElementById('TextBox_tel').readOnly = true;
                document.getElementById('TextBox_mobile').readOnly = true;
                document.getElementById('TextBox_addr').style.backgroundColor = 'gray';
                document.getElementById('TextBox_zip').style.backgroundColor = 'gray';
                document.getElementById('TextBox_tel').style.backgroundColor = 'gray';
                document.getElementById('TextBox_mobile').style.backgroundColor = 'gray';
                
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    法会名称：<asp:TextBox ID="TextBox_fahui_name" runat="server"></asp:TextBox>
        <br />
    编号：<asp:TextBox ID="TextBox_fahua_no" runat="server"></asp:TextBox>
        <br />
    字号：<asp:DropDownList ID="DropDownList_zihao" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
    座次：<asp:TextBox ID="TextBox_zuoci" runat="server"></asp:TextBox>
        <br />
    佛光注照一：<asp:TextBox ID="TextBox_zhuzhao1" runat="server"></asp:TextBox>
        <br />
    佛光注照二：<asp:TextBox ID="TextBox_zhuzhao2" runat="server"></asp:TextBox>
        <br />
    佛光注照三：<asp:TextBox ID="TextBox_zhuzhao3" runat="server"></asp:TextBox>
        <br />
    佛光注照四：<asp:TextBox ID="TextBox_zhuzhao4" runat="server"></asp:TextBox>
        <br />
    过期时间：<asp:TextBox ID="TextBox_expired_time" runat="server"></asp:TextBox>
    <img onclick="WdatePicker({el:'TextBox_expired_time'})" src="../../Scripts/My97DatePicker/skin/datePicker.gif" width="16" height="22" alt="datepicker" />
                <asp:Button ID="Button_Extend" runat="server" Text="延长一年" 
    onclick="Button_Extend_Click" /><br />
    登记人：<asp:TextBox ID="TextBox_log_user" runat="server" 
            BackColor="#999999" BorderStyle="None" ReadOnly="True"></asp:TextBox>
        <br />
    登记时间：<asp:TextBox ID="TextBox_log_time" runat="server" BackColor="#999999" 
            BorderStyle="None" ReadOnly="True"></asp:TextBox>
        <br />
    ------------------------------------------------------------------------------------<br />
    施主编号：<asp:TextBox ID="TextBox_shizhubianhao" runat="server" ></asp:TextBox><br />
    姓名：<asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>&nbsp;<asp:Button 
            ID="Button_find" runat="server" Text="查找" 
            onclientclick="window.open('../shizhuinfo/list.aspx?sel='+document.getElementById('TextBox_name').value,'newwindow','toolbar=no,menubar=no,location=no,status=no');return false;" />
        <br />
    是否新增：<asp:DropDownList ID="DropDownList_isnew" runat="server" 
            AutoPostBack="True" ontextchanged="DropDownList_isnew_TextChanged">
        </asp:DropDownList><br />
    家庭住址：<asp:TextBox ID="TextBox_addr" runat="server"></asp:TextBox><br />
    家庭邮编：<asp:TextBox ID="TextBox_zip" runat="server"></asp:TextBox><br />
    家庭电话：<asp:TextBox ID="TextBox_tel" runat="server"></asp:TextBox><br />
    手机：<asp:TextBox ID="TextBox_mobile" runat="server"></asp:TextBox><br />
    </div>
        <asp:Button ID="Button_save" runat="server" Text="保存(S)" 
        onclick="Button_save_Click" AccessKey="s" />
    &nbsp;&nbsp;
    <asp:Button ID="Button_cancel" runat="server" Text="取消(C)" 
        onclick="Button_cancel_Click" AccessKey="c" />
    <br />
    <asp:Button ID="Button_savenext" runat="server" AccessKey="d" 
        onclick="Button_savenext_Click" Text="保存并下一条(D)" />
    </form>
</body>
</html>
