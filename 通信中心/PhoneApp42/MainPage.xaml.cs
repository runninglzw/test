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

namespace PhoneApp41
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click_phone(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }

        private void Button_Click_email(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
        }

        private void Button_Click_message(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void Button_Click_search(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page5.xaml", UriKind.Relative));
        }

        private void Button_Click_liulan(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page4.xaml", UriKind.Relative));
        }

        private void Button_Click_map(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/map.xaml", UriKind.Relative));
        }
        private void Button_Click_camra(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/camera.xmal", UriKind.Relative));
        }
    }
}