using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LayingOff
{
    public partial class SearchForm : Form
    {
        DataSet Ds;
        DBProcess Db;
        SaveFileDialog ExportDia;
        int TempRow = 0;

        public SearchForm()
        {
            InitializeComponent();

            Ds = new DataSet();
            Db = new DBProcess();
            ExportDia = new SaveFileDialog();

            ExportDia.AutoUpgradeEnabled = false;
            ExportDia.Filter = "Execl表格|.xls"; ;
            ExportDia.FileName = "工单";
            ExportDia.Title = "导出";
            ExportDia.RestoreDirectory = false;

            ExportDia.InitialDirectory = "D:";
         
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            Search("SELECT * FROM GongDan");
        }
        void FillCbox()
        {
            try
            {
                CboxSearch.DataSource = Db.Search("SELECT HeTongBianHao FROM GongDan order by Id Desc").Tables[0];
                CboxSearch.DisplayMember = "HeTongBianHao";
            }
            catch
            {
                return;
            }
        }

        private void CboxSearch_DropDown(object sender, EventArgs e)
        {
            FillCbox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Search("SELECT * FROM GongDan WHERE  HeTongBianHao='" + CboxSearch.Text + "'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CboxSearch.Text == "") return;
            Search("SELECT * FROM GongDan");
        }

        void Search(string sqlstr)
        {
            DataSet Ds = new DataSet();
            if ((Ds = Db.Search(sqlstr)) != null)
            {
                DGrdSearchWork.DataSource = Ds.Tables[0];
                if (Ds.Tables[0].Rows.Count <= 0)
                    MessageBox.Show("没有查到");

                Ds.Dispose();
            }
        }
        private void DGrdSearchWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGrdSearchWork.Rows[TempRow].DefaultCellStyle.BackColor = Color.White;
                TempRow = DGrdSearchWork.CurrentRow.Index;
                DGrdSearchWork.Rows[TempRow].DefaultCellStyle.BackColor = Color.Blue;
               
               string Head= DGrdSearchWork.CurrentRow.Cells["HeTongBianHao"].Value.ToString();

               MoreDetail more = new MoreDetail(Head);
                more.Text = "合同编号:"+Head;
                more.Show();


            }
            catch
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CboxSearch.Text == "") return;
            Db.DataProcess("Delete from GongDan where HeTongBianHao='"+CboxSearch.Text+"'");
            Db.DataProcess("Delete from LiaoDan where HeTongBianHao='" + CboxSearch.Text + "'");
            Db.DataProcess("Delete from CanShuDan where HeTongBianHao='" + CboxSearch.Text + "'");

            Search("SELECT * FROM GongDan");
            FillCbox();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DGrdSearchWork.RowCount <= 0) return;

           if (DialogResult.OK == ExportDia.ShowDialog())
            {
                Export(DGrdSearchWork, ExportDia.FileName);
                MessageBox.Show("导出成功!!");
            }
          

        }

        private void Export(DataGridView ExportDgrid,string pathname)
        {
           
            int i, j;
           
                try
                {
                    string tempStr = "";

                    FileStream stream = new FileStream(pathname, FileMode.Create);
                    StreamWriter write = new StreamWriter(stream, Encoding.Default);

                    for (i = 0; i < ExportDgrid.ColumnCount-1; i++)
                    {
                        tempStr += ExportDgrid.Columns[i].HeaderText + "\t";
                    }
                    write.WriteLine(tempStr);

                    for (i = 0; i < ExportDgrid.RowCount; i++)
                    {
                        tempStr = "";
                        for (j = 0; j < ExportDgrid.ColumnCount-1; j++)
                        {
                            if (ExportDgrid.Rows[i].Cells[j].Value != null)
                                tempStr += ExportDgrid.Rows[i].Cells[j].Value.ToString() + "\t";
                            else
                                tempStr += "\t";
                        }
                        write.WriteLine(tempStr);
                    }
                    
                    write.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        private void DGrdSearchWork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CboxSearch.Text = DGrdSearchWork.CurrentRow.Cells[1].Value.ToString();
        }

    }
}
