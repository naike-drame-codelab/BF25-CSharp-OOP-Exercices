using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice01_CreationClass.Models
{
    public class Bank
    {
        #region Attributs / Membres
        private string _Name;
        Dictionary<string, Current> _Accounts = new Dictionary<string, Current>();
        // on renvoie le dictionnaire sous forme de tableau
        public KeyValuePair<string, Current>[] Accounts
        {
            get { return _Accounts.ToArray(); }
        }

        #region Si on veut travailler directement avec un dictionnaire et ses méthodes
        // private Dictionary<string, Current> _Accounts = new Dictionary<string, Current>(); // Initialisation directement dans le membre
        #endregion 

        #endregion

        #region Propriétés
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        // Indexeur pour récupérer un compte par son numéro
        public Current this[string number]
        {
            get
            {
                _Accounts.TryGetValue(number, out Current acc);
                return acc;

                #region Alternative avec ContainsKey()
                //if (_Accounts.ContainsKey(number))
                //{
                //    return _Accounts[number];
                //}
                //Console.WriteLine("Compte non trouvé.");
                //return null; 
                #endregion
            }
        }
        #endregion

        #region Méthodes
        // Ajouter un compte
        public void AddNewAccount(Current account)
        {
            _Accounts.Add(account.Number, account);

            #region Alternative avec ContainsKey()
            //if (!_Accounts.ContainsKey(account.Number))
            //{
            //    _Accounts.Add(account.Number, account);
            //    Console.WriteLine($"Compte {account.Number} ajouté à la banque.");
            //}
            //else
            //{
            //    Console.WriteLine("Le compte existe déjà.");
            //} 
            #endregion
        }

        // Supprimer un compte
        /// <summary>
        /// Supprimer un compte de la banque
        /// </summary>
        public void DeleteAccount(string number)
        {

            _Accounts.Remove(number);

            #region Alternative avec ContainsKey()
            //if (_Accounts.ContainsKey(account))
            //{
            //    _Accounts.Remove(account);
            //    Console.WriteLine($"Compte {account} supprimé de la banque.");
            //}
            //else
            //{
            //    Console.WriteLine("Compte non trouvé.");
            //} 
            #endregion
        }

        #endregion
    }
}
