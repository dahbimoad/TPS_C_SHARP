namespace TP {
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("===== Gestion des Ressources Humaines ENSA Tanger =====\n");

            // Création des instances
            RessourcesHumaines rh = new RessourcesHumaines();

            // Création du directeur (singleton)
            Directeur directeur = Directeur.GetInstance(1, "Alami", "Ahmed", "B001", 25000, 5000);
            rh.AjouterPersonnel(directeur);

            // Test du singleton
            Console.WriteLine("\n--- Test du Singleton ---");
            Directeur directeur2 = Directeur.GetInstance(2, "El Idrissi", "Mohamed", "B002", 26000, 5500);

            // Création d'administratifs
            Administratif admin1 = new Administratif(3, "Benani", "Fatima", "A101", 12000);
            rh.AjouterPersonnel(admin1);

            // Création d'enseignants
            Enseignant ens1 = new Enseignant(4, "El Fahsi", "Karim", "E201", 15000, "PA", 20, 3000);
            Enseignant ens2 = new Enseignant(5, "Saidi", "Leila", "E202", 18000, "PH", 25, 3500);
            Enseignant ens3 = new Enseignant(6, "Moussa", "Hassan", "E203", 20000, "PES", 30, 4000);

            rh.AjouterPersonnel(ens1);
            rh.AjouterPersonnel(ens2);
            rh.AjouterPersonnel(ens3);

            // Création des groupes et des étudiants
            Groupe gi1 = new Groupe("GI1");
            Groupe gi2 = new Groupe("GI2");
            Groupe gm1 = new Groupe("GM1");

            Etudiant etd1 = new Etudiant(101, "Chakir", "Yassine", 2, 15.5);
            Etudiant etd2 = new Etudiant(102, "Bennani", "Younes", 2, 14.2);
            Etudiant etd3 = new Etudiant(103, "Karimi", "Imane", 2, 16.8);
            Etudiant etd4 = new Etudiant(104, "Tazi", "Salma", 2, 13.7);
            Etudiant etd5 = new Etudiant(105, "El Amrani", "Omar", 2, 12.9);

            Console.WriteLine("\n--- Ajout des étudiants aux groupes ---");
            gi1.Ajouter_etudiant(etd1);
            gi1.Ajouter_etudiant(etd2);
            gi2.Ajouter_etudiant(etd3);
            gi2.Ajouter_etudiant(etd4);
            gm1.Ajouter_etudiant(etd5);

            Console.WriteLine("\n--- Affectation des groupes aux enseignants ---");
            ens1.Ajouter_groupe(gi1);
            ens1.Ajouter_groupe(gi2);
            ens2.Ajouter_groupe(gm1);

            // Tests des méthodes
            Console.WriteLine("\n--- Test de recherche d'enseignant ---");
            int pos = rh.Rechercher_Ens(4);
            Console.WriteLine($"Position de l'enseignant avec code 4: {pos}");
            pos = rh.Rechercher_Ens(10);
            Console.WriteLine($"Position de l'enseignant avec code 10: {pos}");

            Console.WriteLine("\n--- Test d'affichage d'un groupe ---");
            gi1.Afficher_grp();

            Console.WriteLine("\n--- Test d'affichage d'un étudiant ---");
            rh.Afficher_etd(etd3);

            Console.WriteLine("\n--- Test d'affichage d'un enseignant ---");
            ens1.Afficher_ens();

            Console.WriteLine("\n--- Test d'affichage de tous les enseignants ---");
            rh.Afficher_Enseignants();

            Console.WriteLine("\n--- Test d'utilisation de l'indexeur ---");
            Groupe groupe = ens1["GI1"];
            if (groupe != null)
            {
                Console.WriteLine($"Groupe trouvé: {groupe.NomGroupe}");
                groupe.Afficher_grp();
            }

            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }

}