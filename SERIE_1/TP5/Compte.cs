using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5
{
    public class Compte
    {
        public int Numero { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public double Solde { get; set; }
        public List<Operation> Operations { get; set; }

        public Compte(int numero, string nom, string prenom)
        {
            Numero = numero;
            Nom = nom;
            Prenom = prenom;
            Solde = 0;
            Operations = new List<Operation>();
        }

        public void Crediter(double montant)
        {
            Solde += montant;
            Operations.Add(new Operation("credite", montant, Solde, DateTime.Now));
        }

        public bool Debiter(double montant)
        {
            if (montant > Solde)
            {
                Console.WriteLine("Erreur: Solde insuffisant");
                return false;
            }

            Solde -= montant;
            Operations.Add(new Operation("debite", montant, Solde, DateTime.Now));
            return true;
        }

        public void AfficherHistorique()
        {
            if (Operations.Count == 0)
            {
                Console.WriteLine("Aucune opération effectuée sur ce compte.");
                return;
            }

            foreach (var op in Operations)
            {
                Console.WriteLine(op);
            }
        }

        public override string ToString()
        {
            return $"{Numero} - {Nom} {Prenom} - {Solde:0.00} dhs /{Operations.Count} operation(s) effectuee(s)";
        }
    }
}
