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
    public partial class zhuce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //验证是否存在该用户
                string sql = "select count(*) from users where username=@username";
                SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@username",TextBox1.Text.Trim())};
                if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                    Response.Write("该用户名已存在，请重新输入");
                else
                {
                    sql = "insert into users values(@username,@userpwd,@regtime,@lastlogintime,@islock,@email,@isopen)";
                    SqlParameter[] param2 = new SqlParameter[]
                    {
                        new SqlParameter("@username",SqlDbType.VarChar),
                        new SqlParameter("@userpwd",SqlDbType.VarChar),
                        new SqlParameter("@regtime",SqlDbType.DateTime),
                        new SqlParameter("@lastlogintime",SqlDbType.DateTime),
                        new SqlParameter("@islock",SqlDbType.Bit),
                        new SqlParameter("@email",SqlDbType.VarChar),
                        new SqlParameter("@isopen",SqlDbType.Bit)
                    };
                    //为sql参数赋值
                    param2[0].Value=TextBox1.Text;
                    param2[1].Value = TextBox2.Text;
                    param2[2].Value = System.DateTime.Now;
                    param2[3].Value = System.DateTime.Now;
                    param2[4].Value = 0;
                    param2[5].Value = TextBox4.Text;
                    param2[6].Value = CheckBox1.Checked;
                    if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param2) > 0)
                        Response.Write("注册成功！");
                    else
                        Response.Write("注册失败！");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), ex.Message, "<script language='javascript'>alert('注册错误!')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }
    }
}