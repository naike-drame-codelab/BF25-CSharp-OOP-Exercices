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

// initialisation d'un objet Bank comme banque
Bank bank = new Bank()
{
    Name = "Belfius"
};

// opérations
Console.WriteLine($"Bonjour {titular.FirstName} {titular.LastName}, née le {titular.Birthday}.");

bank.AddNewAccount(account);

bank["123456789"].Deposit(1000);
bank["123456789"].Withdraw(200);

Console.WriteLine($"Le solde actuel du compte {account.Titular.FirstName} est de {account.Balance:C} et sa ligne de crédit est de {account.CreditLine:C}.");

for (int i = 0; i < bank.Accounts.Length; i++)
{
    Console.WriteLine($"Compte bancaire {i + 1} : {bank.Accounts[i].Value.Titular.FirstName}");
}

bank["123456789"].Withdraw(2000); // tentative de retrait excédant la limite --> va nous afficher notre message d'erreur