using CarteAuTresor.Librairie.Outils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie
{
    /// <summary>
    /// Gestionnaire de fichier 
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Le chemin du fichier texte
        /// </summary>
        private FileInfo filePath;
        
        /// <summary>
        /// Tableau de configuration
        /// </summary>
        private List<RowConfiguration> configurationTable = new List<RowConfiguration>();

        /// <summary>
        /// Nombre de ligne dans le fichier texte
        /// </summary>
        private int rowCount;


        public FileManager(string filePath)
        {
            this.filePath = new FileInfo(filePath);

            this.rowCount = 0;
        }

        /// <summary>
        /// Gets or sets le chemin
        /// </summary>
        public FileInfo FilePath
        {
            get
            {
                if(this.filePath.Exists == true)
                {
                    return this.filePath;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int RowCount
        {
            get
            {
                return this.rowCount;
            }
        }

        /// <summary>
        /// Tableau qui contient tous les caractères du fichier texte.
        /// Il permet la configuration de la chasse au trésor
        /// </summary>
        public List<RowConfiguration> ConfigurationTable
        {
            get
            {
                if(this.configurationTable == null)
                {
                    this.configurationTable = new List<RowConfiguration>();
                    return this.configurationTable;
                }
                else
                {
                    return this.configurationTable;
                }
            }
        }

        public List<RowConfiguration> FileReader()
        {
            string[] fileRead = File.ReadAllLines(this.filePath.FullName);
            List<string[]> vs = new List<string[]>();

            foreach(string line in fileRead)
            {
                var split = line.Split('-');
                vs.Add(split);
            }

            foreach(var line  in vs)
            {
                var row = new RowConfiguration();
                foreach(var l in line)
                {
                    row.Row.Add(l);
                }
                this.configurationTable.Add(row);
            }

            return this.configurationTable;
        }

        ///// <summary>
        ///// Permet de convertir le fichier texte en un tableau de <see cref="char"/>
        ///// <paramref name="rowFileCount"/> 
        ///// </summary>
        ///// <returns></returns>
        //public List<RowConfiguration> FileReader2()
        //{
        //    var nombreLigne = this.rowCount; 
        //    this.configurationTable = new List<RowConfiguration>(nombreLigne - 1);

        //    using (Stream stream = new FileStream(this.filePath.FullName, FileMode.Open))
        //    {
        //        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        //        {
        //            for (int row = 0; row < nombreLigne; row++)
        //            {
        //                var charArray = reader.ReadLine();

        //                var tempCharTab = new RowConfiguration();
        //                for (int column = 0; column < charArray.Count(); column++)
        //                {
        //                    if(IsValid(charArray[column])==true)
        //                    {
        //                        tempCharTab.Row.Add(charArray[column]);
        //                    }
        //                    else
        //                    {
        //                        continue;
        //                    }
        //                }
        //                this.configurationTable.Add(tempCharTab);
        //            }
        //        }
        //    }
        //    return this.configurationTable;
        //}

        public static void FileTextWriter(List<List<string>> fileToWrite, string cheminDuFichier)
        {
            using (Stream s = new FileStream(cheminDuFichier + @"\Sortie.txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(s, Encoding.UTF8))
                {
                    writer.Write("#Résultat de la chasse au trésor");
                    writer.WriteLine(string.Empty);
                    foreach (var line in fileToWrite)
                    {
                        var listLength = line.Count;
                        for(int i = 0; i < listLength; i++)
                        {
                            writer.Write(line[i]);
                            if ( i == listLength - 1)
                            {
                                continue;
                            }
                            else
                            {
                                writer.Write("-");
                            }
                        }
                        writer.WriteLine(string.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Vérifie la validitié du caractère en cours de lecture
        /// Exclue plusieurs caractères
        /// </summary>
        /// <param name="character"></param>
        /// <returns>True si le caractère est valide</returns>
        private static bool IsValid(char character)
        {
            if (character >= 0x41 && character <= 0x5a || character >= 0x30 && character <= 0x39 ||
                character >= 0x61 && character <= 0x7a || character == 0x2d)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
