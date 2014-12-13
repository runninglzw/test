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
    public partial class guanliyuandenglu : Form
    {
        public guanliyuandenglu()
        {
            InitializeComponent();
        }
        public static string id;//将管理员账号保存到id中
        private void button1_Click(object sender, EventArgs e)
        {
            //id = guanlizhanghao_textBox1.Text;
            string source = "server=(local) \\SQLEXPRESS;database=users;integrated security=SSPI";
            SqlConnection con = new SqlConnection(source);
            con.Open();//打开数据库
            if (con.State == ConnectionState.Open)
                MessageBox.Show("数据库连接成功！");
            string select = "select * from 管理员";
            SqlDataAdapter sda = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "guanliyuan");
            //MessageBox.Show("正在匹配");
            int flag = 0;//设置一个标记，判断用户是否登录成功
            foreach (DataRow x in ds.Tables["guanliyuan"].Rows)
            {
                //MessageBox.Show("正在匹配");
                if (guanlizhanghao_textBox1.Text == x["id"].ToString().Trim() && guanlimima_textbox2.Text == x["mima"].ToString().Trim())
                {
                    id = guanlizhanghao_textBox1.Text;
                    //MessageBox.Show("以匹配！");
                    con.Close();
                    flag = 1;
                    管理员界面 f = new 管理员界面();
                    f.ShowDialog();
                }
            }
            if (flag == 0)//如果没有登录成功，则显示
            {
                MessageBox.Show("账号或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guanliyuandenglu_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            zhaohuimima_shuruzhanghao f = new zhaohuimima_shuruzhanghao();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
