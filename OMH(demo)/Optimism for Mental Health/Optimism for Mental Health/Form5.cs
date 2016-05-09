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
    public partial class Form5 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Form5(string strTextBox)
        {
            InitializeComponent();
            name.Text = strTextBox;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            kryptonGroupBox2.Text = "Thông tin cá nhân";
            kryptonGroupBox1.Text = "Bảng theo dõi";
            int k = 0;
            string s = "data\\dulieutheodoi\\"+name.Text;
            string[] lines = File.ReadAllLines(s);
            string st = lines[0];
            string[] ketqua = st.Split('/');
            
            day.Text = ketqua[0];
            month.Text = ketqua[1];
            year.Text = ketqua[2];
            note.Text = lines[1];
            for (int i = 2; i <= lines.Length; i++)
            {
                st = lines[i];
                string stm = lines[i];
                char tr = stm[0];
                if (tr == '@') break;
                string[] chuoi = st.Split('/', ' ');
                k = k + 1;
                //listBox1.Items.Add(k);
                //listBox3.Items.Add(chuoi[2]);
                //listBox2.Items.Add(chuoi[1]);
                DataGridView.Rows.Add(k.ToString(), chuoi[1].ToString(), chuoi[2].ToString());
            }
                 
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string stt = "data\\dulieutheodoi\\";

            stt = stt + name.Text;
            FileStream fs = new FileStream(stt, FileMode.Create);
            StreamWriter fin1 = new StreamWriter(fs, Encoding.UTF8);
            fin1.WriteLine(day.Text + "/" + month.Text + "/" + year.Text);
            if (note.Text == "") fin1.WriteLine("none");
            else fin1.WriteLine(note.Text);
            //fin1.WriteLine("#" + " " + chieucao.Text + " " + cannang.Text);
            //fin1.WriteLine("@");
            string a = "";
            string b = "";
            for (int i = 0; i < DataGridView.RowCount - 1; i++)
            {
                a = DataGridView.Rows[i].Cells[1].Value.ToString();
                b = DataGridView.Rows[i].Cells[2].Value.ToString();
                fin1.WriteLine("#" + " " + a + " " + b);
            }
            fin1.WriteLine("@");
            fin1.Close();
            MessageBox.Show("Dữ liệu đã được lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);  
        }

        private void kryptonGroupBox2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
