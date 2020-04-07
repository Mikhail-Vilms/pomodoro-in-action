using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using PomodoroInAction.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.Services
{
    public class ContainerService : IContainerService
    {
        private readonly IDBTransaction _transaction;

        public ContainerService(IDBTransaction transaction)
        {
            _transaction = transaction;
        }

        public bool Create(KanbanContainer container)
        {
            try
            {
                _transaction.Containers.Create(container);
                _transaction.Save();

                return true;
            }
            catch(Exception ex)
            {
                // #TODO log ex
                return false;
            }
        }

        public async Task<KanbanContainer> Get(int id)
        {
            return await _transaction.Containers.GetById(id);
        }

        public Task<IEnumerable<Board>> FetchContainersForBoard(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(KanbanContainer container)
        {
            await _transaction.Containers.Update(container);
        }

        public async Task Delete(KanbanContainer container)
        {
            await _transaction.Containers.Delete(container);
        }

        public async Task<bool> SetSortOrderForTickets(int containerId, IEnumerable<int> sortedTicketIds)
        {
            int _sortPosition = 0;
                
            foreach (int ticketId in sortedTicketIds)
            {
                Ticket ticket = await _transaction.Tickets.GetById(ticketId);
                ticket.KanbanContainerId = containerId;
                ticket.SortOrder = _sortPosition++;
                await _transaction.Tickets.Update(ticket);
            }
            
            return true;
        }
    }
}
