using TP2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== Suivi de Consommation de Café =====");

        // Création du projet
        Console.Write("Code du projet: ");
        string code = Console.ReadLine();

        Console.Write("Sujet du projet: ");
        string sujet = Console.ReadLine();

        Console.Write("Durée du projet (semaines): ");
        int duree = int.Parse(Console.ReadLine());

        Projet projet = new Projet(code, sujet, duree);
        Console.WriteLine($"Projet '{sujet}' créé avec succès.\n");

        bool continuer = true;
        while (continuer)
        {
            AfficherMenu();
            Console.Write("Donnez votre choix: ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1": 
                    Console.WriteLine("Projet déjà créé!");
                    break;

                case "2": 
                    AjouterProgrammeur(projet);
                    break;

                case "3": 
                    RechercherProgrammeur(projet);
                    break;

                case "4":
                    AfficherProgrammeur(projet);
                    break;

                case "5": 
                    projet.AfficherProgrammeurs();
                    break;

                case "6": 
                    SupprimerProgrammeur(projet);
                    break;

                case "7": 
                    AjouterConsommation(projet);
                    break;

                case "8":
                    ChangerBureau(projet);
                    break;

                case "9": 
                    AfficherTotalSemaine(projet);
                    break;

                case "0": 
                    continuer = false;
                    Console.WriteLine("Programme terminé.");
                    break;

                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
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

    // Affiche le menu principal
    static void AfficherMenu()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("1) Créer un projet");
        Console.WriteLine("2) Ajouter un programmeur");
        Console.WriteLine("3) Rechercher un programmeur");
        Console.WriteLine("4) Afficher un programmeur");
        Console.WriteLine("5) Afficher la liste des programmeurs");
        Console.WriteLine("6) Supprimer un programmeur");
        Console.WriteLine("7) Ajouter une consommation de café");
        Console.WriteLine("8) Changer le bureau d'un programmeur");
        Console.WriteLine("9) Afficher total des tasses par semaine");
        Console.WriteLine("0) Quitter le programme");
        Console.WriteLine("=======================================");
    }

    // Ajouter un programmeur
    static void AjouterProgrammeur(Projet projet)
    {
        Console.WriteLine("\n=== Ajouter un Programmeur ===");

        try
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("NOM: ");
            string nom = Console.ReadLine();

            Console.Write("PRENOM: ");
            string prenom = Console.ReadLine();

            Console.Write("BUREAU: ");
            string bureau = Console.ReadLine();

            projet.AjouterProgrammeur(id, nom, prenom, bureau);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    // Rechercher un programmeur
    static void RechercherProgrammeur(Projet projet)
    {
        Console.WriteLine("\n=== Rechercher un Programmeur ===");

        try
        {
            Console.Write("Entrez l'ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());

            int index = projet.RechercherProgrammeur(id);
            if (index != -1)
            {
                Console.WriteLine("Programmeur trouvé à l'index: " + index);
            }
            else
            {
                Console.WriteLine($"Aucun programmeur avec l'ID {id}.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    // Afficher un programmeur
    static void AfficherProgrammeur(Projet projet)
    {
        Console.WriteLine("\n=== Afficher un Programmeur ===");

        try
        {
            Console.Write("Entrez l'ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());

            projet.AfficherProgrammeur(id);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    // Supprimer un programmeur
    static void SupprimerProgrammeur(Projet projet)
    {
        Console.WriteLine("\n=== Supprimer un Programmeur ===");

        try
        {
            Console.Write("Entrez l'ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());

            projet.SupprimerProgrammeur(id);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    // Ajouter une consommation
    static void AjouterConsommation(Projet projet)
    {
        Console.WriteLine("\n=== Ajouter une Consommation ===");

        try
        {
            Console.Write("ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Numéro de semaine: ");
            int semaine = int.Parse(Console.ReadLine());

            Console.Write("Nombre de tasses: ");
            int tasses = int.Parse(Console.ReadLine());

            projet.AjouterConsommation(id, semaine, tasses);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    // Changer le bureau
    static void ChangerBureau(Projet projet)
    {
        Console.WriteLine("\n=== Changer le Bureau ===");

        try
        {
            Console.Write("ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nouveau bureau: ");
            string bureau = Console.ReadLine();

            projet.ChangerBureau(id, bureau);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    // Afficher le total de tasses par semaine
    static void AfficherTotalSemaine(Projet projet)
    {
        Console.WriteLine("\n=== Total Tasses par Semaine ===");

        try
        {
            Console.Write("Numéro de semaine: ");
            int semaine = int.Parse(Console.ReadLine());

            projet.AfficherTotalSemaine(semaine);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }
}
