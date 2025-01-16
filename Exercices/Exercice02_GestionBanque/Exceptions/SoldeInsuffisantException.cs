using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_GestionBanque.Exceptions
{
    public class SoldeInsuffisantException : Exception
    {
        public double SoldeDisponible { get; set; }
        public double Montant { get; set; }
        
        public SoldeInsuffisantException(double soldeDisponible, double montant) : base($"Le solde est insuffisant. Solde disponible  :  {soldeDisponible}.")
        {
            SoldeDisponible = soldeDisponible;
            Montant = montant;
        }
    }
}
