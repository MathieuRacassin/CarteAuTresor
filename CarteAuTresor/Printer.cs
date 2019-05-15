using System;
using System.Text;

namespace CarteAuTresor
{
    public class Printer
    {
        private GameMap map;

        public Printer(GameMap map)
        {
            this.map = map;
        }

        public string Print()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(map.ToString());
            builder.AppendLine(map.Aventuriers.ToString());

            return builder.ToString();
        }
    }
}