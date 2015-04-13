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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox3.Text.Trim().ToLower() != Session["ValidNums"].ToString())
                {
                    throw new Exception("验证码错误");
                }
                string username = TextBox1.Text.Trim();
                string userpwd = TextBox2.Text.Trim();
                string sql = "select count(*) from users where username=@username and userpwd=@userpwd and islock=0";
                SqlParameter[] param =
            {
                new SqlParameter("@username",username),
                new SqlParameter("@userpwd",userpwd)
            };
                //ClientScript.RegisterStartupScript(this.GetType(), "s", "<script language='javascript'>alert('登录出错1!')</script>");
                int result = (int)sqlHelper.ExecuteScalar(sqlHelper.connectionstring, CommandType.Text, sql, param);
                //ClientScript.RegisterStartupScript(this.GetType(), "s", "<script language='javascript'>alert('登录出错2!')</script>");
                //登录成功
                if (result > 0)
                {
                    Session["username"] = username;
                    //更新用户的最后登录时间
                    sql = "update users set lastlogintime=getdate() where username=@username";
                    SqlParameter[] param2 = new SqlParameter[]
                {
                    new SqlParameter("@username",username)
                };
                    sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param2);
                    Response.Redirect("yonghu.aspx");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "验证码错误")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), ex.Message, "<script language='javascript'>alert('验证码出错!')</script>");
                }
                //显示错误信息
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), ex.Message, "<script language='javascript'>alert('登录出错!')</script>");
                }
            }
        }
    }
}