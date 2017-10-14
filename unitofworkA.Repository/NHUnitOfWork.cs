using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using unitofworkA.Infrastructure.Domain;
using unitofworkA.Infrastructure.UnitOfWork;

namespace unitofworkA.Repository
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> addedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> changedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> deletedEntities;

        public NHUnitOfWork()
        {
            addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            changedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            deletedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        public void RegisterAdd(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!addedEntities.ContainsKey(entity))
            {
                addedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!deletedEntities.ContainsKey(entity))
            {
                changedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void RegisterUpdate(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!changedEntities.ContainsKey(entity))
            {
                changedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void Commit()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (IAggregateRoot entity in this.addedEntities.Keys)
                    {
                        addedEntities[entity].PersistCreationOf(entity);
                    }

                    foreach (IAggregateRoot entity in this.changedEntities.Keys)
                    {
                        changedEntities[entity].PersistUpdateOf(entity);
                        throw new Exception("1231231");
                    }

                    foreach (IAggregateRoot entity in this.deletedEntities.Keys)
                    {
                        deletedEntities[entity].PersistDeletionOf(entity);
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Commit:{0}",ex.Message);
            }
        }

    }
}
