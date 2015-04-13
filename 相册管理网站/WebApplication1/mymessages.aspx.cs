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
    public partial class mymessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("main.aspx");
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string commandname = e.CommandName;
            //获取参数字符串
            string argument = e.CommandArgument.ToString();
            string[] args = argument.Split('|');
            //回复留言
            if (commandname == "answer")
            {
                Response.Redirect(string.Format("answermessage.aspx?friendname={0}&contents={1}",args[0],args[1]));
            }
                //忽略留言
            else if (commandname == "ignore")
            {
                try
                {
                    string sql = "update talkmessage set ishandle='1' where friendname=@friendname and contents=@contents and myname=@myname";
                    SqlParameter[] param = new SqlParameter[]
                    {
                    new SqlParameter("@myname",Session["username"]),
                    new SqlParameter("@friendname",args[0]),
                    new SqlParameter("@contents",args[1])
                    };

                    sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param);
                    ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('该留言已被忽略')</script>");
                    Response.Redirect("mymessages.aspx");
                }

                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('" + ex.Message + "')</script>");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("yonghu.aspx");
        }
    }
}