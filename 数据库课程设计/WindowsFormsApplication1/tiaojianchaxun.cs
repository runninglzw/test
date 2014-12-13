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
    public partial class tiaojianchaxun : Form
    {
        public tiaojianchaxun()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                label1.Text = "-";
            }

            else
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Text = " ";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox3.Visible = true;
                textBox4.Visible = true;
                label2.Text = "-";
            }

            else
            {
                textBox3.Visible = false;
                textBox4.Visible = false;
                label2.Text = " ";
            }
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                try
                {
                    int plow = Convert.ToInt32(textBox1.Text);
                    int phigh = Convert.ToInt32(textBox2.Text);
                    int slow = Convert.ToInt32(textBox3.Text);
                    int shigh = Convert.ToInt32(textBox4.Text);
                    string source = "server=(local) \\SQLEXPRESS;database=market;integrated security=true";
                    SqlConnection sc = new SqlConnection(source);
                    sc.Open();
                    if (sc.State == ConnectionState.Open)
                    {
                        MessageBox.Show("数据库连接成功！");
                    }
                    SqlDataAdapter sda = new SqlDataAdapter("selectasall", sc);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@plow", plow);
                    sda.SelectCommand.Parameters.AddWithValue("@phigh", phigh);
                    sda.SelectCommand.Parameters.AddWithValue("@slow", slow);
                    sda.SelectCommand.Parameters.AddWithValue("@shigh", shigh);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "all");
                    dataGridView1.DataSource = ds.Tables["all"];
                    dataGridView1.ReadOnly = true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (checkBox1.Checked == true)
            {
                try
                {
                    int low = Convert.ToInt32(textBox1.Text);
                    int high = Convert.ToInt32(textBox2.Text);
                    string source = "server=(local) \\SQLEXPRESS;database=market;integrated security=true";
                    SqlConnection sc = new SqlConnection(source);
                    sc.Open();
                    if (sc.State == ConnectionState.Open)
                    {
                        MessageBox.Show("数据库连接成功！");
                    }
                    SqlDataAdapter sda = new SqlDataAdapter("selectasprice", sc);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@low", low);
                    sda.SelectCommand.Parameters.AddWithValue("@high", high);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "price");
                    dataGridView1.DataSource = ds.Tables["price"];
                    dataGridView1.ReadOnly = true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (checkBox2.Checked == true)
            {
                try
                {
                    int low = Convert.ToInt32(textBox3.Text);
                    int high = Convert.ToInt32(textBox4.Text);
                    string source = "server=(local) \\SQLEXPRESS;database=market;integrated security=true";
                    SqlConnection sc = new SqlConnection(source);
                    sc.Open();
                    if (sc.State == ConnectionState.Open)
                    {
                        MessageBox.Show("数据库连接成功！");
                    }
                    SqlDataAdapter sda = new SqlDataAdapter("selectasstorage", sc);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@low", low);
                    sda.SelectCommand.Parameters.AddWithValue("@high", high);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "storage");
                    dataGridView1.DataSource = ds.Tables["storage"];
                    dataGridView1.ReadOnly = true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("请选择查询条件！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
