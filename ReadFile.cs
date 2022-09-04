using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ma_BaseDeDonnée
{
    public class ReadFile
    {
        StreamReader reader;
        public string Path;

        public ReadFile(string FilePath)
        {
            this.Path = FilePath;

        }

        public string[] GetFirstLine()
        {
            // J'instancie un streamreader pour pouvoir lire le fichier
            this.reader = new StreamReader(File.OpenRead(Path));
            string[] value = null; // C'est le tableau de string de la première ligne

            string Header = reader.ReadLine(); // Ca c'est le string de la première ligne
            if(Header != null) // Je vérifie qu'il y a qqu chose à la premère ligne
            {
                value = Header.Split(';');
            }
            // Et puis je ferme le reader
            this.reader.Close();

            return value;
        }

        public List<string> GetAllData()
        {
            List<string> lines = File.ReadAllLines(Path).ToList();

            return lines;
        }

        public List<string> GetDataOfColown(int index)
        {
            List<string> colown = new List<string>(); // C'est la liste qui contient la data d'une collonne

            List<string> ListOfAllData = new List<string>();

            ListOfAllData = GetAllData(); // liste avec toute la data

            foreach(string item in ListOfAllData)
            {
                var localTable = item.Split(';'); // C'est le tableau d'une ligne
                colown.Add(localTable[index]); 
            }

            return colown;
        }
    }
}
