using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QConnectSDK;//请加入这个命名空间
using QConnectSDK.Models;
public partial class QQCallback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["code"] != null)
        {
            QOpenClient qzone = null;
            User currentUser = null;

            var verifier = Request.Params["code"];
            string state = Session["requeststate"].ToString();
            qzone = new QOpenClient(verifier, state);
            currentUser = qzone.GetCurrentUser();
            if (null != currentUser)
            {
                this.result.Text = "成功登陆";
                this.Nickname.Text = currentUser.Nickname;
                this.Figureurl.ImageUrl = currentUser.Figureurl;
            }
            Session["QzoneOauth"] = qzone;
        }
    }
}