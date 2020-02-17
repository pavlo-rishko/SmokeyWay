﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
         DbSet<TEntity> _dbSet { get; }

        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            var entity = await GetAll().Where(predicate).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
