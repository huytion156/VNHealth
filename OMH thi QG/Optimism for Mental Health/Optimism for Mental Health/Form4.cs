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
    public partial class Form4 : ComponentFactory.Krypton.Toolkit.KryptonForm

    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            kryptonGroupBox2.Text = "Thông tin";
            int i = 0;
            for (i = 1; i <= 31; i++)
                day.Items.Add(i);
            for (i = 1; i <= 12; i++)
                month.Items.Add(i);
            for (i = 1900; i <= DateTime.Now.Year; i++)
                year.Items.Add(i);
            for (i = 50; i <= 250; i++)
                chieucao.Items.Add(i);
            for (i = 1; i <= 300; i++)
                cannang.Items.Add(i);

            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            StreamWriter fin= new StreamWriter("data\\dulieutheodoi\\list.dat",true);
            fin.WriteLine(name.Text);
            fin.Close();
            string s = "data\\dulieutheodoi\\";

            s = s + name.Text;
            FileStream fs = new FileStream(s, FileMode.Create);
            StreamWriter fin1 = new StreamWriter(fs, Encoding.UTF8);
            fin1.WriteLine(day.Text + "/"+month.Text+"/"+year.Text);
            if (note.Text=="") fin1.WriteLine("none");
            else    fin1.WriteLine(note.Text);
            fin1.WriteLine("#"+" "+chieucao.Text + " " + cannang.Text);
            fin1.WriteLine("@");
            fin1.Close();
            MessageBox.Show("Dữ liệu đã được lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            name.Text = "";
            day.Text = ""; month.Text = ""; year.Text = "";
            chieucao.Text = ""; cannang.Text = "";
            note.Text = "";

        }
    }
}
