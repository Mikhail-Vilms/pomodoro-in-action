using PomodoroInAction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int entityId);
        void Create(TEntity entityToCreate);
        void Update(TEntity entityToUpdate);
        void Delete(TEntity entityToDelete);
    }
}
