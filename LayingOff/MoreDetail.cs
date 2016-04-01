using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace LayingOff
{
    public partial class MoreDetail : Form
    {

        DBProcess Db;
        FolderBrowserDialog ExportDia;
        string HeTongBianHao = "";

        Microsoft.Office.Interop.Word._Application wordApp = null;
        Object NoThing = Missing.Value;
        Microsoft.Office.Interop.Word._Document docGongDan = null;
        Microsoft.Office.Interop.Word._Document docLiaoDan = null;
        Microsoft.Office.Interop.Word._Document docCanShuDan = null;

        public MoreDetail(string BianHao)
        {
            InitializeComponent();
            Db = new DBProcess();
            ExportDia = new FolderBrowserDialog();
            HeTongBianHao = BianHao;
            Cursor.Current = Cursors.WaitCursor;
            wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            Cursor.Current = Cursors.Default;

        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DialogResult GetDialogResult(string str)
        {
            return MessageBox.Show(str, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        string MakeQuestionStr()
        {
            string question = "是否打印";

            if (ChkGongDan.Checked)
            {
                question += " 工单 ";

            }
            if (ChkLiaoDan.Checked)
            {
                question += " 料单 ";
            }
            if (ChkCanShuDan.Checked)
            {
                question += " 参数单 ";
            }
            if (question == "是否打印") return "没有选择";

            return question;

        }
        void MakeExport()
        {

            #region  分别打印三个表
            //*
            try
            {
                if (DialogResult.OK == ExportDia.ShowDialog())
                {
                    String PathName = ExportDia.SelectedPath + "//" + HeTongBianHao + "单据";// ExportDia.FileName;;


                    if (!Directory.Exists(PathName))
                    {
                        Directory.CreateDirectory(PathName);
                    }

                    if (ChkGongDan.Checked)
                    {
                        if (DgridGongDanMore.RowCount > 0)
                        {

                            String path = PathName + "\\" + HeTongBianHao + "-工单.doc";

                            docGongDan = wordApp.Documents.Add(NoThing, NoThing, NoThing, NoThing);

                            Export(DgridGongDanMore, docGongDan, HeTongBianHao + "-工单");




                            Object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;
                            docGongDan.SaveAs(path, format, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing);
                            docGongDan.Close(ref NoThing, ref NoThing, ref NoThing);

                        }
                    }
                    if (ChkLiaoDan.Checked)
                    {
                        if (DgridLiaoDanMoer.RowCount > 0)
                        {

                            String path = PathName + "\\" + HeTongBianHao + "-料单.doc";

                            docLiaoDan = wordApp.Documents.Add(NoThing, NoThing, NoThing, NoThing);

                            Export(DgridLiaoDanMoer, docLiaoDan, HeTongBianHao + "-料单");
                            Object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;
                            docLiaoDan.SaveAs(path, format, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing);
                            docLiaoDan.Close(ref NoThing, ref NoThing, ref NoThing);

                        }
                    }
                    if (ChkCanShuDan.Checked)
                    {
                        if (DgridCanShuDanMoer.RowCount > 0)
                        {

                            String path = PathName + "\\" + HeTongBianHao + "-参数单.doc";

                            docCanShuDan = wordApp.Documents.Add(NoThing, NoThing, NoThing, NoThing);

                            Export(DgridCanShuDanMoer, docCanShuDan, HeTongBianHao + "-参数单");

                            Object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;

                            docCanShuDan.SaveAs(path, format, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing);
                            docCanShuDan.Close(ref NoThing, ref NoThing, ref NoThing);


                        }
                    }


                    MessageBox.Show("导出成功!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // */

            #endregion


            #region  合成一个表
            /*
            try
            {
                if (DialogResult.OK == ExportDia.ShowDialog())
                {
                    String PathName = ExportDia.SelectedPath + "//" + HeTongBianHao + "单据";// ExportDia.FileName;;

                    if (!Directory.Exists(PathName))
                    {
                        Directory.CreateDirectory(PathName);
                    }

                    String path = PathName + "\\" + HeTongBianHao + "-料单.doc";

                    docGongDan = wordApp.Documents.Add(NoThing, NoThing, NoThing, NoThing);
                    if (ChkGongDan.Checked)
                    {
                        if (DgridGongDanMore.RowCount > 0)
                        {
                            Export(DgridGongDanMore, docGongDan, HeTongBianHao + "-工单");
                        }
                    }
                    if (ChkLiaoDan.Checked)
                    {
                        if (DgridLiaoDanMoer.RowCount > 0)
                        {
                            Export(DgridLiaoDanMoer, docGongDan, HeTongBianHao + "-料单");
                        }
                    }
                    if (ChkCanShuDan.Checked)
                    {
                        if (DgridCanShuDanMoer.RowCount > 0)
                        {
                            Export(DgridCanShuDanMoer, docGongDan, HeTongBianHao + "-参数单");
                        }
                    }
                    Object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;
                    docGongDan.SaveAs(path, format, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing, NoThing);
                    docGongDan.Close(ref NoThing, ref NoThing, ref NoThing);

                    MessageBox.Show("导出成功!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            */
            #endregion
        }




        private void BtnExport_Click(object sender, EventArgs e)
        {
            wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            string question;
            if ((question = MakeQuestionStr()) != "没有选择")
            {
                Cursor.Current = Cursors.WaitCursor;
                ;
                if (GetDialogResult(question) == DialogResult.OK)
                {
                    MakeExport();
                }
                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show(question);
            }

            wordApp.Quit();
           
        }


        void FillGongDan()
        {
            DataSet Ds = new DataSet();
            Ds = Db.Search("select * from GongDan where HeTongBianHao='" + HeTongBianHao + "'");

            if (Ds.Tables[0].Rows.Count <= 0)
                return;

            int j = 0;
            int i = 0;
            AddGridRow(DgridGongDanMore, "标识名称", Ds.Tables[0].Rows[j][i++].ToString());
            AddGridRow(DgridGongDanMore, "合同编号", Ds.Tables[0].Rows[j][i++].ToString(), " 日期", Ds.Tables[0].Rows[j][i++].ToString());
            AddGridRow(DgridGongDanMore, "产品名称", Ds.Tables[0].Rows[j][i++].ToString(), " 定金", Ds.Tables[0].Rows[j][i++].ToString());
            AddGridRow(DgridGongDanMore, "型号", Ds.Tables[0].Rows[j][i++].ToString(), " 金额", Ds.Tables[0].Rows[j][i++].ToString());
            AddGridRow(DgridGongDanMore, "开向", Ds.Tables[0].Rows[j][i++].ToString(), " 颜色", Ds.Tables[0].Rows[j][i++].ToString());
            AddGridRow(DgridGongDanMore, "客户地址", Ds.Tables[0].Rows[j][i++].ToString(), "联系人", Ds.Tables[0].Rows[j][i++].ToString());
            AddGridRow(DgridGongDanMore, "客户电话", Ds.Tables[0].Rows[j][i++].ToString(), " 安装日期 : ", Ds.Tables[0].Rows[0][i++].ToString());

            Ds.Dispose();
        }

        void FillLiaoDan()
        {
            DataSet Ds = new DataSet();
            Ds = Db.Search("select * from LiaoDan where HeTongBianHao='" + HeTongBianHao + "'");

            if (Ds.Tables[0].Rows.Count <= 0)
                return;
            int i;
            for (i = 1; i < Ds.Tables[0].Columns.Count; )
            {
                string co1 = Ds.Tables[0].Columns[i].ColumnName;
                string co2 = Ds.Tables[0].Rows[0][i++].ToString();
                if (co2 != "")
                    AddGridRow(DgridLiaoDanMoer, co1, co2);
            }

            Ds.Dispose();


        }
        void FillCanShuDan()
        {
            DataSet Ds = new DataSet();
            Ds = Db.Search("select * from CanShuDan where HeTongBianHao='" + HeTongBianHao + "'");

            if (Ds.Tables[0].Rows.Count <= 0)
                return;


            int j = 0;
            int i = 1;
            string Open = "";
            AddGridRow(DgridCanShuDanMoer, "类型 ", Ds.Tables[0].Rows[j][i++].ToString());
            AddGridRow(DgridCanShuDanMoer, "开向", (Open = Ds.Tables[0].Rows[j][i++].ToString()));
            AddGridRow(DgridCanShuDanMoer, "高", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
            AddGridRow(DgridCanShuDanMoer, "宽", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
            AddGridRow(DgridCanShuDanMoer, "门宽", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
            AddGridRow(DgridCanShuDanMoer, "门高", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
            int len;
            if ((len = Open.Length) < 2)
                return;
            if (Open.Substring(Open.Length - 2) == "单开")
            {
                i = i + 6;
                AddGridRow(DgridCanShuDanMoer, "门扇外板", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
                AddGridRow(DgridCanShuDanMoer, "门扇内板", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
            }
            else
            {

                AddGridRow(DgridCanShuDanMoer, "主扇成型尺寸", Ds.Tables[0].Rows[j][i++].ToString() + " cm²");
                AddGridRow(DgridCanShuDanMoer, "副扇成型尺寸", Ds.Tables[0].Rows[j][i++].ToString() + " cm²");
                AddGridRow(DgridCanShuDanMoer, "主扇外板", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
                AddGridRow(DgridCanShuDanMoer, "主扇内板", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
                AddGridRow(DgridCanShuDanMoer, "副扇外板", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
                AddGridRow(DgridCanShuDanMoer, "副扇内板", Ds.Tables[0].Rows[j][i++].ToString() + " cm");
            }
            Ds.Dispose();




        }

        void AddGridRow(DataGridView DG, string TName, string TValue)
        {
            int row = DG.RowCount;
            DG.Rows.Add();
            DG.Rows[row].Cells[0].Value = TName;
            DG.Rows[row].Cells[1].Value = TValue;
        }

        void AddGridRow(DataGridView DG, string TName0, string TValue1, string TName2, string TValue3)
        {
            int row = DG.RowCount;
            DG.Rows.Add();
            DG.Rows[row].Cells[0].Value = TName0;
            DG.Rows[row].Cells[1].Value = TValue1;
            DG.Rows[row].Cells[2].Value = TName2;
            DG.Rows[row].Cells[3].Value = TValue3;
        }

        private void MoreDetail_Load(object sender, EventArgs e)
        {
            FillGongDan();
            FillCanShuDan();
            FillLiaoDan();

        }



        private void Export(DataGridView ExportDgrid, Microsoft.Office.Interop.Word._Document doc, String flag)
        {

            int row = ExportDgrid.RowCount;
            int column = ExportDgrid.ColumnCount;
            int i, j;

            Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(wordApp.Selection.Range, row + 1, column, NoThing, NoThing);
            table.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
            table.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            if (column == 4)
            {

                table.Columns[1].Width = 80;
                table.Columns[3].Width = 80;
                table.Cell(2, 2).Merge(table.Cell(2, column));

            }
            else
            {
                table.Columns[1].Width = 80;
                table.Columns[2].Width = 80;
            }
            table.Cell(1, 1).Merge(table.Cell(1, column));

            try
            {
                table.Cell(1, 1).Range.Text = flag;
                table.Rows[1].Range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorBlue;
                for (i = 0; i < row; i++)
                {

                    for (j = 0; j < column; j++)
                    {
                        if (ExportDgrid.Rows[i].Cells[j].Value != null)
                            table.Cell(i + 2, j + 1).Range.Text = ExportDgrid.Rows[i].Cells[j].Value.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }





        private void print(DataGridView ExportDgrid, Microsoft.Office.Interop.Word._Document doc, String flag)
        {

            int row = ExportDgrid.RowCount;
            int column = ExportDgrid.ColumnCount;
            int i, j;

            Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(wordApp.Selection.Range, row + 1, column, NoThing, NoThing);            
         
            table.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
            table.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            
            if (column == 4)
            {

                table.Columns[1].Width = 80;
                table.Columns[3].Width = 80;
                table.Cell(2, 2).Merge(table.Cell(2, column));

            }
            else
            {
                table.Columns[1].Width = 80;
                table.Columns[2].Width = 80;
            }
            table.Cell(1, 1).Merge(table.Cell(1, column));

            try
            {
                table.Cell(1, 1).Range.Text = flag;
                table.Rows[1].Range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorBlue;
                for (i = 0; i < row; i++)
                {
                    for (j = 0; j < column; j++)
                    {
                        if (ExportDgrid.Rows[i].Cells[j].Value != null)
                            table.Cell(i + 2, j + 1).Range.Text = ExportDgrid.Rows[i].Cells[j].Value.ToString();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

    
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            if (DialogResult.OK == MessageBox.Show("打印????"))
            {


                if (ChkGongDan.Checked)
                {
                    if (DgridGongDanMore.RowCount > 0)
                    {
                        docGongDan = wordApp.Documents.Add(NoThing, NoThing, NoThing, NoThing);
                        print(DgridGongDanMore, docGongDan, HeTongBianHao + "-工单");

                        docGongDan.PrintOut();
                    }
                }

                if (ChkLiaoDan.Checked)
                {
                    if (DgridLiaoDanMoer.RowCount > 0)
                    {
                        docLiaoDan = wordApp.Documents.Add(NoThing, NoThing, NoThing, NoThing);
                        print(DgridLiaoDanMoer, docLiaoDan, HeTongBianHao + "-料单");
                        docLiaoDan.PrintOut();

                    }
                }
                if (ChkCanShuDan.Checked)
                {
                    if (DgridCanShuDanMoer.RowCount > 0)
                    {
                        docCanShuDan = wordApp.Documents.Add(NoThing, NoThing, NoThing, NoThing);
                        print(DgridCanShuDanMoer, docCanShuDan, HeTongBianHao + "-参数单");
                        docCanShuDan.PrintOut();
                    }
                }
                wordApp.Quit();
            }
        }
    }
}
