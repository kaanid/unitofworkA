using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitofworkA.Infrastructure.Domain;

namespace unitofworkA.Infrastructure.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        void PersistCreationOf(IAggregateRoot entity);

        void PersistUpdateOf(IAggregateRoot entity);

        void PersistDeletionOf(IAggregateRoot entity);
    }
}
