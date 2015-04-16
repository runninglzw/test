using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name=Request.Form["text1"];
            string password=Request.Form["password1"];
            Response.Write("<h1>您的信息如下：</h1>");
            Response.Write("<p>用户名："+name);
            Response.Write("<p>密码："+password);
        }
    }
}