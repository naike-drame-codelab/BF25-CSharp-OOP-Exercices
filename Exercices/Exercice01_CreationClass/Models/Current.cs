using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Exercice01_CreationClass.Models
{
    public class Current
    {
        #region Attributs privés
        private string _Number;
        private double _Balance;
        private double _CreditLine;
        private Person _Titular;

        #endregion

        #region  Propriétés publiques
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        // propriété en lecture seule, modifiée uniquement via les méthodes
        // comme on a un private set, on ne peut pas utiliser get => _Balance
        public double Balance
        {
            get { return _Balance; }
            private set { _Balance = value; }
        }

        // encapsulation permet de protéger les données sensibles d'une classe
        // et de contrôler leur accès ou modification via des règles spécifiques
        // champ privé pour inclure une validation
        public double CreditLine
        {
            get { return _CreditLine; }

            // si la propriété CreditLine est public sans contrôle,
            // un utilisateur pourrait assigner une valeur négative sans déclencher d'erreur
            set
            {
                if (value < 0)
                    throw new ArgumentException("La ligne de crédit doit être supérieure ou égale à 0.");
                _CreditLine = value;
            }
        }

        #region Alternative plus concice pour CreditLine
        /*
         * L'expression lambda (=>) peut être utilisée dans un setter, même avec des validations, tant que le setter ne contient qu'une seule expression. 
         * Cela est possible grâce à la syntaxe de corps d'expression qui permet de simplifier le code.
        
        public double LigneDeCredit
        {
            get => _LigneDeCredit; // Getter simple avec expression lambda
            set => _LigneDeCredit = (value < 0)
                ? throw new ArgumentException("La ligne de crédit doit être supérieure ou égale à 0.")
                : value;
        }
        */
        #endregion

        public Person Titular
        {
            get { return _Titular; }
            set { _Titular = value; }
        }

        #endregion


        #region Méthodes publiques
        public void Withdraw(double amount)
        {
            // empêche les retraits négatifs ou nuls, qui n'ont pas de sens dans ce contexte
            if (amount <= 0) return;
            // throw new ArgumentException("Le montant du retrait doit être strictement positif.");

            // vérifie si le solde après le retrait (Solde - montant)
            // est supérieur ou égal à la limite négative autorisée par la ligne de crédit (-LigneDeCredit)
            if (_Balance - amount < -CreditLine)
                throw new InvalidOperationException("Fonds insuffisants pour effectuer ce retrait.");

            // si les validations passent, le solde est réduit du montant spécifié et un message est affiché dans la console
            _Balance -= amount;
            Console.WriteLine($"Retrait de {amount:C}. Nouveau solde : {_Balance:C}.");
        }

        public void Deposit(double amount)
        {
            // empêche les dépôts négatifs ou nuls
            if (amount <= 0)
                throw new ArgumentException("Le montant du dépôt doit être strictement positif.");

            // si la validation passe, le solde est augmenté du montant spécifié et un message est affiché dans la console
            _Balance += amount;
            Console.WriteLine($"Dépôt de {amount:C}. Nouveau solde : {_Balance:C}.");
        }

        #endregion

    }
}
