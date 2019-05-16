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
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        /// <summary>
        /// Représente la borne maximum de l'axe horizontale
        /// </summary>
        public int Xmax
        {
            get;
            set;
        }

        /// <summary>
        /// Représente la borne maximum de l'axe verticale
        /// </summary>
        public int Ymax
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Position position = obj as Position;

            return position.X == this.X && position.Y == this.Y;
        }
    }


}
