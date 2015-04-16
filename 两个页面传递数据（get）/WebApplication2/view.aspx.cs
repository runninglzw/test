using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.QueryString["name"];//QueryString为获取Http查询字符串变量集合
            string password = Request.QueryString["pwd"];
            Response.Write("<h1>您的信息如下：</h1>");
            Response.Write("<p>用户名：" + name);
            Response.Write("<p>密码：" + password);
        }
    }
}