using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ma_BaseDeDonnée
{
    public class CreatePanelForAddColumn
    {
        public CreatePanelForAddColumn(Form Window, int[] NumberOfPanel, CreatePanelForInputData ClassWithInformation, string path)// le paramètre Window et la fenêtre, c'est dans cette
                                                                        // fenêtre que le panel sera ajouter
                                                                        // et NumberOfPanel me sert à placer le panel en dessous
                                                                        // ClassWithInformation est la classe qui permet d'obtenir les
                                                                        // nouvelle donnée à stocké
                                                                        // Et enfin path et le chemin d'accés vers la base de donné
                                                                        // Qui me servira à écrire dans ce fichier
        {
            // Je crée le panel qui va contenir deux bouton 
            // 1 Bouton pour sauvegarder les nouvelle donnée
            // Et un autre pour ajouter une colonne à la liste
            Panel PanelOfData = new Panel();
            PanelOfData.Location = new Point(NumberOfPanel[0], NumberOfPanel[1]);
            PanelOfData.BackColor = Color.White;
            PanelOfData.Name = "ThePanelForAdd";
            PanelOfData.Size = new Size(1300, 100);
            Window.Controls.Add(PanelOfData); // J'ajoute le panel à la fenêtre

            // Et la j'appelle les classe pour crée les bouton qui va save les données
            CreateButtonForSavingData SaveButton = new CreateButtonForSavingData(PanelOfData, ClassWithInformation,path); // Bouton pour sauvegarder
            // je crée le bouton qui va ajouter une nouvelle collonne
            CreateButtonForAddColumn AddColumnButton = new CreateButtonForAddColumn(Window,PanelOfData, path);

        }
    }
}
