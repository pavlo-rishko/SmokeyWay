using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
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

        public async Task<int> SaveChangesAsync()
        {
            var entries = Context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                                e.State == EntityState.Added
                                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDateTime = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).UpdateDateTime = DateTime.Now;
                }
            }

            return await Context.SaveChangesAsync();
        }
    }
}
