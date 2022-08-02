using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ma_BaseDeDonnée
{
    public class WriteInFile
    {
        string Path;
        List<string> DataToAdd;
        public WriteInFile(string path)
        {
            this.Path = path;
        }

        public void WriteNewData(List<string> value) // Methode qui sert à ajouter une ligne dans le csv
        {
            this.DataToAdd = value;

            foreach (string item in DataToAdd)
            {
                if(item != null) // Si il y a quelque chose à ajouter on l'ajoute
                {
                    if (item == DataToAdd[DataToAdd.Count-1])
                    {
                        File.AppendAllText(Path, item ); // C'est pour la dernière valeur
                    }
                    else
                    {
                        File.AppendAllText(Path, item + ",");

                    }

                }
                else // Sinon on rajoute qu'une virgule
                {
                    File.AppendAllText(Path, item + ",");
                }
            }
            File.AppendAllText(Path, "\n"); // Pour une nouvelle ligne dans le fichier
        }

        public void WriteNewColumn(string NameOfNewColumn) // Cette méthode va me servir à écrire une nouvelle colonne au fichier
        {
            // J'écrit directement les nouvelle données
            List<string> lines = File.ReadAllLines(Path).ToList(); // je lis le fichier et je le
                                                                                                                   // transforme direct en une list
                                                                                                                   // la condition est que line soit
                                                                                                                   // IEnumerable
            if(lines.Count != 0) //Si il y a qqu chose dans le fichier
            {
                lines[0] += ","+NameOfNewColumn; // J'ajoute la nouvelle variable
                int index = 1; 

                lines.Skip(1).ToList().ForEach(line => // => est une expression réduite appelé l'expression lambda
                                                       // cela me permet de créer une méthode anonyme qui va ajouter une
                                                       // virgule à chaque ligne du fichier
                { // La mêthode skip me permet de outre passer le premier index car je ne dois pas mettre une virgule
                    lines[index] += ",";
                    index++;
                });
                File.WriteAllLines(Path, lines);
            }
            else // Si le fichier est vide 
            {
                File.AppendAllText(Path, NameOfNewColumn); // Cette méthode me permet d'ajouter une chaine de caractére 

            }
        }

    }
}
