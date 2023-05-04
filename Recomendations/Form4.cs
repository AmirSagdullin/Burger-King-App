using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recomendations
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void buttonToIzbr_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void buttonToPodbor_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }
    }
}
