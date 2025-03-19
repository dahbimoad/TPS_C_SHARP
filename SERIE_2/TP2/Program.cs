using TP2;
namespace TP2
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Système de Gestion de Bibliothèque ====\n");

            Biblio biblio = new Biblio();
            bool continuer = true;

            while (continuer)
            {
                AfficherMenu();
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterLivre(biblio);
                        break;
                    case "2":
                        AjouterDictionnaire(biblio);
                        break;
                    case "3":
                        Console.WriteLine($"\nNombre de livres dans la bibliothèque: {biblio.CalculerNombreLivres()}");
                        break;
                    case "4":
                        biblio.AfficherDictionnaires();
                        break;
                    case "5":
                        biblio.TousLesAuteurs();
                        break;
                    case "6":
                        biblio.ToutesLesDescriptions();
                        break;
                    case "7":
                        continuer = false;
                        Console.WriteLine("Programme terminé.");
                        break;
                    default:
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        break;
                }

                if (continuer)
                {
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void AfficherMenu()
        {
            Console.WriteLine("=== Menu Principal ===");
            Console.WriteLine("1. Ajouter un livre");
            Console.WriteLine("2. Ajouter un dictionnaire");
            Console.WriteLine("3. Afficher le nombre de livres");
            Console.WriteLine("4. Afficher les dictionnaires");
            Console.WriteLine("5. Afficher tous les auteurs");
            Console.WriteLine("6. Afficher toutes les descriptions");
            Console.WriteLine("7. Quitter");
            Console.Write("\nVotre choix: ");
        }

        static void AjouterLivre(Biblio biblio)
        {
            Console.WriteLine("\n=== Ajouter un livre ===");

            Console.Write("Titre: ");
            string titre = Console.ReadLine();

            Console.Write("Auteur: ");
            string auteur = Console.ReadLine();

            int nombrePages = 0;
            bool valide = false;
            while (!valide)
            {
                Console.Write("Nombre de pages: ");
                valide = int.TryParse(Console.ReadLine(), out nombrePages);
                if (!valide || nombrePages <= 0)
                {
                    Console.WriteLine("Erreur: Veuillez entrer un nombre valide de pages.");
                    valide = false;
                }
            }

            Livre livre = new Livre(titre, auteur, nombrePages);
            biblio.AjouterDocument(livre);
        }

        static void AjouterDictionnaire(Biblio biblio)
        {
            Console.WriteLine("\n=== Ajouter un dictionnaire ===");

            Console.Write("Titre: ");
            string titre = Console.ReadLine();

            Console.Write("Langue: ");
            string langue = Console.ReadLine();

            int nombreDefinitions = 0;
            bool valide = false;
            while (!valide)
            {
                Console.Write("Nombre de définitions: ");
                valide = int.TryParse(Console.ReadLine(), out nombreDefinitions);
                if (!valide || nombreDefinitions <= 0)
                {
                    Console.WriteLine("Erreur: Veuillez entrer un nombre valide de définitions.");
                    valide = false;
                }
            }

            Dictionnaire dictionnaire = new Dictionnaire(titre, langue, nombreDefinitions);
            biblio.AjouterDocument(dictionnaire);
        }
    }
}