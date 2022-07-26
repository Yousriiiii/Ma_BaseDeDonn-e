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
    public partial class InputOfNameOfList : Form
    {
        public string NameOfList { get; set; } // C'est une variable qui représente le nom de la nouvelle colonne
        string Path;
        public InputOfNameOfList(string path)
        {
            this.Path = path;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null)
            {
                this.NameOfList = textBox1.Text; // J'initialise ici le nom de la liste 
                this.Close(); // Et je ferme directement la fenêtre

                // Et la j'appel la méthode pour ajouter une nouvelle collone

                WriteInFile write = new WriteInFile(Path); // Avec ce je définie le chemin d'accés

                write.WriteNewColumn(this.NameOfList); // J'appel la méthode qui va ajouter la nouvelle colonne

                // ET ENFIN je crée l'instance pour la nouvelle fenêtre des data

                InputOfData window = new InputOfData(Path);
                window.Show();

            }
            else
            {
                MessageBox.Show("Aucun nom est détécté", "Erreur", MessageBoxButtons.OK); // Message box qui permet d'alerter qu'il
                                                                                          // faut un nom à la liste
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }

        }
    }
}
