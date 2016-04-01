using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LayingOff
{
    public partial class Equation : Form
    {
       // const string FHM = "防火门";
      //  const string FDM = "防盗门";
      //  const string LYM = "楼宇门";
        const string T52DanKai = "52单开";
        const string T52SanQi  = "52三七";
        const string T52DuiKai = "52对开";
        const string T70DanKai = "70单开";
        const string T70SanQi  = "70三七";
        const string T70DuiKai = "70对开";
        const string DOOR = "DOOR";
   

        XmlProcess xml = new XmlProcess();
        TreeNode TempNode = new TreeNode();
        public Equation()
        {
            InitializeComponent();
            TempNode = null;

        }

        public void UpDateData()
        {
            TvwEquation.Nodes.Clear();
            try
            {
                XmlNodeList List = xml.GetXml().SelectSingleNode("DOOR").ChildNodes;
                foreach (XmlNode XmlNode1 in List)
                {
                    TreeNode TvwNode1 = TvwEquation.Nodes.Add(XmlNode1.Name);
                     TvwNode1.ImageIndex = 0;
                    foreach (XmlNode XmlNode2 in XmlNode1.ChildNodes)
                    {
                        TvwNode1.Nodes.Add(xml.DelF(XmlNode2.Name)).ImageIndex =1 ;
                    }
                }
            }
            catch
            {
                return;
            }

        }

        private void Equation_Load(object sender, EventArgs e)
        {

            UpDateData();
            int x = picture.Location.X + TvwEquation.Width;
            int y = picture.Location.Y + picture.Height;
            TvwEquation.Location = new Point(picture.Location.X, y);

            GboxDanKai.Location = new Point(x,y);
            GboxSanQi.Location = new Point(x,y);
            GboxDuiKai.Location = new Point(x,y);

            GboxDanKai.Size = new Size(506, 301);
            GboxSanQi.Size = new Size(506, 301);
            GboxDuiKai.Size = new Size(506, 301);

        }

        private void TvwEquation_DoubleClick(object sender, EventArgs e)
        {
            if (TvwEquation.SelectedNode.Parent!= null)
            {
                #region
                if (TempNode != null)
                {
                    TempNode.Parent.ForeColor = Color.Black;
                    TempNode.ForeColor = Color.Black;
                }

                TvwEquation.SelectedNode.Parent.ForeColor = Color.Red;
                TvwEquation.SelectedNode.ForeColor = Color.Red;
                TempNode = TvwEquation.SelectedNode;
                LblEquationStatus.Text = "状态:  已选中  " + TempNode.Parent.Text+ ">"+ TempNode.Text;
                LblEquationStatus.ForeColor = Color.Black;


                #endregion  //color process

                string StrType = TvwEquation.SelectedNode.Parent.Text;

                switch( TvwEquation.SelectedNode.Text)
                {
                    case T52DanKai:
                        {
                            SearchDanKai(StrType, T52DanKai);
                        }
                        break;
                    case T52SanQi:
                        {
                            SearchSanQi(StrType, T52SanQi);
                        }
                        break;
                    case T52DuiKai:
                        {
                            SearchDuiKai(StrType, T52DuiKai);
                        }
                        break;
                    case T70DanKai:
                        {
                            SearchDanKai(StrType, T70DanKai);
                        }
                        break;
                    case T70SanQi:
                        {
                            SearchSanQi(StrType, T70SanQi);
                        }
                        break;
                    case T70DuiKai:
                        {
                            SearchDuiKai(StrType, T70DuiKai);
                        }
                        break;
                    default:
                        break;
                }


            }
        }

       
        int ToInt(string str)
        {
            return Convert.ToInt32(str);

        }

        void SearchDanKai(string StrType,string StrOpen)
        {
            DanKaiMenKuan.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门宽"));
            DanKaiMenGao.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门高"));
            DanKaiMenShanWaiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门扇外板-1"));
            DanKaiMenShanWaiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门扇外板-2"));
            DanKaiMenShanNeiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门扇内板-1"));
            DanKaiMenShanNeiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门扇内板-2"));

            GboxSanQi.Visible = false;
            GboxDuiKai.Visible = false;
            GboxDanKai.Visible = true;
            GboxDanKai.Text = StrType + "->" + StrOpen;


        }
        void SearchSanQi(string StrType,string StrOpen)
        {
            SanQiMenKuan.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门宽"));
            SanQiMenGao.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门高"));

            SanQiZhuShanChengXing.Value = Convert.ToDecimal(xml.Search(DOOR,StrType, StrOpen, "主扇成型尺寸"));
            SanQiFuShanChengXing.Value = Convert.ToDecimal(xml.Search(DOOR,StrType, StrOpen, "副扇成型尺寸"));

            SanQiZhuShanWaiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "主扇外板-1"));
            SanQiZhuShanWaiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "主扇外板-2"));
            SanQiZhuShanNeiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "主扇内板-1"));
            SanQiZhuShanNeiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "主扇内板-2"));

            SanQiFuShanWaiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "副扇外板-1"));
            SanQiFuShanWaiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "副扇外板-2"));
            SanQiFuShanNeiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "副扇内板-1"));
            SanQiFuShanNeiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "副扇内板-2"));
           
            GboxDanKai.Visible = false;
            GboxDuiKai.Visible = false;
            GboxSanQi.Visible = true;
            GboxSanQi.Text = StrType + "->" + StrOpen;

        }

        void SearchDuiKai(string StrType, string StrOpen)
        {
            DuiKaiMenKuan.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门宽"));
            DuiKaiMenGao.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "门高"));

            DuiKaiZhuShanChengXing.Value = Convert.ToDecimal(xml.Search(DOOR,StrType, StrOpen, "主扇成型尺寸"));
            DuiKaiFuShanChengXing.Value = Convert.ToDecimal(xml.Search(DOOR,StrType, StrOpen, "副扇成型尺寸"));

            DuiKaiZhuShanWaiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "主扇外板-1"));
            DuiKaiZhuShanWaiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "主扇外板-2"));
            DuiKaiZhuShanNeiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "主扇内板-1"));
            DuiKaiZhuShanNeiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "主扇内板-2"));
            DuiKaiFuShanWaiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "副扇外板-1"));
            DuiKaiFuShanWaiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "副扇外板-2"));
            DuiKaiFuShanNeiBan1.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "副扇内板-1"));
            DuiKaiFuShanNeiBan2.Value = ToInt(xml.Search(DOOR,StrType, StrOpen, "副扇内板-2"));

            GboxDanKai.Visible = false;
            GboxSanQi.Visible = false;
            GboxDuiKai.Visible = true;
            GboxDuiKai.Text = StrType + "->" + StrOpen;


        }
        void SetDanKai(string StrType,string StrOpen)
        {

            xml.UpdateData(DOOR,StrType, StrOpen, "门宽", DanKaiMenKuan.Value.ToString());
            xml.UpdateData(DOOR,StrType, StrOpen, "门高", DanKaiMenGao.Value.ToString());
            xml.UpdateData(DOOR,StrType, StrOpen, "门扇外板-1", DanKaiMenShanWaiBan1.Value.ToString());
            xml.UpdateData(DOOR,StrType, StrOpen, "门扇外板-2",DanKaiMenShanWaiBan2.Value.ToString());
            xml.UpdateData(DOOR,StrType, StrOpen, "门扇内板-1", DanKaiMenShanNeiBan1.Value.ToString());
            xml.UpdateData(DOOR,StrType, StrOpen, "门扇内板-2", DanKaiMenShanNeiBan2.Value .ToString());
            xml.Save();
        }
        void SetSanQi(string StrType,string StrOpen)
        {
             xml.UpdateData(DOOR,StrType, StrOpen, "门宽",SanQiMenKuan.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "门高",SanQiMenGao.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "主扇成型尺寸",SanQiZhuShanChengXing.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇成型尺寸",SanQiFuShanChengXing.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "主扇外板-1", SanQiZhuShanWaiBan1.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "主扇外板-2", SanQiZhuShanWaiBan2.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "主扇内板-1", SanQiZhuShanNeiBan1.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "主扇内板-2", SanQiZhuShanNeiBan2.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇外板-1", SanQiFuShanWaiBan1.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇外板-2",SanQiFuShanWaiBan2.Value .ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇内板-1",  SanQiFuShanNeiBan1.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇内板-2", SanQiFuShanNeiBan2.Value .ToString());
             xml.Save();
        }
         void SetDuiKai(string StrType, string StrOpen)
        {
             xml.UpdateData(DOOR,StrType, StrOpen, "门宽",DuiKaiMenKuan.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "门高", DuiKaiMenGao.Value.ToString());

             xml.UpdateData(DOOR,StrType, StrOpen, "主扇成型尺寸",  DuiKaiZhuShanChengXing.Value .ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇成型尺寸", DuiKaiFuShanChengXing.Value.ToString());

             xml.UpdateData(DOOR,StrType, StrOpen, "主扇外板-1",DuiKaiZhuShanWaiBan1.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "主扇外板-2", DuiKaiZhuShanWaiBan2.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "主扇内板-1",DuiKaiZhuShanNeiBan1.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "主扇内板-2", DuiKaiZhuShanNeiBan2.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇外板-1", DuiKaiFuShanWaiBan1.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇外板-2", DuiKaiFuShanWaiBan2.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇内板-1", DuiKaiFuShanNeiBan1.Value.ToString());
             xml.UpdateData(DOOR,StrType, StrOpen, "副扇内板-2",DuiKaiFuShanNeiBan2.Value.ToString());
             xml.Save();
        }
   
        private void BtDanKai_Click(object sender, EventArgs e)
        {
            if(TvwEquation.SelectedNode!=null &&TvwEquation.SelectedNode.Parent!=null)
            {
                SetDanKai(TvwEquation.SelectedNode.Parent.Text, TvwEquation.SelectedNode.Text);
                LblEquationStatus.Text = "状态:  " + TvwEquation.SelectedNode.Parent.Text + " >" + TvwEquation.SelectedNode.Text + "  已更新  " + DateTime.Now.ToLongTimeString() + "   继续更改请重选!!!";
                LblEquationStatus.ForeColor = Color.Red;
                UpDateData();
         
            }
        }

        private void BtSanQi_Click(object sender, EventArgs e)
        {

            if (TvwEquation.SelectedNode != null && TvwEquation.SelectedNode.Parent != null)
            {

                SetSanQi(TvwEquation.SelectedNode.Parent.Text, TvwEquation.SelectedNode.Text);
                LblEquationStatus.Text = "状态:  " + TvwEquation.SelectedNode.Parent.Text + " >" + TvwEquation.SelectedNode.Text + "  已更新  " + DateTime.Now.ToLongTimeString() + "   继续更改请重选!!!";
                LblEquationStatus.ForeColor = Color.Red;
                UpDateData();


            }
            
        }

        private void BtDuiKai_Click(object sender, EventArgs e)
        {

            if (TvwEquation.SelectedNode != null && TvwEquation.SelectedNode.Parent != null)
            {

                SetDuiKai(TvwEquation.SelectedNode.Parent.Text, TvwEquation.SelectedNode.Text);
                LblEquationStatus.Text = "状态:  " + TvwEquation.SelectedNode.Parent.Text + " >" + TvwEquation.SelectedNode.Text + "  已更新  " + DateTime.Now.ToLongTimeString()+"   继续更改请重选!!!";
                LblEquationStatus.ForeColor = Color.Red;
                UpDateData();

            }
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
     
    }
}
