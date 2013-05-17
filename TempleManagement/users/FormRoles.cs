using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempleManagement.users
{
    public partial class FormRoles : Form
    {
        private string queryStr = "SELECT ID,ROLE_NAME,PERMISSION FROM ROLE_INFO";
        public FormRoles()
        {
            InitializeComponent();
        }

        private void FormRoles_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (pub.DataBase db = new pub.DataBase())
            {
                dgvRole.DataSource = db.ExecuteDataTable(queryStr);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            FormAddRole frmAddRole = new FormAddRole();
            frmAddRole.ShowDialog();
            LoadData();
        }

        private void button_modify_Click(object sender, EventArgs e)
        {
            if (dgvRole.SelectedRows.Count != 1) return;
            DataGridViewRow dgvr = dgvRole.SelectedRows[0];
            FormAddRole frmAddRole = new FormAddRole(false,dgvr.Cells["ID"].Value.ToString());
            frmAddRole.ShowDialog();
            LoadData();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dgvRole.SelectedRows.Count != 1) return;
            DataGridViewRow dgvr = dgvRole.SelectedRows[0];
            using (pub.DataBase db = new pub.DataBase())
            {
                db.ExecuteNonQuery("DELETE FROM ROLE_INFO WHERE ID=" + dgvr.Cells["ID"].Value.ToString());
                MessageBox.Show("删除成功!");
            }
            LoadData();
        }
    }
}
