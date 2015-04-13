using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class myfriends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("yonghu.aspx");
        }

        protected void myfriendsLabel_Command(object sender, CommandEventArgs e)
        {
            //获取命令的参数
            string name = e.CommandArgument.ToString();
            Response.Redirect(string.Format("myfriend_photoset.aspx?friendname={0}", name));
        }


    }
}