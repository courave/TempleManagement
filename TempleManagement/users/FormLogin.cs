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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "" || textBox_password.Text == "")
            {
                MessageBox.Show("用户名密码不能为空!");
                return;
            }
            if (pub.UserInfo.checkIfExist(textBox_username.Text, textBox_password.Text))
            {
                //
                this.Hide();
                FormMainPanel frmMain = new FormMainPanel();
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("密码错误!");
                return;

            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
