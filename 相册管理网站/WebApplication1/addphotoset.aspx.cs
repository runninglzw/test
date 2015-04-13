using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class addphotoset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string sql = "insert into photoset values(@username,@psname,@psconnect,@createtime,@pskey,@psstate)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username",username),
                new SqlParameter("@psname",TextBox1.Text),
                new SqlParameter("@psconnect",TextBox2.Text),
                new SqlParameter("@createtime",System.DateTime.Now),
                new SqlParameter("@pskey",TextBox3.Text),
                new SqlParameter("@psstate",1)
            };
            if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring,CommandType.Text,sql,param) > 0)
                Response.Write("添加成功！");
            else
                Response.Write("添加失败！");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("yonghu.aspx");
        }
    }
}