using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace send
{
    public partial class send : System.Web.UI.Page
    {
        public string ChannelUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["url"] != null)
            {
                ChannelUrl = Request.QueryString["url"].ToString();
                Application["url"] = ChannelUrl;
            }
            if (Application["url"] != null)
            {
                url.Text = Application["url"].ToString();
            }

        }
        protected void SendToast_Click(object sender, EventArgs e)
        {
            try
            {
                //准备POST Message
                HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(url.Text);
                sendNotificationRequest.Method = WebRequestMethods.Http.Post;
                sendNotificationRequest.ContentType = "text/xml; charset=utf-8";



                //准备消息头HttpHeader
                sendNotificationRequest.Headers = new WebHeaderCollection();
                sendNotificationRequest.Headers["X-MessageID"] = Guid.NewGuid().ToString();
                sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", "toast");
                sendNotificationRequest.Headers.Add("X-NotificationClass", "2");

                //消息的内容


                string ToastPushXML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                        "<wp:Notification xmlns:wp=\"WPNotification\">" +
                                          "<wp:Toast>" +
                                            "<wp:Text1>"+"消息提醒"+"</wp:Text1>" +
                                            "<wp:Text2>{0}</wp:Text1>" +
                                          "</wp:Toast>" +
                                        "</wp:Notification>";

                //將XML序列化
                string str = string.Format(ToastPushXML, msg.Text);
                byte[] strBytes = Encoding.UTF8.GetBytes(str);
                sendNotificationRequest.ContentLength = strBytes.Length;
                using (Stream requestStream = sendNotificationRequest.GetRequestStream())
                {
                    requestStream.Write(strBytes, 0, strBytes.Length);
                }
                
                //送出內容並取得HttpResponse 
                HttpWebResponse response = (HttpWebResponse)sendNotificationRequest.GetResponse();
                string notificationStatus = response.Headers["X-NotificationStatus"];
                string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
                state.Text = "状态: " + notificationStatus + " 连线: " + deviceConnectionStatus;
            }
            catch (Exception)
            {

            }

        }

        protected void SendTile_Click(object sender, EventArgs e)
        {
            try
            {
                string tileMessage = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                        "<wp:Notification xmlns:wp=\"WPNotification\">" +
                           "<wp:Tile>" +
                              "<wp:BackgroundImage>ApplicationIcon.png</wp:BackgroundImage>" +
                              "<wp:Count>2</wp:Count>" +
                              "<wp:Title>" + msg.Text + "</wp:Title>" +
                           "</wp:Tile> " +
                        "</wp:Notification>";
                byte[] strBytes = new UTF8Encoding().GetBytes(tileMessage);

                HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(url.Text);

                sendNotificationRequest.Method = WebRequestMethods.Http.Post;

                sendNotificationRequest.Headers["X-MessageID"] = Guid.NewGuid().ToString();
                sendNotificationRequest.ContentType = "text/xml; charset=utf-8";
                sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", "token");
                sendNotificationRequest.Headers.Add("X-NotificationClass", "1");
                sendNotificationRequest.ContentLength = strBytes.Length;

                byte[] notificationMessage = strBytes;

                using (Stream requestStream = sendNotificationRequest.GetRequestStream())
                {
                    requestStream.Write(notificationMessage, 0, notificationMessage.Length);
                }

                HttpWebResponse response = (HttpWebResponse)sendNotificationRequest.GetResponse();
                string notificationStatus = response.Headers["X-NotificationStatus"];
                string notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
                string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
                state.Text = String.Format("通知状态：{0}，管道状态：{1}，设备状态：{2}", notificationStatus, notificationChannelStatus, deviceConnectionStatus);
            }
            catch (Exception)
            {

            }
        }

        protected void SendRaw_Click(object sender, EventArgs e)
        {
            try
            {

                byte[] strBytes = new UTF8Encoding().GetBytes(msg.Text);
                HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(url.Text);

                sendNotificationRequest.Method = WebRequestMethods.Http.Post;
                sendNotificationRequest.Headers["X-MessageID"] = Guid.NewGuid().ToString();

                sendNotificationRequest.ContentType = "text/xml; charset=utf-8";
                sendNotificationRequest.Headers.Add("X-NotificationClass", "3");

                sendNotificationRequest.ContentLength = strBytes.Length;


                byte[] notificationMessage = strBytes;

                using (Stream requestStream = sendNotificationRequest.GetRequestStream())
                {
                    requestStream.Write(notificationMessage, 0, notificationMessage.Length);
                }

                HttpWebResponse response = (HttpWebResponse)sendNotificationRequest.GetResponse();
                string notificationStatus = response.Headers["X-NotificationStatus"];
                string notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
                string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
                state.Text = String.Format("通知状态：{0}，管道状态：{1}，设备状态：{2}", notificationStatus, notificationChannelStatus, deviceConnectionStatus);
            }
            catch (Exception)
            {

            }
        }

    }
}