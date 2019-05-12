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
    public class Aventurier
    { 
        /// <summary>
        /// Le nom de l'avenutier
        /// </summary>
        private string nom;

        /// <summary>
        /// La position de l'aventurier
        /// </summary>
        private PositionAventurier position;

        /// <summary>
        /// L'orientation de l'aventurier
        /// </summary>
        private string orientation;

        /// <summary>
        /// Les mouvements de l'aventurier
        /// </summary>
        private string sequence;

        /// <summary>
        /// Nombre de trésor ramassé par l'aventurier
        /// </summary>
        private int nombreTresor;

        /// <summary>
        /// Nombre de tour restants à l'aventurier
        /// </summary>
        private int nombreTour;

        /// <summary>
        /// Instancie l'<see cref="Aventurier"/>
        /// </summary>
        /// <param name="position">Position de l'aventurier sur la carte</param>
        /// <param name="nom">Nom de l'aventurier</param>
        /// <param name="orientation">Orientation de l'aventurier</param>
        /// <param name="sequence">Sequence de mouvement de l'aventurier</param>
        /// <param name="nombreTresor">Nombre de trésor ramassé</param>
        /// <param name="nombreTour">Nombre de tour</param>
        public Aventurier(PositionAventurier position, string nom, string orientation, string sequence, int nombreTresor, int nombreTour)
        {
            this.nom = nom;
            this.position = position;
            this.orientation = orientation;
            this.sequence = sequence;
            this.nombreTresor = nombreTresor;
            this.nombreTour = nombreTour;
        }

        /// <summary>
        /// Gets le nom de l'aventurier
        /// </summary>
        public string Nom
        {
            get
            {
                return this.nom;
            }
        }

        /// <summary>
        /// Gets ou sets la position de l'aventurier
        /// </summary>
        public PositionAventurier Position
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

        /// <summary>
        /// Gets orientation de l'<see cref="Aventurier"/>
        /// </summary>
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

        /// <summary>
        /// Gets ou sets le nombre de tour restants à l'<see cref="Aventurier"/>
        /// </summary>
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
        public void JouerSequence()
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
                        this.position.Avancer(this.orientation);
                        this.ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("G"))
                    {
                        this.position.Gauche(this.orientation);
                        this.ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("D"))
                    {
                        this.position.Droite(this.orientation);
                        this.ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("R"))
                    {
                        this.position.Reculer(this.orientation);
                        this.ChangeOrientation(mouvement);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carte"></param>
        public void JouerElement(Carte carte)
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
                        this.position.Avancer(this.orientation);
                        this.ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("G"))
                    {
                        this.position.Gauche(this.orientation);
                        this.ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("D"))
                    {
                        this.position.Droite(this.orientation);
                        this.ChangeOrientation(mouvement);
                    }
                    if (mouvement == Char.Parse("R"))
                    {
                        this.position.Reculer(this.orientation);
                        this.ChangeOrientation(mouvement);
                    }

                    foreach( var element in carte.CarteAuTresor)
                    {
                        if(element.IsTresor)
                        {
                            if(
                                element.Tresor.NombreTresor > 0 &&
                                element.Tresor.Position.X == this.Position.X && 
                                element.Tresor.Position.Y ==this.Position.Y)
                            {
                                element.Tresor.NombreTresor--;
                                this.NombreTresor++;
                            }
                        }
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

    }
}
