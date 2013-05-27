using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempleManagement.employees
{
    public partial class FormAddEmployee : Form
    {
        public FormAddEmployee()
        {
            InitializeComponent();
        }

        private void pictureBox_avatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件(*.png,*.jpg,*.gif,*.bmp)|*.png;*.jpg;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image imgAvatar = Image.FromFile(ofd.FileName);
                    pictureBox_avatar.Image = imgAvatar;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
