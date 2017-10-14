using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitofworkA.Infrastructure.UnitOfWork;

namespace unitofworkA.Model
{
    public class AccountService
    {
        private IAccountRepository _accountRepository;
        private IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository rep,IUnitOfWork unit)
        {
            _accountRepository = rep;
            _unitOfWork = unit;
        }

        public void Transfer(Account from,Account to,decimal amount)
        {
            if (from.Balance >= amount)
            {
                from.Balance -= amount;
                to.Balance += amount;

                _accountRepository.Update(from);
                _accountRepository.Update(to);

                _unitOfWork.Commit();
            }
        }
    }
}
