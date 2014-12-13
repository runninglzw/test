namespace WindowsFormsApplication1
{
    partial class zhujiemian
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.guanliyuandenglu = new System.Windows.Forms.Button();
            this.yonghudenglu = new System.Windows.Forms.Button();
            this.form1label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guanliyuandenglu
            // 
            this.guanliyuandenglu.Location = new System.Drawing.Point(60, 66);
            this.guanliyuandenglu.Name = "guanliyuandenglu";
            this.guanliyuandenglu.Size = new System.Drawing.Size(166, 38);
            this.guanliyuandenglu.TabIndex = 0;
            this.guanliyuandenglu.Text = "管理员登陆";
            this.guanliyuandenglu.UseVisualStyleBackColor = true;
            this.guanliyuandenglu.Click += new System.EventHandler(this.guanliyuandenglu_Click);
            // 
            // yonghudenglu
            // 
            this.yonghudenglu.Location = new System.Drawing.Point(60, 140);
            this.yonghudenglu.Name = "yonghudenglu";
            this.yonghudenglu.Size = new System.Drawing.Size(166, 38);
            this.yonghudenglu.TabIndex = 1;
            this.yonghudenglu.Text = "用户登录";
            this.yonghudenglu.UseVisualStyleBackColor = true;
            this.yonghudenglu.Click += new System.EventHandler(this.yonghudenglu_Click);
            // 
            // form1label1
            // 
            this.form1label1.AutoSize = true;
            this.form1label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.form1label1.Location = new System.Drawing.Point(12, 19);
            this.form1label1.Name = "form1label1";
            this.form1label1.Size = new System.Drawing.Size(254, 31);
            this.form1label1.TabIndex = 2;
            this.form1label1.Text = "欢迎来到超市管理系统";
            // 
            // zhujiemian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.form1label1);
            this.Controls.Add(this.yonghudenglu);
            this.Controls.Add(this.guanliyuandenglu);
            this.Name = "zhujiemian";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zhujiemian_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button guanliyuandenglu;
        private System.Windows.Forms.Button yonghudenglu;
        private System.Windows.Forms.Label form1label1;
    }
}

