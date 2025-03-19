using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Dictionnaire : Document
    {
        private string langue;
        private int nombreDefinitions;

        public Dictionnaire(string titre, string langue, int nombreDefinitions) : base(titre)
        {
            this.langue = langue;
            this.nombreDefinitions = nombreDefinitions;
        }

        public string Langue { get { return langue; } set { langue = value; } }
        public int NombreDefinitions { get { return nombreDefinitions; } set { nombreDefinitions = value; } }

        public override string Description()
        {
            return $"Dictionnaire N°{Numero}: \"{Titre}\", langue: {langue}, {nombreDefinitions} définitions";
        }
    }
}
