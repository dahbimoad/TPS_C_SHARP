using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public abstract class Document
    {
        private static int compteur = 1; // Pour auto_increment
        private int numero;
        private string titre;

        public Document(string titre)
        {
            this.numero = compteur++;
            this.titre = titre;
        }

        public int Numero { get { return numero; } }
        public string Titre { get { return titre; } set { titre = value; } }

        // Méthode abstraite à redéfinir dans les classes dérivées
        public abstract string Description();
    }
}
