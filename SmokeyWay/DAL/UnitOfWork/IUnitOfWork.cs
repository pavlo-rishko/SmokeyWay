using DAL.Repository;
using System;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
