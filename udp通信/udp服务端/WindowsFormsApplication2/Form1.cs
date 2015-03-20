using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread th = new Thread(new ThreadStart(listen));
            th.Start();
            richTextBox1.Text = "监听中。。。";
        }
        protected delegate void updatedisplay(string s);
        private void listen()
        {
                UdpClient uc = new UdpClient();
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                uc.Connect(ip);
                byte[] receive = uc.Receive(ref ip);
                string result = Encoding.UTF8.GetString(receive);
                Invoke(new updatedisplay(update), new object[]{result});
        }

        private void update(string s)
        {
            richTextBox1.Text = s;
        }
    }
}
