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
    public class RowConfiguration
    {
        /// <summary>
        /// Contient tous les caractères d'une ligne
        /// </summary>
        private readonly List<string> row = new List<string>();

        /// <summary>
        /// Instancie une ligne de configuration
        /// </summary>
        public RowConfiguration()
        {
        }

        /// <summary>
        /// Gets la ligne de configuration
        /// </summary>
        public List<string> Row
        {
            get
            {
                return this.row;
            }
        }
    }
}
