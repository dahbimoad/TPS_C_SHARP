using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Repertoire
    {
        public string Nom { get; set; }
        public int Nbr_fichiers { get; set; }
        public Fichier[] fichiers = new Fichier[30];

        public Repertoire()
        {

        }
        public Repertoire(string nom)
        {
            Nom = nom;
        }

        public void Afficher()
        {
            Console.WriteLine($"Nom du repertoire : {Nom} Nombre de fichiers : {Nbr_fichiers}");
            Console.WriteLine("Liste des fichiers : ");
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                fichiers[i].Afficher();
            }
        }

        public int Rechercher(string file_name)
        {
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                if (fichiers[i].Nom == file_name)
                {
                    return i;

                }
            }
            return -1;
        }

        public void Ajouter(Fichier fichier)
        {
            if (fichier == null)
            {
                Console.WriteLine("Impossible d'ajouter un fichier null");
                return;
            }
            if (Nbr_fichiers < 30)
            {
                fichiers[Nbr_fichiers] = fichier;
                Nbr_fichiers++;
            }
            else
            {
                Console.WriteLine("Le repertoire est plein");
            }
        }

        public void Afficher_PDF()
        {
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                if (fichiers[i].Extension == "pdf")
                    Console.WriteLine(fichiers[i].Nom);
            }
        }


        public bool Supprimer(string fichier)
        {
            int inx = Rechercher(fichier);

            if (inx != -1)
            {
                for (int i = inx; i < Nbr_fichiers - 1; i++)
                {
                    fichiers[i] = fichiers[i + 1];
                }

                fichiers[Nbr_fichiers - 1] = null;

                Nbr_fichiers--;

                return true;
            }

            return false;
        }

        public float getTaille()
        {
            float taille = 0;
            for (int i = 0; i < Nbr_fichiers; i++)
                taille += fichiers[i].Taille;

            return taille / 1024;
        }
        public bool RenommerFichier(string nom, string nouveauNom)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                fichiers[index].Renommer(nouveauNom);
                return true;
            }
            return false;
        }

        public bool ModifierTaille(string nom, float nouvelleTaille)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                fichiers[index].Modifier(nouvelleTaille);
                return true;
            }
            return false;
        }

    }
}
