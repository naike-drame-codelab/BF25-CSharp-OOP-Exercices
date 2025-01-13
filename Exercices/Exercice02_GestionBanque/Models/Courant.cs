using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_GestionBanque.Models
{
    public class Courant : Compte
    {
        #region Attributs 

        private double _LigneDeCredit;

        #endregion

        #region Prop's

        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            set
            {
                if (value < 0)
                {
                    return; // à remplacer plus tard par un exception
                }

                _LigneDeCredit = value;
            }

        }

        #endregion

        #region Méthodes
        // Retrait
        public override void Retrait(double montant)
        {
           
            if (Solde - montant < -_LigneDeCredit)
            {
                return; // à remplacer plus tard par un exception
            }

            base.Retrait(montant);
        }

        #endregion
        
        #region Surcharge d'opérateur
        // opérateur +
        public static double operator+(Courant c1, Courant c2)
        {
            return Math.Max(c1.Solde, 0) + Math.Max(c2.Solde, 0);
            
            #region Solution avec ternaires
            //double solde1 = c1.Solde > 0 ? c1.Solde : 0;
            //double solde2 = c2.Solde > 0 ? c2.Solde : 0;

            //return solde1 + solde2; 
            #endregion

        }

        #endregion

    }
}
