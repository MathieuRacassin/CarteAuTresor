using CarteAuTresor.Librairie;
using CarteAuTresor.Librairie.Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor
{
    public class GameMap
    {
        private Element[,] map;

        private GameMap(int horizontalLength, int verticalLength)
        {
            HorizontalLength = horizontalLength;
            VerticalLength = verticalLength;

            map = new Element[horizontalLength, verticalLength];
        }

        public int HorizontalLength { get; }
        public int VerticalLength { get; }

        public Aventuriers Aventuriers { get; } = new Aventuriers();

        public bool IsTresor(Position position)
        {
            return GetElementAt(position).TypeOf() == TypeOfElement.Tresor.ToString();
        }

        private void Initialize()
        {
            for (int verticale = 0; verticale <= this.VerticalLength - 1; verticale++)
            {
                for (int horizontale = 0; horizontale <= this.HorizontalLength - 1; horizontale++)
                {
                    var position = new Position(horizontale, verticale);

                    this.map[verticale, horizontale] = new Plaine(position);
                }
            }
        }



        public void InitializeElement(FileManager configurationFile)
        {
            var configuration = configurationFile.GetMapConfiguration();
            foreach (ElementFactory element in configuration)
            {
                InitializeTresor(element);
                InitializeMontagne(element);

                InitializeAventurier(element);
            }
        }

        private void InitializeAventurier(ElementFactory element)
        {
            if (element.GetElementAt(0) == TypeOfElement.Aventurier)
            {
                Int32.TryParse(element.GetElementAt(2), out int valeurX);
                Int32.TryParse(element.GetElementAt(3), out int valeurY);

                var position = new Position(valeurX, valeurY);

                Aventurier aventurier = new Aventurier(position, element.GetElementAt(1), element.GetElementAt(4), element.GetElementAt(5), 0, element.GetElementAt(5).Length);

                Aventuriers.AddAventurier(aventurier);
            }
        }

        private void InitializeTresor(ElementFactory element)
        {
            if (element.GetElementAt(0) == TypeOfElement.Tresor.ToString())
            {
                Int32.TryParse(element.GetElementAt(1), out int valeurX);
                Int32.TryParse(element.GetElementAt(2), out int valeurY);
                Int32.TryParse(element.GetElementAt(3), out int nombreTresor);

                var position = new Position(valeurX, valeurY);

                this.map[position.X, position.Y] = new Tresor(position, nombreTresor);
            }
        }

        private Element GetElementAt(Position position)
        {
            return map[position.X, position.Y];
        }

        private void InitializeMontagne(ElementFactory element)
        {
            if (element.GetElementAt(0) == TypeOfElement.Montagne.ToString())
            {
                Int32.TryParse(element.GetElementAt(1), out int valeurX);
                Int32.TryParse(element.GetElementAt(2), out int valeurY);

                var position = new Position(valeurX, valeurY);

                this.map[position.X, position.Y] = new Montagne(position);
            }
        }

        public static GameMap Create(FileManager fileManager)
        {
            var configuration = fileManager.GetMapConfiguration();
            int horizontalLength = 0;
            int verticalLenght = 0;
            foreach (ElementFactory element in configuration)
            {
                if (element.GetElementAt(0) == "C")
                {
                    Int32.TryParse(element.GetElementAt(1), out horizontalLength);
                    Int32.TryParse(element.GetElementAt(2), out verticalLenght);
                }
            }

            GameMap gameMap = new GameMap(horizontalLength, verticalLenght);
            gameMap.Initialize();

            return gameMap;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("C");
            builder.Append("-");
            builder.Append(HorizontalLength);
            builder.Append("-");
            builder.Append(VerticalLength);

            builder.AppendLine();

            foreach (var element in map)
            {
                if(element.TypeOf() == TypeOfElement.Montagne)
                {
                    builder.AppendLine(element.ToString());
                }
            }

            foreach (var element in map)
            {
                if (element.TypeOf() == TypeOfElement.Tresor)
                {
                    builder.AppendLine(element.ToString());
                }
            }

            return builder.ToString();
        }

        public Tresor GetTresor(Position position)
        {
            if(IsTresor(position))
            {
                return (Tresor)GetElementAt(position);
            }
            return new Tresor(position, 0);
        }
    }
}
