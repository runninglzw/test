using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] b = new byte[1024];
            byte[] b2 = new byte[1024];
            string send = "hello![final]";
            b = Encoding.UTF8.GetBytes(send);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //获得主机信息
            IPHostEntry iphost = Dns.Resolve("lzw");
            //使用主机的ip地址和指定端口号建立一个网络端点
            IPEndPoint ip = new IPEndPoint(iphost.AddressList[0], 2112);
            //使用这个网络端点连接远程服务器
            s.Connect(ip);
            Console.WriteLine("成功连接到服务器！");
            //向服务器发送数据
            s.Send(b);
            int x = s.Receive(b2);
            Console.WriteLine("从服务器返回的数据："+Encoding.UTF8.GetString(b2));
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }
    }
}
