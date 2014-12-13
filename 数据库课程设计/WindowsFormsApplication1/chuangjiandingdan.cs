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
    public partial class chuangjiandingdan : Form
    {
        public chuangjiandingdan()
        {
            InitializeComponent();
        }
        string source = "server=(local) \\SQLEXPRESS;database=market;integrated security=true";
        SqlConnection con;
        DataSet ds = new DataSet();
        SqlDataAdapter sda;
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(source);
            con.Open();
            string select1 = "select * from goods";
            sda = new SqlDataAdapter(select1, con);
            sda.Fill(ds, "goods");
            //此处必须新定义一个SqlDataAdapter，否则goods表会多一列customers表的cname（具体原因不清楚）
            SqlDataAdapter sda2 = new SqlDataAdapter("selectgerenxinxi", con);
            sda2.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda2.SelectCommand.Parameters.AddWithValue("@name", yonghuyanzhengjiemian.yonghuname);
            sda2.Fill(ds, "customers");
            foreach (DataRow x in ds.Tables["goods"].Rows)
            {
                if (x["goodsid"].ToString().Trim() == textBox1.Text && Convert.ToInt32(x["storage"]) >= Convert.ToInt32(textBox2.Text))
                {
                    int goodsid = Convert.ToInt32(textBox1.Text);
                    MessageBox.Show("商品编号：" + goodsid.ToString());
                    int customerid=0;
                    foreach (DataRow y in ds.Tables["customers"].Rows)
                    {
                        if (y["cname"].ToString().Trim() == yonghuyanzhengjiemian.yonghuname)
                        {
                            customerid = Convert.ToInt32(y["customerid"]);
                            break;
                        }
                    }
                    MessageBox.Show("会员编号：" + customerid.ToString());
                    int quantity = Convert.ToInt32(textBox2.Text);
                    MessageBox.Show("订单数量：" + quantity.ToString());
                    int ordersum = quantity * Convert.ToInt32(x["price"]);
                    MessageBox.Show(ordersum.ToString());
                    DateTime orderdate = DateTime.Now;
                    MessageBox.Show(orderdate.ToShortDateString());
                    SqlCommand com = new SqlCommand("insertorders", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@goodsid", goodsid);
                    com.Parameters.AddWithValue("@customerid", customerid);
                    com.Parameters.AddWithValue("@quantity", quantity);
                    //如果是c#中没有的类型要插入的话，必须用add方法指定类型
                    com.Parameters.Add(new SqlParameter("@ordersum", SqlDbType.Money));//此处用add方法将新的sql参数对象添加到参数集合中，并指定参数类型
                    com.Parameters["@ordersum"].Value = ordersum;
                    com.Parameters.Add(new SqlParameter("@orderdate", SqlDbType.DateTime));
                    com.Parameters["@orderdate"].Value = orderdate;//这里orderdate可以是任何类型，它最终会被转换为datetime类型的
                    com.ExecuteNonQuery();
                    
                    //将订单的订购数量从库存中减去，更新Goods表的Quantity值即可（利用DataSet["goods"]更新数据库）
                    x["storage"] = Convert.ToInt32(x["storage"]) - Convert.ToInt32(textBox2.Text);
                    MessageBox.Show("库存：" + x["storage"].ToString());
                    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                    sda.Update(ds, "goods");
                    MessageBox.Show("创建订单成功！");
                    //sda = new SqlDataAdapter("insertorders", con);
                    //sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                    //sda.InsertCommand.Parameters.AddWithValue("@goodsid", goodsid);
                    //sda.InsertCommand.Parameters.AddWithValue("@customerid", customerid);

                    //sda.InsertCommand.Parameters.AddWithValue("@quantity", quantity);
                    //sda.InsertCommand.Parameters.Add("@ordersum", SqlDbType.Money).Value = ordersum;
                    //sda.InsertCommand.Parameters.AddWithValue("@orderdate", SqlDbType.DateTime).Value = orderdate;
                    //sda.InsertCommand.ExecuteNonQuery();
                    //MessageBox.Show("成功！");
                    return;
                }
            }
            MessageBox.Show("没有该商品或商品库存不足！");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
