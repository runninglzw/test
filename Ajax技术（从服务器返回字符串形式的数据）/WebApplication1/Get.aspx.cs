using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Get : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();

            string username = Request.QueryString["username"];

            string age = Request.QueryString["age"];

            Response.Write("姓名:'" + username + "'<br/>年龄:" + age + "<br/>时间:'" + DateTime.Now.ToString() + "'");

            Response.End();
        }
    }
}