using PomodoroInAction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.ServiceInterfaces
{
    public interface IContainerService
    {
        public bool CreateNewContainer(KanbanContainer board);

        public Task<IEnumerable<Board>> FetchContainersForBoard(string userId);
    }
}
