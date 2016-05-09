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
    public partial class danhsachthucan : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public danhsachthucan()
        {
            InitializeComponent();
        }
        long res = 0;
        public long getvalue()
        {
            return res;
        }
        private void danhsachthucan_Load(object sender, EventArgs e)
        {
            //Excel _excel = new Excel("menu.xls");
            //dataGridView1.DataSource = _excel.GetDataTable("select * from [Sheet1$]");
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 70;
            StreamReader fin = new StreamReader("menu.dat");
            var a = new int[500];
            var lines = new string[500];
            int tmp = 0;
            string s = "";
            int k = 0;
            for (int i = 1; i <= 283; i++)
            {
                s = fin.ReadLine();
                tmp = Convert.ToInt32(fin.ReadLine());
                k = k + 1;
                lines[k] = s;
                a[k] = tmp;
                dataGridView1.Rows.Add(k, s, tmp);
            }
            fin.Close();
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int j = 0; j < dataGridView1.Rows.Count; j++) dataGridView1.Rows[j].Selected = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().StartsWith(textBox1.Text + e.KeyChar.ToString()))
                {
                    dataGridView1.Rows[i].Selected = true;
                    //grdData.CurrentCell = grdData.Rows[iRow].Cells[0];
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];
                    break;
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kryptonListBox1.Items.Add(s);
            kryptonListBox2.Items.Add(dataGridView1.CurrentRow.Cells[2].Value);
            res = res + Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
            sum.Text = res.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kryptonListBox1.Items.Add(s);
            kryptonListBox2.Items.Add(dataGridView1.CurrentRow.Cells[2].Value);
            res = res + Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
            sum.Text = res.ToString();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            int tmp = kryptonListBox1.SelectedIndex;
            if (tmp == -1) MessageBox.Show("Chưa chọn món ăn cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                res = res - Convert.ToInt32(kryptonListBox2.Items[tmp]);
                kryptonListBox1.Items.RemoveAt(tmp);
                kryptonListBox2.Items.RemoveAt(tmp);
                if(kryptonListBox1.Items.Count!=0) kryptonListBox1.SelectedIndex = tmp;
            }
            sum.Text = res.ToString();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
