using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Scheduler;

namespace VNHealth
{
    public partial class clock : PhoneApplicationPage
    {
        public clock()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime _date = dpkDate.Value.Value;
            TimeSpan _time = tpkTime.Value.Value.TimeOfDay;
            _date = _date.Date + _time;
            String _content = txtContent.Text;
            _content = "Ghi chú: " + _content;
            if (_date < DateTime.Now)
                MessageBox.Show("Thời gian bạn chọn đã xảy ra"
                    + "!\n Vui lòng chọn lại !");
            else if (String.IsNullOrEmpty(_content))
                MessageBox.Show("Bạn chưa chọn thời gian"
                    + "!\n Vui lòng chọn");
            else
            {
                ScheduledAction _oldreminder = ScheduledActionService.Find("Nhacnhouongthuoc");
                if (_oldreminder != null)
                    ScheduledActionService.Remove(_oldreminder.Name);
                Reminder _Reminder = new Reminder("Nhacnhouongthuoc")
                {
                    BeginTime = _date,
                    Title = "Bạn ơi đã đến giờ uống thuốc rồi !!"
                    + "!\n Nhớ uống bạn nhé!!",
                    Content = _content,
                };
                ScheduledActionService.Add(_Reminder);
                MessageBox.Show("Thời gian đã được lưu");
            }
        }
    }
}