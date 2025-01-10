using Exercice01_CreationClass.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;


// initialisation d'un objet Person comme titulaire
Person titular = new Person()
{
    LastName = "Dramé",
    FirstName = "Naïké",
    Birthday = new DateTime(1990, 9, 20)
};

// initialisation d'un objet Current comme compte courant
Current account = new Current()
{
    Number = "123456789",
    CreditLine = 500,
    Titular = titular
};

// opérations
Console.WriteLine($"Bonjour {titular.FirstName} {titular.LastName}, née le {titular.Birthday}.");
Console.WriteLine($"Le solde actuel du compte {account.Number:C} est de {account.Balance:C} et sa ligne de crédit est de {account.CreditLine:C}.");
account.Deposit(1000);   // dépôt de 1000
account.Withdraw(200);  // retrait de 200

account.Withdraw(2000); // tentative de retrait excédant la limite --> va nous afficher notre message d'erreur