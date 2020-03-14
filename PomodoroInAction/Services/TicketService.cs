using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using PomodoroInAction.ServiceInterfaces;

namespace PomodoroInAction.Services
{
    public class TicketService : ITicketService
    {
        private readonly IDBTransaction _transaction;

        public TicketService(IDBTransaction transaction)
        {
            _transaction = transaction;
        }

        public bool CreateNewTicket(Ticket ticket)
        {
            try
            {
                _transaction.Tickets.Create(ticket);
                _transaction.Save();

                return true;
            }
            catch (Exception ex)
            {
                // #TODO log ex
                return false;
            }
        }

        public Task<IEnumerable<Ticket>> FetchTicketsForContainer(string containerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
