using PomodoroInAction.Models;
using System.Threading.Tasks;

namespace PomodoroInAction.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int entityId);
        void Create(TEntity entityToCreate);
        void Update(TEntity entityToUpdate);
    }
}
