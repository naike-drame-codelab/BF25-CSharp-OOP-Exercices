using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice02_GestionBanque.Models;

namespace Exercice02_GestionBanque.Interfaces
{
    interface IBanker : ICustomer
    {
        Personne Titulaire { get; }
        string Numero { get; }

        void AppliquerInterets();

    }
}

