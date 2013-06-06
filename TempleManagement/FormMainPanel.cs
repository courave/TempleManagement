using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempleManagement
{
    public partial class FormMainPanel : Form
    {
        public FormMainPanel()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem_userinfo_Click(object sender, EventArgs e)
        {
            users.FormUsers frmUser = new users.FormUsers();
            frmUser.Show();
        }

        private void ToolStripMenuItem_roleinfo_Click(object sender, EventArgs e)
        {
            users.FormRoles frmRole = new users.FormRoles();
        }

        private void ToolStripMenuItem_logout_Click(object sender, EventArgs e)
        {
            this.Dispose();
            users.FormLogin frmLogin = new users.FormLogin();
            frmLogin.Show();
        }

        private void FormMainPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormMainPanel_Load(object sender, EventArgs e)
        {
            toolStripTextBox_welcome.Text = "当前用户:"+pub.UserInfo.NickName+" "+ChinaDate.GetChinaDate(DateTime.Now);
            ListRecentFahui(5);
        }

        private void ToolStripMenuItem_employeeinfo_Click(object sender, EventArgs e)
        {
            employees.FormEmployees frmEmployees = new employees.FormEmployees();
            frmEmployees.Show();
        }

        private void ToolStripMenuItem_shizhuinfo_Click(object sender, EventArgs e)
        {
            shizhu.FormShizhu frmShizhu = new shizhu.FormShizhu();
            frmShizhu.Show();
        }

        private void ToolStripMenuItem_qingjiajiaban_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_fahuilist_Click(object sender, EventArgs e)
        {
            fahui.FormFahui frmFahui = new fahui.FormFahui();
            frmFahui.Show();
        }

        private void ToolStripMenuItem_addfahui_Click(object sender, EventArgs e)
        {
            fahui.FormAddFahui frmAddFahui = new fahui.FormAddFahui();
            frmAddFahui.Show();
        }

        private void ListRecentFahui(int top)
        {
            String sql = "SELECT TOP "+top+" CAST(FAHUI_YEAR AS NVARCHAR(4))+' '+FAHUI_NAME AS FAHUI FROM [FAHUI_LIST] ORDER BY ID DESC";
            
            using (pub.DataBase db = new pub.DataBase())
            {
                DataTable dt = db.ExecuteDataTable(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)ToolStripMenuItem_fahui.DropDownItems.Add(dr[0].ToString());
                    item.Click+=new EventHandler(RecentFahuiClickEventHandler);
                }
            }
        }
        private void RecentFahuiClickEventHandler(object sender,EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            String year = item.Text.Substring(0, 4);
            String fahuiname = item.Text.Substring(5);
            //MessageBox.Show("Year:" + year + "\nFahui:" + fahuiname);
            fahui.FormFahuiDetail frmFahuiDetail = new fahui.FormFahuiDetail(year,fahuiname);
            frmFahuiDetail.Show();
        }
    }
}
