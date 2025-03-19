using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    // Classe principale du projet
    class Projet
    {
        public string Code { get; set; }
        public string Sujet { get; set; }
        public int Duree { get; set; }
        public int NbProgrammeurs { get; set; }

        private Programmeur[] Pr;  // Tableau des programmeurs
        private ConsommationCafe[] CC;  // Tableau des consommations de café
        private int nbConsos;  // Nombre actuel de consommations enregistrées

        public Projet(string code, string sujet, int duree, int nbProgMax = 10)
        {
            Code = code;
            Sujet = sujet;
            Duree = duree;
            NbProgrammeurs = 0;
            Pr = new Programmeur[nbProgMax];
            CC = new ConsommationCafe[100];  
            nbConsos = 0;
        }

        public void AjouterProgrammeur(int id, string nom, string prenom, string bureau)
        {
            if (NbProgrammeurs < 10)
            {
                Pr[NbProgrammeurs] = new Programmeur(id, nom, prenom, bureau);
                NbProgrammeurs++;
                Console.WriteLine("Programmeur ajouté avec succès.");
            }
            else
            {
                Console.WriteLine("Erreur: Nombre maximum de programmeurs atteint.");
            }
        }

        public int RechercherProgrammeur(int id)
        {
            for (int i = 0; i < NbProgrammeurs; i++)
            {
                if (Pr[i].Id == id)
                {
                    return i;
                }
            }
            return -1;  
        }

        public void AfficherProgrammeur(int id)
        {
            int index = RechercherProgrammeur(id);
            if (index != -1)
            {
                Pr[index].Afficher();
            }
            else
            {
                Console.WriteLine($"Programmeur avec ID {id} non trouvé.");
            }
        }

        public void AfficherProgrammeurs()
        {
            Console.WriteLine("Liste des programmeurs:");
            for (int i = 0; i < NbProgrammeurs; i++)
            {
                Pr[i].Afficher();
            }
        }

        public void SupprimerProgrammeur(int id)
        {
            int index = RechercherProgrammeur(id);
            if (index != -1)
            {
                for (int i = index; i < NbProgrammeurs - 1; i++)
                {
                    Pr[i] = Pr[i + 1];
                }
                NbProgrammeurs--;
                Console.WriteLine("Programmeur supprimé avec succès.");
            }
            else
            {
                Console.WriteLine($"Programmeur avec ID {id} non trouvé.");
            }
        }

        public void AjouterConsommation(int idProgrammeur, int semaine, int tasses)
        {
            if (RechercherProgrammeur(idProgrammeur) == -1)
            {
                Console.WriteLine("Erreur: Programmeur non trouvé.");
                return;
            }

            if (semaine < 1 || semaine > Duree)
            {
                Console.WriteLine($"Erreur: La semaine doit être entre 1 et {Duree}.");
                return;
            }

            CC[nbConsos] = new ConsommationCafe(semaine, idProgrammeur, tasses);
            nbConsos++;
            Console.WriteLine("Consommation de café enregistrée.");
        }

        public void ChangerBureau(int idProgrammeur, string nouveauBureau)
        {
            int index = RechercherProgrammeur(idProgrammeur);
            if (index != -1)
            {
                Pr[index].Bureau = nouveauBureau;
                Console.WriteLine("Bureau modifié avec succès.");
            }
            else
            {
                Console.WriteLine($"Programmeur avec ID {idProgrammeur} non trouvé.");
            }
        }

        public void AfficherTotalSemaine(int semaine)
        {
            if (semaine < 1 || semaine > Duree)
            {
                Console.WriteLine($"Erreur: La semaine doit être entre 1 et {Duree}.");
                return;
            }

            int total = 0;
            for (int i = 0; i < nbConsos; i++)
            {
                if (CC[i].NoSemaine == semaine)
                {
                    total += CC[i].NbTasses;
                }
            }

            Console.WriteLine($"Total des tasses consommées en semaine {semaine}: {total}");
        }
    }
}
