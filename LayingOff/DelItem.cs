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
    public partial class DelItem : Form
    {
        public string Type;
        public Panel panel;
        XmlProcess xml = new XmlProcess();

        public DelItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBProcess DB = new DBProcess();
            if (xml.ItemCount(Type,CboxDel.Text) == 1)
            {
                DB.AlterTableAdd("del", CboxDel.Text);
                MessageBox.Show("该字段已在表内删除");

            }

            Control[] colLbl = new Control[1];
            Control[] colCbo = new Control[1];
            if ((colLbl = panel.Controls.Find("Lbl" + CboxDel.Text, false)).Count() > 0 &&(colCbo = panel.Controls.Find(CboxDel.Text, false)).Count() >0)
            {
                colLbl[0].Dispose();
                colCbo[0].Dispose();
              //  MessageBox.Show("del find");

            }


            xml.DelItem(Type, CboxDel.Text);
            CboxDel.Text = "";
            
        }

        private void CboxDel_DropDown(object sender, EventArgs e)
        {
            CboxDel.Items.Clear();
            foreach(XmlNode node in xml.GetXml().SelectSingleNode("CONTROLS//"+Type).ChildNodes)
            {
                CboxDel.Items.Add(xml.DelF(node.Name));
            }
        }

        private void DelItem_Load(object sender, EventArgs e)
        {
            this.Text = Type + "删除列表项";
        }
    }
}
