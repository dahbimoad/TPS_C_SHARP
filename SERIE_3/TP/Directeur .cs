using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Directeur : Personnel
    {
        private static Directeur instance;
        private double primeDeplacement;

        private Directeur(int code, string nom, string prenom, string bureau, double salaire, double primeDeplacement)
            : base(code, nom, prenom, bureau, salaire)
        {
            this.primeDeplacement = primeDeplacement;
        }

        public static Directeur GetInstance(int code, string nom, string prenom, string bureau, double salaire, double primeDeplacement)
        {
            if (instance == null)
            {
                instance = new Directeur(code, nom, prenom, bureau, salaire, primeDeplacement);
                return instance;
            }
            else
            {
                Console.WriteLine("Erreur: Un directeur existe déjà, impossible d'en créer un autre.");
                return instance;
            }
        }

        public double PrimeDeplacement { get => primeDeplacement; set => primeDeplacement = value; }

        public override double Calculer_Salaire()
        {
            return salaire + primeDeplacement;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine($"Prime de déplacement: {primeDeplacement}, Salaire total: {Calculer_Salaire()}");
        }
    }
}
