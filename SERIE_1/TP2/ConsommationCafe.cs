using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class ConsommationCafe
    {
        public int NoSemaine { get; set; }
        public int Programmeur { get; set; }
        public int NbTasses { get; set; }

        public ConsommationCafe(int semaine, int programmeur, int tasses)
        {
            NoSemaine = semaine;
            Programmeur = programmeur;
            NbTasses = tasses;
        }
    }
}
