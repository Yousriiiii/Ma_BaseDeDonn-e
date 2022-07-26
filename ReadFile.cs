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
        public static string FirstLine;
        public ReadFile(string FilePath)
        {
            this.Path = FilePath;
            /* pour lire tout le fichier
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var value = line.Split(',');
            }
            */
        }

        public string[] GetFirstLine()
        {
            // J'instancie un streamreader pour pouvoir lire le fichier
            this.reader = new StreamReader(File.OpenRead(Path));
            string[] value = null; // C'est le tableau de string de la première ligne

            FirstLine = reader.ReadLine(); // Ca c'est le string de la première ligne
            if(FirstLine != null) // Je vérifie qu'il y a qqu chose à la premère ligne
            {
                value = FirstLine.Split(',');
            }
            // Et puis je ferme le reader
            this.reader.Close();
            return value;
        }
    }
}
