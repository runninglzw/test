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
    public partial class SearchFriend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("main.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("yonghu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string sql = "select username,email from users where username=@username";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username",TextBox1.Text)
            };
            
            //ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('''+ex.Message+''')</script>");
            try
            {
                if (TextBox1.Text == "")
                {
                    throw new Exception("查询不能为空");
                }
                string name=null, email=null;
                if (TextBox1.Text == Session["username"].ToString())
                {
                    throw new Exception("不能添加自己为好友");
                }
                SqlDataReader reader = sqlHelper.EcecuteReader(sqlHelper.connectionstring, CommandType.Text, sql, param);

                if (reader.Read())
                {
                    name = reader[0].ToString();
                    email = reader[1].ToString();
                }
                else 
                {
                    throw new Exception("查询失败！");
                }                
                Response.Redirect("AddFriend.aspx?name="+name+"&email="+email);
            }
            catch (Exception ex)
            {
                    ClientScript.RegisterStartupScript(this.GetType(),"", "<script language='javascript'>alert('" + ex.Message + "')</script>");
            }
        }
    }
}