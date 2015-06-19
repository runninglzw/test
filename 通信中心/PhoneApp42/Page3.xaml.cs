using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace PhoneApp42
{
    public partial class Page3 : PhoneApplicationPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            SmsComposeTask sms = new SmsComposeTask();
            sms.To = to.Text;
            sms.Body = body.Text;
            sms.Show();
        }
    }
}