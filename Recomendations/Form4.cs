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
        public int User_id { get; set; }

        public Form4(int user_id)
        {
            InitializeComponent();
            CenterToScreen();
            User_id = user_id;
        }

        private void buttonToIzbr_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 form6 = new Form6(User_id);
            form6.Show();
        }

        private void buttonToPodbor_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
