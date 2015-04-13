using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class myfriend_photoset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //是首次装载，不是回发
            {
                ViewState["back_no"] = 0; //隐藏的窗体字段ViewState，是页面级的
            }
            ViewState["back_no"] = Convert.ToInt32(ViewState["back_no"]) + 1;
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //判断命令是否是Link命令，是则跳转
            if (e.CommandName == "Link")
            {
                //获得界面传递的”相册名“参数和”好友姓名“参数，传递给myfriend_photo页面，就可显示照片
                string psid = e.CommandArgument.ToString();
                string friendname = Request.QueryString["friendname"];
                Response.Redirect(string.Format("myfriend_photo.aspx?friendname={0}&psid={1}",friendname,psid));
            }
        }
        //留言
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("sendtalkmessage.aspx?friendname={0}", Request.QueryString["friendname"]));
        }
    }
}