using CarteAuTresor.Librairie;
using CarteAuTresor.Librairie.Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor
{
    /// <summary>
    /// Représente la carte au trésor
    /// </summary>
    public class Carte
    {
        /// <summary>
        /// Tableau de cases de la carte
        /// </summary>
        private PositionElement[,] carteAuTresor;

        /// <summary>
        /// Largeur de la carte
        /// </summary>
        private int axeHorizontale;

        /// <summary>
        /// Hauteur le carte
        /// </summary>
        private int axeVerticale;

        /// <summary>
        /// Instancie une carte 
        /// </summary>
        /// <param name="tailleAxeVerticale">Hauteur de la carte</param>
        /// <param name="tailleAxeHorizontale">Largeur de la carte</param>
        private Carte(int tailleAxeVerticale, int tailleAxeHorizontale)
        {
            this.axeHorizontale = tailleAxeHorizontale;
            this.axeVerticale = tailleAxeVerticale;

            this.carteAuTresor = new PositionElement[this.axeVerticale, this.axeHorizontale];
        }

        /// <summary>
        /// Gets le tableau des cases de la carte
        /// </summary>
        public PositionElement[,] CarteAuTresor
        {
            get
            {
                return this.carteAuTresor;
            }
            set
            {
                this.carteAuTresor = value;
            }
        }

        /// <summary>
        /// Gets la largeur de la carte
        /// </summary>
        public int AxeHorizontale
        {
            get
            {
                return this.axeHorizontale;
            }
        }

        /// <summary>
        /// Gets la hauteur de la carte
        /// </summary>
        public int AxeVerticale
        {
            get
            {
                return this.axeVerticale;
            }
        }

        /// <summary>
        /// Crée une carte
        /// </summary>
        public void ConfigurerCarteAuTresor()
        {
            for (int verticale = 0; verticale <= this.axeVerticale - 1; verticale++)
            {
                for (int horizontale = 0; horizontale <= this.axeHorizontale - 1; horizontale++)
                {
                    var position = new Position()
                    {
                        X = horizontale,
                        Y = verticale,
                    };

                    this.CarteAuTresor[verticale, horizontale] = new PositionElement(position);
                }
            }
        }

        /// <summary>
        /// Configure la position des aventuriers
        /// </summary>
        /// <param name="fichierConfiguration">Fichir de configuration</param>
        public void ConfigurerAventurier(FileManager fichierConfiguration)
        {
            var configuration = fichierConfiguration.ConfigurationTable;

            int valeurX = 0;
            int valeurY = 0;

            foreach (RowConfiguration rowConfiguration in configuration)
            {
                // 0x41 vaut A
                if (rowConfiguration.Row[0] == 0x41)
                {
                    var listeValeur = FileManager.ExtraireString(rowConfiguration.Row);
                    Int32.TryParse(listeValeur[2], out valeurX);
                    Int32.TryParse(listeValeur[3], out valeurY);

                    var position = new PositionAventurier()
                    {
                        X = valeurX,
                        Y = valeurY
                    };

                    var aventurier = new Aventurier(position, listeValeur[1], listeValeur[4], listeValeur[5], 0, listeValeur[5].Length);
                    this.CarteAuTresor[position.X, position.Y] = new PositionElement(aventurier);
                }
            }
        }

        /// <summary>
        /// Configure la positon des trésors
        /// </summary>
        /// <param name="fichierConfiguration">fichier de configuration</param>
        public void ConfigurerTresor(FileManager fichierConfiguration)
        {
            var configuration = fichierConfiguration.ConfigurationTable;

            int valeurX = 0;
            int valeurY = 0;
            int nombreTresor = 0;

            foreach (RowConfiguration rowConfiguration in configuration)
            {
                // 0x54 vaut T
                if (rowConfiguration.Row[0] == 0x54)
                {
                    var listeValeur = FileManager.ExtraireString(rowConfiguration.Row);
                    Int32.TryParse(listeValeur[1], out valeurX);
                    Int32.TryParse(listeValeur[2], out valeurY);
                    Int32.TryParse(listeValeur[3], out nombreTresor);

                    var position = new Position()
                    {
                        X = valeurX,
                        Y = valeurY
                    };

                    var montagne = new Tresor(position,nombreTresor);
                    this.CarteAuTresor[position.X, position.Y] = new PositionElement(montagne);
                }
            }
        }

        /// <summary>
        /// Configure la position des montagnes
        /// </summary>
        /// <param name="fichierConfiguration"></param>
        public void ConfigurerMontagne(FileManager fichierConfiguration)
        {
            var configuration = fichierConfiguration.ConfigurationTable;

            int valeurX = 0;
            int valeurY = 0;

            foreach(RowConfiguration rowConfiguration in configuration)
            {
                // 0x4d vaut M
                if (rowConfiguration.Row[0] == 0x4d)
                {
                    var listeValeur = FileManager.ExtraireString(rowConfiguration.Row);
                    Int32.TryParse(listeValeur[1], out valeurX);
                    Int32.TryParse(listeValeur[2], out valeurY);

                    var position = new Position()
                    {
                        X = valeurX,
                        Y = valeurY
                    };

                    var montagne = new Montagne(position);
                    this.CarteAuTresor[position.X, position.Y] = new PositionElement(montagne);
                }
            }
        }

        /// <summary>
        /// Configure la carte au trésor
        /// </summary>
        /// <param name="fichierConfiguration">Ficheir de configuration</param>
        /// <returns>Une <see cref="Carte"/></returns>
        public static Carte CreerCarteAuTresor(FileManager fichierConfiguration)
        {
            var configuration = fichierConfiguration.ConfigurationTable;

            int dimensionHorizontale = 0;
            int dimensionVerticale = 0;

            foreach (RowConfiguration rowConfiguration in configuration)
            {
                // 0x043 vaut C
                if (rowConfiguration.Row[0] == 0x43)
                {
                    var listeValeur = FileManager.ExtraireString(rowConfiguration.Row);

                    Int32.TryParse(listeValeur[1], out dimensionHorizontale);
                    Int32.TryParse(listeValeur[2], out dimensionVerticale);
                }
            }
            return new Carte(dimensionVerticale, dimensionHorizontale);
        }

        /// <summary>
        /// Ecrit les résultats de la chasse au trésor sous forme de liste
        /// </summary>
        /// <returns>Tableau de string</returns>
        public List<List<string>> EcrireResultatChasseAuTresor()
        {
            var ecrireListe = new List<List<string>>();

            //Sortie configuration de la carte
            ecrireListe.Add(new List<string>()
            {   "C",
                this.axeHorizontale.ToString(),
                this.axeVerticale.ToString()
            });

            // Une boucle pour ajouter les éléments de sortie dans l'ordre
            foreach (var element in this.CarteAuTresor)
            {
                if (element.IsMontagne)
                {
                    ecrireListe.Add(new List<string>
                    {   "M",
                        element.Montagne.Position.X.ToString(),
                        element.Montagne.Position.Y.ToString()
                    });
                }
            }

            foreach (var element in this.CarteAuTresor)
            {
                if (element.IsTresor)
                {
                    ecrireListe.Add(new List<string>
                    {   "T",
                        element.Tresor.Position.X.ToString(),
                        element.Tresor.Position.Y.ToString(),
                        element.Tresor.NombreTresor.ToString()
                    });
                }
            }

            foreach (var element in this.CarteAuTresor)
            {
                if (element.Aventurier != null)
                {
                    ecrireListe.Add(new List<string>
                    {   "A",
                        element.Aventurier.Nom,
                        element.Aventurier.Position.X.ToString(),
                        element.Aventurier.Position.Y.ToString(),
                        element.Aventurier.Orientation,
                        element.Aventurier.NombreTresor.ToString()
                    });
                }
            }
            return ecrireListe;
        }
    }
}
