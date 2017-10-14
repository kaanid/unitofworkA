using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitofworkA.Infrastructure.UnitOfWork;
using unitofworkA.Model;
using unitofworkA.Repository;
using static System.Console;

namespace unitofworkA.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a = new Account("a",100);
            WriteLine($"name:{a.Name},amount:{a.Balance}");

            Account b = new Account("b",100);
            WriteLine($"name:{a.Name},amount:{a.Balance}");

            decimal amount = 50M;
            WriteLine($"a to b amount:{amount}");

            IUnitOfWork nhUnitOfWork = new NHUnitOfWork();

            IAccountRepository accountRepository = new AccountRepository(nhUnitOfWork);

            AccountService service = new AccountService(accountRepository, nhUnitOfWork);
            service.Transfer(a, b, amount);

            WriteLine("Transfered");
            WriteLine($"name:{a.Name},amount:{a.Balance}");
            WriteLine($"name:{a.Name},amount:{a.Balance}");

            ReadKey();
        }
    }
}
