using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ma_BaseDeDonnée
{
    public class CreateButtonForChangeData
    {
        public string path;
        public CreateButtonForChangeData(Panel container, string path)
        {
            this.path = path;
            #region création du bouton
            Button btn = new Button();
            btn.Text = "Modifier les données";
            btn.Location = new Point(27, 25);
            btn.Size = new Size(140, 50);
            btn.Click += new EventHandler(OpenDataWindow);
            #endregion

            container.Controls.Add(btn);
        }

        private void OpenDataWindow(object sender, EventArgs e)
        {
            DataView dataView = new DataView(this.path);
            dataView.Show();
        }
    }
}
