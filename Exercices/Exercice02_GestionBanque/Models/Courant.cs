using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice02_GestionBanque.Exceptions;

namespace Exercice02_GestionBanque.Models
{
    sealed class Courant : Compte
    {
        #region Attributs 
        private double _LigneDeCredit;


        #endregion

        #region Ctors
        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }
        public Courant(string numero, Personne titulaire, double solde, double ligneDeCredit) : base(numero, titulaire, solde)
        {
            _LigneDeCredit = ligneDeCredit;
        }
        
        public Courant(string numero, Personne titulaire, double ligneDeCredit) : base(numero, titulaire)
        {
            _LigneDeCredit = ligneDeCredit;
        }

        #endregion

        #region Prop's

        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException();
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
                throw new SoldeInsuffisantException(Solde + LigneDeCredit, montant);
            }

            base.Retrait(montant);
        }

        // implémentation de la class abstract CalculInteret()
        protected override double CalculInterets()
        {
            return Solde > 0 ? Solde * 0.03 : Solde * 0.0975;
        }

        #endregion

        #region Surcharge d'opérateur
        // opérateur +
        public static double operator +(Courant c1, Courant c2)
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
