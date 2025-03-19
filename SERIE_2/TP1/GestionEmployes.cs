using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class GestionEmployes
    {
        private List<Employee> employees;

        public GestionEmployes()
        {
            employees = new List<Employee>();
        }

        public void AjouterEmployee(Employee emp)
        {
            employees.Add(emp);
            Console.WriteLine($"Employé {emp.Nom} ajouté avec succès.");
        }

        public bool SupprimerEmployee(string nom)
        {
            Employee emp = employees.Find(e => e.Nom == nom);
            if (emp != null)
            {
                employees.Remove(emp);
                Console.WriteLine($"Employé {nom} supprimé avec succès.");
                return true;
            }
            Console.WriteLine($"Employé {nom} non trouvé.");
            return false;
        }

        public double CalculerSalaireTotal()
        {
            return employees.Sum(emp => emp.Salaire);
        }

        public double CalculerSalaireMoyen()
        {
            if (employees.Count == 0)
                return 0;

            return CalculerSalaireTotal() / employees.Count;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public void AfficherEmployees()
        {
            Console.WriteLine("\nListe des employés:");
            Console.WriteLine("-------------------");
            if (employees.Count == 0)
            {
                Console.WriteLine("Aucun employé enregistré.");
                return;
            }

            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
