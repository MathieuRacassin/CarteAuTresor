using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie
{
    public abstract class Element
    {
        protected readonly Position position;

        public Element(Position position)
        {
            this.position = position;
        }
        
        public bool HasSamePosition(Position position)
        {
            return this.position.Equals(position);
        }

        public abstract string TypeOf();
    }
}
