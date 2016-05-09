using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Optimism_for_Mental_Health
{
    public partial class formchinh : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public formchinh()
        {
            InitializeComponent();
        } 
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Visible = false;
            f1.ShowDialog();
            this.Visible = true;
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //MessageBox.Show("Chức năng đang được xây dựng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            chonluabuaan fr = new chonluabuaan();
            fr.ShowDialog();
            this.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bieudosuckhoe f4 = new bieudosuckhoe();
            this.Visible = false;
            f4.ShowDialog();
            this.Visible = true;
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MessageBox.Show("Chức năng đang được xây dựng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Visible = true;       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            adddata f3 = new adddata();
            f3.ShowDialog();
            this.Visible = true;
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("picture\\chucnang2.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("picture\\chucnang3.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("picture\\chucnang1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("picture\\chucnang4.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("picture\\chucnang5.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formchinh_Load(object sender, EventArgs e)
        {
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            infomation fr = new infomation();
            fr.ShowDialog();
            this.Visible = true;
        }

        private void kryptonButton2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("picture\\chucnang6.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ketnoichuyengia fr = new ketnoichuyengia();
            fr.ShowDialog();
            this.Visible = true;
        }

        private void kryptonButton3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("picture\\chucnang7.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            hopthuoc f1 = new hopthuoc();
            this.Visible = false;
            f1.ShowDialog();
            this.Visible = true;
        }
    }
}
