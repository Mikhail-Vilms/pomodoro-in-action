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

        public async Task<Ticket> GetById(int id)
        {
            return await _transaction.Tickets.GetById(id);
        }
        public async Task Create(Ticket ticket)
        {
            await _transaction.Tickets.Create(ticket);
        }
        public async Task Update(Ticket ticket)
        {
            await _transaction.Tickets.Update(ticket);
        }

        public async Task Delete(Ticket ticket)
        {
            await _transaction.Tickets.Delete(ticket);
        }
    }
}
