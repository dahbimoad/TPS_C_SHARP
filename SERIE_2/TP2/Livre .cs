using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Livre : Document
    {
        private string auteur;
        private int nombrePages;

        public Livre(string titre, string auteur, int nombrePages) : base(titre)
        {
            this.auteur = auteur;
            this.nombrePages = nombrePages;
        }

        public string Auteur { get { return auteur; } set { auteur = value; } }
        public int NombrePages { get { return nombrePages; } set { nombrePages = value; } }

        public override string Description()
        {
            return $"Livre N°{Numero}: \"{Titre}\" par {auteur}, {nombrePages} pages";
        }
    }
}
