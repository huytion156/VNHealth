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
    public partial class Form1 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool kiemtra(string s)
        {
            int n = 0;
            if (int.TryParse(s, out n) == true) return true;
            else return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            kryptonGroupBox1.Text = "Thông tin đánh giá";
            kryptonGroupBox2.Text = "Chỉ số sức khỏe";
            kryptonGroupBox3.Text = "Đánh giá sức khỏe của bạn";

        }

        private void check_Click(object sender, EventArgs e)
        {
           
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infomation fr = new infomation();
            fr.ShowDialog();
        }

        private void check_Click_1(object sender, EventArgs e)
        {
            if ((kiemtra(textBox1.Text) == false) || (kiemtra(textBox2.Text) == false))
                MessageBox.Show("ERROR", "Lỗi xác định", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                richTextBox1.Visible = true;
                float chieucao = Convert.ToInt32(textBox1.Text);
                float cannang = Convert.ToInt32(textBox2.Text);
                chieucao = chieucao / 100;
                float bmi = cannang / (chieucao * chieucao);
                if (nam.Checked == true) bmi = bmi + 2;
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
                StreamReader fin = File.OpenText(s);
                richTextBox1.Text = fin.ReadToEnd();
                fin.Close();
                label4.Text = Convert.ToString(Math.Round(bmi, 2));
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
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
