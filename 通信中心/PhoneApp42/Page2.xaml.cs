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
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask ema = new EmailComposeTask();
            ema.To = to.Text;
            ema.Subject = subject.Text;
            ema.Body = body.Text;
            ema.Show();
        }
    }
}