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
    public partial class showphotoset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("main.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //如果是删除按钮,在源里面添加CommandName="del"
            if (e.CommandName == "del")
            {
                //返回该按钮的行号
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                //Response.Write(index);
                //Response.Write(GridView1.DataKeys.Count);
                
                //获取该行所在的主键的值
                if (index >= 0)
                {
                    //获取主键前必须在GridView1的属性中设置datakeysname属性为psname（即设置gridview1的主键为psname），否则会报错
                    string psname = GridView1.DataKeys[index].Value.ToString();
                    Response.Write("主键值：" + psname);
                    string sql = "delete from photoset where psname=@psname";
                    SqlParameter[] param = new SqlParameter[] { 
                    new SqlParameter("@psname",psname)
                };
                    if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                    { 
                        Response.Redirect("showphotoset.aspx");
                    }
                    else
                        Response.Write("删除失败！");
                }
                else
                    Response.Write("index<0");
            }
            if (e.CommandName == "look")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string psname = GridView1.DataKeys[index].Value.ToString();
                //Session["psname"] = psname;
                string sql = "select psid from photoset where psname=@psname";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@psname",psname)
                };
                string psid = sqlHelper.ExecuteScalar(sqlHelper.connectionstring, CommandType.Text, sql, param).ToString();
                Session["psid"] = psid;
                Response.Redirect("showphoto.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("yonghu.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //http://blog.163.com/123xin_xin/blog/static/33429735200932853126748/
            //http://blog.csdn.net/wangyangscut/article/details/4270506  rows[]代表行的数组，cells[]代表单元格的数组，controls代表控件（在cells中的控件）
            string psname = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text.ToString();
            Response.Write(psname);
            string sql = "update photoset set psname=@psname where username=@username";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@psname",psname),
                new SqlParameter("@username",Session["username"].ToString())
            };
            if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
            {
                GridView1.EditIndex = -1;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("修改失败！");
            }
        }
    }
}