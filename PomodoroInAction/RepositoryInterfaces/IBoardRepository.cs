using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using System.Threading.Tasks;

namespace PomodoroInAction.RepositoryInterfaces
{
    public interface IBoardRepository : IBaseRepository<Board>
    {
        public Task<Board> GetKanbanBoard(int id);
    }
}
