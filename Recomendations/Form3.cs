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
    public partial class Form3 : Form
    {
        static public string Login { get; set; }
        public Form3()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public Form3(string login)
        {
            InitializeComponent();
            CenterToScreen();
            Login = login;
        }
    }
}
