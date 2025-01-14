using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice02_GestionBanque.Interfaces;

namespace Exercice02_GestionBanque.Models
{
    // primary constructeur directement à la définition de la class
    // public abstract class Compte(string numero, Personne Titulaire) : ICustomer, IBanker
    // ALT+ENTER sur la class : use primary constructor 
    public abstract class Compte : ICustomer, IBanker
    {
        #region Attributs 

        private string _Numero;
        private double _Solde;
        private Personne _Titulaire;

        #endregion

        #region Constructeurs (ctor shortcut)
        // select les propriétés nécessaires --> ALT+ENTER --> Generate constructor
        // protected a du sens ici car on est dans une class abstract que l'on ne peut instancier
        protected Compte(string numero, Personne titulaire)
        {
            _Numero = numero;
            _Titulaire = titulaire;
        }

        protected Compte(string numero, Personne titulaire, double solde)
        {
            _Numero = numero;
            _Titulaire = titulaire;
            _Solde = solde;
        }

        #endregion

        #region Prop's

        public string Numero
        {
            get { return _Numero; }
            private set { _Numero = value; }
        }

        public double Solde
        {
            get { return _Solde; }
            private set { _Solde = value; }
        }


        public Personne Titulaire
        {
            get { return _Titulaire; }
            private set { _Titulaire = value; }
        }

        #endregion

        #region Méthodes
        // Retrait
        public virtual void Retrait(double montant)
        {
            if (montant <= 0)
            {
                return; // à remplacer plus tard par un exception
            }

            Solde -= montant;
        }

        // Depôt
        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                return; // à remplacer plus tard par un exception
            }

            Solde += montant;
        }

        // Calcul intérêt
        abstract protected double CalculInterets();

        // Appliquer intérêt
        public void AppliquerInterets()
        {
            Solde += CalculInterets();
        }

        #endregion

    }
}
