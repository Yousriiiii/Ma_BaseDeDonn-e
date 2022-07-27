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
        public CreateCsv_File(string CompletedPath)
        {
            File.AppendAllText(CompletedPath, null); // Ici ca ajoute ET créer le fichier csv
                                                                          // mais on ne rajoute rien
        }


    }
}
