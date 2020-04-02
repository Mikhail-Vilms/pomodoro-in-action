using PomodoroInAction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.ServiceInterfaces
{
    public interface ITicketService
    {
        public Task<Ticket> GetById(int id);

        public Task Create(Ticket ticket);

        public Task Update(Ticket ticket);

        public Task Delete(Ticket ticket);
    }
}
