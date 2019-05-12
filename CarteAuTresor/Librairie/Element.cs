using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie
{
    public class Element
    {
        /// <summary>
        /// 
        /// </summary>
        private Position position;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public Element(Position position)
        {
            this.position = position;
        }

        /// <summary>
        /// 
        /// </summary>
        public Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
    }
}
