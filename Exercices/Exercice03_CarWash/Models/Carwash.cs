using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice03_CarWash.Models;

namespace Exercice03_CarWash.Models
{
    class Carwash
    {
        #region Variables privées

        private Etape etapes;

        #endregion

        #region Ctor
        // dans le constructeur :
        // enregistrement des méthodes dans le delegate/tableau de méthodes 
        public Carwash()
        {
            /*
            // ajout des méthodes privées
            etapes += Preparer;
            etapes += Laver;
            etapes += Secher;
            etapes += Finaliser;
            */

            // fonctions ananymes
            etapes += v => Console.WriteLine($"Je prépare la voiture : {v.Plaque}.");
            etapes += v => Console.WriteLine($"Je lave la voiture : {v.Plaque}.");
            etapes += v => Console.WriteLine($"Je sèche la voiture : {v.Plaque}.");
            etapes += v => Console.WriteLine($"Je finalise la voiture : {v.Plaque}.");
        }

        #endregion

        #region Méthodes
        /*
        private void Preparer(Car v)
        {
            Console.WriteLine($"Je prépare la voiture : {v.Plaque}.");
        }
        private void Laver(Car v)
        {
            Console.WriteLine($"Je lave la voiture : {v.Plaque}.");
        }
        private void Secher(Car v)
        {
            Console.WriteLine($"Je sèche la voiture : {v.Plaque}.");
        }
        private void Finaliser(Car v)
        {
            Console.WriteLine($"Je finalise la voiture : {v.Plaque}.");
        }
         */

        public void Traiter(Car v)
        {
            etapes.Invoke(v);
        }

        #endregion
    }

    #region Delegates

    delegate void Etape(Car v);

    #endregion

}
