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
    public partial class changepwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void ChangePassword1_ChangingPassword(object sender, LoginCancelEventArgs e)
        {
            e.Cancel = true;
            string oldpwd = ChangePassword1.CurrentPassword;
            string newpwd = ChangePassword1.NewPassword;
            string username = Session["username"].ToString();
            string sql = "select count(*) from users where username=@username and userpwd=@userpwd";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username",username),
                new SqlParameter("@userpwd",oldpwd)
            };
            if ((int)sqlHelper.ExecuteScalar(sqlHelper.connectionstring, CommandType.Text, sql, param) <= 0)
                Response.Write("旧密码错误！");
            else
            {
                sql = "update users set userpwd=@userpwd where username=@username";
                SqlParameter[] param2 = new SqlParameter[]
                {
                    new SqlParameter("@username",username),
                    new SqlParameter("@userpwd",newpwd)
                };
                if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param2) > 0)
                    Response.Write("修改成功！");
                else
                    Response.Write("修改失败！");
            }
        }
    }
}