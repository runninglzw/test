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
    public partial class sendtalkmessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("main.aspx");
            if (!Page.IsPostBack) //是首次装载，不是回发
            {
                ViewState["back_no"] = 0; //隐藏的窗体字段ViewState，是页面级的
                //Response.Write("12345");
            }
            ViewState["back_no"] = Convert.ToInt32(ViewState["back_no"]) + 1;
            Label1.Text = Request.QueryString["friendname"];
            //获得用户的email
            string sql = "select email from users where username=@username";
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@username",Session["username"].ToString())
            };
            object email = sqlHelper.ExecuteScalar(sqlHelper.connectionstring, CommandType.Text, sql, param);
            TextBox1.Text = (string)email;

        }
        /// <summary>
        /// 保存留言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            string from = Session["username"].ToString();
            string to = Label1.Text;
            //string email = TextBox1.Text;
            string message =TextBox2.Text;
            //DateTime.Now
            string sql = "insert into talkmessage values(@myname,@friendname,@email,@talkdate,@ishandle,@contents)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@myname",to),
                new SqlParameter("@friendname",from),
                new SqlParameter("@email",TextBox1.Text),
                new SqlParameter("@talkdate",DateTime.Now),
                new SqlParameter("@ishandle","0"),
                new SqlParameter("@contents",message)
            };
            
            try
            {
                if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                {
                   //Response.Write("hahahah");
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('留言成功')</script>");
                }
                else
                    throw new Exception("留言失败！");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + ex.Message + "')</script>");
            }
        }
    }
}