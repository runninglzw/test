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
    public partial class yonghubangding : Form
    {
        public yonghubangding()
        {
            InitializeComponent();
        }
        string source = "server=(local) \\SQLEXPRESS;database=market;integrated security=true";
        string source2 = "server=(local) \\SQLEXPRESS;database=users;integrated security=true";
        SqlConnection con;
        SqlConnection con2;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        SqlDataAdapter sda;
        private void button1_Click(object sender, EventArgs e)
        {
            string select = "select cname from customers";
            con = new SqlConnection(source);
            con.Open();
            if (con.State == ConnectionState.Open)
                MessageBox.Show("数据库连接成功！");
            sda = new SqlDataAdapter(select, con);
            sda.Fill(ds,"name");
            //MessageBox.Show("lalala！");
            int flag = 0;//判断customers中是否有输入的姓名
            foreach(DataRow x in ds.Tables["name"].Rows)
            {
                if (textBox1.Text == x["cname"].ToString().Trim())
                {
                    flag = 1;//有的话赋值为1
                    MessageBox.Show("有这个姓名！");
                    con2 = new SqlConnection(source2);
                    string select2 = "select * from yonghu";
                    sda = new SqlDataAdapter(select2, con2);
                    sda.Fill(ds2, "yonghu");
                    foreach (DataRow y in ds2.Tables["yonghu"].Rows)
                    {
                        if (y["id"].ToString().Trim() == yonghuyanzhengjiemian.yonghuid)
                        {
                            y["name"] = textBox1.Text;
                            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                            sda.Update(ds2, "yonghu");
                            yonghuyanzhengjiemian.yonghuname = textBox1.Name.Trim();//保存用户名字，方便以后的查询用户个人信息等操作
                            MessageBox.Show("会员绑定成功！");
                            //yonghuyanzhengjiemian.yonghuname=
                            yuhujiemian yh = new yuhujiemian();
                            yh.ShowDialog();
                        }
                    }
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("你还不是会员！请联系管理员");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
