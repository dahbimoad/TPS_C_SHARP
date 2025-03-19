using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public abstract class Personnel : Personne
    {
        protected string bureau;
        protected double salaire;

        public Personnel(int code, string nom, string prenom, string bureau, double salaire)
            : base(code, nom, prenom)
        {
            this.bureau = bureau;
            this.salaire = salaire;
        }

        public string Bureau { get => bureau; set => bureau = value; }
        public double Salaire { get => salaire; set => salaire = value; }

        // Méthode abstraite à implémenter dans les sous-classes
        public abstract double Calculer_Salaire();

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine($"Bureau: {bureau}, Salaire: {salaire}");
        }
    }
}