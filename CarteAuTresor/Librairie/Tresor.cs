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

        public override string TypeOf()
        {
            return TypeOfElement.Tresor;
        }

        public void LostOneTresor()
        {
            this.nombreTresor--;
        }

        public bool HasTresor()
        {
            return nombreTresor > 0;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(TypeOf());
            builder.Append("-");
            builder.Append(position.X);
            builder.Append("-");
            builder.Append(position.Y);
            builder.Append("-");
            builder.Append(nombreTresor);

            return builder.ToString();
        }
    }
}
