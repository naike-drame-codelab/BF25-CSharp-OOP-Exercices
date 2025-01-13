﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_GestionBanque.Models
{
    public class Courant
    {
        #region Attributs 

        private string _Numero;
        private double _Solde;
        private double _LigneDeCredit;
        private Personne _Titulaire;

        #endregion

        #region Prop's

        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        public double Solde
        {
            get { return _Solde; }
            private set { _Solde = value; }
        }

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

        public Personne Titulaire
        {
            get { return _Titulaire; }
            set { _Titulaire = value; }
        }

        #endregion

        #region Méthodes
        // Retrait
        public void Retrait(double montant)
        {
            if (montant <= 0)
            {
                return; // à remplacer plus tard par un exception
            }

            if (Solde - montant < -_LigneDeCredit)
            {
                return; // à remplacer plus tard par un exception
            }

            _Solde -= montant;
        }

        // Depôt
        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                return; // à remplacer plus tard par un exception
            }

            _Solde += montant;
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
