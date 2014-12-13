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
    public partial class zhaohuimima_update : Form
    {
        public zhaohuimima_update()
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
            if (textBox1.Text == textBox2.Text && textBox1.Text != null)
            {
                con = new SqlConnection(source);
                con.Open();
                SqlCommand com = new SqlCommand("updatemima", con);
                com.CommandType = CommandType.StoredProcedure;
                //zhaohuimima f = new zhaohuimima();
                //string id = f.getid();
                com.Parameters.AddWithValue("@id",zhaohuimima_shuruzhanghao.id);
                com.Parameters.AddWithValue("@mima", textBox1.Text);
                com.ExecuteNonQuery();
                MessageBox.Show("密码重设成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("密码不能为空或两次密码输入不一致！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
