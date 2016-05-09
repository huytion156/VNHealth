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
    public partial class chuandoanbenh : PhoneApplicationPage
    {
        int[,] a = new int[2001, 5];
        long i, n, m, L;
        bool[] p = new bool[2001];
        bool[] free = new bool[2001];
        bool[] chose = new bool[2001];
        long[] next = new long[2001];
        long[] list = new long[5];
        public string[] bangmachuin = new string[100];
        public string[] bangmachuthuong = new string[100];
        public string[] lines = new string[2000];
        public string[] name = new string[500];
        public int[] v = new int[32000];
        public bool kiemtralandau = false;
        public bool dachonbenh = false;
        public bool timkiemlandau = false;

        private bool behon(string a, string b)
        {
            int n = 0;
            int i, x1 = 0, y1 = 0;
            if (a.Length < b.Length) n = a.Length;
            else n = b.Length;
            for (i = 0; i < n; i++)
            {
                x1 = a[i];
                y1 = b[i];
                x1 = v[x1];
                y1 = v[y1];
                if (x1 != y1) break;
            }
            return (x1 <= y1);
        }

        private static string upper1(string s)
        {
            s = s.ToLower();
            char[] charArr = s.ToCharArray();
            charArr[0] = char.ToUpper(charArr[0]);
            return new String(charArr);
        }

        private int binarysearch(string s, string[] chuoi, int n)
        {
            int fir = 0, las = n, mid;
            while (fir + 1 < las)
            {
                mid = ((fir + las) >> 1);
                //if (kiemtrachuoi(chuoi[mid],s)) return mid;
                if (behon(chuoi[mid], s)) fir = mid;
                else las = mid;
            }
            return fir;
        }

        public void nhaptapluat()
        {
            n = 232;
            //string[] lines = File.ReadAllLines("data\\hechuyengia\\tapluat.txt");
            var fin = new StreamReader("data\\hechuyengia\\tapluat.txt");
            for (int i = 0; i <= 231; i++)
            {
                string s = fin.ReadLine();
                if (s != null) lines[i] = s;
            }
            fin.Close();
            for (int i = 0; i <= 231; i++)
            {
                string[] s = lines[i].Split(' ');
                a[i, 0] = Convert.ToInt32(s[0]);
                a[i, 1] = Convert.ToInt32(s[1]);
                a[i, 2] = Convert.ToInt32(s[2]);
                a[i, 3] = Convert.ToInt32(s[3]);
                a[i, 4] = Convert.ToInt32(s[4]);
            }
        }

        public void Process(long k)
        {
            long i, j;
            m = 0;
            p[k] = true;
            for (i = 0; i <= 2000; i++)
                free[i] = false;
            for (i = 0; i <= n - 1; i++)
                if (chose[i] == true)
                {
                    chose[i] = false;
                    for (j = 0; j <= 4; j++)
                        chose[i] = (chose[i] == true || a[i, j] == k);
                    if (chose[i] == false) continue;
                    for (j = 0; j <= 4; j++)
                        if ((p[a[i, j]] == false) && (free[a[i, j]] == false))
                        {
                            free[a[i, j]] = true;
                            next[m] = a[i, j];
                            m++;
                        }
                }
        }




        public chuandoanbenh()
        {
            InitializeComponent();
            nhaptapluat();
            var fin = new StreamReader("data\\hechuyengia\\tenbenh.txt");
            for (int i = 0; i <= 231; i++)
            {
                string s = fin.ReadLine();
                if (s != null) name[i] = s;
            }
            fin.Close();

            fin = new StreamReader("data\\hechuyengia\\trieuchung.txt");
            for (int i = 0; i <= 706; i++)
            {
                string s = fin.ReadLine();
                if (s != null) lines[i] = s;
            }
            fin.Close();
            for (i = 0; i <= 2000; i++) chose[i] = true;
            //trieuchungtieptheo.Items.AddRange(lines);
            //trieuchungtieptheo.Items.Add(lines);
            for (i = 0; i <= 706; i++) trieuchungtieptheo.Items.Add(lines[i]);


        }
        public bool sosanhchuoi(string a, string b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
        public int timvitri(string s)
        {
            for (int i = 0; i <= 706; i++)
                if (checkstr(s, lines[i]) == true) return i + 1;
            return -1;
        }
        public int timvitritenbenh(string s)
        {
            for (int i = 0; i <= 706; i++)
                if (checkstr(s, name[i]) == true) return i + 1;
            return -1;
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            timkiemlandau = true;
            if (L == 5) return;
            trieuchungdachon.Text = "";
            trieuchungtieptheo.Items.Clear();
            tenbenh.Items.Clear();

            //list[L] = Convert.ToInt32(timkiem.Text)+1;
            int tmp = timvitri(timkiem.Text);
            list[L] = tmp;
            L++;
            //for (i = 0; i <= 2000; i++) chose[i] = true;
            Process(tmp);
            string str = "";

            //for (i = 0; i <= L - 1; i++) trieuchungdachon.Items.Add(list[i]);
            for (i = 0; i <= L - 1; i++) str = str + lines[list[i] - 1] + " --> ";
            trieuchungdachon.Text = str;
            if (m > 0)
                for (i = 0; i <= m - 1; i++) trieuchungtieptheo.Items.Add(lines[next[i] - 1]);
            for (i = 0; i <= n - 1; i++)
                if (chose[i] == true) tenbenh.Items.Add(name[i]);
        }

        private void trieuchungtieptheo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kiemtralandau = true;
            if (trieuchungtieptheo.Items.Count != 0) timkiem.Text = trieuchungtieptheo.SelectedItem.ToString();
            label1.Text = "Mã số triệu chứng: " + timvitri(timkiem.Text).ToString();
        }

        private bool checkstr(string a, string b) // kiem tra chuoi a = b ?
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false; //a !=b
            return true; //a=b
        }

        private void timkiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (timkiemlandau == true)
            {
                timkiem.IsReadOnly = true;
                return;
            }
            string tm = timkiem.Text;
            if (tm == "")
            {
                trieuchungtieptheo.Items.Clear();
                for (i = 0; i <= 706; i++)
                {
                    trieuchungtieptheo.Items.Add(lines[i]);
                }
                return;
            }
            trieuchungtieptheo.Items.Clear();
            string tmp; int j;
            string tm_save = tm;
            tm = tm.ToUpper();
            for (i = 0; i <= 706; i++)
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
                        trieuchungtieptheo.Items.Add(lines[i]);
                        break;
                    }
                }
                tm_save = upper1(tm_save);
                if (lines[i].StartsWith(tm_save))
                {
                    trieuchungtieptheo.Items.Add(lines[i]);

                }
            }
        }

        private void xembenh_Click(object sender, RoutedEventArgs e)
        {
            if (dachonbenh == false) return;
            string a = tenbenh.SelectedItem.ToString();

            int n = timvitritenbenh(a);
            //label1.Text = n.ToString();
            var link = "/thongtinbenh.xaml?parameter=" + n.ToString();
            NavigationService.Navigate(new Uri(link, UriKind.Relative));
        }

        private void tenbenh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dachonbenh = true;
        }



    }
}