namespace WindowsFormsApplication1
{
    partial class 管理员界面
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.顾客信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询所有顾客信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询单一顾客信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询所有商品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询单一商品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.订单信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询所有订单信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询单一订单信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.密码管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置密保问题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guanliyuan_dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guanliyuan_dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.顾客信息ToolStripMenuItem,
            this.商品信息ToolStripMenuItem,
            this.订单信息ToolStripMenuItem,
            this.密码管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(322, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 顾客信息ToolStripMenuItem
            // 
            this.顾客信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询所有顾客信息ToolStripMenuItem,
            this.查询单一顾客信息ToolStripMenuItem});
            this.顾客信息ToolStripMenuItem.Name = "顾客信息ToolStripMenuItem";
            this.顾客信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.顾客信息ToolStripMenuItem.Text = "顾客信息";
            this.顾客信息ToolStripMenuItem.Click += new System.EventHandler(this.顾客信息ToolStripMenuItem_Click);
            // 
            // 查询所有顾客信息ToolStripMenuItem
            // 
            this.查询所有顾客信息ToolStripMenuItem.Name = "查询所有顾客信息ToolStripMenuItem";
            this.查询所有顾客信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查询所有顾客信息ToolStripMenuItem.Text = "查询所有顾客信息";
            this.查询所有顾客信息ToolStripMenuItem.Click += new System.EventHandler(this.查询所有顾客信息ToolStripMenuItem_Click);
            // 
            // 查询单一顾客信息ToolStripMenuItem
            // 
            this.查询单一顾客信息ToolStripMenuItem.Name = "查询单一顾客信息ToolStripMenuItem";
            this.查询单一顾客信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查询单一顾客信息ToolStripMenuItem.Text = "查询单一顾客信息";
            this.查询单一顾客信息ToolStripMenuItem.Click += new System.EventHandler(this.查询单一顾客信息ToolStripMenuItem_Click);
            // 
            // 商品信息ToolStripMenuItem
            // 
            this.商品信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询所有商品信息ToolStripMenuItem,
            this.查询单一商品信息ToolStripMenuItem});
            this.商品信息ToolStripMenuItem.Name = "商品信息ToolStripMenuItem";
            this.商品信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.商品信息ToolStripMenuItem.Text = "商品信息";
            // 
            // 查询所有商品信息ToolStripMenuItem
            // 
            this.查询所有商品信息ToolStripMenuItem.Name = "查询所有商品信息ToolStripMenuItem";
            this.查询所有商品信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查询所有商品信息ToolStripMenuItem.Text = "查询所有商品信息";
            this.查询所有商品信息ToolStripMenuItem.Click += new System.EventHandler(this.查询所有商品信息ToolStripMenuItem_Click);
            // 
            // 查询单一商品信息ToolStripMenuItem
            // 
            this.查询单一商品信息ToolStripMenuItem.Name = "查询单一商品信息ToolStripMenuItem";
            this.查询单一商品信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查询单一商品信息ToolStripMenuItem.Text = "查询单一商品信息";
            this.查询单一商品信息ToolStripMenuItem.Click += new System.EventHandler(this.查询单一商品信息ToolStripMenuItem_Click);
            // 
            // 订单信息ToolStripMenuItem
            // 
            this.订单信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询所有订单信息ToolStripMenuItem,
            this.查询单一订单信息ToolStripMenuItem});
            this.订单信息ToolStripMenuItem.Name = "订单信息ToolStripMenuItem";
            this.订单信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.订单信息ToolStripMenuItem.Text = "订单信息";
            // 
            // 查询所有订单信息ToolStripMenuItem
            // 
            this.查询所有订单信息ToolStripMenuItem.Name = "查询所有订单信息ToolStripMenuItem";
            this.查询所有订单信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查询所有订单信息ToolStripMenuItem.Text = "查询所有订单信息";
            this.查询所有订单信息ToolStripMenuItem.Click += new System.EventHandler(this.查询所有订单信息ToolStripMenuItem_Click);
            // 
            // 查询单一订单信息ToolStripMenuItem
            // 
            this.查询单一订单信息ToolStripMenuItem.Name = "查询单一订单信息ToolStripMenuItem";
            this.查询单一订单信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查询单一订单信息ToolStripMenuItem.Text = "查询单一订单信息";
            this.查询单一订单信息ToolStripMenuItem.Click += new System.EventHandler(this.查询单一订单信息ToolStripMenuItem_Click);
            // 
            // 密码管理ToolStripMenuItem
            // 
            this.密码管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改密码ToolStripMenuItem,
            this.设置密保问题ToolStripMenuItem});
            this.密码管理ToolStripMenuItem.Name = "密码管理ToolStripMenuItem";
            this.密码管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.密码管理ToolStripMenuItem.Text = "密码管理";
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 设置密保问题ToolStripMenuItem
            // 
            this.设置密保问题ToolStripMenuItem.Name = "设置密保问题ToolStripMenuItem";
            this.设置密保问题ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置密保问题ToolStripMenuItem.Text = "设置密保问题";
            this.设置密保问题ToolStripMenuItem.Click += new System.EventHandler(this.设置密保问题ToolStripMenuItem_Click);
            // 
            // guanliyuan_dataGridView1
            // 
            this.guanliyuan_dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guanliyuan_dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.guanliyuan_dataGridView1.Name = "guanliyuan_dataGridView1";
            this.guanliyuan_dataGridView1.RowTemplate.Height = 23;
            this.guanliyuan_dataGridView1.Size = new System.Drawing.Size(314, 230);
            this.guanliyuan_dataGridView1.TabIndex = 1;
            this.guanliyuan_dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guanliyuan_dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "保存修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 264);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "删除选中行";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 管理员界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 299);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.guanliyuan_dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "管理员界面";
            this.Text = "管理员界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.管理员界面_FormClosing);
            this.Load += new System.EventHandler(this.管理员界面_Load);
            this.ResizeBegin += new System.EventHandler(this.管理员界面_ResizeBegin);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guanliyuan_dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 顾客信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询所有顾客信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询单一顾客信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询所有商品信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询单一商品信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 订单信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询所有订单信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询单一订单信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 密码管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置密保问题ToolStripMenuItem;
        private System.Windows.Forms.DataGridView guanliyuan_dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}