using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ma_BaseDeDonnée
{
    public class CreatePanelForInputData
    {
        CreateObjetOfPanelForInputData CreateObject;
        public CreatePanelForInputData(string ColumnTitle, int[] NumberOfPanel, Form form)
        {
            // ColumnTitle est le string qui doit être dans le label
            // NumberOfPanel permet de placer les panels l'un en dessous de l'autre
            // Et form représente la fenêtre ou on doit ajouter le panel
            Panel PanelOfData = new Panel();
            PanelOfData.Location = new Point(NumberOfPanel[0], NumberOfPanel[1]);
            PanelOfData.BackColor = Color.White;
            PanelOfData.Name = "ThePanelOfData";
            PanelOfData.Size = new Size(1300, 100);
            form.Controls.Add(PanelOfData); // J'ajoute le panel à la fenêtre

            // Et la j'appelle une autre classe qui va placer un label et une textbox dans chaque panel
            this.CreateObject = new CreateObjetOfPanelForInputData(PanelOfData,ColumnTitle);
        }

        public List<string> GetTheDataToPut() // Cette méthode va me permettre de recevoir la data à ajouté
                                              // dans le fichier csv
        {
            List<string> theData = new List<string>();
            foreach (TextBox text in CreateObjetOfPanelForInputData.ListDesTextBox) // Pour chaque textbox dans la liste
                                                                                    // des textbox, j'ajoute à la liste theData
                                                                                    // la chaine de caractère des textbox
             {
                theData.Add(text.Text);
            }
            if (theData != null)
            {
                return theData;
            }
            else { return null; }
        }


    }
}
