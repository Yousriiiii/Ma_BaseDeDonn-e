using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Ma_BaseDeDonnée
{
    public class CreateButtonForSavingData
    {// C'est dans cette classe que je vais créer le bouton et enregister les nouvelle donné en appelant
     // une autre classe qui va écrire dans le fichier csv

        public List<string> DataToAdd = new List<string>(); // Cette liste contiendra toute la data dans les textbox
                                                            // à mettre dans le fichier CSV

        public string pathForWritting;
        CreatePanelForInputData ClassWithInformation;
        public CreateButtonForSavingData(Panel panelOfData, CreatePanelForInputData ClassWithInformation, string path)
        {
            this.ClassWithInformation = ClassWithInformation;
            this.pathForWritting = path;
            #region Button for saving data
            Button SaveButton = new Button();
            SaveButton.Location = new Point(700, 25);
            SaveButton.Name = "CreateColumnButton";
            SaveButton.Size = new Size(500, 50);
            SaveButton.Text = "Sauvegarder les informations";
            panelOfData.Controls.Add(SaveButton);
            #endregion

            SaveButton.Click += new EventHandler(SaveData);

        }

        private void SaveData(object sender, EventArgs e)
        {

            try
            {
                // Ici je vais enregister toute les info des textbox donc j'ai besoin de toutes les chaine de
                // caractére des textbox
                this.DataToAdd = ClassWithInformation.GetTheDataToPut();

                WriteInFile write = new WriteInFile(this.pathForWritting);

                write.WriteNewData(DataToAdd); // J'appelle cette méthode pour écrire la nouvelle data

                // ET dès que j'ai sauvegardé les data je clear les textbox pour une nouvelle utilisation
                ClearAllTextBox();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Les données ne peuvent pas être sauvegarder", "Erreur", MessageBoxButtons.OK); // Message box qui permet d'alerter qu'il faut un nom au fichier
            }
        }

        private void ClearAllTextBox() // Methode qui permet de clear toute les textbox pour une nouvelle utilisation
        {
            foreach(TextBox textbox in CreateObjetOfPanelForInputData.ListDesTextBox)
            {
                textbox.Clear();
            }
        }
    }
}
