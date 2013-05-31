using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TempleManagement.pub;
namespace TempleManagement.shizhu
{
    public partial class FormShizhu : Form
    {
        private String queryStr = "SELECT [ID],[BIANHAO],[XINGMING],[XINGBIE],[HOME_ADDR],[ZIPCODE],[TELE],[MOBILE] "+
            ",[SHIZHU_TYPE],[EMAIL],[EDU_BKG],[GUOJI],[SHENGSHI],[QUXIAN],[SHENFENZHENG],[BIRTH_TYPE] " +
            ",[NONGLI_BIRTH],[GONGLI_BIRTH],[TUIXIN],[SANGUI],[WUJIE] FROM [SHIZHU_INFO] WHERE 1=1 ";
        public FormShizhu()
        {
            InitializeComponent();
            
        }

        private void FormShizhu_Load(object sender, EventArgs e)
        {
            dgvShizhu.AutoGenerateColumns = false;
            InitData();
            LoadData();
        }
        private void LoadData(String sql)
        {
            using (DataBase db = new DataBase())
            {
                dgvShizhu.DataSource = db.ExecuteDataTable(sql);
            }
        }
        private void LoadData()
        {
            LoadData(queryStr);
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            FormAddShizhu frmAddShizhu = new FormAddShizhu();
            frmAddShizhu.ShowDialog();
            LoadData();
        }

        private void ToolStripMenuItem_modify_Click(object sender, EventArgs e)
        {
            if (dgvShizhu.SelectedRows.Count != 1) return;
            FormAddShizhu frmAddShizhu = new FormAddShizhu(false,dgvShizhu.SelectedRows[0].Cells["ID"].Value.ToString());
            frmAddShizhu.ShowDialog();
            LoadData();
        }

        private void ToolStripMenuItem_delete_Click(object sender, EventArgs e)
        {
            if (dgvShizhu.SelectedRows.Count == 0) return;
            if (DialogResult.Yes == MessageBox.Show("确定要将这" + dgvShizhu.SelectedRows.Count + "条记录删除吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                using (DataBase db = new DataBase())
                {
                    foreach (DataGridViewRow dgvr in dgvShizhu.SelectedRows)
                    {
                        db.ExecuteNonQuery("DELETE FROM SHIZHU_INFO WHERE ID="+dgvr.Cells["ID"].Value.ToString());
                    }
                }
                LoadData();
            }
        }

        private void ToolStripMenuItem_shownong_Click(object sender, EventArgs e)
        {
            queryStr = "SELECT [ID],[BIANHAO],[XINGMING],[XINGBIE],[HOME_ADDR],[ZIPCODE],[TELE],[MOBILE] " +
                ",[SHIZHU_TYPE],[EMAIL],[EDU_BKG],[GUOJI],[SHENGSHI],[QUXIAN],[SHENFENZHENG],[BIRTH_TYPE] " +
                ",[NONGLI_BIRTH],[GONGLI_BIRTH],[TUIXIN],[SANGUI],[WUJIE] FROM [SHIZHU_INFO] WHERE BIRTH_TYPE='农历' ";
            LoadData();
        }

        private void ToolStripMenuItem_showgong_Click(object sender, EventArgs e)
        {
            queryStr = "SELECT [ID],[BIANHAO],[XINGMING],[XINGBIE],[HOME_ADDR],[ZIPCODE],[TELE],[MOBILE] " +
                ",[SHIZHU_TYPE],[EMAIL],[EDU_BKG],[GUOJI],[SHENGSHI],[QUXIAN],[SHENFENZHENG],[BIRTH_TYPE] " +
                ",[NONGLI_BIRTH],[GONGLI_BIRTH],[TUIXIN],[SANGUI],[WUJIE] FROM [SHIZHU_INFO] WHERE BIRTH_TYPE='公历' ";
            LoadData();
        }

        private void ToolStripMenuItem_hasshengri_Click(object sender, EventArgs e)
        {
            queryStr = "SELECT [ID],[BIANHAO],[XINGMING],[XINGBIE],[HOME_ADDR],[ZIPCODE],[TELE],[MOBILE] " +
                ",[SHIZHU_TYPE],[EMAIL],[EDU_BKG],[GUOJI],[SHENGSHI],[QUXIAN],[SHENFENZHENG],[BIRTH_TYPE] " +
                ",[NONGLI_BIRTH],[GONGLI_BIRTH],[TUIXIN],[SANGUI],[WUJIE] FROM [SHIZHU_INFO] WHERE (BIRTH_TYPE IS NULL OR BIRTH_TYPE='') ";
            LoadData();
        }

        private void ToolStripMenuItem_reset_Click(object sender, EventArgs e)
        {
            toolStripTextBox_bianhao.Text = "";
            toolStripTextBox_xingming.Text = "";
            toolStripTextBox_shenfenzheng.Text = "";
            toolStripTextBox_guoji.Text = "";
            toolStripTextBox_shengshi.Text = "";
            toolStripTextBox_quxian.Text = "";
            toolStripTextBox_zhuzhi.Text = "";
            toolStripComboBox_tuixin.SelectedItem = null;
            toolStripComboBox_gongmonth.SelectedItem = null;
            toolStripComboBox_nongmonth.SelectedItem = null;

        }

        private void InitData()
        {
            String[] gongmonth = {"一月","二月","三月","四月","五月","六月","七月","八月","九月","十月","十一月","十二月" };
            String[] nongmonth = {"正月","二月","三月","四月","五月","六月","七月","八月","九月","十月","冬月","腊月" };
            int i = 0;
            for (i = 0; i < 12; i++)
            {
                toolStripComboBox_gongmonth.Items.Add(new ComboItem(i + 1, gongmonth[i]));
                toolStripComboBox_nongmonth.Items.Add(new ComboItem(i + 1, nongmonth[i]));
            }
        }

        private void SearchAction()
        {
            StringBuilder s = new StringBuilder(queryStr);
            if (toolStripTextBox_bianhao.Text != "")
            {
                s.Append(" AND BIANHAO LIKE '%" + toolStripTextBox_bianhao.Text + "%' ");
            }
            if (toolStripTextBox_xingming.Text != "")
            {
                s.Append(" AND XINGMING LIKE '%"+toolStripTextBox_xingming.Text+"%' ");
            }
            if (toolStripTextBox_shenfenzheng.Text != "")
            {
                s.Append(" AND SHENFENZHENG LIKE '%"+toolStripTextBox_shenfenzheng.Text+"%' ");
            }
            if (toolStripTextBox_guoji.Text != "")
            {
                s.Append(" AND GUOJI LIKE '%" + toolStripTextBox_guoji.Text + "%' ");
            }
            if (toolStripTextBox_shengshi.Text != "")
            {
                s.Append(" AND SHENGSHI LIKE '%" + toolStripTextBox_shengshi.Text + "%' ");
            }
            if (toolStripTextBox_quxian.Text != "")
            {
                s.Append(" AND QUXIAN LIKE '%" + toolStripTextBox_quxian.Text + "%' ");
            }
            if (toolStripTextBox_zhuzhi.Text != "")
            {
                s.Append(" AND HOME_ADDR LIKE '%" + toolStripTextBox_zhuzhi.Text + "%' ");
            }
            if (toolStripComboBox_tuixin.SelectedItem != null)
            {
                s.Append(" AND TUIXIN ='"+toolStripComboBox_tuixin.SelectedItem.ToString()+"' ");
            }
            if (toolStripComboBox_gongmonth.SelectedItem != null)
            {
                s.Append(" AND BIRTH_TYPE='公历' AND MONTH(GONGLI_BIRTH) =" + ((ComboItem)toolStripComboBox_gongmonth.SelectedItem).Key + " ");
            }
            if (toolStripComboBox_nongmonth.SelectedItem != null)
            {
                int nongmonth = (int)((ComboItem)toolStripComboBox_nongmonth.SelectedItem).Key;
                String nm = (nongmonth<10?"0"+nongmonth:nongmonth.ToString());
                s.Append(" AND BIRTH_TYPE='农历' AND NONGLI_BIRTH LIKE '%-" + nm + "-%' ");
            }
            LoadData(s.ToString());
        }
    }
}
