using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TempleManagement.pub;

namespace TempleManagement.employees
{
    public partial class FormEmployees : Form
    {
        private String queryStr = "SELECT B.FILE_DATA AVATAR,A.* FROM EMPLOYEE_INFO A LEFT OUTER JOIN FILE_MGR B ON A.AVATAR_ID=B.ID WHERE LISI_TIME IS NULL ";
        public FormEmployees()
        {
            InitializeComponent();
        }

        private void FormEmployees_Load(object sender, EventArgs e)
        {
            dgvEmployee.AutoGenerateColumns = false;
            LoadData();
        }
        private void LoadData()
        {
            //init combobox
            toolStripComboBox_emptype.Items.Clear();
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT DISTINCT EMP_TYPE FROM EMPLOYEE_INFO");
                foreach (DataRow dr in dt.Rows)
                {
                    toolStripComboBox_emptype.Items.Add(dr[0].ToString());
                }
            }
            LoadData(queryStr);
        }
        private void LoadData(String sql)
        {
            using (DataBase db = new DataBase())
            {
                dgvEmployee.DataSource = db.ExecuteDataTable(sql);
            }
        }

        private void ToolStripMenuItem_addrecord_Click(object sender, EventArgs e)
        {
            FormAddEmployee frmAddEmp = new FormAddEmployee();
            frmAddEmp.ShowDialog();
            LoadData();
        }

        private void ToolStripMenuItem_modifyrecord_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count != 1) return;

            FormAddEmployee frmAddEmp = new FormAddEmployee(false, dgvEmployee.SelectedRows[0].Cells["ID"].Value.ToString());
            frmAddEmp.ShowDialog();
            LoadData();

        }

        private void ToolStripMenuItem_deleterecord_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count < 1) return;
            if (!(DialogResult.Yes == MessageBox.Show("确定要删除这" + dgvEmployee.SelectedRows.Count + "条记录吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                return;
            String sql = "DELETE FROM EMPLOYEE_INFO WHERE ID=@ID";
            using (DataBase db = new DataBase())
            {
                foreach (DataGridViewRow dgvr in dgvEmployee.SelectedRows)
                {
                    db.AddParameter("ID", dgvr.Cells["ID"].Value);
                    db.ExecuteNonQuery(sql);
                }
            }
            LoadData();
        }

        private void ToolStripMenuItem_lisicheck_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count != 1) return;
            if (!(DialogResult.Yes == MessageBox.Show("确定要登记 " + dgvEmployee.SelectedRows[0].Cells["XINGMING"].Value.ToString() + " 离寺吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                return;

            using (DataBase db = new DataBase())
            {
                db.AddParameter("ID", dgvEmployee.SelectedRows[0].Cells["ID"].Value);
                db.ExecuteNonQuery("UPDATE EMPLOYEE_INFO SET LISI_TIME=GETDATE() WHERE ID=@ID");
            }
            LoadData();
        }

        private void SearchAction()
        {
            StringBuilder s = new StringBuilder(queryStr);
            if (toolStripTextBox_xingming.Text != "")
            {
                s.Append(" AND XINGMING LIKE '%" + toolStripTextBox_xingming.Text + "%' ");
            }
            if (toolStripTextBox_jiaoming.Text != "")
            {
                s.Append(" AND JIAOMING LIKE '%" + toolStripTextBox_jiaoming.Text + "%' ");
            }
            if (toolStripComboBox_emptype.SelectedItem != null)
            {
                s.Append(" AND EMP_TYPE='" + toolStripComboBox_emptype.SelectedItem.ToString()+ "' ");
            }
            if (toolStripTextBox_rusidate.Text.Length > 8)
            {
                s.Append(GetTimeSearchCondition(toolStripTextBox_rusidate, "JOIN_TIME"));
            }
            if (toolStripTextBox_shoujiedate.Text.Length > 8)
            {
                s.Append(GetTimeSearchCondition(toolStripTextBox_shoujiedate, "SHOUJIE_TIME"));
            }
            if (toolStripTextBox_chujiadate.Text.Length > 8)
            {
                s.Append(GetTimeSearchCondition(toolStripTextBox_chujiadate, "CHUJIA_TIME"));
            }
            if (toolStripTextBox_lisidate.Text.Length > 8)
            {
                s.Append(GetTimeSearchCondition(toolStripTextBox_lisidate, "LISI_TIME"));
            }
            if (toolStripTextBox_general.Text.Trim() != "")
            {
                s.Append(GetGeneralSearchCondition(toolStripTextBox_general.Text.Trim()));
            }
            LoadData(s.ToString());
        }

        private String GetTimeSearchCondition(ToolStripTextBox textBox,String field)
        {
            if (textBox.Text.Length > 8)
            {
                String condition = "";
                String key = textBox.Text;
                int year = 1900;
                int month = 1;
                int day = 1;
                DateTime tmpdate = DateTime.Now;
                if (key.StartsWith(">"))
                {
                    key = key.Remove(0, 1);
                    if (key.StartsWith("=") && key.Length == 9)//>=
                    {
                        key = key.Remove(0, 1);
                        if(int.TryParse(key.Substring(0,4),out year) &&
                           int.TryParse(key.Substring(4,2),out month) &&
                           int.TryParse(key.Substring(6, 2), out day))
                        {
                            tmpdate = new DateTime(year, month, day);
                            condition = " AND "+field + ">='"+tmpdate.ToString("yyyy-MM-dd")+" 00:00:00' ";
                        }
                    }
                    else if (key.Length == 8)//>
                    {
                        if (int.TryParse(key.Substring(0, 4), out year) &&
                               int.TryParse(key.Substring(4, 2), out month) &&
                               int.TryParse(key.Substring(6, 2), out day))
                        {
                            tmpdate = new DateTime(year, month, day);
                            condition = " AND " + field + ">'" + tmpdate.ToString("yyyy-MM-dd") + " 00:00:00' ";
                        }
                    }
                }
                else if (key.StartsWith("<"))
                {
                    key = key.Remove(0, 1);
                    if (key.StartsWith("=") && key.Length == 9)
                    {
                        key = key.Remove(0, 1);
                        if (int.TryParse(key.Substring(0, 4), out year) &&
                           int.TryParse(key.Substring(4, 2), out month) &&
                           int.TryParse(key.Substring(6, 2), out day))
                        {
                            tmpdate = new DateTime(year, month, day);
                            condition = " AND " + field + "<='" + tmpdate.ToString("yyyy-MM-dd") + " 23:59:59' ";
                        }
                    }
                    else if (key.Length == 8)
                    {
                        if (int.TryParse(key.Substring(0, 4), out year) &&
                           int.TryParse(key.Substring(4, 2), out month) &&
                           int.TryParse(key.Substring(6, 2), out day))
                        {
                            tmpdate = new DateTime(year, month, day);
                            condition = " AND " + field + "<'" + tmpdate.ToString("yyyy-MM-dd") + " 23:59:59' ";
                        }
                    }
                }
                else if (key.StartsWith("="))
                {
                    key = key.Remove(0, 1);
                    if (int.TryParse(key.Substring(0, 4), out year) &&
                       int.TryParse(key.Substring(4, 2), out month) &&
                       int.TryParse(key.Substring(6, 2), out day))
                    {
                        condition = " AND YEAR(" + field + ")=" + year + " AND MONTH(" + field + ")=" + month + " AND DAY(" + field + ")=" + day;
                    }
                }
                return condition;
            }
            return "";
            
        }
        private String GetGeneralSearchCondition(String key)
        {
            String[] fields = {"XINGMING","NICHENG","SEX","BIRTH_YEARMONTH","JIGUAN","MINZU","EMP_TYPE"
                            ,"GUOMINXUELI","SHENFENZHENG","DIANHUA","YOUBIAN","SHEHUIZHIWU","XIANZAIZHIWU"
                            ,"EMAIL","HUJISUOZAIDI","XINGQUAIHAO","TECHANG","CENGYONGMING","JIAOMING"
                            ,"CHUJIASIYUAN","SHEOUJIESHI","TIDUSHI","JIAONEIZHIWU","JIAOZHIZHENGSHU"
                            ,"ZONGJIAOXUELI","GERENJIANLI","SHEHUIGUANXI","JIANGCHENG","BEIZHU" };
            String condition = " AND (1=2 ";
            foreach (String field in fields)
            {
                condition += " OR " + field + " LIKE '%" + key + "%' ";
            }
            condition += ")";
            return condition;
        }

        private void ToolStripMenuItem_showlisi_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItem_showlisi.Text == "显示已离寺人员")
            {
                ToolStripMenuItem_showlisi.Text = "显示在职人员";
                queryStr = "SELECT B.FILE_DATA AVATAR,A.* FROM EMPLOYEE_INFO A LEFT OUTER JOIN FILE_MGR B ON A.AVATAR_ID=B.ID WHERE LISI_TIME IS NOT NULL ";
            }
            else
            {
                ToolStripMenuItem_showlisi.Text = "显示已离寺人员";
                queryStr = "SELECT B.FILE_DATA AVATAR,A.* FROM EMPLOYEE_INFO A LEFT OUTER JOIN FILE_MGR B ON A.AVATAR_ID=B.ID WHERE LISI_TIME IS NULL ";
            }
            LoadData();
        }

        private void ToolStripMenuItem_reset_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_showlisi.Text = "显示已离寺人员";
            toolStripTextBox_xingming.Text = "";
            toolStripTextBox_jiaoming.Text = "";
            toolStripTextBox_rusidate.Text = "";
            toolStripTextBox_chujiadate.Text = "";
            toolStripTextBox_shoujiedate.Text = "";
            toolStripTextBox_lisidate.Text = "";
            toolStripComboBox_emptype.SelectedItem = null;
            toolStripTextBox_general.Text = "";

            queryStr = "SELECT B.FILE_DATA AVATAR,A.* FROM EMPLOYEE_INFO A LEFT OUTER JOIN FILE_MGR B ON A.AVATAR_ID=B.ID WHERE LISI_TIME IS NULL ";
            LoadData();
        }

        private void toolStripTextBox_xingming_TextChanged(object sender, EventArgs e)
        {
            SearchAction();
        }

        private void toolStripTextBox_jiaoming_TextChanged(object sender, EventArgs e)
        {
            SearchAction();
        }

        private void toolStripComboBox_emptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAction();
        }

        private void toolStripTextBox_rusidate_TextChanged(object sender, EventArgs e)
        {
            SearchAction();
        }

        private void toolStripTextBox_chujiadate_TextChanged(object sender, EventArgs e)
        {
            SearchAction();
        }

        private void ToolStripMenuItem_shoujiedate_TextChanged(object sender, EventArgs e)
        {
            SearchAction();
        }

        private void ToolStripMenuItem_lisidate_TextChanged(object sender, EventArgs e)
        {
            SearchAction();
        }

        private void toolStripTextBox_general_TextChanged(object sender, EventArgs e)
        {
            SearchAction();
        }
    }
}
