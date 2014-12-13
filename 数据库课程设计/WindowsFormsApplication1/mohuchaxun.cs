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
    public partial class mohuchaxun : Form
    {
        public mohuchaxun()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(textBox1.Text);
            //MessageBox.Show(Convert.ToString(textBox1.Text == null));

            if (textBox1.Text.Trim() != string.Empty)
            {
                string name = textBox1.Text.Trim();
                string source = "server=(local) \\SQLEXPRESS;database=market;integrated security=true";
                SqlConnection sc = new SqlConnection(source);
                sc.Open();
                if (sc.State == ConnectionState.Open)
                    MessageBox.Show("数据库已连接！");
                SqlDataAdapter sda = new SqlDataAdapter("mohuchaxun", sc);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@name", name);
                //sda.SelectCommand.Parameters.AddWithValue("@low", 1);
                //sda.SelectCommand.Parameters.AddWithValue("@high", 100);
                DataSet ds = new DataSet();
                sda.Fill(ds, "mohu");
                dataGridView1.DataSource = ds.Tables["mohu"];
                dataGridView1.ReadOnly = true;
            }
            else
                MessageBox.Show("请输入信息！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
