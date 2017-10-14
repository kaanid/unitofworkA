using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitofworkA.Infrastructure.Domain;

namespace unitofworkA.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterUpdate(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        void RegisterAdd(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        void Commit();
    }
}
