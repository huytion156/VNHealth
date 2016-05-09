using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Optimism_for_Mental_Health
{
    public partial class Form2 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        string[] lines  = File.ReadAllLines("data\\dulieubenh\\menu.crak");
        private string[] bangmachuin = File.ReadAllLines("data\\bangmachuin.txt");
        private string[] bangmachuthuong = File.ReadAllLines("data\\bangmachuthuong.txt");
        public int[] v = new int[32000];
        public Form2()
        {
            InitializeComponent();
        }
        private bool behon(string a, string b)
        {
            int n = 0;
            int i,x1=0,y1=0;
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
            int n = b.Length,x1,y1;
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
        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            groupBox2.Text = "Tìm kiếm";
            groupBox1.Text = "Danh sách bệnh";
            groupBox3.Text = "Thông tin";
            //Array.Sort(lines, StringComparer.InvariantCulture);            f
            int i = 0;
            int a;
            //richTextBox1.Visible = true;
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
           /* for ( i = 0; i < bangmachuin.Length; i++)
            {
                a = bangmachuin[i][0];
                richTextBox1.Text += bangmachuin[i] + " " + a + " " + v[a];
                a = bangmachuthuong[i][0];
                richTextBox1.Text += " " + bangmachuthuong[i] + " " + a + " " + v[a] + "\n";
            }*/
           for (i = 0; i < lines.Length; i++)
             listBox1.Items.Add(lines[i]);            
        }

        private void listBox1_SelectedIndexChanged(EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            string s = "";
            richTextBox1.Visible = true;
            richTextBox1.Enabled = true;
            s = listBox1.SelectedItem.ToString();
            s = "data\\dulieubenh\\information\\" + s + ".txt";
            StreamReader fin = File.OpenText(s);
            richTextBox1.Text = fin.ReadToEnd();
            fin.Close();
            s = listBox1.SelectedItem.ToString();
            s = "data\\dulieubenh\\picture\\" + s + ".jpg";
            
            if (File.Exists(s))
            {
                pictureBox1.Image = Image.FromFile(s);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.Image = Image.FromFile("data\\dulieubenh\\picture\\noinfomation.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
                string tm = textBox1.Text;
                if (tm == "")
                {
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(lines);
                    return;               
                } 
                int root = binarysearch(tm, lines, lines.Length);
                if (kiemtrachuoi(lines[root],tm))
                {
                    int i=0;
                    listBox1.Items.Clear();
                    for (i = root; i >-1;i--)
                        //if ( (i==-1) || (lines[i].ToString().StartsWith(tm)==false)) break;
                        if ((kiemtrachuoi(lines[i], tm))) listBox1.Items.Add(lines[i]);
                    /*for (j = root; j <= lines.Length; j++)
                        //if ((j == lines.Length + 1) || (lines[j].ToString().StartsWith(tm)==false)) break;
                        if (j == lines.Length) break;
                        else
                        {
                            if (kiemtrachuoi(lines[j], tm) == false) break;
                        }
                            
                    i += 1;
                    j -= 1;
                    
                    for (int k = i; k <= j; k++)
                        listBox1.Items.Add(lines[k]);*/
                }
                
                
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //string tm = "";
            //tm = textBox1.Text + e.KeyChar.ToString();
            //if (lines[0].ToString().StartsWith(tm)) listBox1.SelectedIndex = 0;    
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void find_Click_1(object sender, EventArgs e)
        {
            string link = "";
            string part1 = "https://www.google.com.vn/search?q=";
            string part2 = "&oq=";
            string part3 = "&aqs=chrome..69i57j69i59j69i61j0l3.3371j0j7&sourceid=chrome&es_sm=93&ie=UTF-8";
            //công thức = part1+bệnh+part2+bệnh+part3;
            link = part1 + textBox1.Text + part2 + textBox1.Text + part3;
            Process.Start(link);
            textBox1.Text = "";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infomation fr = new infomation();
            fr.ShowDialog();
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "huongdansudung.pdf";
            proc.Start();
        }

        private bool checkstr(string a, string b) // kiem tra a = b
        {
            if (a.Length!=b.Length) return false;
            for(int i=0;i<a.Length;i++)
                if (a[i]!=b[i]) return false;
            return true;
        }
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string s = textBox1.Text;
            string tmp = "";
            int j;
            for (int i = 0; i < lines.Length; i++)
            {
                tmp = lines[i];
                string[] tachchuoi = tmp.Split(' ');
                for (j = 0; j < tachchuoi.Length; j++)
                {
                    bool res = checkstr(tachchuoi[j], s);
                    if (res)
                    {
                        listBox1.Items.Add(lines[i]);
                        break;
                        
                    }
                }
            }
        }

        private void chuẩnĐoánBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chuandoanbenh fr = new chuandoanbenh();
            fr.ShowDialog();
            //textBox1.Text= fr.getvalue();
            string s = fr.getvalue();
            if (s != "")
            {
                richTextBox1.Visible = true;
                richTextBox1.Enabled = true;
                s = "data\\dulieubenh\\information\\" + s + ".txt";
                StreamReader fin = File.OpenText(s);
                richTextBox1.Text = fin.ReadToEnd();
                fin.Close();
                s = fr.getvalue();
                s = "data\\dulieubenh\\picture\\" + s + ".jpg";

                if (File.Exists(s))
                {
                    pictureBox1.Image = Image.FromFile(s);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBox1.Image = Image.FromFile("data\\dulieubenh\\picture\\noinfomation.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}
