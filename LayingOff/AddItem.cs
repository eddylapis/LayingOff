using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LayingOff
{
    public partial class AddItem : Form
    {
        public string Type;
        public AddItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlProcess xml = new XmlProcess();
            DBProcess DB = new DBProcess();
            if (TxtAddName.Text == "") return;

            if (xml.ItemCount(Type, TxtAddName.Text) == 0)
            {
                DB.AlterTableAdd("add", TxtAddName.Text);
                MessageBox.Show("该字段为首次添加");

            }
            xml.AddItem(Type, TxtAddName.Text);
            TxtAddName.Text = "";
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            this.Text = Type + "添加列表项";
        }
    }
}
