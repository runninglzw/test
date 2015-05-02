using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("服务器已经开启！");
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            //绑定一个IP地址和端口号
            s.Bind(new IPEndPoint(IPAddress.Any,2112));
            //开始监听
            s.Listen(10);
                string result = string.Empty;
            //获得到连接到这台服务器的socket对象
                Socket socket = s.Accept();
            //读取socket对象上的数据
                while (true)
                {
                    byte[] b1 = new byte[1024];
                    int x = socket.Receive(b1);
                    Console.WriteLine("正在接收！");
                    result += Encoding.UTF8.GetString(b1, 0, x);
                    if (result.IndexOf("[final]") > -1)
                    {
                        break;
                    }
                    //x = socket.Receive(b1);
                }
                Console.WriteLine("接收到的数据："+result);
            //返回给客户端一个信息
                string fanhui = "我已经接收到您的数据！";
                byte[] b2 = Encoding.UTF8.GetBytes(fanhui);
                socket.Send(b2);
            //关闭socket对象的发送和接收功能
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
        }
    }
}
