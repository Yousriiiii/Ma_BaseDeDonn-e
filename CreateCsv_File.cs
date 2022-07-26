using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Ma_BaseDeDonnée
{
    public class CreateCsv_File
    {
        public CreateCsv_File(string csvPath, string NameOfFile)
        {
            File.AppendAllText(csvPath +"\\"+ NameOfFile, null); // Ici ca ajoute ET créer le fichier csv
        }


    }
}
