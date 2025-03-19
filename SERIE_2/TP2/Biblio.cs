using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Biblio
    {
        private List<Document> documents;

        public Biblio()
        {
            documents = new List<Document>();
        }

        // 1. Ajouter un document (livre ou dictionnaire)
        public void AjouterDocument(Document doc)
        {
            documents.Add(doc);
            Console.WriteLine($"Document N°{doc.Numero} ajouté avec succès.");
        }

        // 2. Calculer le nombre de livres
        public int CalculerNombreLivres()
        {
            int compteur = 0;
            foreach (Document doc in documents)
            {
                if (doc is Livre)
                    compteur++;
            }
            return compteur;
        }

        // 2. Afficher que les dictionnaires
        public void AfficherDictionnaires()
        {
            Console.WriteLine("\n=== Liste des dictionnaires ===");
            bool trouve = false;
            foreach (Document doc in documents)
            {
                if (doc is Dictionnaire)
                {
                    Console.WriteLine(doc.Description());
                    trouve = true;
                }
            }
            if (!trouve)
                Console.WriteLine("Aucun dictionnaire dans la bibliothèque.");
        }

        // 3. Tous les auteurs
        public void TousLesAuteurs()
        {
            Console.WriteLine("\n=== Liste des documents avec auteurs ===");
            foreach (Document doc in documents)
            {
                string auteur = "Pas d'auteur";
                if (doc is Livre livre)
                    auteur = livre.Auteur;

                Console.WriteLine($"Document N°{doc.Numero}: {auteur}");
            }
        }

        // 5. Toutes les descriptions
        public void ToutesLesDescriptions()
        {
            Console.WriteLine("\n=== Descriptions de tous les documents ===");
            if (documents.Count == 0)
            {
                Console.WriteLine("La bibliothèque est vide.");
                return;
            }

            foreach (Document doc in documents)
            {
                Console.WriteLine(doc.Description());
            }
        }
    }
}
