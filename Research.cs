using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ma_BaseDeDonnée
{
    public partial class Research : Form
    {
        public string path;
        public Research(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void Research_Load(object sender, EventArgs e)
        {
            // ICI je met les info dans la combobox
            ReadFile read = new ReadFile(this.path);
            string [] firstLine = read.GetFirstLine();

            foreach(string line in firstLine)
            {
                this.ComboBox1.Items.Add(line);
            }
            this.ComboBox1.SelectedIndex = 0; // J'initialise l'index à 0

            this.label1.Text = this.ComboBox1.Text + " :"; // Je change le label 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ResearchData research = new ResearchData(this.path, this.ComboBox1.SelectedIndex);
            List<string> listOfResult = research.Research(this.textBox1.Text); ;

            DataTable dt = new DataTable();

            dt.Columns.Add(research.header);

            for (int i = 0; i < listOfResult.Count; i++)
            {
                dt.Rows.Add(listOfResult[i]);
            }

            this.dataGridView1.DataSource = dt;

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // A chaque fois que l'index change, je change le label
            this.label1.Text = this.ComboBox1.Text + " :"; // Je change le label 
        }
    }
}
