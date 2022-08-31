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
    public partial class InputOfData : Form
    {
        public string CurrentPath;
        CreatePanelForInputData PanelInputData;
        public InputOfData(string PathOfBD)
        {
            InitializeComponent();
            this.CurrentPath = PathOfBD; // C'est ici qu'on définie le chemin d'accés pour la base de donnée
            // J'initialise directement en plein écran
            this.WindowState = FormWindowState.Maximized;
        }



        private void InputOfData_Load(object sender, EventArgs e) // Cette évenement sera appelé à chaque fois qu'il y aura une nouvelle collone
                                                                  // à la data base
        {
            // Je lis la base de donnée afin de m'assurer qu'il y est aucune donnée
            ReadFile reader = new ReadFile(this.CurrentPath);
            string [] FirstLine = reader.GetFirstLine();

            //Je commence à crée les panels l'un à la suite de l'autre
            var NumberOfPanel = new int [2]; // Je crée un tableau à deux place pour pouvoir ajouter un panel sous un autre panel
            NumberOfPanel[0] = 12;
            NumberOfPanel[1] = 12;
            // A chaque fois que cette fenêtre se load, j'efface toute les info dans la list des text box pour en refaire une nouvelle
            CreateObjetOfPanelForInputData.ListDesTextBox.Clear();

            if(FirstLine != null)
            {
                foreach(string line in FirstLine) // C'est ici que je crée un panel pour chaque colonne
                {
                    PanelInputData = new CreatePanelForInputData(line,NumberOfPanel,this);
                    // Je l'ai incrémente pour que le panel soit plus bas
                    NumberOfPanel[1] += 105;

                }
            }
            // Et la j'ajoute en dernier le panel pour ajouter des choses à la liste

            CreatePanelForAddColumn PanelOfSaveAndAdd = new CreatePanelForAddColumn(this, NumberOfPanel, PanelInputData,this.CurrentPath); // Attention ce panel contient deux bouton
                                                                                                                                           // un bouton pour ajouter une colonne dans le fichier csv
                                                                                                                                           // et le deuxième bouton sert à sauvegarder les donné

            // Je crée un panel à droite pour ajouter des fonctionnalitées comme modifier les donnée,...

            PanelWithMoficatorButton panelWithMoficatorButton = new PanelWithMoficatorButton(this, this.CurrentPath);
        }
    }
}
