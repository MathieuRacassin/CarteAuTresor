using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie
{
    /// <summary>
    /// 
    /// </summary>
    public class Tresor : Element
    {
        /// <summary>
        /// 
        /// </summary>
        private int nombreTresor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="nombreTresor"></param>
        public Tresor(Position position, int nombreTresor)
            :base(position)
        {
            this.nombreTresor = nombreTresor;
        }

        /// <summary>
        /// 
        /// </summary>
        public int NombreTresor
        {
            get
            {
                return this.nombreTresor;
            }
            set
            {
                this.nombreTresor = value;
            }
        }
    }
}
