namespace WindowsFormsApplication1
{
    partial class zhuce_jiemian
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
            this.zhuce_zhanghao_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.mima_textbox2 = new System.Windows.Forms.TextBox();
            this.mima_textbox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zhuce_zhanghao_label
            // 
            this.zhuce_zhanghao_label.AutoSize = true;
            this.zhuce_zhanghao_label.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zhuce_zhanghao_label.Location = new System.Drawing.Point(19, 17);
            this.zhuce_zhanghao_label.Name = "zhuce_zhanghao_label";
            this.zhuce_zhanghao_label.Size = new System.Drawing.Size(0, 27);
            this.zhuce_zhanghao_label.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "请再次输入：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mima_textbox2
            // 
            this.mima_textbox2.Location = new System.Drawing.Point(156, 145);
            this.mima_textbox2.Name = "mima_textbox2";
            this.mima_textbox2.Size = new System.Drawing.Size(127, 21);
            this.mima_textbox2.TabIndex = 5;
            this.mima_textbox2.UseSystemPasswordChar = true;
            // 
            // mima_textbox1
            // 
            this.mima_textbox1.Location = new System.Drawing.Point(156, 105);
            this.mima_textbox1.Name = "mima_textbox1";
            this.mima_textbox1.Size = new System.Drawing.Size(127, 21);
            this.mima_textbox1.TabIndex = 6;
            this.mima_textbox1.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "请输入姓名：";
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(156, 180);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(127, 21);
            this.name_textBox.TabIndex = 8;
            this.name_textBox.UseSystemPasswordChar = true;
            // 
            // zhuce_jiemian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 261);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mima_textbox1);
            this.Controls.Add(this.mima_textbox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zhuce_zhanghao_label);
            this.Name = "zhuce_jiemian";
            this.Text = "zhuce_jiemian";
            this.Load += new System.EventHandler(this.zhuce_jiemian_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label zhuce_zhanghao_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox mima_textbox2;
        private System.Windows.Forms.TextBox mima_textbox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name_textBox;
    }
}