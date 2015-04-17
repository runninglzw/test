using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Notification;
using System.IO;

namespace PushNotification
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
                HttpNotificationChannel httpChannel = null;
                string channelName = "NotificationTest";

                httpChannel = HttpNotificationChannel.Find(channelName);
                if (httpChannel != null)
                {
                    httpChannel.Close();
                    httpChannel.Dispose();
                }
                httpChannel = new HttpNotificationChannel(channelName);

                httpChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(httpChannel_ChannelUriUpdated);
                httpChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(httpChannel_ErrorOccurred);
                httpChannel.ShellToastNotificationReceived += new EventHandler<NotificationEventArgs>(httpChannel_ShellToastNotificationReceived);
                httpChannel.HttpNotificationReceived += new EventHandler<HttpNotificationEventArgs>(httpChannel_HttpNotificationReceived);
                httpChannel.Open();
                httpChannel.BindToShellToast();
                httpChannel.BindToShellTile();
        }

        void httpChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://localhost:49343/websend.aspx?url=" + e.ChannelUri));//在不阻止调用线程的情况下，从资源返回数据         
                webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);//异步操作完成时发生

        }

        void httpChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                msg.Text = e.Message;
            });
        }

        void httpChannel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
        {
            foreach (var key in e.Collection.Keys)
            {
                string pushmsg = e.Collection[key];

                Dispatcher.BeginInvoke(() =>
                {
                    msg.Text += key + ": " + pushmsg + "\r\n";
                });
            }

        }

        void httpChannel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            using (var reader = new StreamReader(e.Notification.Body))
            {
                string Rawmsg = reader.ReadToEnd();
                Dispatcher.BeginInvoke(() =>
                {
                    msg.Text = Rawmsg;
                });
            }
        }

        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                state.Text = "注册失败！请检查web服务是否搭建成功。";
            }
            else
            {
                Dispatcher.BeginInvoke(() =>
                    {
                        state.Text = "恭喜你，注册成功^_^";
                    });            
            }
        }
    }
}