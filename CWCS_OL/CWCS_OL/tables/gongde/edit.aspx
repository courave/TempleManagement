<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.gongde.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/calendar/lang/zh-cn.js"></script>
<link rel="stylesheet" type="text/css" href="../../Scripts/calendar/skin/WdatePicker.css" />

    <script type="text/javascript" src="../../Scripts/calendar/WdatePicker.js"></script>
    <script type="text/javascript">
        function selRec(gid, gname, gsex, gaddr, gzip, gtel, gmobile, gtype, gemail, gbirthday, gbirth_type, glunar_date, gtuixin) {
            document.getElementById('TextBox_id').value = gid;
            document.getElementById('TextBox_name').value = gname;
            document.getElementById('Label_sex').innerHTML = gsex;
            document.getElementById('Label_addr').innerHTML = gaddr;
            document.getElementById('Label_zip').innerHTML = gzip;
            document.getElementById('Label_tel').innerHTML = gtel;
            document.getElementById('Label_mobile').innerHTML = gmobile;
            document.getElementById('Label_type').innerHTML = gtype;
            document.getElementById('Label_email').innerHTML = gemail;
            document.getElementById('Label_birthday').innerHTML = gbirthday;
            document.getElementById('Label_birth_type').innerHTML = gbirth_type;
            document.getElementById('Label_lunar_date').innerHTML = glunar_date;
            document.getElementById('Label_tuixin').innerHTML = gtuixin;
            document.getElementById('TextBox_id').readOnly = true;
            document.getElementById('TextBox_name').readOnly = true;
            document.getElementById('Button_get').style.display = "none";
            document.getElementById('Button_find').style.display = "none";
            document.getElementById('Button_save').disabled = false;
            document.getElementById('Button_savenext').disabled = false;
        }
        function selFangwei(fangwei, row, col) {
            document.getElementById("TextBox_fangwei").value = fangwei;
            document.getElementById("TextBox_row").value = row;
            document.getElementById("TextBox_col").value = col;
            document.getElementById("fangwei_info").value = fangwei + " " + row + "," + col;

        }
        function newSelector() {
            window.open('selector.aspx?type=' + document.getElementById('DropDownList_type').value, 'newwindow', 'toolbar=no,menubar=no,location=no,status=no,scrollbars=yes');
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <iframe src="about:blank" style="display:none;" id="getf" name="getf" ></iframe>
    施主编号：<asp:TextBox ID="TextBox_id" runat="server"></asp:TextBox>&nbsp;<asp:Button 
            ID="Button_get" runat="server" Text="获取信息" onclientclick="window.open('../shizhuinfo/detail.aspx?getId='+document.getElementById('TextBox_id').value,'getf');return false;"/>
        <br />
    姓名：<asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>&nbsp;<asp:Button 
            ID="Button_find" runat="server" Text="查找" onclientclick="window.open('../shizhuinfo/list.aspx?sel='+document.getElementById('TextBox_name').value,'newwindow','toolbar=no,menubar=no,location=no,status=no');return false;" />
        <br />
    性别：<asp:Label ID="Label_sex" runat="server"></asp:Label><br />
        <br />
    家庭住址：<asp:Label ID="Label_addr" runat="server"></asp:Label><br />
    家庭邮编：<asp:Label ID="Label_zip" runat="server"></asp:Label><br />
    家庭电话：<asp:Label ID="Label_tel" runat="server"></asp:Label><br />
    手机：<asp:Label ID="Label_mobile" runat="server"></asp:Label><br />
    施主类型：<asp:Label ID="Label_type" runat="server"></asp:Label><br />
    电子邮件：<asp:Label ID="Label_email" runat="server"></asp:Label><br />
    出生日期：<asp:Label ID="Label_birthday" runat="server"></asp:Label><br />
    日期类型：<asp:Label ID="Label_birth_type" runat="server"></asp:Label><br />
    农历日期：<asp:Label ID="Label_lunar_date" runat="server"></asp:Label><br />
    退信：<asp:Label ID="Label_tuixin" runat="server"></asp:Label><br />

    捐赠编号：<asp:TextBox ID="TextBox_donate_no" runat="server"></asp:TextBox><br />
    捐赠类别：<asp:DropDownList ID="DropDownList_type" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
    <div id="fangwei">
    <input type='text' id='fangwei_info' name='fangwei_info' onclick='newSelector();' value='<%=strFangwei %>'/>
    <input type="button" id="fangwei_select" name="fangwei_select" onclick="newSelector();" value="选择位置信息" />
    </div><br />
        <asp:TextBox ID="TextBox_fangwei" runat="server" style="display:none;"></asp:TextBox>
        <asp:TextBox ID="TextBox_row" runat="server" style="display:none;"></asp:TextBox>
        <asp:TextBox ID="TextBox_col" runat="server" style="display:none;"></asp:TextBox>
    捐赠金额：<asp:TextBox ID="TextBox_donate_money" runat="server"></asp:TextBox><br />
    发票号码：<asp:TextBox ID="TextBox_invoice_no" runat="server"></asp:TextBox><br />
    捐赠日期：<asp:TextBox ID="TextBox_donate_date" runat="server"></asp:TextBox><br />
    经办人：<asp:TextBox ID="TextBox_log_user" runat="server" 
            BackColor="#999999" ReadOnly="True"></asp:TextBox><br />
    经办日期：<asp:TextBox ID="TextBox_log_time" runat="server" BackColor="#999999" 
            ReadOnly="True"></asp:TextBox><br />
    功德芳名：<asp:TextBox ID="TextBox_gongde_fangming" runat="server"></asp:TextBox><br />
    捐赠说明：<asp:TextBox ID="TextBox_donate_description" runat="server"></asp:TextBox><br />
    备注：<asp:TextBox ID="TextBox_donate_comments" runat="server" 
            Height="46px" TextMode="MultiLine" Width="100%"></asp:TextBox><br />
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
