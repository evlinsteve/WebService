using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Evlin
{
    public partial class map : Form
    {
        Form1 f1 = null;
        public map(Form1 f1)
        {
            InitializeComponent();
            webBrowser1.Navigate("http://ist.rit.edu/api/map");
        }
    }
}
