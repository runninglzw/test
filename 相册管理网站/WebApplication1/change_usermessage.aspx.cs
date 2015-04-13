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
    public partial class change_usermessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            bool isopen = CheckBox1.Checked;
            string username = Session["username"].ToString();
            string sql = "update users set email=@email,isopen=@isopen where username=@username";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@email",email),
                new SqlParameter("@isopen",isopen),
                new SqlParameter("@username",username)
            };
            if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                Response.Write("修改成功！");
            else
                Response.Write("修改失败！");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("yonghu.aspx");
        }
    }
}