using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_GestionBanque.Models
{
    public class Banque
    {
        private List<Courant> courants = new();
        public string Nom { get; set; }

        public Courant? this[string numero]
        {
            get
            {
                Courant? c = courants.Find(c => c.Numero == numero);
                return c;
            }
        }

        public void Ajouter(Courant courant)
        {
            // permet de vérifier s'il existe déjà un compte dans la banque avec ce numero - LINQ
            if (courants.Any(c => c.Numero == courant.Numero))
            {
                // plus déclencher une erreur
                return;
            }
            courants.Add(courant);
        }

        public void Supprimer(string numero)
        {
            // Chercher un compte dans la liste de comptes
            // qui repond à une condition
            Courant? c = courants.Find(c => c.Numero == numero);
            if (c == null)
            {
                // plus déclencher une erreur
                return;
            }
            courants.Remove(c);
        }

        public double AvoirDesComptes(string nom, string prenom)
        {
            // Filtrer les comptes du titulaire
            List<Courant> comptesDuTitulaire = courants.Where(c => c.Titulaire.Nom == nom && c.Titulaire.Prenom == prenom).ToList();

            // Utiliser l'opérateur + pour calculer la somme des soldes positifs
            double total = 0;
            foreach (Courant compte in comptesDuTitulaire)
            {
                 total += Math.Max(compte.Solde, 0);
                //total += compte.Solde > 0 ? compte.Solde : 0;
            }

            return total;
        }
    }
}
