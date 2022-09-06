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
    public partial class DataView : Form
    {
        public string CurrentPath;
        public DataView(string path)
        {
            InitializeComponent();
            this.CurrentPath = path;
        }

        private void DataView_Load(object sender, EventArgs e)
        {
            // je vais lire le ficheir csv et mettre toute les donnée dans un datagridview

            ReadFile read = new ReadFile(this.CurrentPath);

            DataTable dt = new DataTable();

            var Data = new List<string>();

            Data = read.GetAllData(); // ICI j'ai toute les données du fichier csv

            if(Data.Count > 0)
            {
            #region Initialisation du header de la datagrid

            string[] Header = Data[0].Split(';');

                int index = 1; // Il va être utile si il y a conflit des données
            foreach (string header in Header)
            {
                try {
                        dt.Columns.Add(header);
                    }
                    catch (Exception ex) {
                        dt.Columns.Add(header + index.ToString());
                        index += 1;
                    }

            }
            

            #endregion

            #region Mise en place des data


            for(int i = 1; i < Data.Count; i++)
            {
                string [] vs = Data[i].Split(';');

                dt.Rows.Add(vs);
            }


            #endregion

            this.dataGridView1.DataSource = dt; // Et enfin j'initilise la source de data comme étant ma data table 

            }
            else
            {
                MessageBox.Show("Aucune donnée", "Erreur", MessageBoxButtons.OK); // Message box qui permet d'alerter qu'il n'y a pas de data

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            // bouton pour enregistrer les changements

            List<List<string>> NewData = new List<List<string>>();  // C'est la liste qui contient la data row

            #region Obtention du header 

            List<string> header = new List<string>();

            for(int i = 0; i < this.dataGridView1.Columns.Count; i++) 
            { 
                header.Add(this.dataGridView1.Columns[i].HeaderText); 
            }

            NewData.Add(header);
            #endregion

            #region Obtention des data
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                List<string> DataRow = new List<string>(); // C'est la data d'une collone

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    DataRow.Add((string) row.Cells[i].Value);
                }
                NewData.Add(DataRow); 
            }
            #endregion


            WriteInFile write = new WriteInFile(this.CurrentPath);
            write.ReWriteAllData(NewData);

            this.Close(); // et puis je ferme la fenêtre
                
        }
    }
}
