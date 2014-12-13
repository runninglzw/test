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
    public partial class zhuce_jiemian : Form
    {
        public zhuce_jiemian()
        {
            InitializeComponent();
        }
        string id;
        private void zhuce_jiemian_Load(object sender, EventArgs e)
        {
            zhuce_zhanghao_label.Text = "您的账号为：";
            Random ra=new Random();//定义一个随机种子
            int i=ra.Next();//获得随机种子数
            id = i.ToString();
            zhuce_zhanghao_label.Text += id;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mima_textbox1.Text == null )
                MessageBox.Show("密码不能为空！");
            if (mima_textbox1.Text == mima_textbox2.Text)
            {
                if (mima_textbox1.Text == null || mima_textbox2.Text == null || name_textBox.Text == null)
                    MessageBox.Show("密码不能为空！");
                else
                {
                    string source = "server=(local) \\SQLEXPRESS;database=users;integrated security=true";
                    SqlConnection con = new SqlConnection(source);
                    con.Open();
                    if (con.State == ConnectionState.Open)
                        MessageBox.Show("数据库连接成功！");
                    SqlCommand sc = new SqlCommand("insertyonghu", con);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@mima", mima_textbox2.Text);
                    sc.Parameters.AddWithValue("@name", name_textBox.Text);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("账号申请成功！");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("两次密码输入不符，请重新输入！");
            }
        }
    }
}
