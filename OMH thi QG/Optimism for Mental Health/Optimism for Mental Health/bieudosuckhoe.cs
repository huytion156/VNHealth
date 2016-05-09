using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Optimism_for_Mental_Health
{
    public partial class bieudosuckhoe : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
      
        
        public bieudosuckhoe()
        {
            InitializeComponent();
        }
        public delegate void Truyen(TextBox text);
        private void bieudosuckhoe_Load(object sender, EventArgs e)
        {
            kryptonGroupBox1.Text = "Nhập dữ liệu theo dõi";
            kryptonGroupBox2.Text = "Bảng theo dõi";
            string s = "";
            s = "data\\dulieutheodoi\\list.dat";
            string[] lines = File.ReadAllLines(s);
            for (int i = 0; i < lines.Length; i++)
            {
                chondulieu.Items.Add(lines[i]);
            };
            

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.ShowDialog();
            chondulieu.Items.Clear();
            string s = "";
            s = "data\\dulieutheodoi\\list.dat";
            string[] lines = File.ReadAllLines(s);
            for (int i = 0; i < lines.Length; i++)
            {
                chondulieu.Items.Add(lines[i]);
            };
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (chondulieu.Text == "") MessageBox.Show("Bạn chưa chọn đối tượng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                int k = 0;
                string s = "data\\dulieutheodoi\\";

                s = s + chondulieu.Text;
                string[] lines = File.ReadAllLines(s);
                for (int i = 0; i <= lines.Length; i++)
                {
                    s = lines[i];
                    if (s == "@") break;
                    char thu = s[0];
                    if (thu == '#')
                    {
                        k = k + 1;
                        listBox1.Items.Add(k);
                        string[] ketqua = s.Split('#', ' ');
                        chart1.Series["Cân nặng"].Points.Add(new DataPoint(k, Convert.ToInt32(ketqua[3])));
                        chart1.Series["Cân nặng"].Points.Add(new DataPoint(k, Convert.ToInt32(ketqua[3])));
                        chart1.Series["Cân nặng"].ChartType = SeriesChartType.Line;
                        listBox3.Items.Add(ketqua[3]);
                        listBox2.Items.Add(ketqua[2]);
                        chart1.Series["Chiều cao"].Points.Add(new DataPoint(k, Convert.ToInt32(ketqua[2])));
                        chart1.Series["Chiều cao"].Points.Add(new DataPoint(k, Convert.ToInt32(ketqua[2])));
                        chart1.Series["Chiều cao"].ChartType = SeriesChartType.Line;
                    }
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp=listBox1.SelectedIndex;
            listBox2.SelectedIndex = tmp;
            listBox3.SelectedIndex = tmp;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = listBox2.SelectedIndex;
            listBox1.SelectedIndex = tmp;
            listBox3.SelectedIndex = tmp;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = listBox3.SelectedIndex;
            listBox2.SelectedIndex = tmp;
            listBox1.SelectedIndex = tmp;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chondulieu.Text == "") MessageBox.Show("Bạn chưa chọn đối tượng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Form5 frm = new Form5(chondulieu.Text);
                frm.ShowDialog();
            }
        }

        private void thôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infomation fr = new infomation();
            fr.ShowDialog();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
