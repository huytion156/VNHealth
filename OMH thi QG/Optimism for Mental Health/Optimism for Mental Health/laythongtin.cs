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
    public partial class laythongtin : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        int data = 0;
        public int getvalue()
        {
            return data;
        }
        public laythongtin()
        {
            InitializeComponent();
        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mucdo1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mucdo2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            kryptonGroupBox1.Text = "Thông tin";
            int i = 0;
            for (i = 1; i <= 200; i++)
            {
                weight.Items.Add(i);
                height.Items.Add(i);
                if ((i >= 10) && (i <= 120)) age.Items.Add(i);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            double res = 0;
            double a = 0, b = 0, c = 0;
            if (checkNam.Checked == true)
            {
                a = 9.9 * Convert.ToInt16(weight.Text);
                b = 6.3 * Convert.ToInt16(height.Text);
                c = 4.9 * Convert.ToInt16(age.Text);
                res = a + b + c + 5;
            };
            if (checkNữ.Checked == true)
            {
                a = 9.9 * Convert.ToInt16(weight.Text);
                b = 6.3 * Convert.ToInt16(height.Text);
                c = 4.9 * Convert.ToInt16(age.Text);
                res = a + b + c -161;
            };

            if (checkNam.Checked == true)
            {
                res = res*0.9;
            };
            if (checkNữ.Checked == true)
            {
                res = res*0.9;
            };
            if (mucdo1.Checked == true) res = res * 1.3;
            else if (mucdo2.Checked == true) res = res * 1.55;
            else if (mucdo3.Checked == true) res = res * 1.65;
            else if (mucdo4.Checked == true) res = res * 1.8;
            else if (mucdo5.Checked == true) res = res * 2;
            if (muctieu1.Checked == true) res = res + 500;
            else if (muctieu2.Checked == true) res = res - 500;
            data = Convert.ToInt16(res);
            this.Close();
        }
    }
}
