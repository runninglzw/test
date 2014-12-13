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
    public partial class G_xianshi_danyidingdan : Form
    {
        string name;
        public G_xianshi_danyidingdan()
        {
            InitializeComponent();
        }

        private void G_xianshi_danyidingdan_Load(object sender, EventArgs e)
        {
            this.name = G_danyi_dingdan.name.Trim();
            int orderid = Convert.ToInt32(name);
            //MessageBox.Show(name);
            string source = "server=(local) \\SQLEXPRESS;integrated security=SSPI;database=Market";
            SqlConnection con = new SqlConnection(source);//建立一个连接
            con.Open();//打开数据库
            if (con.State == ConnectionState.Open)//ConnectionState为枚举值，描述数据源的连接状态为打开
                Console.WriteLine("数据库连接成功！");
            //SqlDataAdapter sda = new SqlDataAdapter("selectdanyiguke",con);
            try
            {

                SqlCommand sc = new SqlCommand("selectdanyidingdan", con);
                //SqlDataAdapter sda = new SqlDataAdapter("selectgerenxinxi", con);
                sc.CommandType = CommandType.StoredProcedure;//这里SelectCommand就相当于SqlCommand（获取语句或存储过程）
                sc.Parameters.AddWithValue("@orderid", orderid);//和sqlcommand.parameters.addwithvalue()功能相同
                SqlDataReader reader = sc.ExecuteReader();
                if (reader.Read())
                {
                    do
                        label2.Text = "订单号:" + reader[0] + "\n" + "商品号:" + reader[1] + "\n" + "订货人编号:" + reader[2] + "\n" + "订单数量:" + reader[3] + "\n" + "订单总额:￥" + reader[4] + "\n" + "下单时间:" + reader[5] + "\n" ;
                    while (reader.Read());
                }
                else
                {

                    MessageBox.Show("没有该订单！");
                    this.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("error!");
            }
        }
    }
}
