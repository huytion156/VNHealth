using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Optimism_for_Mental_Health
{
    public partial class chonluabuaan : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        long sang = 0, trua = 0, nhe = 0, toi = 0, khac = 0,tong=0,muctieu=0,conlai=0;
        double phantram = 0;
        public chonluabuaan()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void chonluabuaan_Load(object sender, EventArgs e)
        {
            //int sang = 0, trua = 0, nhe = 0, toi = 0, khac = 0;
            

        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            laythongtin fr = new laythongtin();
            fr.ShowDialog();
            muctieu = fr.getvalue();
            label3.Text = fr.getvalue().ToString();
            
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            tong = tong - sang;
            sang = 0;
            danhsachthucan fr=new danhsachthucan();
            fr.ShowDialog();
            sang = fr.getvalue();
            sumsang.Text=fr.getvalue().ToString();
            tong = tong + sang;
            res.Text = tong.ToString();
            label1.Text = res.Text;
            conlai = muctieu - tong;
            label2.Text = conlai.ToString();
            if (muctieu == 0)
            {
                MessageBox.Show("Chưa chọn mục tiêu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            phantram = (tong * 100) / muctieu;
            
            if ((phantram > 20) && (phantram <= 40))
                pictureBox3.Image = Image.FromFile("picture\\25.png");
            else
                if ((phantram > 40) && (phantram <= 60))
                    pictureBox3.Image = Image.FromFile("picture\\50.png");
                else
                    if ((phantram > 60) && (phantram <= 80)) pictureBox3.Image = Image.FromFile("picture\\75.png");
                    else if (phantram > 95) pictureBox3.Image = Image.FromFile("picture\\100.png");
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            tong = tong - trua;
            trua = 0;
            danhsachthucan fr = new danhsachthucan();
            fr.ShowDialog();
            trua = fr.getvalue();
            sumtrua.Text = fr.getvalue().ToString();
            tong = tong + trua;
            res.Text = tong.ToString();
            label1.Text = res.Text;
            conlai = muctieu - tong;
            label2.Text = conlai.ToString();
            phantram = (tong * 100) / muctieu;
            if ((phantram > 20) && (phantram <= 40))
                pictureBox3.Image = Image.FromFile("picture\\25.png");
            else
                if ((phantram > 40) && (phantram <= 60))
                    pictureBox3.Image = Image.FromFile("picture\\50.png");
                else
                    if ((phantram > 60) && (phantram <= 80)) pictureBox3.Image = Image.FromFile("picture\\75.png");
                    else if (phantram > 95) pictureBox3.Image = Image.FromFile("picture\\100.png");
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            tong = tong - nhe;
            nhe = 0;
            danhsachthucan fr = new danhsachthucan();
            fr.ShowDialog();
            nhe = fr.getvalue();
            sumnhe.Text = fr.getvalue().ToString();
            tong = tong + nhe;
            res.Text = tong.ToString();
            label1.Text = res.Text;
            conlai = muctieu - tong;
            label2.Text = conlai.ToString();
            phantram = (tong * 100) / muctieu;
            if ((phantram > 20) && (phantram <= 40))
                pictureBox3.Image = Image.FromFile("picture\\25.png");
            else
                if ((phantram > 40) && (phantram <= 60))
                    pictureBox3.Image = Image.FromFile("picture\\50.png");
                else
                    if ((phantram > 60) && (phantram <= 80)) pictureBox3.Image = Image.FromFile("picture\\75.png");
                    else if (phantram > 95) pictureBox3.Image = Image.FromFile("picture\\100.png");
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            tong = tong - toi;
            toi = 0;
            danhsachthucan fr = new danhsachthucan();
            fr.ShowDialog();
            toi = fr.getvalue();
            sumtoi.Text = fr.getvalue().ToString();
            tong = tong + toi;
            res.Text = tong.ToString();
            label1.Text = res.Text;
            conlai = muctieu - tong;
            label2.Text = conlai.ToString();
            phantram = (tong * 100) / muctieu;
            if ((phantram > 20) && (phantram <= 40))
                pictureBox3.Image = Image.FromFile("picture\\25.png");
            else
                if ((phantram > 40) && (phantram <= 60))
                    pictureBox3.Image = Image.FromFile("picture\\50.png");
                else
                    if ((phantram > 60) && (phantram <= 80)) pictureBox3.Image = Image.FromFile("picture\\75.png");
                    else if (phantram > 95) pictureBox3.Image = Image.FromFile("picture\\100.png");
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            tong = tong - khac;
            khac = 0;
            danhsachthucan fr = new danhsachthucan();
            fr.ShowDialog();
            khac = fr.getvalue();
            sumkhac.Text = fr.getvalue().ToString();
            tong = tong + khac;
            res.Text = tong.ToString();
            label1.Text = res.Text;
            conlai = muctieu - tong;
            label2.Text = conlai.ToString();
            phantram = (tong * 100) / muctieu;
            if ((phantram > 20) && (phantram <= 40))
                pictureBox3.Image = Image.FromFile("picture\\25.png");
            else
                if ((phantram > 40) && (phantram <= 60))
                    pictureBox3.Image = Image.FromFile("picture\\50.png");
                else
                    if ((phantram > 60) && (phantram <= 80)) pictureBox3.Image = Image.FromFile("picture\\75.png");
                    else if (phantram > 95) pictureBox3.Image = Image.FromFile("picture\\100.png");
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "huongdansudung.pdf";
            proc.Start();
        }
    }
}
