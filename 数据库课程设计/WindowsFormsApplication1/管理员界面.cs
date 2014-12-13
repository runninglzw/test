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
    public partial class 管理员界面 : Form
    {
        public 管理员界面()
        {
            InitializeComponent();
        }
        string source = "server=(local) \\SQLEXPRESS;database=market;integrated security=true";
        SqlConnection con;
        DataSet ds=new DataSet();
        //DataSet ds2=new DataSet();
        SqlDataAdapter sda;
        private void 顾客信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查询所有顾客信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guanliyuan_dataGridView1.AllowUserToAddRows = true;
            guanliyuan_dataGridView1.AllowUserToDeleteRows = true;
            string select = "select * from customers";
            con = new SqlConnection(source);
            con.Open();
            if (con.State == ConnectionState.Open)
                MessageBox.Show("数据库连接成功！");
            sda = new SqlDataAdapter(select, con);
            if (ds.Tables["customers"] == null)
                sda.Fill(ds, "customers");
            guanliyuan_dataGridView1.DataSource = ds.Tables["customers"];
            }

        private void 查询所有商品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guanliyuan_dataGridView1.AllowUserToAddRows = true;
            guanliyuan_dataGridView1.AllowUserToDeleteRows = true;
            string select = "select goodsid,goodsname,price,description,storage,provider,status from goods";
            con = new SqlConnection(source);
            if (con.State == ConnectionState.Open)
                MessageBox.Show("数据库连接成功！");
            sda = new SqlDataAdapter(select, con);
            if(ds.Tables["goods"]==null)
                sda.Fill(ds, "goods");
            guanliyuan_dataGridView1.DataSource = ds.Tables["goods"];
        }

        private void 管理员界面_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void 管理员界面_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("是否关闭页面", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;//指示不应该取消事件，继续关闭
                //con.Close();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;//指示取消事件，停止关闭
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ds.Tables["customers"] != null || ds.Tables["goods"] != null || ds.Tables["orders"] != null)
            {
                DialogResult result = MessageBox.Show("是否保存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                    if (ds.Tables["customers"] != null)
                    { sda.Update(ds, "customers"); }
                    if (ds.Tables["goods"] != null)
                    { sda.Update(ds, "goods"); }
                    if (ds.Tables["orders"] != null)
                    { sda.Update(ds, "orders"); }
                }
            }
        }

        private void 查询所有订单信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guanliyuan_dataGridView1.AllowUserToAddRows = true;
            guanliyuan_dataGridView1.AllowUserToDeleteRows = true;
            string select = "select * from orders";
            con = new SqlConnection(source);
            if (con.State == ConnectionState.Open)
                MessageBox.Show("数据库连接成功！");
            sda = new SqlDataAdapter(select, con);
            if (ds.Tables["orders"] == null)
                sda.Fill(ds, "orders");
            guanliyuan_dataGridView1.DataSource = ds.Tables["orders"];
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理员修改密码界面 f = new 管理员修改密码界面();
            f.ShowDialog();
        }

        private void 设置密保问题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            password_question pq = new password_question();
            pq.ShowDialog();
        }

        private void 查询单一顾客信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_danyi_guke gdg = new G_danyi_guke();
            gdg.ShowDialog();
        }

        private void guanliyuan_dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 查询单一商品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_danyi_shangpin gds = new G_danyi_shangpin();
            gds.ShowDialog();
        }

        private void 查询单一订单信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_danyi_dingdan gdd = new G_danyi_dingdan();
            gdd.ShowDialog();
        }

        private void 管理员界面_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (guanliyuan_dataGridView1.SelectedRows != null)
            {
                foreach (DataGridViewRow row in guanliyuan_dataGridView1.SelectedRows)
                {
                    guanliyuan_dataGridView1.Rows.Remove(row);
                }
            }
        }
    }
}
