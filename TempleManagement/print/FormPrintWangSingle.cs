using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempleManagement.print
{
    public partial class FormPrintWangSingle : Form
    {
        private String sql = "";
        private DataTable PrintDt=new DataTable();
        public FormPrintWangSingle(String _fahuiid):this(_fahuiid,true){}
        public FormPrintWangSingle(String _fahuiid, Boolean _printall)
        {
            InitializeComponent();
            sql = "SELECT [ZUOCI],[ZIHAO],[JIEYIN1],[JIEYIN2],[JIEYIN3],[JIEYIN4],[YANGSHANG1],[YANGSHANG2],[YANGSHANG3],[YANGSHANG4] FROM [FAHUI_WANG] WHERE FAHUI_ID="+_fahuiid;
            if (!_printall)
                sql += " AND HAS_PRINT<>1";
            using (pub.DataBase db = new pub.DataBase())
            {
                PrintDt = db.ExecuteDataTable(sql);
            }
        }
        public FormPrintWangSingle(DataTable _PrintDt)
        {
            InitializeComponent();
            PrintDt = _PrintDt;
        }

        private void FormPrintWangSingle_Load(object sender, EventArgs e)
        {
            PrintTable(PrintDt);
        }
        private void PrintTable(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有需要打印的记录!");
                Dispose();
                return;
            }
            CrystalReport_wangsingle reportWangSingle = new CrystalReport_wangsingle();
            List<ClassWangSingle> printList = new List<ClassWangSingle>();
            foreach (DataRow dr in dt.Rows)
            {
                ClassWangSingle wangSingle = new ClassWangSingle();
                String jieyin = "";
                String ys = "";
                wangSingle.zihao = dr["ZIHAO"].ToString();
                wangSingle.zuoci = dr["ZUOCI"].ToString();
                if (dr["JIEYIN1"].ToString() != "")
                    jieyin = dr["JIEYIN1"].ToString();
                if (dr["JIEYIN2"].ToString() != "")
                    jieyin +=";"+ dr["JIEYIN2"].ToString();
                if (dr["JIEYIN3"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN3"].ToString();
                if (dr["JIEYIN4"].ToString() != "")
                    jieyin += ";" + dr["JIEYIN4"].ToString();
                if (dr["YANGSHANG1"].ToString() != "")
                    ys = dr["YANGSHANG1"].ToString();
                if (dr["YANGSHANG2"].ToString() != "")
                    ys += ";" + dr["YANGSHANG2"].ToString();
                if (dr["YANGSHANG3"].ToString() != "")
                    ys += ";" + dr["YANGSHANG3"].ToString();
                if (dr["YANGSHANG4"].ToString() != "")
                    ys += ";" + dr["YANGSHANG4"].ToString();
                String[] jieyins = jieyin.Split(';');
                if (jieyins.Count() > 0)
                {
                    wangSingle.jieyin3 = jieyins[0].Trim(';');
                }
                if (jieyins.Count() > 1)
                {
                    wangSingle.jieyin2 = jieyins[1].Trim(';');
                }
                if (jieyins.Count() > 2)
                {
                    wangSingle.jieyin4 = jieyins[2].Trim(';');
                }
                if (jieyins.Count() > 3)
                {
                    wangSingle.jieyin1 = jieyins[3].Trim(';');
                }
                String[] yss = ys.Split(';');
                if (yss.Count() > 0)
                {
                    wangSingle.ys1 = yss[0].Trim(';');
                }
                if (yss.Count() > 1)
                {
                    wangSingle.ys2 = yss[1].Trim(';');
                }
                if (yss.Count() > 2)
                {
                    wangSingle.ys3 = yss[2].Trim(';');
                }
                if (yss.Count() > 3)
                {
                    wangSingle.ys4 = yss[3].Trim(';');
                }
                printList.Add(wangSingle);
            }
            reportWangSingle.SetDataSource(printList);
            crystalReportViewer_wangsingle.ReportSource = reportWangSingle;
        }
    }
}
