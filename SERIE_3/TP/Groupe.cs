using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Groupe
    {
        private string nomGroupe;
        private List<Etudiant> etudiants;

        public Groupe(string nomGroupe)
        {
            this.nomGroupe = nomGroupe;
            this.etudiants = new List<Etudiant>();
        }

        public string NomGroupe { get => nomGroupe; }
        public List<Etudiant> Etudiants { get => etudiants; }

        public void Ajouter_etudiant(Etudiant etudiant)
        {
            etudiants.Add(etudiant);
            Console.WriteLine($"Étudiant {etudiant.Nom} {etudiant.Prenom} ajouté au groupe {nomGroupe}");
        }

        public void Afficher_grp()
        {
            Console.WriteLine($"Groupe: {nomGroupe}");
            Console.WriteLine("Liste des étudiants:");

            if (etudiants.Count == 0)
            {
                Console.WriteLine("Aucun étudiant dans ce groupe.");
                return;
            }

            foreach (Etudiant etudiant in etudiants)
            {
                etudiant.Afficher();
                Console.WriteLine();
            }
        }
    }
}
