using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5
{
    public class Operation
    {
        public string Type { get; set; }
        public double Montant { get; set; }
        public double SoldeApres { get; set; }
        public DateTime Date { get; set; }

        public Operation(string type, double montant, double soldeApres, DateTime date)
        {
            Type = type;
            Montant = montant;
            SoldeApres = soldeApres;
            Date = date;
        }

        public override string ToString()
        {
            return $"*** Operation {Type}: {Date:dd/MM/yyyy HH:mm:ss} ***\n" +
                   $"      Mantant: {Montant:0.00} dhs\n" +
                   $"      Solde: {SoldeApres:0.00} dhs";
        }
    }
}
