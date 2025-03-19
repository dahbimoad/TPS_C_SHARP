using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Employee
    {
        private string nom;
        private double salaire;
        private string poste;
        private DateTime dateEmbauche;

        public Employee(string nom, double salaire, string poste, DateTime dateEmbauche)
        {
            this.nom = nom;
            this.salaire = salaire;
            this.poste = poste;
            this.dateEmbauche = dateEmbauche;
        }

        // Getters et Setters
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public double Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        public DateTime DateEmbauche
        {
            get { return dateEmbauche; }
            set { dateEmbauche = value; }
        }

        public override string ToString()
        {
            return $"Nom: {nom}, Poste: {poste}, Salaire: {salaire:F2}, Date d'embauche: {dateEmbauche.ToShortDateString()}";
        }
    }
}
