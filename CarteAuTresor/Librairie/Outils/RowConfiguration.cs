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
        private List<char> row;

        /// <summary>
        /// Instancie une ligne de configuration
        /// </summary>
        public RowConfiguration()
        {
            this.row = new List<char>();
        }

        /// <summary>
        /// Gets la ligne de configuration
        /// </summary>
        public List<char> Row
        {
            get
            {
                if(this.row == null)
                {
                    return new List<char>();
                }
                else
                {
                    return this.row;
                }
            }
        }
    }
}
