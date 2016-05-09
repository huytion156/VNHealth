using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;

namespace VNHealth
{
    public partial class thongtinbenh : PhoneApplicationPage
    {
        private static StackPanel TextToXaml(string filename)
        {
            var panel = new StackPanel();
            var resourceStream = Application.GetResourceStream(new Uri(filename, UriKind.RelativeOrAbsolute));
            if (resourceStream != null)
            {
                using (var reader = new StreamReader(resourceStream.Stream))
                {
                    string line;
                    do
                    {
                        line = reader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                        {
                            panel.Children.Add(new Rectangle { Height = 20.0 });
                        }
                        else
                        {
                            var textBlock = new TextBlock
                            {
                                TextWrapping = TextWrapping.Wrap,
                                Text = line,
                                Style = (Style)Application.Current.Resources["PhoneTextNormalStyle"],
                                FontSize = 22,
                            };
                            panel.Children.Add(textBlock);
                        }
                    } while (line != null);
                }
            }
            return panel;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string value = NavigationContext.QueryString["parameter"];
            string linkfile = "data\\dulieubenh\\thongtinbenh\\" + value.ToString() + ".txt";
            string linkpic = "data/dulieubenh/picture/" + value + ".jpg";
            BitmapImage myImage = new BitmapImage(new Uri(linkpic, UriKind.Relative));
            picture.Source = myImage;
            thongtin.Content = TextToXaml(linkfile);
            //tenbenh.Text = value.ToString();
            tenbenh.Text = "";


            base.OnNavigatedTo(e);


        }
        public thongtinbenh()
        {
            InitializeComponent();
        }
    }
}