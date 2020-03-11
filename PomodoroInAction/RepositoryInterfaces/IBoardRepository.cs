using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.RepositoryInterfaces
{
    public interface IBoardRepository : IBaseRepository<Board>
    {
    }
}
