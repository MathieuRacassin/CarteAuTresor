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
        private List<string> row;

        /// <summary>
        /// Instancie une ligne de configuration
        /// </summary>
        public RowConfiguration()
        {
            this.row = new List<string>();
        }

        /// <summary>
        /// Gets la ligne de configuration
        /// </summary>
        public List<string> Row
        {
            get
            {
                if(this.row == null)
                {
                    return new List<string>();
                }
                else
                {
                    return this.row;
                }
            }
        }
    }
}
