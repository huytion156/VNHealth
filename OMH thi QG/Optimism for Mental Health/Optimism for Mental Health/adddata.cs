using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ComponentFactory.Krypton.Toolkit;
namespace Optimism_for_Mental_Health
{
    public partial class adddata : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private string[] bangmachuin = File.ReadAllLines("data\\bangmachuin.txt");
        private string[] bangmachuthuong = File.ReadAllLines("data\\bangmachuthuong.txt");
        public int[] v = new int[32000];
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
            return (x1 < y1);
        }
        private void Quicksort(ref string[] a, int l,int r)
        {
            if (l >= r) return;
            int i = l; int j = r;
            string v = a[(l + r) >> 1];
            while (i <= j)
            {
                while (behon(a[i], v)) i++;
                while (behon(v, a[j])) j--;
                if (i <= j)
                {
                    string t = "";
                    t = a[i]; a[i] = a[j]; a[j] = t;
                    i++;
                    j--;
                }
            }
            Quicksort(ref a, i, r);
            Quicksort(ref a, l, j);
        }
        public adddata()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void adddata_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "Thông tin vừa lưu";
            int i = 0;
            int a;
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
        }
     

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s = "";
            s = "data\\dulieubenh\\information\\" + textBox1.Text + ".txt";
            FileStream fs = new FileStream(s, FileMode.Create);
            StreamWriter fin = new StreamWriter(fs, Encoding.UTF8);
            int dem = 1;
            if (richTextBox1.Text != "")
            {
                fin.WriteLine(Convert.ToString(dem) + ". Nguyên nhân và triệu chứng");
                fin.WriteLine(richTextBox1.Text);
                fin.WriteLine();
                dem = dem + 1;
            }
            if (richTextBox2.Text != "")
            {
                fin.WriteLine(Convert.ToString(dem) + ". Cách chữa trị thông thường");
                fin.WriteLine(richTextBox2.Text);
                fin.WriteLine();
                dem = dem + 1;
            }
            if (richTextBox3.Text != "")
            {
                fin.WriteLine(Convert.ToString(dem) + ". Cách phòng tránh");
                fin.WriteLine(richTextBox3.Text);
                fin.WriteLine();
                dem = dem + 1;
            }
            if (richTextBox4.Text != "")
            {
                fin.WriteLine(Convert.ToString(dem) + ". Thông tin thêm");
                fin.WriteLine(richTextBox4.Text);
                fin.WriteLine();
            }
            fin.Close();

            string[] lines = File.ReadAllLines("data\\dulieubenh\\menu.crak");
            Array.Resize(ref lines, lines.Length + 1);
            lines[lines.Length - 1] = textBox1.Text;
            Array.Sort(lines, StringComparer.InvariantCulture);
            FileStream fo = new FileStream("data\\dulieubenh\\menu.crak", FileMode.Create);
            StreamWriter fout = new StreamWriter(fo, Encoding.UTF8);
            for (int i = 0; i < lines.Length; i++)
            {
                fout.WriteLine(lines[i]);
            }
            fout.Close();

            StreamReader doc = new StreamReader(s);
            richTextBox5.Text = doc.ReadToEnd();
            //richTextBox4.Enabled = false;
            doc.Close();

            MessageBox.Show("Chúng tôi khuyến cáo bạn không nên tự ý thêm vào cơ sở dữ liệu \n nếu không phải là người chuyên ngành, bạn nên tham khảo chuyên gia trước khi bổ sung bệnh \n Chúng tôi sẽ không chịu trách nhiệm về những thông tin bạn bổ sung!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            s = "data\\dulieubenh\\information\\" + textBox1.Text + ".txt";
            FileStream fs = new FileStream(s, FileMode.Create);
            StreamWriter fin = new StreamWriter(fs, Encoding.UTF8);
            int dem = 1;
            if (richTextBox1.Text != "")
            {
                fin.WriteLine(Convert.ToString(dem) + ". Nguyên nhân và triệu chứng");
                fin.WriteLine(richTextBox1.Text);
                fin.WriteLine();
                dem = dem + 1;
            }
            if (richTextBox2.Text != "")
            {
                fin.WriteLine(Convert.ToString(dem) + ". Cách chữa trị thông thường");
                fin.WriteLine(richTextBox2.Text);
                fin.WriteLine();
                dem = dem + 1;
            }
            if (richTextBox3.Text != "")
            {
                fin.WriteLine(Convert.ToString(dem) + ". Cách phòng tránh");
                fin.WriteLine(richTextBox3.Text);
                fin.WriteLine();
                dem = dem + 1;
            }
            if (richTextBox4.Text != "")
            {
                fin.WriteLine(Convert.ToString(dem) + ". Thông tin thêm");
                fin.WriteLine(richTextBox4.Text);
                fin.WriteLine();
            }
            fin.Close();

            string[] lines = File.ReadAllLines("data\\dulieubenh\\menu.crak");
            Array.Resize(ref lines, lines.Length + 1);
            lines[lines.Length - 1] = textBox1.Text;
            //Array.Sort(lines, StringComparer.InvariantCulture);
            //Quicksort(ref lines, 0, lines.Length-1);
            int n = lines.Length - 1;
            string tmp;
            for (int i = n - 1; i >= 1; i--)
            {
                if (behon(lines[i], lines[i - 1]))
                {
                    tmp = lines[i]; lines[i] = lines[i - 1]; lines[i - 1] = tmp;
                }
                else break;
            }


            FileStream fo = new FileStream("data\\dulieubenh\\menu.crak", FileMode.Create);
            StreamWriter fout = new StreamWriter(fo, Encoding.UTF8);
            for (int i = 0; i < lines.Length; i++)
            {
                fout.WriteLine(lines[i]);
            }
            fout.Close();

            StreamReader doc = new StreamReader(s);
            richTextBox5.Text = doc.ReadToEnd();
            //richTextBox4.Enabled = false;
            doc.Close();

            MessageBox.Show("The file is saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void thôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infomation fr = new infomation();
            fr.ShowDialog();
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "huongdansudung.pdf";
            proc.Start();
        }
    }
}
