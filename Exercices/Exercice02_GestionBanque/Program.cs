﻿using System.Text;
using Exercice02_GestionBanque.Models;

Console.OutputEncoding = Encoding.UTF8;

Banque banque = new()
{
    Nom = "Banque de Digital City"
};
banque.Charger();

ConsoleKey key = default;

while (true)
{
    Console.Clear();
    Console.WriteLine($"Bienvenue à la {banque.Nom}");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("1. Ajouter un compte");
    Console.WriteLine("2. Afficher un compte");
    Console.WriteLine("3. Afficher les avoirs");
    key = Console.ReadKey(true).Key;
    switch (key)
    {
        case ConsoleKey.NumPad1:
            AjouterCompte();
            break;
        case ConsoleKey.NumPad2:
            AfficherCompte();
            break;
        case ConsoleKey.NumPad3:
            AfficherLesAvoirs();
            break;
    }
    banque.Sauver();
}

void AfficherLesAvoirs()
{
    string nom = Question("nom ?");
    string prenom = Question("prenom ?");
    Console.WriteLine($"Avoirs du compte de {nom} {prenom}: {banque.AvoirDesComptes(nom, prenom)} €");
    Console.ReadKey(true);
}

void AfficherCompte()
{
    string numero = Question("Entrer le numéro");
    Compte? c = banque[numero];
    if (c == null)
    {
        Console.WriteLine("Aucun compte existant avec ce numero");
        return;
    }

    while (key != ConsoleKey.Escape)
    {
        Console.Clear() ;
        AfficherInfo(c);

        Console.WriteLine("1. Ajouter de l'argent");
        Console.WriteLine("2. Retirer de l'argent");
        Console.WriteLine("3. Appliquer intérêts");

        key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.NumPad1:
                AjouterArgent(c);
                break;
            case ConsoleKey.NumPad2:
                RetirerArgent(c);
                break;
            case ConsoleKey.NumPad3:
                c.AppliquerInterets();
                break;
        }
    }
}

void AfficherInfo(Compte c)
{
    Console.WriteLine("------------------------");
    Console.WriteLine($"Type {c.GetType().Name}");
    Console.WriteLine($"Numero {c.Numero}");
    Console.WriteLine($"Solde {c.Solde}€");
    // création d'une variable contenant l'instance déjà castée (ici Compte)
    // égalité au niveau de l'adresse mémoire : Compte et Courant
    if (c is Courant courant)
    {
        Console.WriteLine("-----");
        Console.WriteLine(c == courant); // true
        Console.WriteLine(c.GetType()); // GestionBanque.Models
        Console.WriteLine(courant.GetType()); // GestionBanque.Models
        Console.WriteLine($"Ligne de crédit {courant.LigneDeCredit}€"); // on ne peut pas faire c.LigneDeCredit car ici c'est un Compte et non un Courant
    }
    else if (c is Epargne epargne)
    {
        Console.WriteLine($"Date du dernier retrait {epargne.DateDernierRetrait}");
    }
    Console.WriteLine($"Nom {c.Titulaire.Nom}");
    Console.WriteLine($"Prenom {c.Titulaire.Prenom}");
    Console.WriteLine($"Date de naissance {c.Titulaire.DateNaissance:dd/MM/yyyy}");
    Console.WriteLine("------------------------");
}

void AjouterArgent(Compte c)
{
    double montant = double.Parse(Question("Quel montant ?"));
    c.Depot(montant);
}

void RetirerArgent(Compte c)
{
    double montant = double.Parse(Question("Quel montant ?"));
    c.Retrait(montant);
}

void AjouterCompte()
{
    string type = Question("type?");

    Personne p = new()
    {
        Nom = Question("Entrer un nom"),
        Prenom = Question("Entrer un prenom"),
        DateNaissance = DateTime.Parse(Question("Entrer une date de naissance")),
    };

    if (type == "Courant")
    {
        Courant c = new()
        {
            Numero = Question("Entrer le numero"),
            Titulaire = p,
            LigneDeCredit = double.Parse(Question("Entrer la ligne de crédit"))
        };
        banque.Ajouter(c);
    }
    else
    {
        Epargne c = new()
        {
            Numero = Question("Entrer le numero"),
            Titulaire = p
        };
        banque.Ajouter(c);
    }

}

string Question(string message)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write(message + ": ");
    Console.ResetColor();
    return Console.ReadLine() ?? string.Empty;
}
