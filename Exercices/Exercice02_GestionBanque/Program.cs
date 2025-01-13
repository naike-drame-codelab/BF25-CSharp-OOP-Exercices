﻿using Exercice02_GestionBanque.Models;

Banque banque = new()
{
    Nom = "Banque de Digital City"
};

ConsoleKey key = default;

while (true)
{
    Console.Clear();
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
}

void AfficherLesAvoirs()
{
    string nom = Question("Nom ?");
    string prenom = Question("Prenom ?");
    Console.WriteLine($"Avoirs du compte {nom} {prenom} : {banque.AvoirDesComptes(nom, prenom)}");
}

void AfficherCompte()
{
    string numero = Question("Entrer le numéro");
    Courant? c = banque[numero];
    if (c == null)
    {
        Console.WriteLine("Aucun compte existant avec ce numero");
        return;
    }

    Console.WriteLine("------------------------");
    Console.WriteLine($"Numéro : {c.Numero}");
    Console.WriteLine($"Solde : {c.Solde}");
    Console.WriteLine($"Nom : {c.Titulaire.Nom}");
    Console.WriteLine($"Prénom : {c.Titulaire.Prenom}");
    Console.WriteLine("------------------------");

    Console.WriteLine("1. Ajouter de l'argent");
    Console.WriteLine("2. Retirer de l'argent");

    key = Console.ReadKey(true).Key;
    switch (key)
    {
        case ConsoleKey.NumPad1:
            AjouterArgent(c);
            break;
        case ConsoleKey.NumPad2:
            RetirerArgent(c);
            break;
    }
}

void AjouterArgent(Courant c)
{
    double montant = double.Parse(Question("Quel montant ?"));
    c.Depot(montant);
}

void RetirerArgent(Courant c)
{
    double montant = double.Parse(Question("Quel montant ?"));
    c.Retrait(montant);
}

void AjouterCompte()
{
    Personne p = new()
    {
        Nom = Question("Entrer un nom"),
        Prenom = Question("Entrer un prenom"),
        DateNaissance = DateTime.Parse(Question("Entrer une date de naissance")),
    };

    Courant c = new()
    {
        Numero = Question("Entrer le numero"),
        Titulaire = p,
        LigneDeCredit = double.Parse(Question("Entrer la ligne de crédit"))
    };
    banque.Ajouter(c);
}

string Question(string message)
{
    Console.WriteLine(message);
    return Console.ReadLine();
}