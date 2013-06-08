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
    public partial class FormPrintYanSingle : Form
    {
        private String sql = "";
        private DataTable PrintDt = new DataTable();
        public FormPrintYanSingle(String _fahuiid):this(_fahuiid,true){}
        public FormPrintYanSingle(String _fahuiid,Boolean _printall)
        {
            InitializeComponent();
            sql = "SELECT [ZHUZHAO1],[ZHUZHAO2],[ZHUZHAO3],[ZHUZHAO4],[ZUOCI],[ZIHAO] FROM [FAHUI_YAN] WHERE FAHUI_ID="+_fahuiid;
            if (!_printall)
                sql += " AND HAS_PRINT<>1";
            using (pub.DataBase db = new pub.DataBase())
            {
                PrintDt = db.ExecuteDataTable(sql);
            }
        }
        private FormPrintYanSingle(DataTable _PrintDt)
        {
            InitializeComponent();
            PrintDt = _PrintDt;
        }
        private void FormPrintYanSingle_Load(object sender, EventArgs e)
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
            CrystalReport_yansingle reportYanSingle = new CrystalReport_yansingle();
            List<ClassYanSingle> printList = new List<ClassYanSingle>();
            foreach (DataRow dr in dt.Rows)
            {
                ClassYanSingle yanSingle = new ClassYanSingle();
                String zhuzhao = "";
                yanSingle.zihao = dr["ZIHAO"].ToString();
                yanSingle.zuoci = dr["ZUOCI"].ToString();
                if (dr["ZHUZHAO1"].ToString() != "")
                    zhuzhao = dr["ZHUZHAO1"].ToString();
                if (dr["ZHUZHAO2"].ToString() != "")
                    zhuzhao += ";" + dr["ZHUZHAO2"].ToString();
                if (dr["ZHUZHAO3"].ToString() != "")
                    zhuzhao += ";" + dr["ZHUZHAO3"].ToString();
                if (dr["ZHUZHAO4"].ToString() != "")
                    zhuzhao += ";" + dr["ZHUZHAO4"].ToString();
                String[] zhuzhaos = zhuzhao.Split(';');
                if (zhuzhaos.Count() > 0)
                    yanSingle.zhuzhao3 = zhuzhaos[0].Trim(';');
                if (zhuzhaos.Count() > 1)
                    yanSingle.zhuzhao2 = zhuzhaos[1].Trim(';');
                if (zhuzhaos.Count() > 2)
                    yanSingle.zhuzhao4 = zhuzhaos[2].Trim(';');
                if (zhuzhaos.Count() > 3)
                    yanSingle.zhuzhao1 = zhuzhaos[3].Trim(';');
                printList.Add(yanSingle);
            }
            reportYanSingle.SetDataSource(printList);
            crystalReportViewer_printyansingle.ReportSource = reportYanSingle;
        }
    }
}
