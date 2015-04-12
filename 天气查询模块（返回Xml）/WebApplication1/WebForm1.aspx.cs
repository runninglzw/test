using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 网络请求的实现
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private string begingetsource(string address)
        {
            StringBuilder sb = new StringBuilder();//创建可变字符字符串实例
            //try
            //{
                WebRequest wrq = WebRequest.Create(address);//对统一资源标识符 (URI) 发出请求
                WebResponse wrp = wrq.GetResponse();//后者返回对 Internet 请求的响应，前者提供来自统一资源标识符 (URI) 的响应
                StreamReader sr = new StreamReader(wrp.GetResponseStream(), Encoding.UTF8);//用wrp.ToString()或（wrp.GetResponseStream()）是指用指定的字符编码，为指定的文件名（流）初始化 StreamReader 类的一个新实例。
                string resule = sr.ReadToEnd();
                return resule;
                //string str = "";//用来存每一行的数据
                //while ((str = sr.ReadLine()) != null)//判断是否成功读取完一行数据
                //{
                //    sb.Append(str);//\r和\n都相当于回车符，这里将读取到的每一行数据添加给可变字符串sb
                //}
                //sr.Close();//关闭数据流
                //Stream a=wrq.GetRequestStream();


            //}
            //catch (WebException e)
            //{
            //    //MessageBox.Show(e.Message, "error", MessageBoxButtons.OK);//MessageBoxButtons.OK为确定按钮，此行用于显示错误信息
            //}
            //return sb.ToString();//返回网页源码内容
            //throw new NotImplementedException();
        }
        protected void button1_Click(object sender, EventArgs e)
        {
            string city = TextBox1.Text;
            string result = null;
            Label1.Text = null;
            TextBox2.Text = null;
            try
            {
                if (city == string.Empty)
                    throw new Exception("城市不能为空");

                result=begingetsource("http://api.36wu.com/Weather/GetWeather?district=" + city + "&format=xml&AuthKey=718fc7202ce04e2b97ac0946455e14f6");
                TextBox2.Text = result;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                //XmlNamespaceManager nsmgr = new XmlNamespaceManager(new XmlDocument().NameTable);
                nsmgr.AddNamespace("i", "http://www.w3.org/2001/XMLSchema-instance");
                nsmgr.AddNamespace("j", "http://schemas.datacontract.org/2004/07/Cloud.Api.Servicestack.ServiceModel");
                nsmgr.AddNamespace("d2p1", "http://schemas.datacontract.org/2004/07/Cloud.Api.Models");
                XmlNode node = doc.SelectSingleNode("j:GetWeatherResult/j:data/d2p1:weather", nsmgr);
                Label1.Text = node.InnerText;
            }
            catch (Exception ex)
            {
                this.Page.RegisterStartupScript("","<script>alert('"+ex.Message+"')</script>");
            }
        }
    }
}