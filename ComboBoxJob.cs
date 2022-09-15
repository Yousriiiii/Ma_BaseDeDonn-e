using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ma_BaseDeDonnée
{
    public class ComboBoxJob
    {
        private static Point point = new Point(0,40); // C'est pour la localisation des panel
        private Panel panel1; // représente le container dans laquelle se trouve la panel 
        private Panel panel2; // Panel contenant les widget comme combobox,label et textbox
        private static List<ComboBox> listOfComboBox = new List<ComboBox>();
        private static List<Label> listOfLabel = new List<Label>();
        private static List<TextBox> listOfTextBox = new List<TextBox>();
        private static List<CheckBox> listOfCheckBox = new List<CheckBox>();

        private string path;
        private DataGridView DataList;


        // Cette classe doit crée les autre combobox,label et textbox qui devront être dans un panel
        public ComboBoxJob(Panel panel, string path, DataGridView DataList)
        {
            this.panel1 = panel;
            this.path = path;
            this.DataList = DataList;
        }

        public void PanelResearchInterface() // C'est dans ce panel qu'il aura la combobox,...
        {
            // c'est ici que les panels vont être les uns en dessous de l'autre
            #region création du panel
            panel2 = new Panel();
            panel2.Location = point;
            panel2.Dock = DockStyle.Top;
            #endregion

            // Je met à jour la nouvelle localisation pour le prochain panel

            point = new Point(3,point.Y + 105);

            // Je met dans le container qui englobe tout

            this.panel1.Controls.Add(panel2);   

            // Et enfin, j'ajoute les widgets

            NewResearchInterface();

        }

        public void NewResearchInterface()
        {
            #region Création d'une CheckBox

            CheckBox cb = new CheckBox();
            cb.Location = new Point(10,3);
            cb.Size = new Size(95,50);
            cb.AutoSize = true;
            cb.Text = "Faire une recherche selon ...";

            #endregion

            #region création de ComboBox
            ComboBox comboBox = new ComboBox();
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(25, 30);
            comboBox.Size = new System.Drawing.Size(130, 24);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Pour que l'utilisateur ne puisse pas écrire dans 
                                                                 // la comboBox
            #endregion

            #region Création du label

            Label label = new Label();
            label.AutoSize = true;
            label.Location = new Point(9, 67);
            label.Size = new System.Drawing.Size(79, 16);
            label.Text = "Recherche :";


            #endregion

            #region Création de textBox

            TextBox textBox = new TextBox();
            textBox.Location = new Point(79, 64);
            textBox.Size = new System.Drawing.Size(110, 22);


            #endregion

            // Je ajoute directement tous les widget dans leur liste respective, cela me permetra de retrouver pour quelle 
            // TextBox et Label travaille avec quelle ComboBox

            ComboBoxAdded(comboBox);
            LabelAdded(label, comboBox);
            TextBoxAdded(textBox);


            // et enfin, je place tous dans le panel
            panel2.Controls.Add(cb);
            panel2.Controls.Add(comboBox);
            panel2.Controls.Add(label);
            panel2.Controls.Add(textBox);
        }


        private void IndexOfComboBoxChanged(object sender, EventArgs e) // Lorsque l'index change, on doit reactualiser le label
        {
            var ComboBoxAssociated = sender as ComboBox;

            int indexOfComboBox = 0;

            foreach (ComboBox item in listOfComboBox) // je recherche l'index de la combobox correspondante dans la liste des combobox
            {
                if (ComboBoxAssociated == item)
                {
                    indexOfComboBox = listOfComboBox.IndexOf(item); // J'ai l'index
                    break;
                }
            }

            listOfLabel[indexOfComboBox].Text = ComboBoxAssociated.Text + " :";



        }


        private void TextChanged(object sender, EventArgs e)
        {
            var TextBoxProvisoire = sender as TextBox; // Ici on dit que x est sender
                                                       // ET que l'on considére comme une textbox

            int indexOfTextBox = 0 ;

            foreach(TextBox textBox in listOfTextBox) // je recherche la textbox x correspondante dans la liste des textbox
            {
                if(TextBoxProvisoire == textBox)
                {
                    indexOfTextBox = listOfTextBox.IndexOf(textBox); // J'ai l'index
                    break;
                }
            }

            var ComboBoxAssociated = listOfComboBox[indexOfTextBox];

            #region Partie recherche
            ResearchData research = new ResearchData(this.path, ComboBoxAssociated.SelectedIndex);
            List<string> listOfResult = research.Research(TextBoxProvisoire.Text);

            DataTable dt = new DataTable(); // C'est la datasource du datagrid


            dt.Columns.Add(research.header);

            for (int i = 0; i < listOfResult.Count; i++)
            {
                dt.Rows.Add(listOfResult[i]);
            }

            this.DataList.DataSource = dt;

            // Problème : ca réinitialise la datatable

            #endregion
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

        public void InitializeLabelText(Label label,ComboBox comboBox)
        {
            label.Text = comboBox.Text + " :";
        }

        #region Widget Added
        public void ComboBoxAdded(ComboBox combobox)
        {
            // Lorsqu'une combobox est ajouter, je le stock dans une list
            // -> cela permet de le lier avec un label et textbox
            listOfComboBox.Add(combobox);
            InitializeComBoxItem(combobox); // J'appelle la méthode pour initialisé les items dans la comboBox
            combobox.SelectedIndexChanged += new EventHandler(IndexOfComboBoxChanged);

        }

        public void TextBoxAdded(TextBox textBox)
        {
            // Lorsqu'une combobox est ajouter, je le stock dans une list
            // -> cela permet de le lier avec un label et textbox
            listOfTextBox.Add(textBox);
            // J'initialise l'event
            textBox.TextChanged += new EventHandler(TextChanged);
        }

        public void LabelAdded(Label label, ComboBox comboBox)
        {
            // Lorsqu'une combobox est ajouter, je le stock dans une list
            // -> cela permet de le lier avec un label et textbox
            listOfLabel.Add(label);

            // Lorsqu'un label est ajouter, je l'initialise avec un text

            InitializeLabelText(label,comboBox);
        }

        public void CheckBoxAdded(CheckBox cb)
        {
            listOfCheckBox.Add(cb);
            // Lorsqu'une checkbox est crée, j'initialise son event
            // cb.CheckedChanged += new EventHandler(CheckBoxStateChanged);
        }
        #endregion


    }
}
