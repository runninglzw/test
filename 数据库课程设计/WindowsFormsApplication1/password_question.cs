using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class password_question : Form
    {
        public password_question()
        {
            InitializeComponent();
        }
        string source = "server=(local) \\SQLEXPRESS;database=users;integrated security=true";
        SqlConnection con;
        DataSet ds = new DataSet();
        SqlDataAdapter sda;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {
                string select = "select * from 密保问题";
                con = new SqlConnection(source);
                con.Open();
                if (con.State == ConnectionState.Open)
                    MessageBox.Show("数据库连接成功！");
                sda = new SqlDataAdapter(select, con);
                if (ds.Tables["密保问题"] == null)
                    sda.Fill(ds, "密保问题");
                //两个窗体间的传值问题
               
                //guanliyuandenglu guan = (guanliyuandenglu)this.Owner;//这个窗体拥有guanliyuandenglu窗体的所有成员
                int flag = 0;
                foreach (DataRow x in ds.Tables["密保问题"].Rows)
                {
                    
                    if (x["id"].ToString().Trim() == guanliyuandenglu.id) ;
                    {
                        flag = 1;
                        DialogResult result = MessageBox.Show("是否替换密保问题？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            x["question"] = textBox1.Text;
                            x["answer"] = textBox2.Text;
                            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                            sda.Update(ds, "密保问题");
                            MessageBox.Show("替换成功！");
                            this.Close();
                        }
                    }
                }
                if (flag == 0)
                {
                    DialogResult result2 = MessageBox.Show("是否保存密保问题？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result2 == DialogResult.Yes)
                    {
                        DataRow r = ds.Tables["密保问题"].NewRow();
                        r["id"] = guanliyuandenglu.id;
                        r["question"] = textBox1.Text;
                        r["answer"] = textBox2.Text;
                        ds.Tables["密保问题"].Rows.Add(r);
                        SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                        sda.Update(ds, "密保问题");
                        MessageBox.Show("保存成功！");
                        this.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
