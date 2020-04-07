using PomodoroInAction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.ServiceInterfaces
{
    public interface IContainerService
    {
        public bool Create(KanbanContainer container);

        public Task<KanbanContainer> Get(int id);

        public Task Update(KanbanContainer container);

        public Task Delete(KanbanContainer container);

        public Task<IEnumerable<Board>> FetchContainersForBoard(string userId);

        public Task<bool> SetSortOrderForTickets(int containerId, IEnumerable<int> sortedTicketIds);
    }
}
