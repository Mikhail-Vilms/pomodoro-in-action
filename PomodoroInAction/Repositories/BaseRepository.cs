﻿using Microsoft.EntityFrameworkCore;
using PomodoroInAction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {
        internal PomodoroAppDbContext _dbContext;
        internal DbSet<TEntity> _dbSet;

        public BaseRepository(PomodoroAppDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async virtual Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }
    }
}
