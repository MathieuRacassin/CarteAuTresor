using CarteAuTresor.Librairie;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    public class Aventuriers
    {
        private List<Aventurier> aventuriers = new List<Aventurier>();

        public void AddAventurier(Aventurier aventurier)
        {
            aventuriers.Add(aventurier);
        }

        public void SetUp()
        {
            throw new NotImplementedException();
        }

        public void PlaySequences()
        {
            foreach(Aventurier aventurier in aventuriers)
            {
                aventurier.PlaySequence();
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach(var aventurier in aventuriers)
            {
                builder.AppendLine(aventurier.ToString());
            }
            
            return builder.ToString();
        }
    }
}