using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    class Program
    {
        public void send()
        {
            string result = string.Empty;
            Socket socket = null;
            //do
            //{
            Console.WriteLine("服务端已经开启！");

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定一个IP地址和端口号
            s.Bind(new IPEndPoint(IPAddress.Parse("172.20.2.175"), 2112));

            do
            {
                //开始监听
                s.Listen(10);

                //获得到连接到这台服务器的socket对象
                socket = s.Accept();


                byte[] receive = new byte[1024];
                int x = socket.Receive(receive);
                if (receive != null)
                {
                    result = Encoding.UTF8.GetString(receive);
                    Console.WriteLine("接收到的数据：" + result);

                    result = result.Substring(0, result.IndexOf('\0'));
                    bool kkkk = (result == "进程");
                    if (result == "进程")
                    {
                        //返回给客户端进程的信息
                        string fanhui = xinxi.getjincheng();
                        byte[] send = Encoding.UTF8.GetBytes(fanhui);
                        socket.Send(send);
                    }
                    if (result == "注册表")
                    {
                        //返回给客户端注册表的信息
                        string fanhui = xinxi.getzhucebiao();
                        byte[] send = Encoding.UTF8.GetBytes(fanhui);
                        socket.Send(send);
                    }
                    if (result == "浏览器")
                    {
                        //返回给客户端浏览器的信息
                        string fanhui = xinxi.getliulanqi();
                        byte[] send = Encoding.UTF8.GetBytes(fanhui);
                        socket.Send(send);
                    }
                    if (result == "启动项")
                    {
                        //返回给客户端启动项的信息
                        string fanhui = xinxi.getqidongxiang();
                        byte[] send = Encoding.UTF8.GetBytes(fanhui);
                        socket.Send(send);
                    }
                }
            } while (result != "取消");
            //关闭socket对象的发送和接收功能
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            //} while (result != "取消");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Thread t = new Thread(p.send);
            t.Start();
        }
    }
}
