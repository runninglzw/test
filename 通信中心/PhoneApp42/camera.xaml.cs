using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;//show的命名空间
using System.Windows.Media.Imaging;// BitmapImage的命名空间

namespace PhoneApp42
{
    public partial class camera : PhoneApplicationPage
    {
        CameraCaptureTask cct;
        public camera()
        {
            InitializeComponent();
            CameraCaptureTask cct = new CameraCaptureTask();
            cct.Completed+=new EventHandler<PhotoResult>(cct_Completed);
        }
        private void Button_Click_camera(object sender, RoutedEventArgs e)
        {
            cct.Show();
        }
        private void cct_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bmi = new BitmapImage();
                bmi.SetSource(e.ChosenPhoto);
                image1.Source = bmi;
            }
            else
                image1.Source = null;
        }
    }
}