using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice02_GestionBanque.Exceptions;

namespace Exercice02_GestionBanque.Models
{
    sealed class Epargne : Compte
    {
        #region Constructeurs
        public Epargne(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }
        public Epargne(string numero, Personne titulaire, double solde) : base(numero, titulaire, solde)
        {
        }
        #endregion
                
        #region Prop's
        public DateTime? DateDernierRetrait { get; set; }

        #endregion

         

        #region Méthodes
        // Retrait
        public override void Retrait(double montant)
        {
            if (Solde - montant < 0)
            {
                throw new SoldeInsuffisantException(Solde, montant);
            }
            DateDernierRetrait = DateTime.Now;
            base.Retrait(montant);
        }

        // Implémentation de la class abstract CalculInteret()
        protected override double CalculInterets()
        {
            return Solde * 0.045;
        }

        #endregion
    }
}
