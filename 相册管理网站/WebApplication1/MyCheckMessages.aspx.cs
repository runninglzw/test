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
    public partial class MyCheckMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("main.aspx");
            }
            string op = Request.QueryString["op"];
            string fromname = Request.QueryString["fromname"];
            string message = Request.QueryString["message"];
            //如果为同意，则把该好友插入到自己的好友列表中，同时将该好友的好友列表插入自己
            if (op!=null&&op.Equals("agree"))
            {
                try
                {
                    string sql = "select count(*) from friendslist where myname=@myname and myfriends=@myfriends";
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@myname",Session["username"]),
                        new SqlParameter("@myfriends",fromname)
                    };
                    if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                    {
                        throw new Exception("该用户已经在您的好友列表！");
                    }
                    string insertsql = "insert into friendslist values(@myname,@myfriends)";
                    string updatesql = "update checkmessages set ishandle='1' where toname=@toname";
                    SqlParameter[] insertparam1 = new SqlParameter[]
                    {
                    new SqlParameter("@myname",Session["username"]),
                    new SqlParameter("@myfriends",fromname)
                    };
                    SqlParameter[] insertparam2 = new SqlParameter[]
                    {
                    new SqlParameter("@myname",fromname),
                    new SqlParameter("@myfriends",Session["username"])
                    };
                    SqlParameter[] updateparam = new SqlParameter[]
                    {
                    new SqlParameter("@toname",Session["username"])
                    };
 
                    //双向插入好友列表并且更新验证消息的状态为已经处理
                    if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, insertsql, insertparam1) > 0 && sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, insertsql, insertparam2) > 0 && sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, updatesql, updateparam) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('好友添加成功！')</script>");
                    }
                    else
                    {
                        throw new Exception("好友添加失败");
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('" + ex.Message + "')</script>");
                }
            }
            else if (op != null && op.Equals("ignore"))
            {
                try
                {
                    string sql = "update checkmessages set ishandle='1' where toname=@toname";
                    SqlParameter[] param = new SqlParameter[]
                    {
                    new SqlParameter("@toname",Session["username"])
                    };

                    sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param);
                }

                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('" + ex.Message + "')</script>");
                }
            }
        }
    }
}