using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Ma_BaseDeDonnée
{
    public class CreateButtonForAddColumn
    {
        string Path;

        Form WindowForData;
        public CreateButtonForAddColumn(Form Window,Panel panelOfData, string path)
        {
            this.Path = path;

            this.WindowForData = Window; // JE défini la fenêtre qui contient le panel et le bouton pour la fermé par la suite

            #region Button For Add a column
            Button AddColumn = new Button();
            AddColumn.Location = new Point(100, 25);
            AddColumn.Name = "CreateColumnButton";
            AddColumn.Size = new Size(500, 50);
            AddColumn.Text = "Ajouter une nouvelle donnée";
            panelOfData.Controls.Add(AddColumn);
            #endregion

            // Et la maintenant je crée une instance qui va permettre de détecter si le bouton est pressé
            AddColumn.Click += new EventHandler(Button_AddColumn);

        }

        private void Button_AddColumn(object sender, EventArgs e) // Event pour créer une nouvelle colonne à la liste
        {
            // Ce bouton ne vas QUE ouvrir une nouvelle fenêtre pour ajouter la nouvelle colonne et fermé l'ancienne
            // (je fait ca pour reload la fenêtre)
            #region C'est la partie où j'obtiens le nom de la nouvelle liste

            #region ICI je montre la fenêtre qui permet de définir le nom de la liste 

            InputOfNameOfList NameOfListWindow = new InputOfNameOfList(this.Path);
            NameOfListWindow.Show();

            #endregion
            // ET le fichier sera mis à jour grâce à cette fenêtre

            // ET enfin je ferme la fenêtre pour voir et ajouter les data

            WindowForData.Close();
            
            #endregion
            
            // Attention c'est dans la form "InputOfNameOfList" qu'on ajoute la nouvelle colonne
        }
    }
}
