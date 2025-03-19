using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class Enseignant : Personnel
    {
        private string grade;
        private int volumeHoraire;
        private double primeDeplacement;
        private Dictionary<string, Groupe> groupes;

        public Enseignant(int code, string nom, string prenom, string bureau, double salaire,
                         string grade, int volumeHoraire, double primeDeplacement)
            : base(code, nom, prenom, bureau, salaire)
        {
            this.grade = grade;
            this.volumeHoraire = volumeHoraire;
            this.primeDeplacement = primeDeplacement;
            this.groupes = new Dictionary<string, Groupe>();
        }

        public string Grade { get => grade; set => grade = value; }
        public int VolumeHoraire { get => volumeHoraire; set => volumeHoraire = value; }
        public double PrimeDeplacement { get => primeDeplacement; set => primeDeplacement = value; }

        // Indexeur pour accéder aux groupes
        public Groupe this[string nomGroupe]
        {
            get
            {
                if (groupes.ContainsKey(nomGroupe))
                    return groupes[nomGroupe];
                return null;
            }
        }

        public void Ajouter_groupe(Groupe groupe)
        {
            if (!groupes.ContainsKey(groupe.NomGroupe))
            {
                groupes.Add(groupe.NomGroupe, groupe);
                Console.WriteLine($"Groupe {groupe.NomGroupe} ajouté à l'enseignant {nom} {prenom}");
            }
            else
            {
                Console.WriteLine($"Le groupe {groupe.NomGroupe} existe déjà pour cet enseignant");
            }
        }

        public override double Calculer_Salaire()
        {
            double prixHeure = 0;
            switch (grade.ToUpper())
            {
                case "PA": prixHeure = 300; break;
                case "PH": prixHeure = 350; break;
                case "PES": prixHeure = 400; break;
                default: prixHeure = 300; break;
            }

            double salaireHeuresSupp = volumeHoraire * prixHeure;
            return salaire + primeDeplacement + salaireHeuresSupp;
        }

        public void Afficher_ens()
        {
            base.Afficher();
            Console.WriteLine($"Grade: {grade}, Volume horaire: {volumeHoraire}, Prime de déplacement: {primeDeplacement}");
            Console.WriteLine($"Salaire total: {Calculer_Salaire()}");

            Console.WriteLine("Groupes enseignés:");
            if (groupes.Count == 0)
            {
                Console.WriteLine("Aucun groupe assigné.");
                return;
            }

            foreach (var groupe in groupes)
            {
                Console.WriteLine($"- {groupe.Key}");
            }
        }

        public void Afficher_ens_details()
        {
            Afficher_ens();

            Console.WriteLine("\nDétails des groupes:");
            foreach (var groupe in groupes)
            {
                groupe.Value.Afficher_grp();
                Console.WriteLine();
            }
        }
    }
}
