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
        private String queryStr = "SELECT B.FILE_DATA AVATAR,A.* FROM EMPLOYEE_INFO A LEFT OUTER JOIN FILE_MGR B ON A.AVATAR_ID=B.ID WHERE LISI_TIME IS NULL";
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
            //todo
        }
    }
}
