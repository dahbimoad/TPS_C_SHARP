using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Directeur
    {
        // Instance unique (Singleton)
        private static Directeur instance;

        // Instance de GestionEmployes
        private GestionEmployes gestionEmployes;

        // Constructeur privé (empêche l'instanciation directe)
        private Directeur()
        {
            gestionEmployes = new GestionEmployes();
        }

        // Méthode statique pour obtenir l'instance unique
        public static Directeur GetInstance()
        {
            if (instance == null)
            {
                instance = new Directeur();
            }
            return instance;
        }

        // Permet au directeur de mettre à jour la gestion des employés
        public void SetGestionEmployes(GestionEmployes gestionEmployes)
        {
            this.gestionEmployes = gestionEmployes;
            Console.WriteLine("Liste des employés mise à jour par le directeur.");
        }

        // Accès aux informations de l'entreprise
        public GestionEmployes GetGestionEmployes()
        {
            return gestionEmployes;
        }

        public double GetSalaireTotal()
        {
            return gestionEmployes.CalculerSalaireTotal();
        }

        public double GetSalaireMoyen()
        {
            return gestionEmployes.CalculerSalaireMoyen();
        }

        // Affiche un résumé des informations de l'entreprise
        public void AfficherInformationsEntreprise()
        {
            Console.WriteLine("\nInformations de l'entreprise (via le Directeur):");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Nombre d'employés: {gestionEmployes.GetEmployees().Count}");
            Console.WriteLine($"Salaire total: {GetSalaireTotal():F2} DHS");
            Console.WriteLine($"Salaire moyen: {GetSalaireMoyen():F2} DHS");
        }
    }
}
