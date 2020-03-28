using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using System.Threading.Tasks;

namespace PomodoroInAction.RepositoryInterfaces
{
    public interface IContainerRepository : IBaseRepository<KanbanContainer>
    {
        public Task<bool> Exists(int containerId, int boardId);
    }
}
