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
    public partial class FormUsers : Form
    {
        private string queryStr = "SELECT A.ID,USER_NAME,NICK_NAME,ROLE_NAME FROM USER_INFO A,ROLE_INFO B";
        public FormUsers()
        {
            InitializeComponent();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (pub.DataBase db = new pub.DataBase())
            {
                dgvUser.DataSource = db.ExecuteDataTable(queryStr);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            FormAddUser frmAddUser = new FormAddUser();
            frmAddUser.ShowDialog();
            LoadData();
        }

        private void button_modify_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count != 1) return;
            DataGridViewRow dgvr = dgvUser.SelectedRows[0];
            FormAddUser frmAddUser = new FormAddUser(false, dgvr.Cells["ID"].Value.ToString());
            frmAddUser.ShowDialog();
            LoadData();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count != 1) return;
            DataGridViewRow dgvr = dgvUser.SelectedRows[0];
            using (pub.DataBase db = new pub.DataBase())
            {
                db.ExecuteNonQuery("DELETE FROM USER_INFO WHERE ID=" + dgvr.Cells["ID"].Value.ToString());
                MessageBox.Show("删除成功!");
            }
            LoadData();
        }
    }
}
