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
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("main.aspx");
            Label1.Text = Request.QueryString["name"];
        }
        /// <summary>
        /// 返回上一级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFriend.aspx");
        }
        /// <summary>
        /// 发送验证消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string from = Session["username"].ToString();
            string to = Label1.Text;
            string message = null;
            if (TextBox1.Text == "")
            {
                message = "对方请求加你为好友";
            }
            else
            {
                message = TextBox1.Text;
            }
            string sql = "insert into checkmessages values(@from,@to,@message,@ishandle)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@from",from),
                new SqlParameter("@to",to),
                new SqlParameter("@message",message),
                new SqlParameter("@ishandle","0")
            };
            try
            {
                if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('发送成功，等待对方回复')</script>");
                }
                else
                    throw new Exception("消息发送失败！");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('" + ex.Message + "')</script>");
            }
        }
    }
}