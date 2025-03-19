using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Fichier
    {
        public string Nom { get; set; }
        public string Extension { get; set; }
        public float Taille { get; set; }

        public Fichier()
        {
        }

        public Fichier(string nom, string extension, float taille)
        {
            Nom = nom;
            Extension = extension;
            Taille = taille;
        }

        public void Afficher()
        {
            Console.WriteLine($"Nom de fichier : {Nom}, Extension : {Extension}, Taille : {Taille} Ko");
        }

        public void Renommer(string newName)
        {
            Nom = newName;
        }
        public void Modifier(float newTaille)
        {
            Taille = newTaille;
        }

    }
}
