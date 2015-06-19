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
    public partial class map : PhoneApplicationPage
    {
        public map()
        {
            InitializeComponent();
        }

        private void Button_Click_map(object sender, RoutedEventArgs e)
        {
            BingMapsTask bmt = new BingMapsTask();
            bmt.SearchTerm = maptxt.Text;
            bmt.Show();
        }
    }
}