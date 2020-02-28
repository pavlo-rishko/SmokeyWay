using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        private  DbContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IRepositoryBase<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new RepositoryBase<TEntity>(Context.Set<TEntity>());
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
