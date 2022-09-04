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
        public int index; // L'index de la collonne 
        public string header;


        public ResearchData(string path, int index) { this.path = path; this.index = index; } // Constructeur de la classe

        // BUT : Pouvoir réaliser des recherches d'information selon le type de donné (exemple : nom, prénom,...) 
        // Cette classe doit pouvoir avoir comme entré, ce qu'il y a dans la textbox, le type de donnée et le chemin d'accés
        // , et en sortie, le résultat des recherches


        public List<string> Research(string textInBox) // Item représente ce qu'il y a dans la textbox
        {

            List<string> ResearchList = new List<string>(); // C'est la liste qui correspond au résultat des recherche


            List<string> list = ListOfData(this.index); //C'est la liste des data de toute la colonne             

            this.header = list[0]; // initialisation deu header

            if (textInBox != "")
            {
                list.Skip(1).ToList().ForEach(item => {

                if (item.StartsWith(textInBox))
                    {
                        ResearchList.Add(item);
                    }
                
                });

            }
            else
            {
                for(int i = 1; i < list.Count; i++)
                {
                    ResearchList.Add(list[i]);
                }

                
            }
            return ResearchList;
        }

        public List<string> ListOfData(int index) // Cette méthode va renvoyé toute la data d'une colonne
        {
            ReadFile read = new ReadFile(this.path);
            List<string> list = read.GetDataOfColown(index);
            return list;
        }
    }
}
