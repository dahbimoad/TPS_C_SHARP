using TP5;

class Program
{
    static GestionnaireComptes gestionnaire;

    static void Main(string[] args)
    {
        gestionnaire = new GestionnaireComptes();

        if (!Authentification())
        {
            Console.WriteLine("Authentification échouée. Programme terminé.");
            return;
        }

        bool continuer = true;
        while (continuer)
        {
            AfficherMenuPrincipal();
            Console.Write("Donnez votre choix: ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterCompte();
                    break;
                case "2":
                    RechercherCompte();
                    break;
                case "3":
                    SupprimerCompte();
                    break;
                case "4":
                    OperationSurCompte();
                    break;
                case "5":
                    gestionnaire.AfficherTousComptes();
                    break;
                case "6":
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

    static bool Authentification()
    {
        Console.WriteLine("=== Authentification ===");

        Console.Write("Login: ");
        string login = Console.ReadLine();

        Console.Write("Mot de passe: ");
        string motDePasse = Console.ReadLine();

        return gestionnaire.Authentifier(login, motDePasse);
    }

    static void AfficherMenuPrincipal()
    {
        Console.WriteLine("================================");
        Console.WriteLine("1) Ajouter un nouveau compte");
        Console.WriteLine("2) Rechercher un compte");
        Console.WriteLine("3) Supprimer un compte");
        Console.WriteLine("4) Operation sur un compte");
        Console.WriteLine("5) Afficher tous les comptes");
        Console.WriteLine("6) Quitter le programme");
        Console.WriteLine("================================");
    }

    static void AjouterCompte()
    {
        if (!gestionnaire.EstAdmin())
        {
            Console.WriteLine("Vous n'avez pas les droits administrateur pour cette action.");
            return;
        }

        Console.WriteLine("\n=== Ajout d'un compte ===");

        try
        {
            Console.Write("Entrez le num du compte bancaire: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Entrez le nom du client: ");
            string nom = Console.ReadLine();

            Console.Write("Entrez son prenom: ");
            string prenom = Console.ReadLine();

            gestionnaire.AjouterCompte(numero, nom, prenom);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    static void RechercherCompte()
    {
        Console.WriteLine("\n=== Recherche d'un compte ===");

        try
        {
            Console.Write("Entrez le numero du compte: ");
            int numero = int.Parse(Console.ReadLine());

            Compte compte = gestionnaire.RechercherCompte(numero);
            if (compte != null)
            {
                Console.WriteLine(compte);
            }
            else
            {
                Console.WriteLine($"Le compte {numero} n'existe pas !!!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    static void SupprimerCompte()
    {
        if (!gestionnaire.EstAdmin())
        {
            Console.WriteLine("Vous n'avez pas les droits administrateur pour cette action.");
            return;
        }

        Console.WriteLine("\n=== Suppression d'un compte ===");

        try
        {
            Console.Write("Entrez le numero du compte: ");
            int numero = int.Parse(Console.ReadLine());

            gestionnaire.SupprimerCompte(numero);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    static void OperationSurCompte()
    {
        Console.WriteLine("\n=== Operation sur un compte ===");

        try
        {
            Console.Write("Entrez le numero du compte: ");
            int numero = int.Parse(Console.ReadLine());

            Compte compte = gestionnaire.RechercherCompte(numero);
            if (compte == null)
            {
                Console.WriteLine($"Le compte {numero} n'existe pas !!!");
                return;
            }

            bool retourMenuPrincipal = false;
            while (!retourMenuPrincipal)
            {
                AfficherMenuOperation(numero);
                Console.Write("Donnez votre choix: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        CrediterCompte(numero);
                        break;
                    case "2":
                        DebiterCompte(numero);
                        break;
                    case "3":
                        compte.AfficherHistorique();
                        break;
                    case "4":
                        TransfererArgent(numero);
                        break;
                    case "5":
                        retourMenuPrincipal = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }

                if (!retourMenuPrincipal)
                {
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    static void AfficherMenuOperation(int numeroCompte)
    {
        Console.WriteLine($"========== OPERATION SUR LE COMPTE {numeroCompte} =========");
        Console.WriteLine("1) Crediter");
        Console.WriteLine("2) Debiter");
        Console.WriteLine("3) Historique");
        Console.WriteLine("4) Transfert d'argent");
        Console.WriteLine("5) Revenir au menu principal");
        Console.WriteLine("=====================================");
    }

    static void CrediterCompte(int numero)
    {
        try
        {
            Console.Write("Entrez le montant a verser: ");
            double montant = double.Parse(Console.ReadLine());

            if (montant <= 0)
            {
                Console.WriteLine("Le montant doit être positif.");
                return;
            }

            if (gestionnaire.Crediter(numero, montant))
            {
                Console.WriteLine($"Le compte {numero} a été crédité de {montant:0.00} dhs");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    static void DebiterCompte(int numero)
    {
        try
        {
            Console.Write("Entrez le montant a retirer: ");
            double montant = double.Parse(Console.ReadLine());

            if (montant <= 0)
            {
                Console.WriteLine("Le montant doit être positif.");
                return;
            }

            if (gestionnaire.Debiter(numero, montant))
            {
                Console.WriteLine($"Le compte {numero} a été débité de {montant:0.00} dhs");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }

    static void TransfererArgent(int numeroSource)
    {
        try
        {
            Console.Write("Entrez le numero du destinataire: ");
            int numeroDestination = int.Parse(Console.ReadLine());

            if (numeroSource == numeroDestination)
            {
                Console.WriteLine("Vous ne pouvez pas transférer de l'argent au même compte.");
                return;
            }

            Console.Write("Entrez le montant a transferer: ");
            double montant = double.Parse(Console.ReadLine());

            if (montant <= 0)
            {
                Console.WriteLine("Le montant doit être positif.");
                return;
            }

            if (gestionnaire.TransfererArgent(numeroSource, numeroDestination, montant))
            {
                Console.WriteLine($"Transfert de {montant:0.00} dhs du compte {numeroSource} vers le compte {numeroDestination} effectué avec succès.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur: Format de donnée invalide.");
        }
    }
}