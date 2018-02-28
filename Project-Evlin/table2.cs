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
    public partial class table2 : Form
    {
        Form1 f1 = null;
        int count = 0;
        Employment emp;
        Rest rj = new Rest("http://ist.rit.edu/api");
        Rest rjGoogle = new Rest("http://info.google.com/api");
        public table2(Form1 f1)
        {
            this.f1 = f1;
            string jsonAbout = rj.getRestData("/employment/");
            emp = JToken.Parse(jsonAbout).ToObject<Employment>();
            InitializeComponent();
            for (var i = 0; i < emp.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                dataGridView2.Rows.Add();       // Adiing information of Employment to datagrid
                dataGridView2.Rows[i].Cells[0].Value =
                    emp.employmentTable.professionalEmploymentInformation[i].employer;
                dataGridView2.Rows[i].Cells[1].Value =
                    emp.employmentTable.professionalEmploymentInformation[i].degree;
                dataGridView2.Rows[i].Cells[2].Value =
                    emp.employmentTable.professionalEmploymentInformation[i].city;
                dataGridView2.Rows[i].Cells[3].Value =
                    emp.employmentTable.professionalEmploymentInformation[i].title;
                dataGridView2.Rows[i].Cells[4].Value =
                   emp.employmentTable.professionalEmploymentInformation[i].startDate;
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
