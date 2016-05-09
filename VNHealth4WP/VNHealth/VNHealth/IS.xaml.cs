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
    public partial class IS : PhoneApplicationPage
    {
        private static string upper1(string s)
        {
            s = s.ToLower();
            char[] charArr = s.ToCharArray();
            charArr[0] = char.ToUpper(charArr[0]);
            return new String(charArr);
        }
        public string[] lines = new string[400];
        public IS()
        {
            InitializeComponent();
            
            var fin = new StreamReader("data\\dulieubenh\\menu.txt");
            for (int i = 0; i <= 231; i++)
            {
                string s = fin.ReadLine();
                if (s != null) listbox.Items.Add(s);
                lines[i] = s;
            }
            fin.Close();
        }
        
        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* string a = listbox.SelectedIndex.ToString();
            int n = Convert.ToInt32(a) + 1; */
            
            //var link = "/thongtinbenh.xaml?parameter=" + n.ToString();
            if (textbox.Text == "") return;
            string a = listbox.SelectedItem.ToString();
            int n = Convert.ToInt32(timvitritenbenh(a));
            var link = "/thongtinbenh.xaml?parameter=" + n.ToString();
            NavigationService.Navigate(new Uri(link, UriKind.Relative));
        }
        public int timvitritenbenh(string s)
        {
            for (int i = 0; i <= 706; i++)
                if (checkstr(s, lines[i]) == true) return i + 1;
            return -1;
        }
        private bool checkstr(string a, string b) // kiem tra chuoi a = b ?
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false; //a !=b
            return true; //a=b
        }
        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            string tm = textbox.Text;
            if (tm == "")
            {
                listbox.Items.Clear();
                for (i = 0; i <= 231; i++)
                {
                    listbox.Items.Add(lines[i]);
                }
                return;
            }
            listbox.Items.Clear();
            string tmp; int j;
            string tm_save = tm;
            tm = tm.ToUpper();
            for (i = 0; i <= 231; i++)
            {
                tmp = lines[i];
                string[] tachchuoi = tmp.Split(' ');
                for (j = 0; j < tachchuoi.Length; j++) 
                {
                    string a1 = tachchuoi[j];
                    a1 = a1.ToUpper();
                    bool res = checkstr(a1, tm);
                    if (res)
                    {
                        listbox.Items.Add(lines[i]);
                        break;
                    }
                }
                tm_save = upper1(tm_save);
                if (lines[i].StartsWith(tm_save))
                {
                    listbox.Items.Add(lines[i]);
                    
                }
            }
            
        }
        
        private void textbox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            textbox.Text = "";
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/infomation.xaml", UriKind.Relative));
        }

        private void find_Click(object sender, EventArgs e)
        {
            //textbox_Tap(textbox,System.Windows.Input.GestureEventArgs e);
            //textbox.Tap += new EventHandler(textbox_Tap);
            
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/chuandoanbenh.xaml", UriKind.Relative));
        }


    }
}