using System;
using System.Collections.Generic;
using System.Linq;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            //加载xml文档
            xmldoc.Load("F:\\ASP.NET\\WebApplication1\\WebApplication1\\text.xml");
            //获取xml文档的根节点
            var root = xmldoc.DocumentElement;
            //获取匹配表达式的第一个结点
            XmlNode no = xmldoc.SelectSingleNode("PlaceSearchResponse/results/result/name");
            Response.Write(no.InnerText);
            //获取匹配表达式的节点列表
            XmlNodeList nodes = xmldoc.SelectNodes("PlaceSearchResponse/results/result/name");
            foreach (XmlNode node in nodes)
            {
                //Response.Write(node.Attributes["name"].Value);
                //获取该结点的内容
                Response.Write("</br>"+node.InnerText);
            }
        }


    }
}