using CarteAuTresor.Librairie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteAuTresor.Librairie.Outils;

namespace CarteAuTresor.Librairie
{
    /// <summary>
    /// Représente un aventurier
    /// </summary>
    public class Aventurier : Element
    { 
        private string nom;

        private string orientation;

        private string sequence;

        private int nombreTresor;

        private int nombreTour;

        public Aventurier(Position position,string nom, string orientation, string sequence, int nombreTresor, int nombreTour) : base(position)
        {
            this.nom = nom;
            this.orientation = orientation;
            this.sequence = sequence;
            this.nombreTresor = nombreTresor;
            this.nombreTour = nombreTour;
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }
        }

        public string Orientation
        {
            get
            {
                return this.orientation;
            }
            set
            {
                this.orientation = value;
            }
        }

        /// <summary>
        /// Gets Sequence de mouvement de l'<see cref="Aventurier"/>
        /// </summary>
        public string Sequence
        {
            get
            {
                return this.sequence;
            }
        }

        /// <summary>
        /// Gets ou sets le nombre de trésor ramassé par l'<see cref="Aventurier"/>
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

        public int NombreTour
        {
            get
            {
                return this.nombreTour;
            }
            set
            {
                this.nombreTour = value;
            }
        }

        /// <summary>
        /// Joue la séquence de mouvement
        /// </summary>
        public void PlaySequence()
        {
            if (string.IsNullOrEmpty(this.sequence))
            {
                throw new Exception("Votre séquence est vide");
            }
            else
            {
                var listeSequence = new List<char>(this.sequence.ToArray());

                foreach( var mouvement in listeSequence)
                {
                    if( mouvement == Char.Parse("A"))
                    {
                        Avancer(this.orientation);
                        ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("G"))
                    {
                        Gauche(this.orientation);
                        ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("D"))
                    {
                        Droite(this.orientation);
                        ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("R"))
                    {
                        Reculer(this.orientation);
                        ChangeOrientation(mouvement);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carte"></param>
        public void JouerElement(GameMap carte)
        {
            if (string.IsNullOrEmpty(this.sequence))
            {
                throw new Exception("Votre séquence est vide");
            }
            else
            {
                var listeSequence = new List<char>(this.sequence.ToArray());

                foreach (var mouvement in listeSequence)
                {
                    if (mouvement == Char.Parse("A"))
                    {
                        Avancer(this.orientation);
                        ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("G"))
                    {
                        Gauche(this.orientation);
                        this.ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("D"))
                    {
                        Droite(this.orientation);
                        ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("R"))
                    {
                        Reculer(this.orientation);
                        ChangeOrientation(mouvement);
                    }

                    if(carte.IsTresor(position))
                    {
                         carte.GetTresor(position).LostOneTresor();
                         WinOneTresor();
                    }
                    
                }

                
            }

        }

        /// <summary>
        /// Change l'orientation de l'aventurier en fonction souvent
        /// </summary>
        /// <param name="mouvement">Mouvement réalisé par l'aventurier</param>
        private void ChangeOrientation(char mouvement)
        {
            if(this.orientation == Outils.Orientation.Nord)
            {
                if(mouvement == Char.Parse("G"))
                {
                    this.orientation = Outils.Orientation.Ouest;
                }
                if(mouvement == Char.Parse("D"))
                {
                    this.orientation = Outils.Orientation.Est;
                }
            }

            if (this.orientation == Outils.Orientation.Sud)
            {
                if (mouvement == Char.Parse("G"))
                {
                    this.orientation = Outils.Orientation.Est;
                }
                if (mouvement == Char.Parse("D"))
                {
                    this.orientation = Outils.Orientation.Ouest;
                }
            }

            if (this.orientation == Outils.Orientation.Est)
            {
                if (mouvement == Char.Parse("G"))
                {
                    this.orientation = Outils.Orientation.Nord;
                }
                if (mouvement == Char.Parse("D"))
                {
                    this.orientation = Outils.Orientation.Sud;
                }
            }

            if (this.orientation == Outils.Orientation.Ouest)
            {
                if (mouvement == Char.Parse("G"))
                {
                    this.orientation = Outils.Orientation.Sud;
                }
                if (mouvement == Char.Parse("D"))
                {
                    this.orientation = Outils.Orientation.Nord;
                }
            }
        }

        /// <summary>
        /// Permet d'avancer
        /// </summary>
        /// <param name="orientation">Orientation de l'aventurier </param>
        public void Avancer(string orientation)
        {
            if (orientation == Outils.Orientation.Est && position.Xmax >= position.X + 1)
            {
                position.X += 1;
            }
            if (orientation == Outils.Orientation.Nord && 0 <= position.Y - 1)
            {
                position.Y -= 1;
            }
            if (orientation == Outils.Orientation.Sud && position.Ymax >= position.Y + 1)
            {
                position.Y += 1;
            }
            if (orientation == Outils.Orientation.Ouest && 0 <= position.X - 1)
            {
                position.X -= 1;
            }
        }

        /// <summary>
        /// Permet de faire reculer l'aventurier
        /// </summary>
        /// <param name="orientation">Orientation de l'aventurier </param>
        public void Reculer(string orientation)
        {
            if (orientation == Outils.Orientation.Est && 0 <= position.X - 1)
            {
                position.X -= 1;
            }
            if (orientation == Outils.Orientation.Nord && position.Ymax >= position.Y + 1)
            {
                position.Y += 1;
            }
            if (orientation == Outils.Orientation.Sud && 0 <= position.Y - 1)
            {
                position.Y -= 1;
            }
            if (orientation == Outils.Orientation.Ouest && position.Xmax >= position.X + 1)
            {
                position.X += 1;
            }
        }

        /// <summary>
        /// Permet de déplacer vers la gauche l'aventurier
        /// </summary>
        /// <param name="orientation">Orientation de l'aventurier </param>
        public void Gauche(string orientation)
        {
            if (orientation == Outils.Orientation.Est && 0 <= position.Y - 1)
            {
                position.Y -= 1;
            }
            if (orientation == Outils.Orientation.Nord && 0 <= position.X - 1)
            {
                position.X -= 1;
            }
            if (orientation == Outils.Orientation.Sud && position.Xmax >= position.X + 1)
            {
                position.X += 1;
            }
            if (orientation == Outils.Orientation.Ouest && position.Ymax >= position.Y + 1)
            {
                position.Y += 1;
            }
        }

        /// <summary>
        /// Permet de déplacer vers la droite l'aventurier
        /// </summary>
        /// <param name="orientation">Orientation de l'aventurier</param>
        public void Droite(string orientation)
        {
            if (orientation == Outils.Orientation.Est  && position.Ymax >= position.Y + 1)
            {
                position.Y += 1;
            }
            if (orientation == Outils.Orientation.Nord && position.Xmax >= position.X + 1)
            {
                position.X += 1;
            }
            if (orientation == Outils.Orientation.Sud && 0 <= position.X - 1)
            {
                position.X -= 1;
            }
            if (orientation == Outils.Orientation.Ouest && 0 <= position.Y - 1)
            {
                position.Y -= 1;
            }
        }

        public void WinOneTresor()
        {
            this.nombreTour++;
        }

        public override string TypeOf()
        {
            return TypeOfElement.Aventurier;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("A");
            builder.Append("-");
            builder.Append(nom);
            builder.Append("-");
            builder.Append(position.X);
            builder.Append("-");
            builder.Append(position.Y);
            builder.Append("-");
            builder.Append(orientation);
            builder.Append("-");
            builder.Append(nombreTresor);

            return builder.ToString();
        }
    }
}
