using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //登录
        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text.Trim(); //id值
            string mima = TextBox2.Text.Trim();//mima值
            //判断是否为空
            if (id == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "id为空！", "<script language='javascript'>alert('id不许为空！')</script>");
            }
            if (mima == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "密码为空！", "<script language='javascript'>alert('密码不许为空！')</script>");
            }
            try
            {
                //连接到数据库
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YonghuConnectionString"].ToString());//ConfigurationManager.ConnectionStrings["YonghuConnectionString"]为获取对配置文件中YonghuConnectionString标签的使用
                string sql = string.Format("select count(*) from yonghu where id='{0}' and mima='{1}'", id, mima);
                con.Open();
                //定义一个sql命令
                SqlCommand sc = new SqlCommand(sql, con);
                //执行定义好的sql命令
                int x = (int)sc.ExecuteScalar();
                if (x > 0)//如果x大于0则登录成功
                {
                    Response.Redirect("webform2.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "没有此用户", "<script language='javascript'>alert('id或密码输入有误！')</script>");
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), ex.Message, "<script language='javascript'>alert('ex.Message')</script>");
            }

        }
        //重置
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}