using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice03_CarWash.Models
{
    // internal : interne au programme/projet
    class Car //si rien, internal par défaut
    {
        // readonly : {get; private set;}
        public string Plaque { get; private set; }
        public Car(string plaque)
        {
            Plaque = plaque;
        }
    }
}
