using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace json
{
    public partial class Weather : System.Web.UI.Page
    {
        private void dorequest()
        {
            string city = TextBox1.Text;
            string url = "http://api.36wu.com/Weather/GetWeather?district=" + city + "&format=json&AuthKey=718fc7202ce04e2b97ac0946455e14f6";
            WebRequest request = WebRequest.Create(url);
            IAsyncResult result=request.BeginGetResponse(null, request);
            WebResponse response = request.EndGetResponse(result);
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string res = reader.ReadToEnd();
            TextBox2.Text = res;
            //解析json
            JObject jo = (JObject)JsonConvert.DeserializeObject(res);
            label1.Text = jo["data"]["weather"].ToString();
            //result.AsyncWaitHandle;
        }
        //异步回调方法
        private void responsecallback(IAsyncResult ar)
        {
            HttpWebRequest request = (HttpWebRequest)ar.AsyncState;
            WebResponse response = request.EndGetResponse(ar);
            Stream stream = response.GetResponseStream();
            StreamReader reader=new StreamReader(stream);
            string result = reader.ReadToEnd();
            TextBox2.Text = result;
            //解析json
            JObject jo = (JObject)JsonConvert.DeserializeObject(result);
            label1.Text=jo["data"]["weather"].ToString();
            this.Page.RegisterStartupScript("", "<script>alert('"+label1.Text+"')</script>");
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thread.Sleep(1100);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dorequest();
        }
    }
}