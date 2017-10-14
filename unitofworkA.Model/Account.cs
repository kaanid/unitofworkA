using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitofworkA.Infrastructure.Domain;

namespace unitofworkA.Model
{
    public class Account:IAggregateRoot
    {
        public Account(string name,decimal balance)
        {
            Balance = balance;
            Name = name;
        }

        public string Name { set; get; }
        public decimal Balance { get; set; }
    }
}
