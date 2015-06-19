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
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Call_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask tel = new PhoneCallTask();
            tel.DisplayName = "正在呼叫";
            tel.PhoneNumber = Phonenumber.Text;
            tel.Show();
        }
    }
}