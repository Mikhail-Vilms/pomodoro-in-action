using PomodoroInAction.Models;
using System.Threading.Tasks;

namespace PomodoroInAction.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task Create(TEntity entityToCreate);
        Task<TEntity> GetById(int entityId);
        Task Update(TEntity entityToUpdate);
        Task Delete(TEntity entityToDelete);
    }
}
