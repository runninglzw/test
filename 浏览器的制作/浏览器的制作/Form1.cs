using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 浏览器的制作
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem导航_Click(object sender, EventArgs e)
        {
            navigate(toolStripTextBox1.Text);//自定义navigate方法
            //前进ToolStripMenuItem.Enabled = webBrowser1.CanGoForward;
            //WebBrowserNavigatedEventHandler navigated;
        }

        private void 后退ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();//向文档的上一页导航
            //前进ToolStripMenuItem.Enabled = webBrowser1.CanGoForward;
        }

        private void 前进ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();//向文档的下一页导航
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();//重新加载当前网页
        }

        private void 主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();//导航到主页
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoSearch();//导航到默认搜索页必应搜索
        }

        private void toolStripMenuItem属性_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPropertiesDialog();//打开ie的属性对话框
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowSaveAsDialog();//打开ie的保存网页对话框
        }

        private void toolStripMenuItem打印浏览_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();//打开打印预览对话框
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();//取消所有挂起的导航并停止所有动态元素
        }

        private void 页面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPageSetupDialog();//打开页面设置对话框
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();//打印当前网页
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString();//显示网址到文本框1中
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                navigate(toolStripTextBox1.Text);//文本框1中按回车开始导航网页
            }
        }
       /// <summary>
       /// 判断url是否合法，合法则开始导航
       /// </summary>
        /// <param name="p"></param>toolStripTextBox1文本框中的url地址
        private void navigate(string p)
        {
            if (String.IsNullOrEmpty(p)) return;
            if (p.Equals("about:blank")) return;
            if (!p.StartsWith("http://"))
            {
                p = "http://" + p;
            }
            try
            {
                webBrowser1.Navigate(new Uri(p),false);
            }
            catch (System.UriFormatException)
            {
                return;
            }
            //throw new NotImplementedException();
        }
        /*
        private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
        {
            前进ToolStripMenuItem.Enabled = webBrowser1.CanGoForward;
        }*/
    }
}
