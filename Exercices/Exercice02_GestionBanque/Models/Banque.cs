﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_GestionBanque.Models
{
    public class Banque
    {
        private List<Compte> comptes = new();
        public string Nom { get; set; }
        private string SavePath
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Gestion Banque",
                    Nom + ".csv"
                );
            }
        }

        private string DirectoryPath
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Gestion Banque");
            }
        }

        public Compte? this[string numero]
        {
            get
            {
                Compte? c = comptes.Find(c => c.Numero == numero);
                return c;
            }
        }

        public void Ajouter(Compte courant)
        {
            // permet de vérifier s'il existe déjà un compte dans la banque avec ce numero - LINQ
            if (comptes.Any(c => c.Numero == courant.Numero))
            {
                // plus déclencher une erreur
                return;
            }
            comptes.Add(courant);
        }

        public void Supprimer(string numero)
        {
            // Chercher un compte dans la liste de comptes
            // qui repond à une condition
            Compte? c = comptes.Find(c => c.Numero == numero);
            if (c == null)
            {
                // plus déclencher une erreur
                return;
            }
            comptes.Remove(c);
        }

        public double AvoirDesComptes(string nom, string prenom)
        {
            // Filtrer les comptes du titulaire
            List<Compte> comptesDuTitulaire = comptes.Where(c => c.Titulaire.Nom == nom && c.Titulaire.Prenom == prenom && c is Courant).ToList();

            // Utiliser l'opérateur + pour calculer la somme des soldes positifs
            double total = 0;
            foreach (Courant compte in comptesDuTitulaire)
            {
                total += Math.Max(compte.Solde, 0);
                //total += compte.Solde > 0 ? compte.Solde : 0;
            }

            return total;
        }

        public void Sauver()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }


            List<string> data = comptes.Select(item => $"{item.GetType().Name},{item.Numero},{item.Solde},{(item is Courant ? ((Courant)item).LigneDeCredit : ((Epargne)item).DateDernierRetrait)},{item.Titulaire.Nom},{item.Titulaire.Prenom},{item.Titulaire.DateNaissance}").ToList();

            File.WriteAllLines(SavePath, data);
        }


        public void Charger()
        {
            if (!File.Exists(SavePath))
            {
                return;
            }
            string[] data = File.ReadAllLines(SavePath);
            foreach (string item in data)
            {
                string[] line = item.Split(",");
                Compte c;
                Personne t = new Personne(line[4], line[5], DateTime.Parse(line[6]));

                if (line[0] == "Courant")
                {
                    c = new Courant(line[1], t, double.Parse(line[3]));

                }
                else
                {
                    c = new Epargne(line[1], line[3] == "" ? null : DateTime.Parse(line[3]), t);
                }

                c.Depot(double.Parse(line[2]));
                Ajouter(c);
            }
        }
    }
}
