using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpClient uc = new UdpClient();
            string send = textBox1.Text;
            MessageBox.Show(send);
            byte[] sendbyte = Encoding.UTF8.GetBytes(send);
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            //uc.Connect(ipendpoint);
            uc.Send(sendbyte, sendbyte.Length, ipendpoint);
        }
    }
}