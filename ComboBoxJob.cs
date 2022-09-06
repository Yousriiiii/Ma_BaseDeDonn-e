using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ma_BaseDeDonnée
{
    public class ComboBoxJob
    {
        private static Point point = new Point(40,50); // C'est pour la localisation des widgets et je l'initialise
        private Panel panel1; // représente le container dans laquelle se trouve la combobox
        private static List<ComboBox> listOfComboBox = new List<ComboBox>();
        private static List<Label> listOfLabel = new List<Label>();
        private static List<TextBox> listOfTextBox = new List<TextBox>();
        private string path;


        // Cette classe doit crée les autre combobox et textbox
        public ComboBoxJob(Panel panel, string path)
        {
            this.panel1 = panel;
            this.path = path;
        }

        public void NewResearchInterface()
        {
            #region création de ComboBox
            ComboBox comboBox = new ComboBox();
            comboBox.FormattingEnabled = true;
            comboBox.Location = point;
            // Ensuite je réalise une nouvelle localisation pour le label et la textbox
            point = new Point(point.X - 10, point.Y + 10); 
            comboBox.Size = new System.Drawing.Size(190, 24);
            comboBox.TabIndex = 0;
            #endregion

            #region Création du label

            Label label = new Label();
            label.AutoSize = true;
            label.Location = point;
            // Et enfin, je régle la localisation de la textbox
            point = new Point(point.X + 20, point.Y);
            label.Size = new System.Drawing.Size(79, 16);
            label.Text = "Recherche :";


            #endregion

            #region Création de textBox

            TextBox textBox = new TextBox();
            textBox.Location = point;
            textBox.Size = new System.Drawing.Size(151, 22);


            #endregion

            // Je ajoute directement tous les widget dans leur liste respective, cela me permetra de retrouver pour quelle 
            // TextBox et Label travaille avec quelle ComboBox

            ComboBoxAdded(comboBox);
            LabelAdded(label);
            TextBoxAdded(textBox);


            // et enfin, je place tous dans le panel
            panel1.Controls.Add(comboBox);
            panel1.Controls.Add(label);
            panel1.Controls.Add(textBox);
        }

        public void ComboBoxAdded(ComboBox combobox)
        {
            // Lorsqu'une combobox est ajouter, je le stock dans une list
            // -> cela permet de le lier avec un label et textbox
            listOfComboBox.Add(combobox);
            InitializeComBoxItem(combobox); // J'appelle la méthode pour initialisé les items dans la comboBox

        }

        public void LabelAdded(Label label)
        {
            // Lorsqu'une combobox est ajouter, je le stock dans une list
            // -> cela permet de le lier avec un label et textbox
            listOfLabel.Add(label);
        }

        public void TextBoxAdded(TextBox textBox)
        {
            // Lorsqu'une combobox est ajouter, je le stock dans une list
            // -> cela permet de le lier avec un label et textbox
            listOfTextBox.Add(textBox);
        }

        public void InitializeComBoxItem(ComboBox comboBox)
        {
            ReadFile read = new ReadFile(this.path);
            string[] firstLine = read.GetFirstLine();

            foreach (string line in firstLine)
            {
                comboBox.Items.Add(line);
            }
            comboBox.SelectedIndex = 0;

        }


    }
}
