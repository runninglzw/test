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
    public partial class dingdanxinxi : Form
    {
        public dingdanxinxi()
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
        private void dingdanxinxi_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            con = new SqlConnection(source);
            con.Open();
            string name = yonghuyanzhengjiemian.yonghuname;
            //使用数据适配器调用存储过程
            sda = new SqlDataAdapter("selectdingdanxinxi", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;//这里SelectCommand就相当于SqlCommand（获取语句或存储过程）
            sda.SelectCommand.Parameters.AddWithValue("@name", name);//和sqlcommand.parameters.addwithvalue()功能相同
            sda.Fill(ds, "dingdanxinxi");
            dataGridView1.DataSource = ds.Tables["dingdanxinxi"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
