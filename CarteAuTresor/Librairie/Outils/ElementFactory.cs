using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteAuTresor.Librairie.Outils
{
    public class ElementFactory
    {
        private readonly List<string> row = new List<string>();

        public ElementFactory()
        {
        }

        public string GetElementAt(int index)
        {
            return row[index];
        }

        public void AddElement(string element)
        {
            row.Add(element);
        }
    }
}
