﻿using System;
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
            frmRole.Show();
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
    }
}