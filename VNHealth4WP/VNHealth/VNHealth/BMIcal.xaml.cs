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
namespace VNHealth
{
    public partial class BMIcal : PhoneApplicationPage
    {
        private bool kiemtra(string s)
        {
            int n = 0;
            if (int.TryParse(s, out n) == true) return true;
            else return false;
        }
        public BMIcal()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((kiemtra(Textbox1.Text) == false) || (kiemtra(Textbox2.Text) == false))
                MessageBox.Show("Thông tin không hợp lệ. Nhập lại!");
            else
            {
                float chieucao = Convert.ToInt32(Textbox1.Text);
                float cannang = Convert.ToInt32(Textbox2.Text);
                chieucao = chieucao / 100;
                float bmi = cannang / (chieucao * chieucao);
                if (nam.IsChecked == true) bmi = bmi + 2;
                else bmi = bmi - 2;
                string s = "";
                if (bmi < 18.5) s = "data\\chuandoan\\duoichuan.txt";
                else
                    if ((bmi >= 18.5) && (bmi < 25)) s = "data\\chuandoan\\chuan.txt";
                    else
                        if ((bmi >= 25) && (bmi < 30)) s = "data\\chuandoan\\thuacan.txt";
                        else
                            if ((bmi >= 30) && (bmi < 40)) s = "data\\chuandoan\\beo.txt";
                            else
                                if (bmi >= 40) s = "data\\chuandoan\\ratbeo.txt";
                ketqua.Text = Convert.ToString(Math.Round(bmi, 2));
                StreamReader fin = File.OpenText(s);
                thongtin.Content = fin.ReadToEnd();
                fin.Close();

            }
        }


    }
}