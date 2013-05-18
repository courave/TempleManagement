<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="CWCS_OL.tables.filemgr.edit" validateRequest=false %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%-- Register the FlashUpload control so we can use it below --%>
<%@ Register Assembly="FlashUpload" Namespace="FlashUpload" TagPrefix="FlashUpload" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../Scripts/list.css" type="text/css" />
    <script type="text/javascript">
        function uploadf(fn, noc) {
            document.getElementById("TextBox_upload").value += fn + "\n";
            if (noc)
                document.getElementById("Button_cancel").disabled = true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        档案编号：<asp:TextBox ID="TextBox_FileNo" runat="server"></asp:TextBox>
        <br />
        档案标题：<asp:TextBox ID="TextBox_FileTitle" runat="server"></asp:TextBox>
        <br />
        录入人：<asp:Label ID="Label_LogUser" runat="server"></asp:Label>
        <br />
        录入时间：<asp:Label ID="Label_LogTime" runat="server"></asp:Label>
        <br />
        文件列表：<asp:GridView 
            ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="SqlDataSource1" EnableModelValidation="True" 
            EmptyDataText="没有文件">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:TemplateField HeaderText="文件名" SortExpression="FileName">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink_download" runat="server" 
                            NavigateUrl='<%# "file.aspx?id="+Eval("ID") %>' Text='<%# Eval("FileName") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FileName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [ID], [FileName] FROM [File] WHERE ([MgrId] = @MgrId)"
            DeleteCommand="DELETE FROM [File] WHERE [ID] = @ID">
            <SelectParameters>
                <asp:QueryStringParameter Name="MgrId" QueryStringField="id" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource><br />
        <FlashUpload:FlashUpload ID="flashUpload" runat="server" 
            UploadPage="Upload.axd"
            FileTypeDescription="All Files" FileTypes="*.*" 
            UploadFileSizeLimit="0" TotalUploadSizeLimit="0" />
        <br />

        信息：<br />
        <FCKeditorV2:FCKeditor ID="FCKeditor_info" runat="server">
        </FCKeditorV2:FCKeditor>
       <br />
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
