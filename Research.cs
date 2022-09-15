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

        public DataTable dt = new DataTable();

        public Research(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void Research_Load(object sender, EventArgs e)
        {
            // Je met en évidence les widget initialement utilisé
            ComboBoxJob Job = new ComboBoxJob(this.panel1,this.path, this.dataGridView1);
            Job.PanelResearchInterface();        
        
        }

        private void ajouterUneNouvelleRechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBoxJob Job = new ComboBoxJob(this.panel1, this.path, this.dataGridView1);
            Job.PanelResearchInterface();

        }
    }
}
