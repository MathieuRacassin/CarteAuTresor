using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie
{
    public class Plaine : Element
    {
        public Plaine(Position position)
            :base(position)
        {

        }

        public override string TypeOf()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
