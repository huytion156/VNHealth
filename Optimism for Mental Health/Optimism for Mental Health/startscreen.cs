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
    public partial class startscreen : Form
    {
        public startscreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form fm = new formchinh();
            this.Visible = false;
            this.ShowInTaskbar = false;
            timer1.Enabled = false;
            fm.ShowDialog();
            this.Close();
        }

        private void startscreen_Load(object sender, EventArgs e)
        {

        }
    }
}
