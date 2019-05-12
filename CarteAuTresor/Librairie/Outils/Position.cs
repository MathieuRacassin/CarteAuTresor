using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie
{
    /// <summary>
    /// Décrit une position dans un plan
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Instancie la position
        /// </summary>
        /// <param name="xmax">Valeure maximum </param>
        /// <param name="ymax"></param>
        public Position()
        {
        }

        /// <summary>
        /// Gets ou sets la valeur de x
        /// </summary>
        public int X
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ou sets la valeur de y
        /// </summary>
        public int Y
        {
            get;
            set;
        }
    }
}
