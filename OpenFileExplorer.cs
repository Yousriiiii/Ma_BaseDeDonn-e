using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ma_BaseDeDonnée
{
    public class OpenFileExplorer
    {
        public string InitialPath { get; set; } // C'est le chemin ou la base de donnée sera stocké
        public OpenFileExplorer()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog(); // On crée l'objet 
            var result = folderBrowserDialog.ShowDialog(); // On montre l'objet et la method showdialog nous retourne le résultat
                                                           // de l'objet 

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))// Les conditions sont
                                                                                                          // -  Si l'utilisateur apuuie sur le bouton OK
                                                                                                          // - ET Que le chemin d'accés selectionné n'est pas null ou un espace blanc
            {
                this.InitialPath = folderBrowserDialog.SelectedPath; // Et enfin j'initialise le chemin afin de le retourner
            }

        }
    }
}
