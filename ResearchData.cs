using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ma_BaseDeDonnée
{
    public class ResearchData
    {
        public string path; // C'est le chemin d'accés
        public string Header; // Le type de donnée
        public ResearchData(string path,string header) { this.path = path; this.Header = header; }

        // BUT : Pouvoir réaliser des recherches d'information selon le type de donné (exemple : nom, prénom,...) 
        // Cette classe doit pouvoir avoir comme entré, ce qu'il y a dans la textbox, le type de donnée et le chemin d'accés
        // , et en sortie, le résultat des recherches

        public List<string> ResearchList { get; set; } // C'est la liste qui correspond au résultat des recherche

        public void Research(string item) // Item représente ce qu'il y a dans la textbox
        {

        }
    }
}
