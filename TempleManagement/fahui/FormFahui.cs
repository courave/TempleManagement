using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TempleManagement.pub;

namespace TempleManagement.fahui
{
    public partial class FormFahui : Form
    {
        public FormFahui()
        {
            InitializeComponent();
        }

        private void FormFahui_Load(object sender, EventArgs e)
        {
            InitList();
        }

        private void InitList()
        {
            LoadList();
        }
        private void LoadList()
        {
            LoadList("SELECT ID,FAHUI_YEAR,FAHUI_NAME FROM FAHUI_LIST ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">id,fahui_year,fahui_name, DEFAULT order by fahui_year,fahui_name, DO NOT ADD ORDER BY</param>
        private void LoadList(String sql)
        {
            listView_fahui.ShowGroups = true;
            sql += " ORDER BY FAHUI_YEAR DESC,FAHUI_NAME ";
            String lastYear = "";
            ListViewItem lvi;
            listView_fahui.Groups.Clear();
            listView_fahui.Items.Clear();
            using (DataBase db = new DataBase())
            {
                DataTable dt = db.ExecuteDataTable(sql);
                ListViewGroup lvg=new ListViewGroup();
                foreach (DataRow dr in dt.Rows)
                {
                    if (lastYear != dr[1].ToString())
                    {
                        lastYear = dr[1].ToString();
                        lvg = new ListViewGroup();
                        lvg.Header = dr[1].ToString();
                        lvg.HeaderAlignment = HorizontalAlignment.Left;
                        listView_fahui.Groups.Add(lvg);
                    }
                    lvi = new ListViewItem();
                    lvi.ImageKey = dr[0].ToString();
                    lvi.Text = dr[2].ToString();
                    

                    lvg.Items.Add(lvi);
                    
                    listView_fahui.Items.Add(lvi);
                }
            }
        }

        private void listView_fahui_DoubleClick(object sender, EventArgs e)
        {
            if (listView_fahui.SelectedItems.Count != 1)
                return;
            ListViewItem lvi = listView_fahui.SelectedItems[0];
            //todo
            //MessageBox.Show(lvi.ImageKey);
            throw new Exception("The method or operation is not implemented.");
        }

        private void ToolStripMenuItem_addfahui_Click(object sender, EventArgs e)
        {
            FormAddFahui frmAddFahui = new FormAddFahui();
            frmAddFahui.ShowDialog();
            LoadList();
        }
    }
}
