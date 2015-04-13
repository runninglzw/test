using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace WebApplication1
{
    public partial class ValidNums : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = CreateNumbers(4);
            CreateImage(result);
        }
        /// <summary>
        /// 用于生成验证码中的字符串
        /// </summary>
        /// <param name="numbers"></param>该字符串包含几个字符
        /// <returns></returns>
        private string CreateNumbers(int numbers)
        {
            string str = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            //字符串数组，用于保存35个字符
            string[] charnumber = str.Split(',');
            //保存最终验证码中的字符串
            string result = "";
            //标记上次随机产生的字符在字符串数组charnumber中的下标
            int temp = -1;
            Random ran = new Random();
            for (int i = 0; i < numbers; i++)
            {
                if (temp != -1)
                {
                    ran = new Random(temp * i * (int)DateTime.Now.Ticks);
                }
                int t = ran.Next(35);
                temp = t;
                result += charnumber[t];
            }
            Session["ValidNums"] = result;
            return result;
        }
        /// <summary>
        /// 设置背景噪音线，背景字体大小和样式，前景噪音点和图片的边框线，背景是Graphics，前景是一个BitMap图像
        /// </summary>
        /// <param name="numbers"></param>验证码字符串
        private void CreateImage(string numbers)
        {
            if (numbers == null || numbers.Trim() == string.Empty)
            {
                return;
            }
            Bitmap bitmap = new Bitmap(numbers.Length * 12 + 10, 22);
            Graphics graphics = Graphics.FromImage(bitmap);
            try
            {
                Random ran = new Random();
                //清除背景色
                graphics.Clear(Color.White);
                //绘制背景噪音线
                for (int i = 1; i <= 30; i++)
                {
                    int x1 = ran.Next(bitmap.Width);
                    int y1 = ran.Next(bitmap.Height);
                    int x2 = ran.Next(bitmap.Width);
                    int y2 = ran.Next(bitmap.Height);
                    graphics.DrawLine(new Pen(Color.Coral), x1, y1, x2, y2);
                }
                //绘制背景字体样式
                Font font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);
                LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                graphics.DrawString(numbers, font, linear, 2, 2);
                //绘制前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = ran.Next(bitmap.Width);
                    int y = ran.Next(bitmap.Height);
                    bitmap.SetPixel(x, y, Color.FromArgb(ran.Next()));
                }
                //绘制图片边框线
                graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
                //创建一个流用于保存图像
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";//设置图像格式
                Response.BinaryWrite(ms.ToArray());//执行保存图像操作
            }
            finally
            {
                graphics.Dispose();
                bitmap.Dispose();
            }
        }
    }

}