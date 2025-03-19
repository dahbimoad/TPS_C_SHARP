using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Administratif : Personnel
    {
        public Administratif(int code, string nom, string prenom, string bureau, double salaire)
            : base(code, nom, prenom, bureau, salaire)
        {
        }

        public override double Calculer_Salaire()
        {
            return salaire;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine($"Salaire total: {Calculer_Salaire()}");
        }
    }
}
