using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //定义后台线程执行监听方法
            Thread t = new Thread(new ThreadStart(listen));
            //启动线程
            t.Start();
            richTextBox1.Text = "正在监听。。。";

        }
        protected delegate void updatedisplay(string text);
        private void listen()
        {
                IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
                int port = 8080;
                //侦听传入的连接请求
                TcpListener tl = new TcpListener(ipaddress, port);

                tl.Start();
               // MessageBox.Show("检测到客户端请求");
                while (true)//一直获取客户端的消息
                {
                    //从队列中获取连接
                    TcpClient tc = tl.AcceptTcpClient();
                    MessageBox.Show("检测到客户端请求");
                    //获取连接的数据流
                    NetworkStream ns = tc.GetStream();
                    //读取数据流
                    StreamReader sr = new StreamReader(ns);
                    string result = sr.ReadToEnd();
                    //不能从后台线程直接访问界面，用invoke方法告诉窗体线程完成相应操作，这里使用委托，把得到的result字符串作为object数组传递给update方法的text参数
                    Invoke(new updatedisplay(update), new object[] { result });
                    
                    //update(result);
                    tc.Close();
                    ns.Close();
                }
        }

        private void update(string text)
        {
            richTextBox1.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //listen();
        }
    }
}
