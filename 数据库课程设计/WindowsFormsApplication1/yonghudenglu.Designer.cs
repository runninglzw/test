namespace WindowsFormsApplication1
{
    partial class yonghuyanzhengjiemian
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yonghumina_textbox = new System.Windows.Forms.TextBox();
            this.yonghuming_textbox = new System.Windows.Forms.TextBox();
            this.denglubutton = new System.Windows.Forms.Button();
            this.zhuce_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // yonghumina_textbox
            // 
            this.yonghumina_textbox.Location = new System.Drawing.Point(104, 109);
            this.yonghumina_textbox.Name = "yonghumina_textbox";
            this.yonghumina_textbox.Size = new System.Drawing.Size(165, 21);
            this.yonghumina_textbox.TabIndex = 2;
            this.yonghumina_textbox.UseSystemPasswordChar = true;
            // 
            // yonghuming_textbox
            // 
            this.yonghuming_textbox.Location = new System.Drawing.Point(104, 59);
            this.yonghuming_textbox.Name = "yonghuming_textbox";
            this.yonghuming_textbox.Size = new System.Drawing.Size(165, 21);
            this.yonghuming_textbox.TabIndex = 3;
            // 
            // denglubutton
            // 
            this.denglubutton.Location = new System.Drawing.Point(12, 185);
            this.denglubutton.Name = "denglubutton";
            this.denglubutton.Size = new System.Drawing.Size(69, 30);
            this.denglubutton.TabIndex = 4;
            this.denglubutton.Text = "登录";
            this.denglubutton.UseVisualStyleBackColor = true;
            this.denglubutton.Click += new System.EventHandler(this.denglubutton_Click);
            // 
            // zhuce_button
            // 
            this.zhuce_button.Location = new System.Drawing.Point(200, 185);
            this.zhuce_button.Name = "zhuce_button";
            this.zhuce_button.Size = new System.Drawing.Size(69, 30);
            this.zhuce_button.TabIndex = 5;
            this.zhuce_button.Text = "注册";
            this.zhuce_button.UseVisualStyleBackColor = true;
            this.zhuce_button.Click += new System.EventHandler(this.zhuce_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // yonghuyanzhengjiemian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zhuce_button);
            this.Controls.Add(this.denglubutton);
            this.Controls.Add(this.yonghuming_textbox);
            this.Controls.Add(this.yonghumina_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "yonghuyanzhengjiemian";
            this.Load += new System.EventHandler(this.yonghuyanzheng_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox yonghumina_textbox;
        private System.Windows.Forms.TextBox yonghuming_textbox;
        private System.Windows.Forms.Button denglubutton;
        private System.Windows.Forms.Button zhuce_button;
        private System.Windows.Forms.Button button1;
    }
}