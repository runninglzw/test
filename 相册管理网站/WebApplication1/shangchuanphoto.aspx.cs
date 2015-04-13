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
    public partial class shangchuanphoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //上传事件
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.FileName == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "上传错误！", "<script language='javascript'>alert('上传不能为空！')</script>");

            }
            else
            {
                string filepath = FileUpload1.PostedFile.FileName;  //得到的是文件的完整路径,包括文件名，如：C:\Documents and Settings\Administrator\My Documents\My Pictures\20022775_m.jpg 
                //string filepath = FileUpload1.FileName;               //得到上传的文件名20022775_m.jpg 
                string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);//20022775_m.jpg 
                string serverpath = Server.MapPath("~/photos/") + filename;//取得文件在服务器上保存的位置C:\Inetpub\wwwroot\WebSite1\images\20022775_m.jpg 
                string type = filename.Substring(filename.LastIndexOf(".") + 1);//取得文件的类型
                if (type == "jpg" || type == "png" || type == "PNG" || type == "JPG" || type == "JPEG" || type == "jpeg" || type == "gif" || type == "GIF")
                {
                    FileUpload1.PostedFile.SaveAs(serverpath);//将上传的文件另存为
                    string sql = "insert into photo values(@username,@psid,@pname,@purl,@posttime)";
                    SqlParameter[] param = new SqlParameter[]{
                        new SqlParameter("@username",Session["username"]),
                        new SqlParameter("@psid",Session["psid"]),
                        new SqlParameter("@pname",TextBox1.Text),
                        new SqlParameter("@purl",filename),
                        new SqlParameter("@posttime",System.DateTime.Now)
                    };
                    if (sqlHelper.ExecuteNonQuary(sqlHelper.connectionstring, CommandType.Text, sql, param) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "上传成功！", "<script language='javascript'>alert('上传成功！')</script>");
                    }
                    else 
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "上传错误！", "<script language='javascript'>alert('上传失败！')</script>");
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("showphoto.aspx");
        }
    }
}