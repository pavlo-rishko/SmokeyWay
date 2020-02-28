using DAL.Repository;
using System;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task SaveChangesAsync();
    }
}
