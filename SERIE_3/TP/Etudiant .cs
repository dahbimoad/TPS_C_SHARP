using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Etudiant : Personne
    {
        private int niveau;
        private double moyenne;

        public Etudiant(int code, string nom, string prenom, int niveau, double moyenne)
            : base(code, nom, prenom)
        {
            this.niveau = niveau;
            this.moyenne = moyenne;
        }

        public int Niveau { get => niveau; set => niveau = value; }
        public double Moyenne { get => moyenne; set => moyenne = value; }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine($"Niveau: {niveau}, Moyenne: {moyenne}");
        }
    }
}
