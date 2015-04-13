using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class showphoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断用户是否登录
            if (Session["username"] == null)
            {
                Response.Redirect("main.aspx");
            }
            //querystring和form都是asp中获取数据的一个方法.
            //form是用来获得表单提交的数据,querystring是用来获得标识在URL后面的所有返回的变量及其值；
            //ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('0000000')</script>");
            string op = Request.QueryString["op"];
            //ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('!!!!!!!!')</script>");
            if (op!=null&&op.Equals("del"))
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('1111111')</script>");
                string pid = Request.Params["pid"];
                string psid = Request.Params["psid"];
                string sql1 = "select purl from photo where pid=@pid";
                string sql2 = "delete from photo where pid=@pid";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@pid",pid)
                };
                SqlDataReader read = sqlHelper.EcecuteReader(sqlHelper.connectionstring, CommandType.Text, sql1, param);
                //首先删除photos文件夹下的图片
                while (read.Read())
                {
                    if (System.IO.File.Exists(Server.MapPath("photos/") + read.GetString(0)))
                    {
                        System.IO.File.Delete(Server.MapPath("photos/") + read.GetString(0));
                    }
                }
                //然后删除数据库中的信息
                if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql2, param) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('删除成功！')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>alert('上传失败！')</script>");
                }
                //如果sql1中改为select * 的话，使用GetString(0)就是返回查询结果第一列上的值
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("shangchuanphoto.aspx");
        }

        protected void Button２_Click(object sender, EventArgs e)
        {
            Response.Redirect("showphotoset.aspx");
        }
    }
}