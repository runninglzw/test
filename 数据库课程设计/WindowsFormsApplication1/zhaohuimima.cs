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
    public partial class zhaohuimima : Form
    {
        public zhaohuimima()
        {
           // InitializeComponent();
        }
        public zhaohuimima(string id)
        {
            this.id = id;
            InitializeComponent();
        }
        public string getid()//获得id属性，以便后面修改密码用
        {
            return id;
        }
        string id;
        string source = "server=(local) \\SQLEXPRESS;database=users;integrated security=true";
        SqlConnection con;
        DataSet ds = new DataSet();
        SqlDataAdapter sda;
        string ans;
        private void zhaohuimima_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                string select = "select * from 密保问题";
                con = new SqlConnection(source);
                con.Open();
                sda = new SqlDataAdapter(select, con);
                sda.Fill(ds, "mibao");
                int flag = 0;
                foreach (DataRow x in ds.Tables["mibao"].Rows)
                {
                    if (x["id"].ToString().Trim() == this.id)
                    {
                        flag = 1;
                        textBox1.Text = x["question"].ToString().Trim();
                        ans = x["answer"].ToString().Trim();
                    }
                }
                if (flag == 0)
                {
                    MessageBox.Show("您的账号不存在！");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("请输入您的账号！");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == ans)
            {
                MessageBox.Show("申请成功 ！");
                zhaohuimima_update zhmm_up = new zhaohuimima_update();
                zhmm_up.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("回答错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
