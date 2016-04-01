namespace LayingOff
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.CboxSearch = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGrdSearchWork = new System.Windows.Forms.DataGridView();
            this.BiaoShiMingCheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeTongBianHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RiQi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChanPinMingCheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DingJin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XingHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JinE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KaiXiang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YanSe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeHuDiZhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeHuDianHua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LianXiRen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnZhuangRiQi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrdSearchWork)).BeginInit();
            this.SuspendLayout();
            // 
            // CboxSearch
            // 
            this.CboxSearch.FormattingEnabled = true;
            this.CboxSearch.Location = new System.Drawing.Point(65, 23);
            this.CboxSearch.Name = "CboxSearch";
            this.CboxSearch.Size = new System.Drawing.Size(121, 20);
            this.CboxSearch.TabIndex = 1;
            this.CboxSearch.DropDown += new System.EventHandler(this.CboxSearch_DropDown);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(192, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "合同编号";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CboxSearch);
            this.groupBox1.Location = new System.Drawing.Point(5, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(992, 61);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(488, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "显示所有";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(393, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "导出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(287, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.DGrdSearchWork);
            this.groupBox2.Location = new System.Drawing.Point(6, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(991, 354);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工单";
            // 
            // DGrdSearchWork
            // 
            this.DGrdSearchWork.AllowUserToAddRows = false;
            this.DGrdSearchWork.AllowUserToDeleteRows = false;
            this.DGrdSearchWork.AllowUserToResizeColumns = false;
            this.DGrdSearchWork.AllowUserToResizeRows = false;
            this.DGrdSearchWork.BackgroundColor = System.Drawing.Color.White;
            this.DGrdSearchWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGrdSearchWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BiaoShiMingCheng,
            this.HeTongBianHao,
            this.RiQi,
            this.ChanPinMingCheng,
            this.DingJin,
            this.XingHao,
            this.JinE,
            this.KaiXiang,
            this.YanSe,
            this.KeHuDiZhi,
            this.KeHuDianHua,
            this.LianXiRen,
            this.AnZhuangRiQi,
            this.Column13});
            this.DGrdSearchWork.Location = new System.Drawing.Point(8, 20);
            this.DGrdSearchWork.Name = "DGrdSearchWork";
            this.DGrdSearchWork.ReadOnly = true;
            this.DGrdSearchWork.RowHeadersVisible = false;
            this.DGrdSearchWork.RowTemplate.Height = 23;
            this.DGrdSearchWork.Size = new System.Drawing.Size(973, 326);
            this.DGrdSearchWork.TabIndex = 2;
            this.DGrdSearchWork.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGrdSearchWork_CellClick);
            this.DGrdSearchWork.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGrdSearchWork_CellDoubleClick);
            // 
            // BiaoShiMingCheng
            // 
            this.BiaoShiMingCheng.DataPropertyName = "BiaoShiMingCheng";
            this.BiaoShiMingCheng.HeaderText = "标识名称";
            this.BiaoShiMingCheng.Name = "BiaoShiMingCheng";
            this.BiaoShiMingCheng.ReadOnly = true;
            // 
            // HeTongBianHao
            // 
            this.HeTongBianHao.DataPropertyName = "HeTongBianHao";
            this.HeTongBianHao.HeaderText = "合同编号";
            this.HeTongBianHao.Name = "HeTongBianHao";
            this.HeTongBianHao.ReadOnly = true;
            // 
            // RiQi
            // 
            this.RiQi.DataPropertyName = "RiQi";
            this.RiQi.HeaderText = "日期";
            this.RiQi.Name = "RiQi";
            this.RiQi.ReadOnly = true;
            // 
            // ChanPinMingCheng
            // 
            this.ChanPinMingCheng.DataPropertyName = "ChanPinMingCheng";
            this.ChanPinMingCheng.HeaderText = "产品名称";
            this.ChanPinMingCheng.Name = "ChanPinMingCheng";
            this.ChanPinMingCheng.ReadOnly = true;
            this.ChanPinMingCheng.Width = 60;
            // 
            // DingJin
            // 
            this.DingJin.DataPropertyName = "DingJin";
            this.DingJin.HeaderText = "定金";
            this.DingJin.Name = "DingJin";
            this.DingJin.ReadOnly = true;
            this.DingJin.Width = 60;
            // 
            // XingHao
            // 
            this.XingHao.DataPropertyName = "XingHao";
            this.XingHao.HeaderText = "型号";
            this.XingHao.Name = "XingHao";
            this.XingHao.ReadOnly = true;
            this.XingHao.Width = 60;
            // 
            // JinE
            // 
            this.JinE.DataPropertyName = "JinE";
            this.JinE.HeaderText = "金额";
            this.JinE.Name = "JinE";
            this.JinE.ReadOnly = true;
            this.JinE.Width = 60;
            // 
            // KaiXiang
            // 
            this.KaiXiang.DataPropertyName = "KaiXiang";
            this.KaiXiang.HeaderText = "开向";
            this.KaiXiang.Name = "KaiXiang";
            this.KaiXiang.ReadOnly = true;
            this.KaiXiang.Width = 60;
            // 
            // YanSe
            // 
            this.YanSe.DataPropertyName = "YanSe";
            this.YanSe.HeaderText = "颜色";
            this.YanSe.Name = "YanSe";
            this.YanSe.ReadOnly = true;
            this.YanSe.Width = 40;
            // 
            // KeHuDiZhi
            // 
            this.KeHuDiZhi.DataPropertyName = "KeHuDiZhi";
            this.KeHuDiZhi.HeaderText = "客户地址";
            this.KeHuDiZhi.Name = "KeHuDiZhi";
            this.KeHuDiZhi.ReadOnly = true;
            // 
            // KeHuDianHua
            // 
            this.KeHuDianHua.DataPropertyName = "KeHuDianHua";
            this.KeHuDianHua.HeaderText = "客户电话";
            this.KeHuDianHua.Name = "KeHuDianHua";
            this.KeHuDianHua.ReadOnly = true;
            this.KeHuDianHua.Width = 90;
            // 
            // LianXiRen
            // 
            this.LianXiRen.DataPropertyName = "LianXiRen";
            this.LianXiRen.HeaderText = "联系人";
            this.LianXiRen.Name = "LianXiRen";
            this.LianXiRen.ReadOnly = true;
            this.LianXiRen.Width = 60;
            // 
            // AnZhuangRiQi
            // 
            this.AnZhuangRiQi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AnZhuangRiQi.DataPropertyName = "AnZhuangRiQi";
            this.AnZhuangRiQi.HeaderText = "安装日期";
            this.AnZhuangRiQi.Name = "AnZhuangRiQi";
            this.AnZhuangRiQi.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Id";
            this.Column13.HeaderText = "Id";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(999, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SearchForm";
            this.Text = "查找";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGrdSearchWork)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CboxSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DGrdSearchWork;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn BiaoShiMingCheng;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeTongBianHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn RiQi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChanPinMingCheng;
        private System.Windows.Forms.DataGridViewTextBoxColumn DingJin;
        private System.Windows.Forms.DataGridViewTextBoxColumn XingHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn JinE;
        private System.Windows.Forms.DataGridViewTextBoxColumn KaiXiang;
        private System.Windows.Forms.DataGridViewTextBoxColumn YanSe;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeHuDiZhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeHuDianHua;
        private System.Windows.Forms.DataGridViewTextBoxColumn LianXiRen;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnZhuangRiQi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}