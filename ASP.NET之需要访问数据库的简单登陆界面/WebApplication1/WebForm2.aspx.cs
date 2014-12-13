using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YonghuConnectionString"].ToString());//ConfigurationManager.ConnectionStrings["YonghuConnectionString"]为获取对配置文件中YonghuConnectionString标签的使用
            con.Open();
            string sql = "select * from yonghu";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "yonghu");
            GridView1.DataSource = ds.Tables["yonghu"];
            GridView1.DataBind();
        }
    }
}