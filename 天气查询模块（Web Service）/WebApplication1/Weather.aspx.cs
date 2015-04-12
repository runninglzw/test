using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using WebApplication1.Service1;

namespace WebApplication1
{
    public partial class Weather : System.Web.UI.Page
    {
        //Service1.WeatherWebServiceSoapClient server = new Service1.WeatherWebServiceSoapClient("WeatherWebServiceSoap");
        //实例化WebServer对象
        WebApplication1.cn.com.webxml.www.WeatherWebService server = new WebApplication1.cn.com.webxml.www.WeatherWebService();
        protected void bindpro()
        {
            DropDownList1.Items.Clear();
            //获得省份
            string[] pros = server.getSupportProvince();

            foreach(string x in pros)
            {
                DropDownList1.Items.Add(new ListItem(x.ToString(),x.ToString()));
            }
        }
        //绑定城市
        protected void bindcity()
        {
            DropDownList2.Items.Clear();
            string[] citys = server.getSupportCity(DropDownList1.SelectedValue);
            foreach (string x in citys)
            {
                DropDownList2.Items.Add(x.ToString());
            }
        }
        //绑定天气
        protected void bindweather()
        {
            
            int index=DropDownList2.SelectedValue.IndexOf('(');
            int length = DropDownList2.SelectedValue.IndexOf(')') - index;
            string city = DropDownList2.SelectedValue.Substring(index+1,length-1);
           // string city = DropDownList2.SelectedValue;
            string[] weathers = server.getWeatherbyCityName(city);
            Label1.Text ="城市："+ weathers[1].ToString();
            Label2.Text ="温度："+ weathers[5].ToString();
            Label3.Text = "天气："+weathers[6].ToString();
            Label4.Text ="风力："+ weathers[7].ToString();
            Label5.Text=weathers[10].ToString();
            //Image1.ImageUrl = weathers[8].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindpro();
                bindcity();
                bindweather();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindcity();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bindweather();
        }
    }
}