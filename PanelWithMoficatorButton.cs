using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Ma_BaseDeDonnée
{
    public class PanelWithMoficatorButton
    {
        public string path;
        public PanelWithMoficatorButton(Form Window, string path)
        {
            // idée -> ne pas utiliser seulement un panel mais plutot un tablelayoutpanel
            this.path = path;

            #region Création du panel
            Panel panel = new Panel();
            panel.Location = new Point(1320,15);
            panel.Size = new Size(190,200);
            panel.BackColor = Color.White;

            Window.Controls.Add(panel);
            #endregion

            // et la j'appellle la classe pour créer le bouton {Modifier les données}

            CreateButtonForChangeData createButtonForChangeData = new CreateButtonForChangeData(panel , this.path);
            CreateButtonForReserachData createButtonForReserachData = new CreateButtonForReserachData(panel , this.path);
        }
    }
}
