using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TP5
{
    public class GestionnaireComptes
    {
        private List<Compte> comptes;
        private List<Utilisateur> utilisateurs;
        private Utilisateur utilisateurConnecte;
        private readonly string fichierComptes = "comptes.txt";
        private readonly string fichierUtilisateurs = "utilisateurs.json";

        public GestionnaireComptes()
        {
            comptes = new List<Compte>();
            utilisateurs = new List<Utilisateur>();
            ChargerUtilisateurs();
            ChargerComptes();
        }

        private void ChargerUtilisateurs()
        {
            if (File.Exists(fichierUtilisateurs))
            {
                string json = File.ReadAllText(fichierUtilisateurs);
                utilisateurs = JsonSerializer.Deserialize<List<Utilisateur>>(json);
            }
            else
            {
                // Créer des utilisateurs par défaut si le fichier n'existe pas
                utilisateurs = new List<Utilisateur>
                {
                    new Utilisateur("admin", "admin", true),
                    new Utilisateur("client", "client", false)
                };

                // Sauvegarder les utilisateurs par défaut
                string json = JsonSerializer.Serialize(utilisateurs, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fichierUtilisateurs, json);
            }
        }

        private void ChargerComptes()
        {
            if (File.Exists(fichierComptes))
            {
                string[] lignes = File.ReadAllLines(fichierComptes);
                foreach (string ligne in lignes)
                {
                    string[] donnees = ligne.Split(';');
                    if (donnees.Length >= 4)
                    {
                        int numero = int.Parse(donnees[0]);
                        string nom = donnees[1];
                        string prenom = donnees[2];
                        double solde = double.Parse(donnees[3]);

                        Compte compte = new Compte(numero, nom, prenom);
                        compte.Solde = solde;

                        // Charger les opérations si elles existent
                        if (donnees.Length > 4)
                        {
                            string[] operations = donnees[4].Split('|');
                            foreach (string op in operations)
                            {
                                if (!string.IsNullOrEmpty(op))
                                {
                                    string[] opDonnees = op.Split(',');
                                    if (opDonnees.Length == 4)
                                    {
                                        string type = opDonnees[0];
                                        double montant = double.Parse(opDonnees[1]);
                                        double soldeApres = double.Parse(opDonnees[2]);
                                        DateTime date = DateTime.Parse(opDonnees[3]);
                                        compte.Operations.Add(new Operation(type, montant, soldeApres, date));
                                    }
                                }
                            }
                        }

                        comptes.Add(compte);
                    }
                }
            }
        }

        private void SauvegarderComptes()
        {
            List<string> lignes = new List<string>();
            foreach (Compte compte in comptes)
            {
                string operationsStr = "";
                foreach (Operation op in compte.Operations)
                {
                    if (!string.IsNullOrEmpty(operationsStr))
                        operationsStr += "|";

                    operationsStr += $"{op.Type},{op.Montant},{op.SoldeApres},{op.Date}";
                }

                string ligne = $"{compte.Numero};{compte.Nom};{compte.Prenom};{compte.Solde};{operationsStr}";
                lignes.Add(ligne);
            }

            File.WriteAllLines(fichierComptes, lignes);
        }

        public bool Authentifier(string login, string motDePasse)
        {
            utilisateurConnecte = utilisateurs.FirstOrDefault(u => u.Login == login && u.MotDePasse == motDePasse);
            return utilisateurConnecte != null;
        }

        public bool EstAdmin()
        {
            return utilisateurConnecte != null && utilisateurConnecte.EstAdmin;
        }

        public bool AjouterCompte(int numero, string nom, string prenom)
        {
            if (comptes.Any(c => c.Numero == numero))
            {
                Console.WriteLine($"Le compte {numero} existe déjà !");
                return false;
            }

            Compte compte = new Compte(numero, nom, prenom);
            comptes.Add(compte);
            SauvegarderComptes();
            Console.WriteLine("Creation de compte effectue.....");
            return true;
        }

        public Compte RechercherCompte(int numero)
        {
            return comptes.FirstOrDefault(c => c.Numero == numero);
        }

        public bool SupprimerCompte(int numero)
        {
            Compte compte = RechercherCompte(numero);
            if (compte == null)
            {
                Console.WriteLine($"Le compte {numero} n'existe pas !!!");
                return false;
            }

            comptes.Remove(compte);
            SauvegarderComptes();
            Console.WriteLine("Compte supprime .........");
            return true;
        }

        public void AfficherTousComptes()
        {
            if (comptes.Count == 0)
            {
                Console.WriteLine("Aucun compte enregistré.");
                return;
            }

            foreach (Compte compte in comptes)
            {
                Console.WriteLine(compte);
            }
        }

        public bool Crediter(int numero, double montant)
        {
            Compte compte = RechercherCompte(numero);
            if (compte == null)
                return false;

            compte.Crediter(montant);
            SauvegarderComptes();
            return true;
        }

        public bool Debiter(int numero, double montant)
        {
            Compte compte = RechercherCompte(numero);
            if (compte == null)
                return false;

            bool resultat = compte.Debiter(montant);
            if (resultat)
                SauvegarderComptes();

            return resultat;
        }

        public bool TransfererArgent(int numeroSource, int numeroDestination, double montant)
        {
            Compte compteSource = RechercherCompte(numeroSource);
            Compte compteDestination = RechercherCompte(numeroDestination);

            if (compteSource == null || compteDestination == null)
            {
                Console.WriteLine("Un des comptes n'existe pas !!!");
                return false;
            }

            if (compteSource.Solde < montant)
            {
                Console.WriteLine("Solde insuffisant pour effectuer le transfert !!!");
                return false;
            }

            compteSource.Debiter(montant);
            compteDestination.Crediter(montant);
            SauvegarderComptes();
            return true;
        }
    }
}