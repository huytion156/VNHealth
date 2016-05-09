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
using System.Windows.Media.Imaging;
namespace VNHealth
{
    public partial class ketnoichuyengia : PhoneApplicationPage
    {
        PhotoChooserTask photoChooserTask;
        EmailAddressChooserTask emailAddresstask;
        public ketnoichuyengia()
        {
            InitializeComponent();
            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooseTask_Completed);
            emailAddresstask = new EmailAddressChooserTask();
            emailAddresstask.Completed += new EventHandler<EmailResult>(emailAddresstask_Completed);
        }
        void photoChooseTask_Completed(object sender, PhotoResult e)
        {
            BitmapImage bitmap= new BitmapImage();
            bitmap.SetSource(e.ChosenPhoto);
            imgchoose.Source = bitmap;
            vandetraodoi.Text = bitmap.ToString() ;
            
        }
        private void addpic_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            photoChooserTask.Show();

        }
        private void emailAddresstask_Completed(object sender, EmailResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                MessageBox.Show(e.Email.ToString(), "Thông báo", MessageBoxButton.OK);
            }
        }
        private void sendmail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask Myemail_Composetask = new EmailComposeTask();
            Myemail_Composetask.To = "vnhealthndc.chuyengia@gmail.com";
            Myemail_Composetask.Subject = "VNHEALTH4WP - Kết nối chuyên gia";
            Myemail_Composetask.Body = hoten.Text + "\n" + tuoi.Text + "\n" + noidung.Text;
            Myemail_Composetask.Show();
        }
    }
}