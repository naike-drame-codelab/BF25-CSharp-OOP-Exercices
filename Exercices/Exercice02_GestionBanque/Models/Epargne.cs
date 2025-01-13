using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_GestionBanque.Models
{
    public class Epargne : Compte
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

        #endregion
    }
}
