using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class myfriend_photo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("main.aspx");
            //Response.Write(Request.QueryString["psid"]);
            if (!Page.IsPostBack) //是首次装载，不是回发
            {
                ViewState["back_no"] = 0; //隐藏的窗体字段ViewState，是页面级的
            }
            ViewState["back_no"] = Convert.ToInt32(ViewState["back_no"]) + 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // System.Data.Entity.Migrations.History.go(-1);
        }
    }
}