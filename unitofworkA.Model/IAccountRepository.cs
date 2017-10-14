using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitofworkA.Model
{
    public interface IAccountRepository
    {
        void Update(Account account);
        void Add(Account account);
        void Remove(Account acccount);
    }
}
