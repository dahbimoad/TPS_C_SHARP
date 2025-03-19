using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public interface IRessourcesHumaines
    {
        void Afficher_Enseignants();
        int Rechercher_Ens(int code);
    }
}
