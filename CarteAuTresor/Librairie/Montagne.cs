using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie
{
    public class Montagne : Element
    {
        public Montagne(Position position)
            :base(position)
        {
        }

        public override string TypeOf()
        {
            return TypeOfElement.Montagne;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(TypeOf());
            builder.Append("-");
            builder.Append(position.X);
            builder.Append("-");
            builder.Append(position.Y);
            
            return builder.ToString();
        }
    }
}
