using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ma_BaseDeDonnée
{
    public partial class FormForNameOfBD : Form
    {
        public string NameOfFolder;
        public string CurrentPath;
        public string InitialPath;
        public FormForNameOfBD(string InitialPath)
        {
            this.InitialPath = InitialPath;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// Le but est de crée un dossier où toutes les BD sont stocké
                                                              // et dans ce dossier, il y aura le vrai dossier crée par l'utilisateur
                                                              // un exemple: l'utilisateur créer dossier client et dans ce dossier, il y a le fichier csv
        {
            if(this.textBox1.Text != "")
            {
                this.NameOfFolder = this.textBox1.Text;
                CreateFolder(this.textBox1.Text); // Je crée un dossier ou il y aura toutes la BD -- selon le initialPath

                var CompletedPath = this.CurrentPath + "\\" + this.NameOfFolder + ".csv";

            // C'est ici que je crée la base de donnée avec le nom de la base de donnée
                CreateCsv_File csvFile = new CreateCsv_File(CompletedPath);

            // J'ouvre la partie la plus utilisé par l'utilisateur où l'utilisateur peut entre du data
                InputOfData form = new InputOfData(CompletedPath);
                form.Show();
            // Et je ferme cette fenêtre
                this.Close();

            }
            else
            {
                MessageBox.Show("Aucun nom est détécté", "Erreur", MessageBoxButtons.OK); // Message box qui permet d'alerter qu'il faut un nom au fichier
            }

        }
        private void CreateFolder(string NameOfBD) // => ici je crée un dossier où toutes la data est stocké en mettant
                                                   // en avant que c'est un fichier csv
        {
            this.CurrentPath = this.InitialPath + "\\"+NameOfBD; // on ajoute le nom du nouveau dossier

            if (!Directory.Exists(this.CurrentPath))
            { // S'il aucun dossier existe
                Directory.CreateDirectory(this.CurrentPath);  // On crée un dossier dans le dossier des bases de données
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) // Event détéctant si la barre espace est appuiyé
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
