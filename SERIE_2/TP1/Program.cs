using TP1;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Système de Gestion des Employés ====\n");

            // Création d'une instance de GestionEmployes
            GestionEmployes gestion = new GestionEmployes();

            // Ajout de quelques employés
            gestion.AjouterEmployee(new Employee("Ahmed Hassan", 10000, "Développeur", new DateTime(2020, 5, 15)));
            gestion.AjouterEmployee(new Employee("Sara Benjelloun", 12000, "Chef de Projet", new DateTime(2019, 3, 10)));
            gestion.AjouterEmployee(new Employee("Karim Alaoui", 8500, "Analyste", new DateTime(2021, 1, 20)));
            gestion.AjouterEmployee(new Employee("Fatima Zahra", 15000, "Architecte Logiciel", new DateTime(2018, 7, 5)));

            // Affichage de tous les employés
            gestion.AfficherEmployees();

            // Obtention de l'instance unique du Directeur
            Directeur directeur = Directeur.GetInstance();

            // Attribution de la gestion des employés au Directeur
            directeur.SetGestionEmployes(gestion);

            // Affichage des informations de l'entreprise via le Directeur
            directeur.AfficherInformationsEntreprise();

            // Test de suppression d'un employé
            Console.WriteLine("\nTest de suppression d'un employé:");
            gestion.SupprimerEmployee("Karim Alaoui");

            // Affichage des informations mises à jour
            directeur.AfficherInformationsEntreprise();

            // Démonstration du Singleton
            Console.WriteLine("\nDémonstration du pattern Singleton:");
            Directeur autreTentative = Directeur.GetInstance();
            Console.WriteLine($"Est-ce la même instance? {(Object.ReferenceEquals(directeur, autreTentative) ? "Oui" : "Non")}");

            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }
