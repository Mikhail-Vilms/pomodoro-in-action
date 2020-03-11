using PomodoroInAction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.RepositoryInterfaces
{
    public interface IAppUserBoardRepo
    {
        Task<IEnumerable<AppUserBoard>> GetPersonalBoards(string userId);
        void GiveOwnership(string userId, int boardId);
    }
}
