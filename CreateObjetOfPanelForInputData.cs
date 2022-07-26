using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ma_BaseDeDonnée
{
    public class CreateObjetOfPanelForInputData
    {
        public static List<TextBox> ListDesTextBox = new List<TextBox>();  // Cela me permettra d'accéder au information
                                                                           // de chaque textbox crée
                                                                           // C'est une variable statique car je veux
                                                                           // qu'il contienne toute les textbox même si je crée
                                                                           // un autre objet de cette classe
                                                                           
        public CreateObjetOfPanelForInputData(Panel panelOfData,string line)
        {
            // panelOfData reprèsente le panel qui englobe le label et le textbox
            // line est le titre de la donné (première ligne)
            #region Label Part
            Label ColomnName = new Label();
            ColomnName.AutoSize = true;
            ColomnName.Location = new Point(100, 25);
            ColomnName.Name = "NameOfColumnLabel";
            ColomnName.Size = new Size(200, 10);
            ColomnName.Text = line + " :";
            ColomnName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            #endregion

            #region TextBox Part

            TextBox TextBoxInputData = new TextBox();// Ce sera la textbox où il y aura la data à ajouter
            TextBoxInputData.Location = new Point(200, 25);
            TextBoxInputData.Name = "NameOfTextBox";
            TextBoxInputData.Size = new Size(100, 100);
            #endregion


            panelOfData.Controls.Add(ColomnName); // C'est pour le label de chaque panel
            panelOfData.Controls.Add(TextBoxInputData);

            SaveTextBox(TextBoxInputData); // Cette méthode va me permttre de stocker toute les informations des textbox crée

        }

        private void SaveTextBox(TextBox textBoxInputData)
        {
            ListDesTextBox.Add(textBoxInputData); // Ici j'ajoute la textbox dans une liste
        }
    }
}
