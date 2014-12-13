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
    public partial class yonghuxiugaimima : Form
    {
        public yonghuxiugaimima()
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
            string select = "select * from yonghu";
            con = new SqlConnection(source);
            if (con.State == ConnectionState.Open)
                MessageBox.Show("数据库连接成功！");
            sda = new SqlDataAdapter(select, con);
            //if (ds.Tables["yonghu"] == null)
            sda.Fill(ds, "yonghu");
            int flag = 0;
            foreach (DataRow x in ds.Tables["yonghu"].Rows)
            {
                if (textBox1.Text == x["mima"].ToString().Trim())
                {
                    flag = 1;
                    x["mima"] = textBox2.Text;
                }
            }
            if (flag == 1)
            {
                if (textBox2.Text == textBox3.Text && textBox2.Text != null && textBox3.Text != null)
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                    sda.Update(ds, "yonghu");
                    MessageBox.Show("密码修改成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码修改失败！");
                }
            }
            else
            {
                MessageBox.Show("初始密码错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
