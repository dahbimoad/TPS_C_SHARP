using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class RessourcesHumaines : IRessourcesHumaines
    {
        private List<Personnel> GRH;

        public RessourcesHumaines()
        {
            GRH = new List<Personnel>();
        }

        public void AjouterPersonnel(Personnel p)
        {
            GRH.Add(p);
            Console.WriteLine($"Personnel {p.Nom} {p.Prenom} ajouté avec succès.");
        }

        public void Afficher_Enseignants()
        {
            Console.WriteLine("Liste des enseignants:");
            bool trouve = false;

            foreach (Personnel p in GRH)
            {
                if (p is Enseignant ens)
                {
                    trouve = true;
                    ens.Afficher_ens_details();
                    Console.WriteLine("---------------------");
                }
            }

            if (!trouve)
            {
                Console.WriteLine("Aucun enseignant dans la liste.");
            }
        }

        public int Rechercher_Ens(int code)
        {
            for (int i = 0; i < GRH.Count; i++)
            {
                if (GRH[i] is Enseignant && GRH[i].Code == code)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Afficher_etd(Etudiant etudiant)
        {
            if (etudiant != null)
            {
                etudiant.Afficher();
            }
            else
            {
                Console.WriteLine("Étudiant introuvable.");
            }
        }
    }
}
