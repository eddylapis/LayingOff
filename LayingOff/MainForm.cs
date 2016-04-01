using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace LayingOff
{

    public partial class MainForm : Form
    {

        Equation FormEq;
        XmlProcess xml = new XmlProcess();
        DBProcess Db = new DBProcess();
        const string DanKai = "单开";
        const string DuiKai = "对开";
        const string SanQi = "三七";
        const string DOOR = "DOOR";
        const string O = "','";

        string GongDanSqlStr = "";
        string LiaoDanSqlStr = "";
        string CanShuDanSqlStr = "";
        int x = 0, y = 0;
        ComboBox CurrentCbox;




        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindType(CboxProductName);
            BindType(CBoxType);
            CboxProductName.SelectedIndex = 0;
            CBoxType.SelectedIndex = 0;
            TxtDate.Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月第" + DateTime.Now.Day.ToString() + "号";

            FillPnl();
        }

        void FillPnl()
        {

            try
            {
                x = 0; y = 0;
                //   PnlDemand.Controls.Clear();
                foreach (XmlNode node in xml.GetXml().SelectSingleNode("CONTROLS//" + CBoxType.Text).ChildNodes)
                {
                    AddComBox(xml.DelF(node.Name));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        void AddComBox(string tname)
        {
            try
            {
                Control[] colLbl = new Control[1];
                Control[] colCbo = new Control[1];
                Label Lbl = new Label();
                ComboBox cbo = new ComboBox();
                if ((colLbl = PnlDemand.Controls.Find("Lbl" + tname, false)).Count() > 0 && (colCbo = PnlDemand.Controls.Find(tname, false)).Count() > 0)
                {

                    Lbl = (Label)colLbl[0];
                    cbo = (ComboBox)colCbo[0];
                    Lbl.Location = new Point((x++ % 4) * 240, (y++ / 4) * 25);
                    cbo.Location = new Point(Lbl.Location.X + Lbl.Size.Width, Lbl.Location.Y);
                //    MessageBox.Show("加加加:" + tname);


                }
                else
                {

                    Lbl.Parent = PnlDemand;
                    Lbl.Text = tname + ": ";
                    Lbl.Name = "Lbl" + tname;
                    Lbl.AutoSize = true;
                    Lbl.BackColor = Color.Transparent;
                    Lbl.Location = new Point((x++ % 4) * 240, (y++ / 4) * 25);
                    cbo.Parent = PnlDemand;
                    cbo.DropDown += new System.EventHandler(this.Cbox_DropDown);
                    cbo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cbox_MouseDown);
                    cbo.ContextMenuStrip = this.contextMenuStrip1;
                    cbo.Name = tname;
                    cbo.Tag = xml.AddF(tname);
                    cbo.Location = new Point(Lbl.Location.X + Lbl.Size.Width, Lbl.Location.Y);

                //    MessageBox.Show("测试用:" + tname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void BtnEquationChange_Click(object sender, EventArgs e)
        {
            FormEq = new Equation();
            FormEq.ShowDialog(); ;
        }


        private void CBoxOpen_DropDown(object sender, EventArgs e)
        {
            if (CBoxType.Text.Trim() != "")
                BindOpen();
        }

        private void CBoxType_DropDown(object sender, EventArgs e)
        {
            BindType(CBoxType);
            CBoxOpen.Text = "";
        }




        private void TxtHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            JudgeNum(e);
        }

        void JudgeNum(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 & e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
                MessageBox.Show("请输入数字");
            }
        }

        private void TxtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            JudgeNum(e);
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CurrentCbox.Tag != null)
            {

                xml.AddComBoxItem(CBoxType.Text + "//" + CurrentCbox.Tag.ToString(), CurrentCbox.Text);
            }

        }

        private void Cbox_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentCbox = (ComboBox)sender;

            if (CurrentCbox.Tag == null)
                return;
            if (CurrentCbox.Text == "")
            {
                ToolMenuAdd.Enabled = false;
                ToolMenuDel.Enabled = false;
            }
            else
                if (xml.Search(CBoxType.Text + "//" + CurrentCbox.Tag.ToString(), CurrentCbox.Text) != null)
                {
                    ToolMenuAdd.Enabled = false;
                    ToolMenuDel.Enabled = true;
                }
                else
                {
                    ToolMenuAdd.Enabled = true;
                    ToolMenuDel.Enabled = false;

                }

        }



        private void Cbox_DropDown(object sender, EventArgs e)
        {
            ComboBox CboxTemp = (ComboBox)sender;
            CboxTemp.Items.Clear();
            try
            {
                XmlNode ParentNode = xml.GetXml().SelectSingleNode("CONTROLS//" + CBoxType.Text).SelectSingleNode(CboxTemp.Tag.ToString());
                foreach (XmlNode node in ParentNode.ChildNodes)
                {
                    CboxTemp.Items.Add(xml.DelF(node.Name));
                }
            }
            catch
            {
                return;

            }
        }

        private void ToolMenuDel_Click(object sender, EventArgs e)
        {
            if (CurrentCbox.Tag != null)
            {
                xml.DelComBoxItem(CBoxType.Text + "//" + CurrentCbox.Tag.ToString(), CurrentCbox.Text);
                CurrentCbox.Text = "";
            }
        }


        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset(GboxWork);
        }




        private void BtnMaterialReset_Click(object sender, EventArgs e)
        {

            Reset(GboxMaterial);
            Reset(PnlDemand);
        }
        private void button3_Click(object sender, EventArgs e)
        {


            if (DGrdWork.RowCount <= 0 || DGrdMaterial.RowCount <= 0)
            {

                MessageBox.Show("单据生成不完整,填充完整后单击 '生成单据'", "存入数据库失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (TxtContractNu.Text == "")
            {
                TxtContractNu.BackColor = Color.Red;
                MessageBox.Show("合同编号不能为空'", "存入数据库失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataSet Ds = new DataSet();
            if ((Ds = Db.Search("SELECT * FROM GongDan where HeTongBianHao='" + TxtContractNu.Text + "'")) != null && Ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("该单号已存在!!");
                return;
            }



            string temp = "";
            if (GongDanSqlStr != "")
            {
                Db.DataProcess(GongDanSqlStr);
                temp += " 工单 ";
            }
            if (LiaoDanSqlStr != "")
            {
                Db.DataProcess(LiaoDanSqlStr);
                temp += " 料单 ";
            }
            if (CanShuDanSqlStr != "")
            {
                Db.DataProcess(CanShuDanSqlStr);
                temp += " 参数单 ";
            }


            MessageBox.Show(temp + "保存成功");

            DGrdWork.Rows.Clear(); DGrdDemand.Rows.Clear(); DGrdMaterial.Rows.Clear();

            GongDanSqlStr = "";
            LiaoDanSqlStr = "";
            CanShuDanSqlStr = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchForm Search = new SearchForm();
            Search.ShowDialog();
        }

        void BindType(ComboBox cbox)
        {
            cbox.Items.Clear();
            foreach (XmlNode node in xml.GetXml().SelectSingleNode(DOOR).ChildNodes)
            {
                cbox.Items.Add(node.Name);
            }

        }
        void BindOpen()
        {
            CBoxOpen.Items.Clear();
            try
            {
                foreach (XmlNode node in xml.GetXml().SelectSingleNode(DOOR).SelectSingleNode(CBoxType.Text.Trim()).ChildNodes)
                {
                    CBoxOpen.Items.Add(xml.DelF(node.Name));
                }
                CBoxOpen.SelectedIndex = 0;
            }
            catch
            {
                CBoxOpen.Items.Clear();
                CBoxOpen.Text = "";

            }
        }

        void CalcSanQi(string StrType, string StrOpen)
        {

            //门宽=门尺寸-xx；
            int MenKuan = ToInt(TxtWidth.Text.Trim()) - ToInt(xml.Search(DOOR, StrType, StrOpen, "门宽"));
            //门高=门尺寸-xx
            int MenGao = ToInt(TxtHigh.Text.Trim()) - ToInt(xml.Search(DOOR, StrType, StrOpen, "门高"));
            //主扇成型尺寸=门宽*xx％；
            double ZhuShanChengXingChiCun = MenKuan * Convert.ToDouble(xml.Search(DOOR, StrType, StrOpen, "主扇成型尺寸"));
            // 副扇成型尺寸=门宽*xx％          
            double FuShanChengXingChiCun = MenKuan * Convert.ToDouble(xml.Search(DOOR, StrType, StrOpen, "副扇成型尺寸"));

            // 主扇外板=（主扇外板成型宽+xx）*（门高-xx）
            double ZhuShanWaiBan = (ZhuShanChengXingChiCun + ToInt(xml.Search(DOOR, StrType, StrOpen, "主扇外板-1"))) * (MenGao - ToInt(xml.Search(DOOR, StrType, StrOpen, "主扇外板-2")));
            //    主扇内板=（主扇内板成型宽+xx）*（门高+xx）
            double ZhuShanNeiBan = (ZhuShanChengXingChiCun + ToInt(xml.Search(DOOR, StrType, StrOpen, "主扇内板-1"))) * (MenGao + ToInt(xml.Search(DOOR, StrType, StrOpen, "主扇内板-2")));
            //    副扇外板=（副扇外板成型尺寸+xx）*（门高-xx）
            double FuShanWaiBan = (FuShanChengXingChiCun + ToInt(xml.Search(DOOR, StrType, StrOpen, "副扇外板-1"))) * (MenGao - ToInt(xml.Search(DOOR, StrType, StrOpen, "副扇外板-2")));
            //    副扇内板=（副扇外板成型尺寸+xx）*（门高+xx）
            double FuShanNeiiBan = (FuShanChengXingChiCun + ToInt(xml.Search(DOOR, StrType, StrOpen, "副扇内板-1"))) * (MenGao + ToInt(xml.Search(DOOR, StrType, StrOpen, "副扇内板-2")));

            DGridAddRow("类型", CBoxType.Text);
            DGridAddRow("开向", CBoxOpen.Text);
            DGridAddRow("高", TxtHigh.Text);
            DGridAddRow("宽", TxtWidth.Text);

            DGridAddRow("门宽", MenKuan + " cm");
            DGridAddRow("门高", MenGao);
            DGridAddRow("主扇成型尺寸", ZhuShanChengXingChiCun + " cm");
            DGridAddRow("副扇成型尺寸", FuShanChengXingChiCun + " cm");
            DGridAddRow("主扇外板", ZhuShanWaiBan + " cm");
            DGridAddRow("主扇内板", ZhuShanNeiBan + " cm");
            DGridAddRow("副扇外板", FuShanWaiBan + " cm");
            DGridAddRow("副扇内板", FuShanNeiiBan + " cm");

            MakeCanShuDanSqlStr(TxtContractNu.Text, MenKuan.ToString(), MenGao.ToString(), ZhuShanChengXingChiCun.ToString(), FuShanChengXingChiCun.ToString(), ZhuShanWaiBan.ToString(), ZhuShanNeiBan.ToString(), FuShanWaiBan.ToString(), FuShanNeiiBan.ToString());



        }
        void CalcDuiKai(string StrType, string StrOpen)
        {


            //门宽=门尺寸-xx；
            int MenKuan = ToInt(TxtWidth.Text.Trim()) - ToInt(xml.Search(DOOR, StrType, StrOpen, "门宽"));
            //门高=门尺寸-xx
            int MenGao = ToInt(TxtHigh.Text.Trim()) - ToInt(xml.Search(DOOR, StrType, StrOpen, "门高"));
            //主扇成型尺寸=门宽*xx％；
            double ZhuShanChengXingChiCun = MenKuan * Convert.ToDouble(xml.Search(DOOR, StrType, StrOpen, "主扇成型尺寸"));
            // 副扇成型尺寸=门宽*xx％          
            double FuShanChengXingChiCun = MenKuan * Convert.ToDouble(xml.Search(DOOR, StrType, StrOpen, "副扇成型尺寸"));

            // 主扇外板=（主扇外板成型宽+xx）*（门高-xx）
            double ZhuShanWaiBan = (ZhuShanChengXingChiCun + ToInt(xml.Search(DOOR, StrType, StrOpen, "主扇外板-1"))) * (MenGao - ToInt(xml.Search(DOOR, StrType, StrOpen, "主扇外板-2")));
            //    主扇内板=（主扇内板成型宽+xx）*（门高+xx）
            double ZhuShanNeiBan = (ZhuShanChengXingChiCun + ToInt(xml.Search(DOOR, StrType, StrOpen, "主扇内板-1"))) * (MenGao + ToInt(xml.Search(DOOR, StrType, StrOpen, "主扇内板-2")));
            //    副扇外板=（副扇外板成型尺寸+xx）*（门高-xx）
            double FuShanWaiBan = (FuShanChengXingChiCun + ToInt(xml.Search(DOOR, StrType, StrOpen, "副扇外板-1"))) * (MenGao - ToInt(xml.Search(DOOR, StrType, StrOpen, "副扇外板-2")));
            //    副扇内板=（副扇外板成型尺寸+xx）*（门高+xx）
            double FuShanNeiiBan = (FuShanChengXingChiCun + ToInt(xml.Search(DOOR, StrType, StrOpen, "副扇内板-1"))) * (MenGao + ToInt(xml.Search(DOOR, StrType, StrOpen, "副扇内板-2")));

            DGridAddRow("类型", CBoxType.Text);
            DGridAddRow("开向", CBoxOpen.Text);
            DGridAddRow("高", TxtHigh.Text + " cm");
            DGridAddRow("宽", TxtWidth.Text + " cm");

            DGridAddRow("门宽", MenKuan + " cm");
            DGridAddRow("门高", MenGao + " cm");
            DGridAddRow("主扇成型尺寸", ZhuShanChengXingChiCun + " cm");
            DGridAddRow("副扇成型尺寸", FuShanChengXingChiCun + " cm");
            DGridAddRow("主扇外板", ZhuShanWaiBan + " cm");
            DGridAddRow("主扇内板", ZhuShanNeiBan + " cm");
            DGridAddRow("副扇外板", FuShanWaiBan + " cm");
            DGridAddRow("副扇内板", FuShanNeiiBan + " cm");

            MakeCanShuDanSqlStr(TxtContractNu.Text, MenKuan.ToString(), MenGao.ToString(), ZhuShanChengXingChiCun.ToString(), FuShanChengXingChiCun.ToString(), ZhuShanWaiBan.ToString(), ZhuShanNeiBan.ToString(), FuShanWaiBan.ToString(), FuShanNeiiBan.ToString());

        }
        void CalcDanKai(string StrType, string StrOpen)
        {

            //门宽=门尺寸-xx；
            int MenKuan = ToInt(TxtWidth.Text.Trim()) - ToInt(xml.Search(DOOR, StrType, StrOpen, "门宽"));
            //门高=门尺寸-xx
            int MenGao = ToInt(TxtHigh.Text.Trim()) - ToInt(xml.Search(DOOR, StrType, StrOpen, "门高"));
            //门扇外板=（门宽-xx）*（门高-xx）
            int MenShanWaiBan = (MenKuan - ToInt(xml.Search(DOOR, StrType, StrOpen, "门扇外板-1"))) * (MenGao - ToInt(xml.Search(DOOR, StrType, StrOpen, "门扇外板-2")));
            //门扇内板=（门宽+xx）*（门高+xx）
            int MenShanNeiBan = (MenKuan + ToInt(xml.Search(DOOR, StrType, StrOpen, "门扇内板-1"))) * (MenGao + ToInt(xml.Search(DOOR, StrType, StrOpen, "门扇内板-2")));


            DGridAddRow("类型", CBoxType.Text + " cm");
            DGridAddRow("开向", CBoxOpen.Text + " cm");
            DGridAddRow("高", TxtHigh.Text + " cm");
            DGridAddRow("宽", TxtWidth.Text + " cm");

            DGridAddRow("门宽", MenKuan + " cm");
            DGridAddRow("门高", MenGao + " cm");
            DGridAddRow("门扇外板", MenShanWaiBan + " cm");
            DGridAddRow("门扇内板", MenShanNeiBan + " cm");
            MakeCanShuDanSqlStr(TxtContractNu.Text, MenKuan.ToString(), MenGao.ToString(), MenShanWaiBan.ToString(), MenShanNeiBan.ToString());
        }
        void DGridAddRow(string TName, int TValue)
        {
            int row = DGrdMaterial.RowCount;
            DGrdMaterial.Rows.Add();
            DGrdMaterial.Rows[row].Cells[0].Value = TName;
            DGrdMaterial.Rows[row].Cells[1].Value = TValue.ToString();
        }
        void DGridAddRow(string TName, string TValue)
        {
            int row = DGrdMaterial.RowCount;
            DGrdMaterial.Rows.Add();
            DGrdMaterial.Rows[row].Cells[0].Value = TName;
            DGrdMaterial.Rows[row].Cells[1].Value = TValue.ToString();
        }
        void DGridAddRow(string TName, double TValue)
        {
            int row = DGrdMaterial.RowCount;
            DGrdMaterial.Rows.Add();
            DGrdMaterial.Rows[row].Cells[0].Value = TName;
            DGrdMaterial.Rows[row].Cells[1].Value = TValue.ToString(); ;
        }
        void DemandDGridAddRow(string TName, string TValue)
        {
            int row = DGrdDemand.RowCount;
            DGrdDemand.Rows.Add();
            DGrdDemand.Rows[row].Cells[0].Value = TName;
            DGrdDemand.Rows[row].Cells[1].Value = TValue.ToString(); ;
        }
        void DGridAddRow(string TName0, string Value1, string TName2, string Value3)
        {
            int row = DGrdWork.RowCount;
            DGrdWork.Rows.Add();
            DGrdWork.Rows[row].Cells[0].Value = TName0;
            DGrdWork.Rows[row].Cells[1].Value = Value1;
            DGrdWork.Rows[row].Cells[2].Value = TName2;
            DGrdWork.Rows[row].Cells[3].Value = Value3;
        }

        int ToInt(string str)
        {
            return Convert.ToInt32(str);
        }
        void MakeWorkTable()
        {
            if (TxtId.Text.Trim() != "")
            {
                DGridAddRow("标识名称", TxtId.Text, "", "");
            }
            DGridAddRow("合同编号", TxtContractNu.Text, "日期", TxtDate.Text);
            DGridAddRow("产品名称", CboxProductName.Text, "定金", TxtEarnestMoney.Text);
            DGridAddRow("型号", TxtProductType.Text, "金额", TxtSum.Text);
            DGridAddRow("开向", Open.Text, "颜色", TxtColor.Text);
            DGridAddRow("客户地址", TxtAddress.Text, "联系人", TxtLinkMan.Text);
            DGridAddRow("客户电话", TxtPhone.Text, "安装日期", DtpFix.Value.ToShortDateString());


            MakeGongDanSqlStr(TxtId.Text, TxtContractNu.Text, CboxProductName.Text, TxtEarnestMoney.Text, TxtProductType.Text, TxtSum.Text, Open.Text, TxtColor.Text, TxtAddress.Text, TxtPhone.Text, TxtLinkMan.Text, DtpFix.Text);
        }
        private void MakeDemandTable()
        {
            ComboBox cbox;
            foreach (Control cb in PnlDemand.Controls)
            {

                if (cb is ComboBox && (cbox = (ComboBox)cb).Tag != null)
                {

                    DemandDGridAddRow(cbox.Name, cbox.Text);
                }
            }
        }
        void Reset(GroupBox Gbox)
        {
            foreach (Control con in Gbox.Controls)
            {
                if (con is TextBox && ((TextBox)con).Name != "TxtDate")
                {
                    ((TextBox)con).Clear();
                }
                else if ((con is ComboBox))
                {
                    ((ComboBox)con).Text = "";
                }
            }
        }
        void Reset(Panel pnl)
        {
            foreach (Control con in pnl.Controls)
            {
                if (con is TextBox)
                {
                    ((TextBox)con).Clear();
                }
                else if ((con is ComboBox))
                {
                    ((ComboBox)con).Text = "";
                }
            }
        }


        void MakeGongDanSqlStr(String BianHao, string HeTong, string ChanPinMingCheng, string DingJin, string XingHao, string JinE, string KaiXiang, string YanSe, string KeHudiZhi, string DianHuan, string LianxiRen, string AnZhuangRiQi)
        {
            // string O="','";
            GongDanSqlStr = "insert into GongDan(BiaoShiMingCheng,HeTongBianHao,RiQi,ChanPinMingCheng,DingJin,XingHao,JinE,KaiXiang,YanSe,KeHuDiZhi,KeHuDianHua,LianXiRen ,AnZhuangRiQi) values('" + BianHao + O + HeTong + O + TxtDate.Text + O + ChanPinMingCheng + O + DingJin + O + XingHao + O + JinE + O + KaiXiang + O + YanSe + O + KeHudiZhi + O + DianHuan + O + LianxiRen + O + AnZhuangRiQi + "')";
        }
        void MakeCanShuDanSqlStr(string HeTong, string MenKuan, string MenGao, string MenShanWaiBan, string MenShanNeiBan)
        {
            // string O="','";
            CanShuDanSqlStr = "insert into CanShuDan(HeTongBianHao,LeiXing,XingHao,Gao,Kuan,MenGao,MenKuan,MenShanWaiBan,MenShanNeiBan) values('" + HeTong + O + CBoxType.Text + O + CBoxOpen.Text + O + TxtHigh.Text + O + TxtWidth.Text + O + MenKuan + O + MenGao + O + MenShanWaiBan + O + MenShanNeiBan + "')";
        }
        void MakeCanShuDanSqlStr(string HeTong, string MenKuan, string MenGao, string ZhuShanChengXingChiCun, string FuShanChengXingChiCun, string ZhuShanWaiBan, string ZhuShanNeiBan, string FuShanWaiBan, string FuShanNeiBan)
        {

            // string O="','";
            CanShuDanSqlStr = "insert into CanShuDan(HeTongBianHao,LeiXing,XingHao,Gao,Kuan,MenGao,MenKuan,ZhuShanChengXingChiCun,FuShanChengXingChiCun,ZhuShanWaiBan,ZhuShanNeiBan,FuShanWaiBan,FuShanNeiBan) values('" + HeTong + O + CBoxType.Text + O + CBoxOpen.Text + O + TxtHigh.Text + O + TxtWidth.Text + O + MenKuan + O + MenGao + O + ZhuShanChengXingChiCun + O + FuShanChengXingChiCun + O + ZhuShanWaiBan + O + ZhuShanNeiBan + O + FuShanWaiBan + O + FuShanNeiBan + "')";
        }

        void MakeLiaoDanSqlStr()
        {
            string[] tmpstr = MakeInsertValue();
            LiaoDanSqlStr = "INSERT INTO LiaoDan(" + tmpstr[0] + ") Values(" + tmpstr[1] + "')";
        }


        private void CboxProductName_DropDown(object sender, EventArgs e)
        {
            BindType(CboxProductName);
        }

        private void CboxProductName_DropDownClosed(object sender, EventArgs e)
        {
            CBoxType.SelectedIndex = CboxProductName.SelectedIndex;
            CBoxOpen.Text = "";

        }

        private void CBoxType_DropDownClosed(object sender, EventArgs e)
        {
            CboxProductName.SelectedIndex = CBoxType.SelectedIndex;
        }

        private void CBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBoxOpen.Text = "";
            if (CBoxType.Text != "")
            {
                PnlDemand.Controls.Clear();
                FillPnl();
            }
        }

        private void AddPnlItem(object sender, EventArgs e)
        {
            AddItem add = new AddItem();
            add.Type = CBoxType.Text;
            add.ShowDialog();
            FillPnl();

        }

        private void DelPnlItem(object sender, EventArgs e)
        {
            DelItem del = new DelItem();
            del.Type = CBoxType.Text;
            del.panel = PnlDemand;
            del.ShowDialog();
            FillPnl();
        }

        string[] MakeInsertValue()
        {
            string[] strValue = new string[2];
            strValue[0] += "HeTongBianHao";
            strValue[1] += "'" + TxtContractNu.Text;
            foreach (Control ctl in PnlDemand.Controls)
            {
                if (ctl is ComboBox)
                {
                    strValue[0] += "," + ((ComboBox)ctl).Name;
                    strValue[1] += "','" + ((ComboBox)ctl).Text;
                }
            }

            return strValue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (CheckControlTrim())
            {
                DialogResult result = MessageBox.Show("表单填写不完整,是否继续生成单据", "表单生成警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result != DialogResult.OK)
                {
                    return;
                }
                ResetControl();

            }


            DGrdWork.Rows.Clear();
            MakeWorkTable();


            int len;


            if ((len = CBoxOpen.Text.Trim().Length) > 0 && TxtHigh.Text.Trim() != "" && TxtWidth.Text.Trim() != "")
            {


                string Open = CBoxOpen.Text.Trim().Substring(len - 2);

                string StrType = CBoxType.Text.Trim();
                string StrOpen = CBoxOpen.Text.Trim();

                DGrdMaterial.Rows.Clear();
                switch (Open)
                {
                    case DanKai:
                        {
                            CalcDanKai(StrType, StrOpen);
                        }
                        break;
                    case SanQi:
                        {
                            CalcSanQi(StrType, StrOpen);
                        }
                        break;
                    case DuiKai:
                        {
                            CalcDuiKai(StrType, StrOpen);
                        }
                        break;
                    default:
                        break;
                }

                DGrdDemand.Rows.Clear();
                MakeDemandTable();
                MakeLiaoDanSqlStr();



            }



        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset(GboxWork);
            Reset(GboxMaterial);
            Reset(PnlDemand);


            DGrdDemand.Rows.Clear();
            DGrdWork.Rows.Clear();
            DGrdMaterial.Rows.Clear();
        }

        private void ReToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string db = Application.StartupPath + "\\DataBase\\LayingOff.accdb";
            string xml = Application.StartupPath + "\\XML\\Equation.xml";
            if (MessageBox.Show("本操作将删除所有数据,是否继续?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;

            try
            {
                File.Copy(Application.StartupPath + "\\reset\\XML\\Equation.xml", xml, true);
                File.Copy(Application.StartupPath + "\\reset\\DataBase\\LayingOff.accdb", db, true);
                MessageBox.Show("数据已初始化");
                FillPnl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {


            String info = "";
            if (CheckControlContext())
            {

                info = "有未完成的工单!!!!，您确定要退出吗";

            }
            else
            {
                info = "您确定要退出吗";

            }

            DialogResult result = MessageBox.Show(info, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result != DialogResult.OK)
            {
                e.Cancel = true;
            }

            ResetControl();

        }

        bool CheckControlContext()
        {
            int count = 0;

            foreach (Control cb in GboxWork.Controls)
            {

                if (cb is TextBox)
                {
                    TextBox tbox = (TextBox)cb;
                    if (tbox.Text.Trim() != "" && tbox.Name != "TxtDate")
                    {
                        cb.ForeColor = Color.Red;
                        count++;
                    }
                }
            }

            return count > 0;
        }


        bool CheckControlTrim()
        {
            int count = 0;
            foreach (Control cb in GboxWork.Controls)
            {

                if (cb is TextBox)
                {
                    TextBox tbox = (TextBox)cb;
                    if (tbox.Text.Trim() == "" && tbox.Name != "TxtDate")
                    {
                        count++;
                        cb.BackColor = Color.Red;
                    }
                }
            }


            if (TxtHigh.Text.Trim() == "")
            {
                TxtHigh.BackColor = Color.Red;
                count++;
            }

            if (TxtWidth.Text.Trim() == "")
            {
                TxtWidth.BackColor = Color.Red;
                count++;
            }
            return count > 0;
        }



        void ResetControl()
        {

            foreach (Control cb in GboxWork.Controls)
            {

                if (cb is TextBox)
                {
                    TextBox tbox = (TextBox)cb;
                    if (tbox.Text.Trim() != "")
                    {
                        cb.ForeColor = Color.Black;

                    }
                    cb.BackColor = Color.White;
                }
            }

            TxtWidth.BackColor = Color.White;
            TxtHigh.BackColor = Color.White;


        }


        private void TxtEarnestMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            JudgeNum(e);
        }

        private void TxtSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            JudgeNum(e);
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            JudgeNum(e);
        }

        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }




    }
}
