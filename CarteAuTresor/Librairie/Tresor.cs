using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie
{
    public class Tresor : Element
    {
        private int nombreTresor;

        public Tresor(Position position, int nombreTresor)
            :base(position)
        {
            this.nombreTresor = nombreTresor;
        }

        public int NombreTresor
        {
            get
            {
                return this.nombreTresor;
            }
        }

        public override string TypeOf()
        {
            throw new NotImplementedException();
        }

        public void LostOneTresor()
        {
            this.nombreTresor--;
        }
    }
}
