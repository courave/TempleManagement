using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TempleManagement.pub;
namespace TempleManagement.fahui
{
    public partial class FormFahuiDetail : Form
    {
        private String fahuiid="-1";
        private int spliterStatus = 0;//0:all,1:wang,2:yan
        private String wangQuery = "";
        private String yanQuery = "";
        public FormFahuiDetail(String _fahuiid)
        {
            InitializeComponent();
            fahuiid = _fahuiid;
            wangQuery = "SELECT [ID],[ZUOCI],[ZIHAO],[JIEYIN1],[JIEYIN2],[JIEYIN3],[JIEYIN4],[YANGSHANG1] " +
                ",[YANGSHANG2],[YANGSHANG3],[YANGSHANG4],[HAS_PRINT] FROM [FAHUI_WANG] WHERE [FAHUI_ID]=" + fahuiid;
            yanQuery = "SELECT [ID],[ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZUOCI],[ZIHAO],[HAS_PRINT] " +
                "FROM [FAHUI_YAN] WHERE [FAHUI_ID]=" + fahuiid;
        }
        public FormFahuiDetail(String fahuiyear, String fahuiname)
        {
            InitializeComponent();
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable("SELECT ID FROM FAHUI_LIST WHERE FAHUI_YEAR="+fahuiyear+" AND FAHUI_NAME='"+fahuiname+"'");
                if (dt.Rows.Count > 0)
                {
                    fahuiid = dt.Rows[0][0].ToString();
                    wangQuery = "SELECT [ID],[ZUOCI],[ZIHAO],[JIEYIN1],[JIEYIN2],[JIEYIN3],[JIEYIN4],[YANGSHANG1] " +
                        ",[YANGSHANG2],[YANGSHANG3],[YANGSHANG4],[HAS_PRINT] FROM [FAHUI_WANG] WHERE [FAHUI_ID]=" + fahuiid;
                    yanQuery = "SELECT [ID],[ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZUOCI],[ZIHAO],[HAS_PRINT] " +
                        "FROM [FAHUI_YAN] WHERE [FAHUI_ID]=" + fahuiid;
                }
            }
        }
        private void FormFahuiDetail_Load(object sender, EventArgs e)
        {
            if(spliterStatus==0)
                splitContainer1.SplitterDistance = this.Width / 2;
            dgvWang.AutoGenerateColumns = false;
            dgvYan.AutoGenerateColumns = false;
            LoadAll(wangQuery, yanQuery);

        }

        private void FormFahuiDetail_SizeChanged(object sender, EventArgs e)
        {
            if (spliterStatus == 0)
                splitContainer1.SplitterDistance = this.Width / 2;
        }

        private void ToolStripMenuItem_showwang_Click(object sender, EventArgs e)
        {
            spliterStatus = 1;
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = true;
        }
        private void ToolStripMenuItem_showyan_Click(object sender, EventArgs e)
        {
            spliterStatus = 2;
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
        }
        private void ToolStripMenuItem_showall_Click(object sender, EventArgs e)
        {
            spliterStatus = 0;
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = false;
        }
        private void LoadWang(String sql)
        {
            using (DataBase db = new DataBase())
            {
                dgvWang.DataSource = db.ExecuteDataTable(sql);
            }
        }
        private void LoadYan(String sql)
        {
            using (DataBase db = new DataBase())
            {
                dgvYan.DataSource = db.ExecuteDataTable(sql);
            }
        }
        private void LoadAll(String wsql,String ysql)
        {
            LoadWang(wsql);
            LoadYan(ysql);
        }

        private void ToolStripMenuItem_addwang_Click(object sender, EventArgs e)
        {
            FormAddWang frmAddWang = new FormAddWang(fahuiid,false);
            frmAddWang.ShowDialog();
            LoadAll(wangQuery, yanQuery);
        }

        private void ToolStripMenuItem_addyan_Click(object sender, EventArgs e)
        {
            FormAddYan frmAddYan = new FormAddYan(fahuiid, false);
            frmAddYan.ShowDialog();
            LoadAll(wangQuery, yanQuery);
        }

        private void ToolStripMenuItem_modify_Click(object sender, EventArgs e)
        {
            if (dgvWang.SelectedRows.Count == 1)
            {
                FormAddWang frmAddWang = new FormAddWang(false, dgvWang.SelectedRows[0].Cells["wID"].Value.ToString());
                frmAddWang.ShowDialog();
                LoadWang(wangQuery);
            }
            else if (dgvYan.SelectedRows.Count == 1)
            {
                FormAddYan frmAddYan = new FormAddYan(false, dgvYan.SelectedRows[0].Cells["yID"].Value.ToString());
                frmAddYan.ShowDialog();
                LoadYan(yanQuery);
            }
        }

        private void dgvWang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvYan.ClearSelection();
        }

        private void dgvYan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvWang.ClearSelection();
        }

        private void ToolStripMenuItem_printwangsingle_Click(object sender, EventArgs e)
        {
            print.FormPrintWangSingle frmPrintWangSingle = new print.FormPrintWangSingle(fahuiid);
            frmPrintWangSingle.ShowDialog();
        }

        private void ToolStripMenuItem_wangmultiple_Click(object sender, EventArgs e)
        {
            print.FormPrintWangMultiple frmPrintWangMultiple = new print.FormPrintWangMultiple(fahuiid);
            frmPrintWangMultiple.ShowDialog();
        }

        private void ToolStripMenuItem_del_Click(object sender, EventArgs e)
        {
            String msg = "";
            if (dgvWang.SelectedRows.Count > 0)
            {
                msg = "确定要删除这"+dgvWang.SelectedRows.Count+"条记录吗？";
                DialogResult dr = MessageBox.Show(msg, "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;
                using (DataBase db = new DataBase())
                {
                    foreach (DataGridViewRow dgvr in dgvWang.SelectedRows)
                    {
                        db.ExecuteNonQuery("DELETE FROM FAHUI_WANG WHERE ID=" + dgvr.Cells["ID"].Value.ToString());
                    }
                }
                LoadWang(wangQuery);

            }
            else if (dgvYan.SelectedRows.Count > 0)
            {
                msg = "确定要删除这" + dgvYan.SelectedRows.Count + "条记录吗？";
                DialogResult dr = MessageBox.Show(msg, "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;
                using (DataBase db = new DataBase())
                {
                    foreach (DataGridViewRow dgvr in dgvYan.SelectedRows)
                    {
                        db.ExecuteNonQuery("DELETE FROM FAHUI_YAN WHERE ID=" + dgvr.Cells["ID"].Value.ToString());
                    }
                }
                LoadYan(yanQuery);
            }
        }

        private void ToolStripMenuItem_printyansingle_Click(object sender, EventArgs e)
        {
            print.FormPrintYanSingle frmPrintYanSingle = new print.FormPrintYanSingle(fahuiid);
            frmPrintYanSingle.ShowDialog();
        }

        private void ToolStripMenuItem_printyanmultiple_Click(object sender, EventArgs e)
        {
            print.FormPrintYanMultiple frmPrintYanMultiple = new print.FormPrintYanMultiple(fahuiid);
            frmPrintYanMultiple.ShowDialog();
            
        }


    }
}
