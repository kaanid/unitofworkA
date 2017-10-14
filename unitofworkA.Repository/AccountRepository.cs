using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitofworkA.Infrastructure.Domain;
using unitofworkA.Infrastructure.UnitOfWork;
using unitofworkA.Model;

namespace unitofworkA.Repository
{
    public class AccountRepository : IAccountRepository, IUnitOfWorkRepository
    {
        private IUnitOfWork _unitOfWork;
        public AccountRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Account account)
        {
            _unitOfWork.RegisterAdd(account, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            var model = entity as Account;
            //实现
            Console.WriteLine($"AccountRepository Create {model.Name} {model.Balance}");
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            var model = entity as Account;
            //实现
            Console.WriteLine($"AccountRepository Delete {model.Name} {model.Balance}");
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            var model = entity as Account;
            //实现
            Console.WriteLine($"AccountRepository Update {model.Name} {model.Balance}");
        }

        public void Remove(Account acccount)
        {
            _unitOfWork.RegisterRemoved(acccount, this);
        }

        public void Update(Account account)
        {
            _unitOfWork.RegisterUpdate(account,this);
        }
    }
}
