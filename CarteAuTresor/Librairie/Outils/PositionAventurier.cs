using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie.Outils
{
    /// <summary>
    /// Décrit la position de l'aventurier et lui permet de réaliser des déplacements
    /// </summary>
    public class PositionAventurier : Position
    {
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

        /// <summary>
        /// Permet d'avancer
        /// </summary>
        /// <param name="orientation">Orientation de l'aventurier </param>
        public void Avancer(string orientation)
        {
            if (orientation == Orientation.Est && this.Xmax >= this.X + 1)
            {
                this.X = this.X + 1;
            }
            if (orientation == Orientation.Nord && 0 <= this.Y - 1)
            {
                this.Y = this.Y - 1;
            }
            if (orientation == Orientation.Sud && this.Ymax >= this.Y + 1)
            {
                this.Y = this.Y + 1;
            }
            if (orientation == Orientation.Ouest && 0 <= this.X - 1)
            {
                this.X = this.X - 1;
            }
        }

        /// <summary>
        /// Permet de faire reculer l'aventurier
        /// </summary>
        /// <param name="orientation">Orientation de l'aventurier </param>
        public void Reculer(string orientation)
        {
            if (orientation == Orientation.Est && 0 <= this.X - 1)
            {
                this.X = this.X - 1;
            }
            if (orientation == Orientation.Nord && this.Ymax >= this.Y + 1)
            {
                this.Y = this.Y + 1;
            }
            if (orientation == Orientation.Sud && 0 <= this.Y - 1)
            {
                this.Y = this.Y - 1;
            }
            if (orientation == Orientation.Ouest && this.Xmax >= this.X + 1)
            {
                this.X = this.X + 1;
            }
        }

        /// <summary>
        /// Permet de déplacer vers la gauche l'aventurier
        /// </summary>
        /// <param name="orientation">Orientation de l'aventurier </param>
        public void Gauche(string orientation)
        {
            if (orientation == Orientation.Est && 0 <= this.Y - 1)
            {
                this.Y = this.Y - 1;
            }
            if (orientation == Orientation.Nord && 0 <= this.X - 1)
            {
                this.X = this.X - 1;
            }
            if (orientation == Orientation.Sud && this.Xmax >= this.X + 1)
            {
                this.X = this.X + 1;
            }
            if (orientation == Orientation.Ouest && this.Ymax >= this.Y + 1)
            {
                this.Y = this.Y + 1;
            }
        }

        /// <summary>
        /// Permet de déplacer vers la droite l'aventurier
        /// </summary>
        /// <param name="orientation">Orientation de l'aventurier</param>
        public void Droite(string orientation)
        {
            if (orientation == Orientation.Est && this.Ymax >= this.Y + 1)
            {
                this.Y = this.Y + 1;
            }
            if (orientation == Orientation.Nord && this.Xmax >= this.X + 1)
            {
                this.X = this.X + 1;
            }
            if (orientation == Orientation.Sud && 0 <= this.X - 1)
            {
                this.X = this.X - 1;
            }
            if (orientation == Orientation.Ouest && 0 <= this.Y - 1)
            {
                this.Y = this.Y - 1;
            }
        }
    }
}
