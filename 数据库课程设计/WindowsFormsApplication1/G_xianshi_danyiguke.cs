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
    public partial class G_xianshi_dayiguke : Form
    {
        public G_xianshi_dayiguke()
        {
            InitializeComponent();
        }
        private string name=null;
        private void G_xianshi_danyiguke_Load(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            this.name = G_danyi_guke.name.Trim();
            //MessageBox.Show(name);
            string source = "server=(local) \\SQLEXPRESS;integrated security=SSPI;database=Market";
            SqlConnection con = new SqlConnection(source);//建立一个连接
            con.Open();//打开数据库
            if (con.State == ConnectionState.Open)//ConnectionState为枚举值，描述数据源的连接状态为打开
                Console.WriteLine("数据库连接成功！");
            //SqlDataAdapter sda = new SqlDataAdapter("selectdanyiguke",con);
            SqlCommand sc = new SqlCommand("selectgerenxinxi", con);
            //SqlDataAdapter sda = new SqlDataAdapter("selectgerenxinxi", con);
            sc.CommandType = CommandType.StoredProcedure;//这里SelectCommand就相当于SqlCommand（获取语句或存储过程）
            sc.Parameters.AddWithValue("@name", name);//和sqlcommand.parameters.addwithvalue()功能相同
            SqlDataReader reader = sc.ExecuteReader();
            if (reader.Read())
            {
                do
                    label2.Text += "customerid:" + reader[0] + "\n" + "name:" + reader[1] + "\n"+"address:"+reader[2]+"\n"+"city:"+reader[3]+"\n"+"tel:"+reader[4]+"\n"+"company:"+reader[5]+"\n"+"birthday:"+reader[6]+"\n"+"type:"+reader[7]+"\n";
                while (reader.Read());
            }
            else
            {
                MessageBox.Show("没有该顾客！");
                this.Close();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
