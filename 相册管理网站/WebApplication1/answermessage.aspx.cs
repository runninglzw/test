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
    public partial class answermessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("main.aspx");
            if (!IsPostBack)
            {
                ViewState["back_no"] = 0;
            }
            ViewState["back_no"] = Convert.ToInt32(ViewState["back_no"]) + 1;
            TextBox1.Text = Request.QueryString["friendname"];
            TextBox2.Text=Request.QueryString["contents"];
            //Response.Write(Request.QueryString["friendname"] + Request.QueryString["contents"]);
        }
        //回复留言
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string from = Session["username"].ToString();
                string to = Request.QueryString["friendname"];
                string message = TextBox3.Text;
                //获得用户的email
                string sqlemail = "select email from users where username=@username";
                SqlParameter[] param0 = new SqlParameter[] 
                {
                new SqlParameter("@username",Session["username"].ToString())
                };
                string email = (string)sqlHelper.ExecuteScalar(sqlHelper.connectionstring, CommandType.Text, sqlemail, param0);

                string sql = "insert into talkmessage values(@myname,@friendname,@email,@talkdate,@ishandle,@contents)";
                SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@myname",to),
                new SqlParameter("@friendname",from),
                new SqlParameter("@email",email),
                new SqlParameter("@talkdate",DateTime.Now),
                new SqlParameter("@ishandle","0"),
                new SqlParameter("@contents",message)
                };
                Response.Write("123");
                if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('回复成功')</script>");
                }
                else
                    throw new Exception("回复失败！");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + ex.Message + "')</script>");
            }
        }
    }
}