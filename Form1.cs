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
    public partial class Form1 : Form
    {
        private string InitialPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // On demande d'abord ou la bdd sera stocké
            SetInitialPath(); // Methode permettant de connaitre le chemin du dossier ou il y aura la base de donné



            //var x = Directory.GetCurrentDirectory();
            //var y = Directory.GetParent(x).FullName;
            // BUG TROUVé
            // - Les racourcis , marche mais si y a rien c'est vide
            FormForNameOfBD SetTheName = new FormForNameOfBD(this.InitialPath);
            SetTheName.Show();
        }

        private void SetInitialPath()
        {
            OpenFileExplorer openFileExplorer = new OpenFileExplorer();

            this.InitialPath = openFileExplorer.InitialPath;

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
