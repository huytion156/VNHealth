using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Optimism_for_Mental_Health
{
    public partial class chuandoanbenh : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public chuandoanbenh()
        {
            InitializeComponent();
        }
        int[,] a = new int[2001, 5];
        long i,n,m, L;
        bool[] p = new bool[2001];
        bool[] free = new bool[2001];
        bool[] chose = new bool[2001];
        long[] next = new long[2001];
        long[] list = new long[5];
        string[] bangmachuin = File.ReadAllLines("data\\bangmachuin.txt");
        string[] bangmachuthuong = File.ReadAllLines("data\\bangmachuthuong.txt");
        string[] lines = File.ReadAllLines("data\\hechuyengia\\trieuchung.txt");
        string[] name = File.ReadAllLines("data\\hechuyengia\\tenbenh.txt");
        public int[] v = new int[32000];
        public bool kiemtralandau = false;
        public bool dachonbenh = false;
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
        private bool kiemtrachuoi(string a, string b) //a dai b ngan
        {
            int n = b.Length, x1, y1;
            for (int i = 0; i < n; i++)
            {
                x1 = a[i];
                y1 = b[i];
                x1 = v[x1];
                y1 = v[y1];
                if (y1 != x1) return false;
            }
            return true;
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
            string[] lines = File.ReadAllLines("data\\hechuyengia\\tapluat.txt");
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
        public string getvalue()
        {
            return tenbenh.SelectedItem.ToString();
        }
        private void chuandoanbenh_Load(object sender, EventArgs e)
        {
            nhaptapluat();
            int i, a;
            for (i = 0; i <= 2000; i++) chose[i] = true;
            trieuchungtieptheo.Items.AddRange(lines);
            for (i = 0; i < bangmachuin.Length; i++)
            {
                a = bangmachuin[i][0];
                v[a] = i;
            }
            for (i = 0; i < bangmachuthuong.Length; i++)
            {
                a = bangmachuthuong[i][0];
                v[a] = i;
            }
            kryptonGroupBox1.Text = "Tìm kiếm";
            kryptonGroupBox2.Text = "Triệu chứng chuẩn đoán";
            kryptonGroupBox3.Text = "Bệnh được chuẩn đoán";
            kryptonGroupBox4.Text = "Bộ máy suy diễn";
        }
        public int timvitri(string s)
        {
            for (int i = 0; i <= lines.Length; i++)
                if (lines[i] == s) return i + 1;
            return -1;
        }
        private void find_Click(object sender, EventArgs e)
        {
            if (L == 5) return;
            trieuchungdachon.Clear();
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

        private void trieuchungtieptheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            kiemtralandau = true;
            timkiem.Text = trieuchungtieptheo.SelectedItem.ToString();
            label1.Text = timvitri(timkiem.Text).ToString();
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
            if ((tenbenh.Items.Count==0)&&(kiemtralandau==false))
            {
                string tm = timkiem.Text;
                if (tm == "")
                {
                    trieuchungtieptheo.Items.Clear();
                    trieuchungtieptheo.Items.AddRange(lines);
                    return;
                }
                int root = binarysearch(tm, lines, lines.Length);
                if (kiemtrachuoi(lines[root], tm))
                {
                    int i = 0;
                    trieuchungtieptheo.Items.Clear();
                    for (i = root; i > -1; i--)
                        if ((kiemtrachuoi(lines[i], tm))) trieuchungtieptheo.Items.Add(lines[i]);
                    //kiemtralandau = true;
                }
            }
            else return;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if(dachonbenh==false)
                MessageBox.Show("Chưa chọn bệnh đã chuẩn đoán", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else this.Close();

        }

        void tenbenh_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



        private void tenbenh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dachonbenh = true;
        }


    }
}
