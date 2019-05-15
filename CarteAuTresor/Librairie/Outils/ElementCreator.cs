using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie.Outils
{
    /// <summary>
    /// Représente chaque ligne du ficher texte de configuration.
    /// </summary>
    public class ElementCreator
    {
        /// <summary>
        /// Contient tous les caractères d'une ligne
        /// </summary>
        private readonly List<string> row = new List<string>();

        /// <summary>
        /// Instancie une ligne de configuration
        /// </summary>
        public ElementCreator()
        {
        }

        public string GetElementAt(int index)
        {
            return row.ElementAt(index);
        }

        public void AddElement(string element)
        {
            row.Add(element);
        }
    }
}
