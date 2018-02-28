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
    
    public partial class peopleform : Form
    {
        Form1 f1 = null;
        int count = 0;
        People p;
        Rest rj = new Rest("http://ist.rit.edu/api");
        Rest rjGoogle = new Rest("http://info.google.com/api");
        public peopleform(Form1 f1, int m,String cat )
        {
            this.f1 = f1;
            InitializeComponent();
            count = m;
            string jsonAbout = rj.getRestData("/people/");
            p = JToken.Parse(jsonAbout).ToObject<People>();
            if (cat == "faculty")
            {
                metroLabel1.Text = p.faculty.ElementAt(count).name;
                pictureBox1.Size = new System.Drawing.Size(140, 140);
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox1.Load(p.faculty.ElementAt(count).imagePath);
                metroLabel4.Text = p.faculty.ElementAt(count).email;
                metroLabel5.Text = p.faculty.ElementAt(count).phone;
            }
            else
            {
                metroLabel1.Text = p.staff.ElementAt(count).name;
                pictureBox1.Size = new System.Drawing.Size(140, 140);
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox1.Load(p.staff.ElementAt(count).imagePath);
                metroLabel4.Text = p.staff.ElementAt(count).email;
                metroLabel5.Text = p.staff.ElementAt(count).phone;

            }
           

        }

    }
}
