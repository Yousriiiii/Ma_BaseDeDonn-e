using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ma_BaseDeDonnée
{
    public class CreateButtonForReserachData
    {
        public string path;
        public CreateButtonForReserachData(Panel panel, string path)
        {
            this.path = path;

            #region Create Button
            Button btn = new Button();
            btn.Text = "Recherche";
            btn.Location = new Point(27, 80);
            btn.Size = new Size(140, 50);
            btn.Click += new EventHandler(OpenResearchWindow);
            #endregion

            panel.Controls.Add(btn);

        }

        private void OpenResearchWindow(object sender, EventArgs e)
        {
            Research researchwindow = new Research(this.path);
            researchwindow.Show();
        }
    }
}
