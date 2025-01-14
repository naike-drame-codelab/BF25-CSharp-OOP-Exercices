using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_GestionBanque.Models
{
    sealed class Epargne : Compte
    {
        #region Prop's
        public DateTime? DateDernierRetrait { get; set; }

        #endregion

        #region Méthodes
        // Retrait
        public override void Retrait(double montant)
        {
            if (Solde - montant < 0)
            {
                return; // à remplacer plus tard par un exception
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
