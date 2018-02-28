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
  
    public partial class ResearchFaculty : Form
    {
        Form1 f1 = null;
        int count = 0;
        Research r;
        Rest rj = new Rest("http://ist.rit.edu/api");
        Rest rjGoogle = new Rest("http://info.google.com/api");
        public ResearchFaculty(Form1 f1, int m,String cat)
        {
            this.f1 = f1;
            InitializeComponent();
            count = m;
            string jsonAbout = rj.getRestData("/research/");
            r = JToken.Parse(jsonAbout).ToObject<Research>();
            //Adding contents to page
            if (cat == "area")
            {
                metroLabel1.Text = r.byInterestArea.ElementAt(count).areaName;
               // metroTextBox1.TextAlign = HorizontalAlignment.Center;
                richTextBox1.Name = count.ToString();
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                richTextBox1.SelectionBullet = true;
                for (int i = 0; i < r.byInterestArea.ElementAt(count).citations.Count; i++)
                {
                    richTextBox1.AppendText(Environment.NewLine);
                    richTextBox1.AppendText(r.byInterestArea.ElementAt(count).citations[i]);

                }
            }
            else
            {
                metroLabel1.Text = r.byFaculty.ElementAt(count).facultyName;
                //metroLabel1.TextAlign = HorizontalAlignment.Center;
                richTextBox1.Name = count.ToString();
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.SelectionBullet = true;
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                for (int i = 0; i < r.byFaculty.ElementAt(count).citations.Count; i++)
                {  
                    richTextBox1.AppendText(Environment.NewLine);
                    if (!String.IsNullOrEmpty(r.byFaculty.ElementAt(count).citations[i]))
                    {
                        richTextBox1.AppendText(r.byFaculty.ElementAt(count).citations[i]);
                    }

                }

            }

        }

    }
}
