using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Programmeur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Bureau { get; set; }

        public Programmeur(int id, string nom, string prenom, string bureau)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Bureau = bureau;
        }

        public void Afficher()
        {
            Console.WriteLine($"{Id} - {Nom} {Prenom} - {Bureau}");
        }
    }
}
