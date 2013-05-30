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
            ",[NONGLI_BIRTH],[GONGLI_BIRTH],[TUIXIN],[SANGUI],[WUJIE] FROM [SHIZHU_INFO] ";
        public FormShizhu()
        {
            InitializeComponent();
            
        }

        private void FormShizhu_Load(object sender, EventArgs e)
        {
            dgvShizhu.AutoGenerateColumns = false;
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
    }
}
