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
    public partial class G_xianshi_danyishangpin : Form
    {
        string name;
        public G_xianshi_danyishangpin()
        {
            InitializeComponent();
        }

        private void G_xianshi_danyishangpin_Load(object sender, EventArgs e)
        {
            this.name = G_danyi_shangpin.name.Trim();
            //MessageBox.Show(name);
            string source = "server=(local) \\SQLEXPRESS;integrated security=SSPI;database=Market";
            SqlConnection con = new SqlConnection(source);//建立一个连接
            con.Open();//打开数据库
            if (con.State == ConnectionState.Open)//ConnectionState为枚举值，描述数据源的连接状态为打开
                Console.WriteLine("数据库连接成功！");
            //SqlDataAdapter sda = new SqlDataAdapter("selectdanyiguke",con);
            try
            {

                SqlCommand sc = new SqlCommand("selectdanyishangpin", con);
                //SqlDataAdapter sda = new SqlDataAdapter("selectgerenxinxi", con);
                sc.CommandType = CommandType.StoredProcedure;//这里SelectCommand就相当于SqlCommand（获取语句或存储过程）
                sc.Parameters.AddWithValue("@name", name);//和sqlcommand.parameters.addwithvalue()功能相同
                SqlDataReader reader = sc.ExecuteReader();
                if (reader.Read())
                {
                    do
                        label2.Text = "goodsrid:" + reader[0] + "\n" + "goodsname:" + reader[1] + "\n" + "price:" + reader[2] + "\n" + "description:" + reader[3] + "\n" + "storage:" + reader[4] + "\n" + "provider:" + reader[5] + "\n" + "status:" + reader[6] + "\n";
                    while (reader.Read());
                }
                else
                {

                    MessageBox.Show("没有该商品！");
                    this.Close();
                } 
            }
            catch(SqlException)
            {
                MessageBox.Show("error!");
            }
        }
    }
}
