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
                    int avatarid = files.FileToDatabase.Upload(ofd.FileName);
                    textBox_avatarid.Text = avatarid.ToString();
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
            textBox_resumedocfileid.Text = fileid.ToString();
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
                    int frontid = files.FileToDatabase.Upload(ofd.FileName);
                    textBox_frontid.Text = frontid.ToString();
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
                    int backid = files.FileToDatabase.Upload(ofd.FileName);
                    textBox_backid.Text = backid.ToString();
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
            if (isNew)
            {
                button_preview.Enabled = false;
                button_download.Enabled = false;
                this.Text = "新增记录";
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
                    textBox_xingming.Text = dt.Rows[0][0].ToString();
                    textBox_nicheng.Text = dt.Rows[0][1].ToString();
                    comboBox_sex.Text = dt.Rows[0][2].ToString();
                    int year = 1900;
                    int month = 1;
                    int.TryParse(dt.Rows[0][3].ToString().Substring(0, 4), out year);
                    int.TryParse(dt.Rows[0][3].ToString().Substring(4),out month);
                    month %= 13;
                    dateTimePicker_birth.Value = new DateTime(year,month,1);
                    textBox_jiguan.Text = dt.Rows[0][4].ToString();
                    textBox_minzu.Text = dt.Rows[0][5].ToString();
                    comboBox_emptype.Text = dt.Rows[0][6].ToString();
                    comboBox_guomindegree.Text = dt.Rows[0][7].ToString();
                    textBox_shenfenzheng.Text = dt.Rows[0][8].ToString();
                    textBox_dianhua.Text = dt.Rows[0][9].ToString();
                    textBox_youbian.Text = dt.Rows[0][10].ToString();
                    textBox_shehuizhiwu.Text = dt.Rows[0][11].ToString();
                    textBox_xianzaizhiwu.Text = dt.Rows[0][12].ToString();
                    textBox_email.Text = dt.Rows[0][13].ToString();
                    textBox_hujisuozaidi.Text = dt.Rows[0][14].ToString();
                    dateTimePicker_join.Value = Convert.ToDateTime(dt.Rows[0][15]);
                    textBox_xingquaihao.Text = dt.Rows[0][16].ToString();
                    textBox_techang.Text = dt.Rows[0][17].ToString();
                    textBox_cengyongming.Text = dt.Rows[0][18].ToString();
                    textBox_jiaoming.Text = dt.Rows[0][19].ToString();
                    textBox_chujiasiyuan.Text = dt.Rows[0][20].ToString();
                    textBox_shoujieshi.Text = dt.Rows[0][21].ToString();
                    textBox_tidushi.Text = dt.Rows[0][22].ToString();
                    textBox_jiaoneizhiwu.Text = dt.Rows[0][23].ToString();
                    dateTimePicker_chujia.Value = Convert.ToDateTime(dt.Rows[0][24]);
                    dateTimePicker_shoujie.Value = Convert.ToDateTime(dt.Rows[0][25]);
                    textBox_jiaozhirenyuanzhengshuhao.Text = dt.Rows[0][26].ToString();
                    comboBox_zongjiaoxueli.Text = dt.Rows[0][27].ToString();
                    
                    richTextBox_jianli.Text = dt.Rows[0][28].ToString();
                    textBox_resumedocfileid.Text = dt.Rows[0][29].ToString();
                    richTextBox_shehuiguanxi.Text = dt.Rows[0][30].ToString();

                    richTextBox_jiangcheng.Text = dt.Rows[0][31].ToString();
                    richTextBox_beizhu.Text = dt.Rows[0][32].ToString();
                    textBox_resumedoc.Text = files.FileToDatabase.GetFileName(dt.Rows[0][29].ToString());
                    pictureBox_avatar.Image = files.FileToDatabase.GetImage(dt.Rows[0][33].ToString());
                    textBox_avatarid.Text = dt.Rows[0][33].ToString();
                    pictureBox_frontid.Image = files.FileToDatabase.GetImage(dt.Rows[0][34].ToString());
                    textBox_frontid.Text = dt.Rows[0][34].ToString();
                    pictureBox_backid.Image = files.FileToDatabase.GetImage(dt.Rows[0][35].ToString());
                    textBox_backid.Text = dt.Rows[0][35].ToString();
                }
            }
        }

        private bool SaveChanges()
        {
            String xingming = textBox_xingming.Text;
            String nicheng = textBox_nicheng.Text;
            String xingbie = comboBox_sex.Text;
            String birthym = dateTimePicker_birth.Value.ToString("yyyyMM");
            String jiguan = textBox_jiguan.Text;
            String minzu = textBox_minzu.Text;
            String emptype = comboBox_emptype.Text;
            String guominxueli = comboBox_guomindegree.Text;
            String shenfenzheng = textBox_shenfenzheng.Text;
            String dianhua = textBox_dianhua.Text;
            String youbian = textBox_youbian.Text;
            String shehuizhiwu = textBox_shehuizhiwu.Text;
            String xianzaizhiwu = textBox_xianzaizhiwu.Text;
            String emailaddr = textBox_email.Text;
            String hujisuozaidi = textBox_hujisuozaidi.Text;
            DateTime joindate = dateTimePicker_join.Value;
            String xingquaihao = textBox_xingquaihao.Text;
            String techang = textBox_techang.Text;
            String cengyongming = textBox_cengyongming.Text;
            String jiaoming = textBox_jiaoming.Text;
            String chujiasiyuan = textBox_chujiasiyuan.Text;
            String shoujieshi = textBox_shoujieshi.Text;
            String tidushi = textBox_tidushi.Text;
            String jiaoneizhiwu = textBox_jiaoneizhiwu.Text;
            DateTime chujiadate = dateTimePicker_chujia.Value;
            DateTime shoujiedate = dateTimePicker_shoujie.Value;
            String jiaozhizhengshu = textBox_jiaozhirenyuanzhengshuhao.Text;
            String zongjiaoxueli = comboBox_zongjiaoxueli.Text;
            String jianli = richTextBox_jianli.Text;
            String resumeid = textBox_resumedocfileid.Text;
            String shehuiguanxi = richTextBox_shehuiguanxi.Text;
            String jiangcheng = richTextBox_jiangcheng.Text;
            String beizhu = richTextBox_beizhu.Text;
            String avatarid = textBox_avatarid.Text;
            String frontid = textBox_frontid.Text;
            String backid = textBox_backid.Text;
            String sql = "";

            using (DataBase db = new DataBase())
            {
                db.AddParameter("XINGMING", xingming);
                db.AddParameter("NICHENG", nicheng);
                db.AddParameter("SEX", xingbie);
                db.AddParameter("BIRTH_YEARMONTH", birthym);
                db.AddParameter("JIGUAN", jiguan);
                db.AddParameter("MINZU", minzu);
                db.AddParameter("EMP_TYPE", emptype);
                db.AddParameter("GUOMINXUELI", guominxueli);
                db.AddParameter("SHENFENZHENG", shenfenzheng);
                db.AddParameter("DIANHUA", dianhua);
                db.AddParameter("YOUBIAN", youbian);
                db.AddParameter("SHEHUIZHIWU", shehuizhiwu);
                db.AddParameter("XIANZAIZHIWU", xianzaizhiwu);
                db.AddParameter("EMAIL", emailaddr);
                db.AddParameter("HUJISUOZAIDI", hujisuozaidi);
                db.AddParameter("JOIN_TIME", joindate);
                db.AddParameter("XINGQUAIHAO", xingquaihao);
                db.AddParameter("TECHANG", techang);
                db.AddParameter("CENGYONGMING", cengyongming);
                db.AddParameter("JIAOMING", jiaoming);
                db.AddParameter("CHUJIASIYUAN", chujiasiyuan);
                db.AddParameter("SHEOUJIESHI", shoujieshi);
                db.AddParameter("TIDUSHI", tidushi);
                db.AddParameter("JIAONEIZHIWU", jiaoneizhiwu);
                db.AddParameter("CHUJIA_TIME", chujiadate);
                db.AddParameter("SHOUJIE_TIME", shoujiedate);
                db.AddParameter("JIAOZHIZHENGSHU", jiaozhizhengshu);
                db.AddParameter("ZONGJIAOXUELI", zongjiaoxueli);
                db.AddParameter("GERENJIANLI", jianli);
                db.AddParameter("JIANLI_FILEID", resumeid);
                db.AddParameter("SHEHUIGUANXI", shehuiguanxi);
                db.AddParameter("JIANGCHENG", jiangcheng);
                db.AddParameter("BEIZHU", beizhu);
                db.AddParameter("AVATAR_ID", avatarid);
                db.AddParameter("SHENFEN_FRONT_ID", frontid);
                db.AddParameter("SHENFEN_BACK_ID", backid);
                if (isNew)
                {
                    sql = "INSERT INTO [EMPLOYEE_INFO]([XINGMING],[NICHENG],[SEX],[BIRTH_YEARMONTH],[JIGUAN] "+
                        ",[MINZU],[EMP_TYPE],[GUOMINXUELI],[SHENFENZHENG],[DIANHUA],[YOUBIAN],[SHEHUIZHIWU] " +
                        ",[XIANZAIZHIWU],[EMAIL],[HUJISUOZAIDI],[JOIN_TIME],[XINGQUAIHAO],[TECHANG] "+
                        ",[CENGYONGMING],[JIAOMING],[CHUJIASIYUAN],[SHEOUJIESHI],[TIDUSHI],[JIAONEIZHIWU] "+
                        ",[CHUJIA_TIME],[SHOUJIE_TIME],[JIAOZHIZHENGSHU],[ZONGJIAOXUELI],[GERENJIANLI] "+
                        ",[JIANLI_FILEID],[SHEHUIGUANXI],[JIANGCHENG],[BEIZHU],[AVATAR_ID],[SHENFEN_FRONT_ID] "+
                        ",[SHENFEN_BACK_ID])VALUES(@XINGMING,@NICHENG,@SEX,@BIRTH_YEARMONTH,@JIGUAN,@MINZU "+
                        ",@EMP_TYPE,@GUOMINXUELI,@SHENFENZHENG,@DIANHUA,@YOUBIAN,@SHEHUIZHIWU,@XIANZAIZHIWU "+
                        ",@EMAIL,@HUJISUOZAIDI,@JOIN_TIME,@XINGQUAIHAO,@TECHANG,@CENGYONGMING,@JIAOMING "+
                        ",@CHUJIASIYUAN,@SHEOUJIESHI,@TIDUSHI,@JIAONEIZHIWU,@CHUJIA_TIME,@SHOUJIE_TIME "+
                        ",@JIAOZHIZHENGSHU,@ZONGJIAOXUELI,@GERENJIANLI,@JIANLI_FILEID,@SHEHUIGUANXI,@JIANGCHENG "+
                        ",@BEIZHU,@AVATAR_ID,@SHENFEN_FRONT_ID,@SHENFEN_BACK_ID)";
                    if (db.ExecuteNonQuery(sql) == 1) return true;
                }
                else
                {
                    sql = "UPDATE [EMPLOYEE_INFO] SET [XINGMING] = @XINGMING,[NICHENG]=@NICHENG,[SEX]=@SEX "+
                        ",[BIRTH_YEARMONTH]=@BIRTH_YEARMONTH,[JIGUAN]=@JIGUAN,[MINZU]=@MINZU,[EMP_TYPE]=@EMP_TYPE " +
                        ",[GUOMINXUELI]=@GUOMINXUELI,[SHENFENZHENG]=@SHENFENZHENG,[DIANHUA]=@DIANHUA "+
                        ",[YOUBIAN]=@YOUBIAN,[SHEHUIZHIWU]=@SHEHUIZHIWU,[XIANZAIZHIWU]=@XIANZAIZHIWU "+
                        ",[EMAIL]=@EMAIL,[HUJISUOZAIDI]=@HUJISUOZAIDI,[JOIN_TIME]=@JOIN_TIME,[XINGQUAIHAO]=@XINGQUAIHAO "+
                        ",[TECHANG]=@TECHANG,[CENGYONGMING]=@CENGYONGMING,[JIAOMING]=@JIAOMING,[CHUJIASIYUAN]=@CHUJIASIYUAN "+
                        ",[SHEOUJIESHI]=@SHEOUJIESHI,[TIDUSHI]=@TIDUSHI,[JIAONEIZHIWU]=@JIAONEIZHIWU,[CHUJIA_TIME]=@CHUJIA_TIME "+
                        ",[SHOUJIE_TIME]=@SHOUJIE_TIME,[JIAOZHIZHENGSHU]=@JIAOZHIZHENGSHU,[ZONGJIAOXUELI]=@ZONGJIAOXUELI "+
                        ",[GERENJIANLI]=@GERENJIANLI,[JIANLI_FILEID]=@JIANLI_FILEID,[SHEHUIGUANXI]=@SHEHUIGUANXI "+
                        ",[JIANGCHENG]=@JIANGCHENG,[BEIZHU]=@BEIZHU,[AVATAR_ID]=@AVATAR_ID,[SHENFEN_FRONT_ID]=@SHENFEN_FRONT_ID "+
                        ",[SHENFEN_BACK_ID]=@SHENFEN_BACK_ID WHERE ID="+empid;
                    if (db.ExecuteNonQuery(sql) == 1) return true;
                }
            }

            return false;
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (SaveChanges())
            {
                MessageBox.Show("成功"+(isNew?"新增":"修改")+"记录");
                if (isNew)
                {
                    ClearControls();
                }
                else
                    this.Close();
            }
            else
            {
                MessageBox.Show((isNew ? "新增" : "修改") + "记录失败");
            }
        }
        private void ClearControls()
        {
            textBox_xingming.Text = "";
            textBox_nicheng.Text = "";
            comboBox_sex.SelectedItem = null;
            dateTimePicker_birth.Value = DateTime.Now;
            textBox_jiguan.Text = "";
            textBox_minzu.Text = "";
            comboBox_emptype.SelectedItem = null;
            comboBox_guomindegree.SelectedItem = null;
            textBox_shenfenzheng.Text = "";
            textBox_dianhua.Text = "";
            textBox_youbian.Text = "";
            textBox_shehuizhiwu.Text = "";
            textBox_xianzaizhiwu.Text = "";
            textBox_email.Text = "";
            textBox_hujisuozaidi.Text = "";
            dateTimePicker_join.Value = DateTime.Now;
            textBox_xingquaihao.Text = "";
            textBox_techang.Text = "";
            textBox_cengyongming.Text = "";
            textBox_jiaoming.Text = "";
            textBox_chujiasiyuan.Text = "";
            textBox_shoujieshi.Text = "";
            textBox_tidushi.Text = "";
            textBox_jiaoneizhiwu.Text = "";
            dateTimePicker_chujia.Value = DateTime.Now;
            dateTimePicker_shoujie.Value = DateTime.Now;
            textBox_jiaozhirenyuanzhengshuhao.Text = "";
            comboBox_zongjiaoxueli.SelectedItem = null;

            richTextBox_jianli.Text = "";
            textBox_resumedocfileid.Text = "";
            richTextBox_shehuiguanxi.Text = "";

            richTextBox_jiangcheng.Text = "";
            richTextBox_beizhu.Text = "";
            textBox_resumedoc.Text = "";
            pictureBox_avatar.Image = Properties.Resources.default_avatar;
            textBox_avatarid.Text = "";
            pictureBox_frontid.Image = Properties.Resources.frontid;
            textBox_frontid.Text = "";
            pictureBox_backid.Image = Properties.Resources.backid;
            textBox_backid.Text = "";

        }
    }
}
