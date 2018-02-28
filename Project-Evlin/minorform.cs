using Newtonsoft.Json.Linq;
using RESTUtil;
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
    public partial class minorform : Form
    {
        Form1 f1 = null;
        int count = 0;
        minors mi;
        Rest rj = new Rest("http://ist.rit.edu/api");
        Rest rjGoogle = new Rest("http://info.google.com/api");
        public minorform(Form1 f1, int m)
        {
            this.f1 = f1;
            InitializeComponent();

            count = m;
            string jsonAbout = rj.getRestData("/minors/");
            mi = JToken.Parse(jsonAbout).ToObject<minors>();
            metroLabel1.Text = mi.UgMinors.ElementAt(count).title;
            textBox1.Text = mi.UgMinors.ElementAt(count).description;


        }

        private void minorform_Load(object sender, EventArgs e)
        {

        }
    }
}
