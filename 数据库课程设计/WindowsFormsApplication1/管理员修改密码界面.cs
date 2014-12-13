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
    public partial class 管理员修改密码界面 : Form
    {
        public 管理员修改密码界面()
        {
            InitializeComponent();
        }
        string source = "server=(local) \\SQLEXPRESS;database=users;integrated security=true";
        SqlConnection con;
        DataSet ds = new DataSet();
        //DataSet ds2=new DataSet();
        SqlDataAdapter sda;
        
        private void button1_Click(object sender, EventArgs e)
        {
            //两个窗体间的传值问题
            //guanliyuandenglu guan = (guanliyuandenglu)this.Owner;//这个窗体拥有guanliyuandenglu窗体的所有成员
            //textBox1.Text = ((TextBox)guan.Controls["guanlizhanghao_textBox1"]).Text;
            string select = "select * from 管理员";
            con = new SqlConnection(source);
            if (con.State == ConnectionState.Open)
                MessageBox.Show("数据库连接成功！");
            sda = new SqlDataAdapter(select, con);
            if (ds.Tables["管理员"] == null)
                sda.Fill(ds, "管理员");
            foreach (DataRow x in ds.Tables["管理员"].Rows)
            {
                if (textBox1.Text == x["mima"].ToString().Trim())//需要修改，如果管理员大于一个则else语句有问题
                {
                    x["mima"] = textBox2.Text;
                }
                else
                {
                    MessageBox.Show("初始密码输入错误！");
                }
            }
            if (textBox2.Text == textBox3.Text && textBox2.Text != null && textBox3.Text != null)
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(ds, "管理员");
                MessageBox.Show("密码修改成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("密码修改失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
