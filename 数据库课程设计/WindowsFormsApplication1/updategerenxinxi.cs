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
    public partial class updategerenxinxi : Form
    {
        public updategerenxinxi()
        {
            InitializeComponent();
        }
        string source = "server=(local) \\SQLEXPRESS;database=market;integrated security=true";
        //string source2 = "server=(local) \\SQLEXPRESS;database=users;integrated security=true";
        SqlConnection con;
        //SqlConnection con2;
        DataSet ds = new DataSet();
        //DataSet ds2 = new DataSet();
        SqlDataAdapter sda;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updategerenxinxi_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = false;
            con = new SqlConnection(source);
            con.Open();
            string name = yonghuyanzhengjiemian.yonghuname;
            //使用数据适配器调用存储过程
            sda = new SqlDataAdapter("selectgerenxinxi", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;//这里SelectCommand就相当于SqlCommand（获取语句或存储过程）
            sda.SelectCommand.Parameters.AddWithValue("@name", name);//和sqlcommand.parameters.addwithvalue()功能相同
            sda.Fill(ds, "yonghuxinxi2");
            dataGridView1.DataSource = ds.Tables["yonghuxinxi2"];
            dataGridView1.Columns[0].ReadOnly = true;//让dataGridView1控件中的第一列只读
            dataGridView1.Columns[1].ReadOnly = true;//让dataGridView1控件中的第二列只读
            int rows = dataGridView1.RowCount;
            dataGridView1.Rows[rows - 1].ReadOnly = true;//将空白行标记为只读，即不允许添加新行
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("是否保存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(ds, "yonghuxinxi2");
            }
        }
    }
}
