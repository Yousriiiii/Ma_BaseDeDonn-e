using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ma_BaseDeDonnée
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormForNameOfBD SetTheName = new FormForNameOfBD();
            SetTheName.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
