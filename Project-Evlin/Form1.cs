using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RESTUtil;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Project_Evlin
{
    public partial class Form1 : Form
    {
        Rest rj = new Rest("http://ist.rit.edu/api");
        Rest rjGoogle = new Rest("http://info.google.com/api");
        Employment emp;
        degrees deg;
        Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            Populate();
            degrees();
            ResearchFaculty();
            ResearchArea();
            people();
            minor();
            Employment();
            newsadd();
          
        }
        private void Employment()
        {
            string jsonEmp = rj.getRestData("/employment/");
            emp = JToken.Parse(jsonEmp).ToObject<Employment>();
           
        }
        //Function to add news to page 
        private void newsadd()
        {
            string jsonAbout = rj.getRestData("/news/");
            news n = JToken.Parse(jsonAbout).ToObject<news>();
            int count1 = 0;
            for (int i = 0; i < n.year.Count; i++)
            {
               
                RichTextBox newstextbox = new RichTextBox();
                // myRichTextBox.Text = "ee";
                newstextbox.Name = count1.ToString();
              
                if (!String.IsNullOrEmpty(n.year.ElementAt(i).description))
                {
                    newstextbox.SelectionAlignment = HorizontalAlignment.Center;
                    newstextbox.AppendText(Environment.NewLine);
                    newstextbox.AppendText(n.year.ElementAt(i).title);
                    newstextbox.AppendText(Environment.NewLine);
                    newstextbox.AppendText(n.year.ElementAt(i).description);
                    newstextbox.Width = 900;
                    newstextbox.Height = 125;
                    tableLayoutPanel8.Controls.Add(newstextbox, i, 0); //adding to table layout
                }
               
                count1++;

            }

        }
        //Function to add minor to page
        private void minor()
        {
            string jsonAbout = rj.getRestData("/minors/");
            minors mi = JToken.Parse(jsonAbout).ToObject<minors>();
            int count1 = 0;
            for (int i = 0; i < mi.UgMinors.Count; i++)
            {
                Label t = new Label();
                t.AutoSize = true;
                //t.Anchor = AnchorStyles.None; 
                t.Text = mi.UgMinors.ElementAt(i).name;

                RichTextBox minortextbox = new RichTextBox();
                // myRichTextBox.Text = "ee";
                minortextbox.Name = count1.ToString();
                minortextbox.SelectionAlignment = HorizontalAlignment.Center;
                minortextbox.AppendText(Environment.NewLine);
                minortextbox.AppendText(mi.UgMinors.ElementAt(i).name);
                minortextbox.AppendText(Environment.NewLine);
                minortextbox.AppendText(mi.UgMinors.ElementAt(i).title);
                minortextbox.AppendText(Environment.NewLine);
                minortextbox.AppendText(Environment.NewLine);
                minortextbox.AppendText("Click to Read More");
                minortextbox.Width = 800;
                minortextbox.Height = 100;
                minortextbox.ForeColor = Color.Red;
                minortextbox.Click += minortextbox_click;
                tableLayoutPanel7.Controls.Add(minortextbox, i, 0);

                count1++;

            }

        }
        //Function to call new form 
        void minortextbox_click(object sender, EventArgs e)
        {
            int m = Int32.Parse(((RichTextBox)sender).Name);

            minorform pu = new minorform(this, m);
            pu.Show();

        }
        //Function to add degrees to page
        private void degrees()
        {
          
            string jsonAbout = rj.getRestData("/degrees/");
            degrees degree = JToken.Parse(jsonAbout).ToObject<degrees>();
            deg = degree;
            // textBox1.Text = about.description;
            //textBox1.Text = about.quoteAuthor;
            int count1 = 0;
            for (int i = 0; i < 3; i++)
            {
                Label t = new Label();
               
                t.AutoSize = true;
               
                t.Text = degree.undergraduate.ElementAt(i).title;
                
                RichTextBox myRichTextBox = new RichTextBox(); //Rich text box to hold data
                // myRichTextBox.Text = "ee";
                myRichTextBox.Name = count1.ToString();
                myRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
                myRichTextBox.AppendText(Environment.NewLine);
                myRichTextBox.AppendText(degree.graduate.ElementAt(i).title);
                myRichTextBox.AppendText(Environment.NewLine);
                myRichTextBox.AppendText(degree.graduate.ElementAt(i).description);
                myRichTextBox.AppendText(Environment.NewLine);
                myRichTextBox.AppendText(Environment.NewLine);
                myRichTextBox.AppendText("Click to Read More");
                myRichTextBox.Width =850;
                myRichTextBox.Height = 100;
                myRichTextBox.BorderStyle = BorderStyle.Fixed3D;
                myRichTextBox.Click += grads_click;
                tableLayoutPanel3.Controls.Add(myRichTextBox, 0, i);//adding to table layout
                myRichTextBox.ForeColor = Color.Red;
                count1++;
                
            }
            int count2 = 0;
            for (int i = 0; i < degree.undergraduate.Count; i++)
            {
               
                RichTextBox r = new RichTextBox(); //Rich text box to hold data
                r.Name = count2.ToString();
                count2++;
                r.ForeColor= Color.Red;
                r.BorderStyle = BorderStyle.Fixed3D;
                r.SelectionAlignment = HorizontalAlignment.Center;
                r.AppendText(Environment.NewLine);
                r.AppendText(degree.undergraduate.ElementAt(i).title);
                r.AppendText(Environment.NewLine);
                r.AppendText(degree.undergraduate.ElementAt(i).description);
                r.AppendText(Environment.NewLine);
                r.AppendText(Environment.NewLine);
                r.AppendText("Click to Read More");
                r.Click += undergrad_click;
                r.Width = 850;
                r.Height = 100;
                tableLayoutPanel4.Controls.Add(r, 0, i); //adding to table layout

            }

        }

  //To open new form
        void undergrad_click(object sender, EventArgs e)
        {
            int m = Int32.Parse(((RichTextBox)sender).Name);
            PopUp pu = new PopUp(this,m); 
            pu.Show();

        }

        //To open new form
        void grads_click(object sender, EventArgs e)
        {
            int m = Int32.Parse(((RichTextBox)sender).Name);
            PopupGrad pu = new PopupGrad(this, m);
            pu.Show();

        }
        //Function to add introduction content to page

        private void Populate()
        {
            string jsonAbout = getRestData("/about/");
            
            about about = JToken.Parse(jsonAbout).ToObject<about>();
            textBox1.Text = about.description;
        }
        private string getRestData(string url)
        {
            string baseUri = "http://ist.rit.edu/api";

            // connect to the API
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUri + url);
            try
            {
                WebResponse response = request.GetResponse();

                using (System.IO.Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException we)
            {
                // Something goes wrong, get the error response, then do something with it
                WebResponse err = we.Response;
                using (Stream responseStream = err.GetResponseStream())
                {
                    StreamReader r = new StreamReader(responseStream, Encoding.UTF8);
                    string errorText = r.ReadToEnd();
                    // display or log error
                    Console.WriteLine(errorText);
                }
                throw;
            }
        }
        
        
        private void b1_Click(object sender, EventArgs e)
        {
            
            Table pu = new Table(this); 
            pu.Show();
        }
        private void metroButton1_click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            map pu = new map(this);
            pu.Show();
        }
        private void proffesional_Click(object sender, EventArgs e)
        {
           
            table2 pu = new table2(this);
            pu.Show();


        }
        //Function to Research area to page
        private void ResearchArea()
        {

            // get the JSON for people
            string jsonResearch = getRestData("/research/");
            Research research = JToken.Parse(jsonResearch).ToObject<Research>();

            // Show all the faculty names and pictures
            var count2 = 0;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            for (var i = 0; i < research.byInterestArea.Count; i++)
            {
                for (var j = 0; j < 4; j++)
                {  // Adding data to tablepanel with 4 columns
                    if (count2 < research.byInterestArea.Count)
                    {
                        Label t = new Label();
                        t.ForeColor = System.Drawing.Color.Pink;
                        t.Anchor = AnchorStyles.None;
                        t.Size = new System.Drawing.Size(140, 140);
                        t.TextAlign = ContentAlignment.MiddleCenter;
                        t.Text = research.byInterestArea.ElementAt(count2).areaName;
                        ToolTip ttip = new ToolTip();
                        ttip.IsBalloon = true;
                        ttip.SetToolTip(t, "Click to read more");
                        tableLayoutPanel2.Controls.Add(t, j, i);
                        t.Name = count2.ToString();
                        t.Click += t1_click;
                        count2++;
                    }
                }
            }
        }

        void t1_click(object sender, EventArgs e)
        {
            int m = Int32.Parse(((Label)sender).Name);
            String cat = "area";
            ResearchFaculty pu = new ResearchFaculty(this, m,cat);
            pu.Show();

        }

        //Function to Research Faculty contents to page
        private void ResearchFaculty()
        {
            // get the JSON for people
            string jsonPeople = getRestData("/research/");
            Research research = JToken.Parse(jsonPeople).ToObject<Research>();
            var count = 0;
            for (var i = 0; i < research.byFaculty.Count; i++)
            {


                for (var j = 0; j < 4; j++)
                {
                    if (count < research.byFaculty.Count)
                    {
                        Label name = new Label();
                        name.ForeColor = System.Drawing.Color.Pink;
                        name.Anchor = AnchorStyles.None;
                        name.TextAlign = ContentAlignment.MiddleCenter;
                        name.Size = new System.Drawing.Size(140, 140);
                        name.Text = research.byFaculty.ElementAt(count).facultyName;
                        ToolTip ttip = new ToolTip();
                        ttip.IsBalloon = true;
                        ttip.SetToolTip(name,"Click to read more");
                        tableLayoutPanel1.Controls.Add(name, j, i);
                        name.Name = count.ToString();
                        count++;
                        name.Click += name_click;
                    }
                }

            }
        }
        void name_click(object sender, EventArgs e)
        {
            int m = Int32.Parse(((Label)sender).Name);
            String cat = "faculty";
            ResearchFaculty pu = new ResearchFaculty(this, m, cat);
            pu.Show();
        }

        //Function to add people contents to page
        private void people()
        {
            string jsonPeople = getRestData("/people/");
            People people = JToken.Parse(jsonPeople).ToObject<People>();
            var count = 0;
            var count2 = 0;
            for (var i = 0; i < people.faculty.Count; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    if (count < people.faculty.Count)
                    {
                        PictureBox p1 = new PictureBox();
                        p1.Size = new System.Drawing.Size(100, 100);
                        p1.SizeMode = PictureBoxSizeMode.CenterImage;
                        TextBox t = new TextBox();
                        t.Text = people.faculty.ElementAt(count).name;
                        t.Visible = false;
                        ToolTip ttip = new ToolTip();
                        ttip.IsBalloon = true;
                        ttip.SetToolTip(p1, people.faculty.ElementAt(count).name);
                       
                        p1.Load(people.faculty.ElementAt(count).imagePath);
                        tableLayoutPanel5.Controls.Add(p1, j, i);
                        p1.Name = count.ToString();
                        count++;
                        p1.Click += p1_click;
                    }
                }
            }
            for (var i = 0; i < people.staff.Count; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    if (count2 < people.staff.Count)
                    {
                        PictureBox p2 = new PictureBox();
                        p2.Size = new System.Drawing.Size(100, 100);
                        p2.SizeMode = PictureBoxSizeMode.CenterImage;
                        ToolTip ttip = new ToolTip();
                        ttip.IsBalloon = true;
                        ttip.SetToolTip(p2, people.staff.ElementAt(count2).name);
                        p2.Load(people.staff.ElementAt(count2).imagePath);
                        tableLayoutPanel6.Controls.Add(p2, j, i);
                        p2.Name = count2.ToString();
                        count2++;
                        p2.Click += p2_click;
                    }
                }
            }
        }
        void p1_click(object sender, EventArgs e)
        {
            int m = Int32.Parse(((PictureBox)sender).Name);
            String cat = "faculty";
            peopleform pu = new peopleform(this, m,cat);
            pu.Show();
        }

        void p2_click(object sender, EventArgs e)
        {
            int m = Int32.Parse(((PictureBox)sender).Name);
            String cat = "staff";
            peopleform pu = new peopleform(this, m, cat);
            pu.Show();
        }
    }
}
