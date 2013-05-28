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
    public partial class FormAddEmployee : Form
    {
        private Boolean isNew = true;
        private String empid = "-1";
        public FormAddEmployee():this(true,"-1"){}
        public FormAddEmployee(Boolean _isNew, String _empid)
        {
            InitializeComponent();
            isNew = _isNew;
            empid = _empid;
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

        private void textBox_resumedoc_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox_resumedoc_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePath.Count() != 1)
            {
                MessageBox.Show("只能拖动一个文件");
                return;
            }
            textBox_resumedoc.Text = filePath[0];
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "所有文件(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox_resumedoc.Text = ofd.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            if (textBox_resumedoc.Text.IndexOf('\\') <= 0) return;
            int fileid = files.FileToDatabase.Upload(textBox_resumedoc.Text);
        }

        private void button_preview_Click(object sender, EventArgs e)
        {
            int ifileid = 0;
            if (int.TryParse(textBox_resumedocfileid.Text, out ifileid))
                files.FileToDatabase.Preview(ifileid.ToString());
        }

        private void button_download_Click(object sender, EventArgs e)
        {
            int ifileid=0;
            if(int.TryParse(textBox_resumedocfileid.Text,out ifileid))
                files.FileToDatabase.Download(ifileid.ToString());
        }

        private void pictureBox_frontid_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件(*.png,*.jpg,*.gif,*.bmp)|*.png;*.jpg;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image imgFrontId = Image.FromFile(ofd.FileName);
                    pictureBox_frontid.Image = imgFrontId;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox_backid_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件(*.png,*.jpg,*.gif,*.bmp)|*.png;*.jpg;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image imgBackId = Image.FromFile(ofd.FileName);
                    pictureBox_backid.Image = imgBackId;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FormAddEmployee_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            pictureBox_avatar.Image = files.FileToDatabase.GetImage("2");
            if (isNew)
            {
                button_preview.Enabled = false;
                button_download.Enabled = false;
            }
            else
            {
                this.Text = "修改记录";
                button_confirm.Text = "确定修改";
                //load data
                String sql = "SELECT [XINGMING],[NICHENG],[SEX],[BIRTH_YEARMONTH],[JIGUAN],[MINZU],[EMP_TYPE],[GUOMINXUELI] "+
                    ",[SHENFENZHENG],[DIANHUA],[YOUBIAN],[SHEHUIZHIWU],[XIANZAIZHIWU],[EMAIL],[HUJISUOZAIDI] " +
                    ",[JOIN_TIME],[XINGQUAIHAO],[TECHANG],[CENGYONGMING],[JIAOMING],[CHUJIASIYUAN],[SHEOUJIESHI] "+
                    ",[TIDUSHI],[JIAONEIZHIWU],[CHUJIA_TIME],[SHOUJIE_TIME],[JIAOZHIZHENGSHU],[ZONGJIAOXUELI] "+
                    ",[GERENJIANLI],[JIANLI_FILEID],[SHEHUIGUANXI],[JIANGCHENG],[BEIZHU],[AVATAR_ID],[SHENFEN_FRONT_ID] "+
                    ",[SHENFEN_BACK_ID] FROM [EMPLOYEE_INFO] WHERE [ID]="+empid;
                using (DataBase db = new DataBase())
                {
                    DataTable dt = db.ExecuteDataTable(sql);
                    if (dt.Rows.Count != 1) return;
                    //pictureBox_avatar.Image = files.FileToDatabase.GetImage(dt.Rows[0][33].ToString());
                    
                }
            }
        }
    }
}
