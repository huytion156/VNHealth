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
    public partial class infomation : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public infomation()
        {
            InitializeComponent();
        }

        private void infomation_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
