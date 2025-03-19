using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Personne
    {
        protected int code;
        protected string nom;
        protected string prenom;

        public Personne(int code, string nom, string prenom)
        {
            this.code = code;
            this.nom = nom;
            this.prenom = prenom;
        }

        public int Code { get => code; set => code = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public virtual void Afficher()
        {
            Console.WriteLine($"Code: {code}, Nom: {nom}, Prénom: {prenom}");
        }
    }
}
