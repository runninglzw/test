using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //发送文字
        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient tc = new TcpClient();
            //使用指定ip地址和端口号连接服务器
            tc.Connect(IPAddress.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            MessageBox.Show("请求已发送！");
            //获得连接到服务器的数据流
            NetworkStream ns = tc.GetStream();
            //选择要发送给服务器的内容转换为字节流
            byte[] sendby = Encoding.UTF8.GetBytes(richTextBox1.Text);
            //把字节流写入数据流，发送
            ns.Write(sendby,0,sendby.Length);
            ns.Close();
            tc.Close();
        }
        //发送文件内容
        private void button2_Click(object sender, EventArgs e)
        {
            TcpClient tc = new TcpClient();
            tc.Connect(IPAddress.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            NetworkStream ns = tc.GetStream();
            //打开指定路径上的文件，存入Filestream流中
            FileStream fs = File.Open("F:/c#/c#编程/c#选择排序.txt",FileMode.Open);
            //读取一个字节，指针上移一个字节
            int data = fs.ReadByte();
            while (data != -1)
            {
                ns.WriteByte((byte)data);
                data = fs.ReadByte();
            }
            fs.Close();
            ns.Close();
            tc.Close();
        }
    }
}
