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
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace Project_Evlin
{
    public partial class PopUp : Form
    {
        Form1 f1 = null;
        int count = 0;
        degrees degree;
        Rest rj = new Rest("http://ist.rit.edu/api");
        Rest rjGoogle = new Rest("http://info.google.com/api");
        public PopUp(Form1 f1,int m)
        {
            // Adding graduate course details to textbox
            this.f1 = f1;
            InitializeComponent();
             count = m;
            //MessageBox.Show(count.ToString());
            string jsonAbout = rj.getRestData("/degrees/");
            degree = JToken.Parse(jsonAbout).ToObject<degrees>();
            metroTextBox1.Text = degree.undergraduate.ElementAt(count).title;
            metroTextBox1.TextAlign = HorizontalAlignment.Center;
            richTextBox1.Name = count.ToString();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.AppendText("Concentrations");
            richTextBox1.SelectionBullet = true;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            for (int i=0;i<degree.undergraduate.ElementAt(count).concentrations.Count;i++)
            {
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText(degree.undergraduate.ElementAt(count).concentrations[i]);

            }
          
        }
         void addtextundergrad()
        {
           
           


        }
        
    }
}

