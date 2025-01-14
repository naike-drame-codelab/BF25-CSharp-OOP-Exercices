using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_GestionBanque.Models
{
    public class Personne
    {
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public DateTime DateNaissance { get; private set; }
    }
}
