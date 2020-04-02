using Microsoft.EntityFrameworkCore;
using PomodoroInAction.Models;
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

        public async virtual Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async virtual Task Create(TEntity entityToCreate)
        {
            _dbSet.Add(entityToCreate);
            await _dbContext.SaveChangesAsync();
        }

        public async virtual Task Update(TEntity entityToUpdate)
        {
            _dbSet.Update(entityToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async virtual Task Delete(TEntity entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
