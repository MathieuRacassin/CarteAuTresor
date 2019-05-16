using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie.Outils
{
    /// <summary>
    /// Représente les paramètres d'une case de la <see cref="CarteAuTresor"/>
    /// </summary>
    public class PositionElement
    {
        /// <summary>
        /// Une plaine 
        /// </summary>
        private Plaine plaine;

        /// <summary>
        /// Une montage
        /// </summary>
        private Montagne montagne;

        /// <summary>
        /// Un trésor
        /// </summary>
        private Tresor tresor;

        /// <summary>
        /// Une aventurier
        /// </summary>
        private Aventurier aventurier;

        /// <summary>
        /// Booléen plaine
        /// </summary>
        private bool isPlaine;

        /// <summary>
        /// Booléen Montagne
        /// </summary>
        private bool isMontagne;

        /// <summary>
        /// Booléen Trésor
        /// </summary>
        private bool isTresor;

        /// <summary>
        /// Instancie une case comme étant un plaine de base
        /// </summary>
        /// <param name="position">postion des élments</param>
        public PositionElement(Position position)
        {
            this.plaine = new Plaine(position);
            this.isPlaine = true;
        }

        /// <summary>
        /// Instancie la postion d'une montagne
        /// </summary>
        /// <param name="montagne">Une montagne</param>
        public PositionElement(Montagne montagne)
        {
            this.montagne = montagne;
            this.isMontagne = true;
        }

        /// <summary>
        /// Instancie la positon d'un trésor
        /// </summary>
        /// <param name="tresor"></param>
        public PositionElement(Tresor tresor)
        {
            this.tresor = tresor;
            this.isTresor = true;
        }

        /// <summary>
        /// Instancie un aventurier sur la carte
        /// </summary>
        /// <param name="aventurier">un aventurier</param>
        public PositionElement(Aventurier aventurier)
        {
            this.aventurier = aventurier;
        }

        /// <summary>
        /// Gets une plaine
        /// </summary>
        public Plaine Plaine
        {
            get
            {
                return this.plaine;
            }
        }

        /// <summary>
        /// Gets une montagne
        /// </summary>
        public Montagne Montagne
        {
            get
            {
                return this.montagne;
            }
        }

        /// <summary>
        /// Gets un trésor
        /// </summary>
        public Tresor Tresor
        {
            get
            {
                return this.tresor;
            }
        }

        /// <summary>
        /// Gets un aventurier
        /// </summary>
        public Aventurier Aventurier
        {
            get
            {
                return this.aventurier;
            }
            set
            {
                this.aventurier = value;
            }
        }

        public bool IsMontagne
        {
            get
            {
                return this.isMontagne;
            }
        }

        public bool IsTresor
        {
            get
            {
                return this.isTresor;
            }
        }

        public bool IsPlaine
        {
            get
            {
                return this.isPlaine;
            }
        }
    }
}
