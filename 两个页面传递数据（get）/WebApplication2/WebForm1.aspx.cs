using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim() != "" && TextBox2.Text.Trim()!= "")
                Response.Redirect("view.aspx?name=" + TextBox1.Text + "&pwd=" + TextBox2.Text);//使用该方法导航到指定url页面，并用get方法提交表单，格式为：？参数名=参数值&参数名=参数值。。。
            else
                ClientScript.RegisterStartupScript(this.GetType(), "系统提示", "<script language='javascript'>" + "alert('您的信息不能为空，请重输！')</script>");//使用该方法启动报错脚本
        }
    }
}