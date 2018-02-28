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
    public partial class Table : Form
    {
        Form1 f1 = null;
        int count = 0;
        Employment emp;
        Rest rj = new Rest("http://ist.rit.edu/api");
        Rest rjGoogle = new Rest("http://info.google.com/api");
        public Table(Form1 f1)
        {
            this.f1 = f1;
            string jsonAbout = rj.getRestData("/employment/");
            emp = JToken.Parse(jsonAbout).ToObject<Employment>();
            InitializeComponent();
            for (var i = 0; i < emp.coopTable.coopInformation.Count; i++)
            {
                dataGridView1.Rows.Add();       // Adiing information of co-op to datagrid
                dataGridView1.Rows[i].Cells[0].Value =
                    emp.coopTable.coopInformation[i].employer;
                dataGridView1.Rows[i].Cells[1].Value =
                    emp.coopTable.coopInformation[i].degree;
                dataGridView1.Rows[i].Cells[2].Value =
                    emp.coopTable.coopInformation[i].city;
                dataGridView1.Rows[i].Cells[3].Value =
                    emp.coopTable.coopInformation[i].term;
            }

        }

        private void Table_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
