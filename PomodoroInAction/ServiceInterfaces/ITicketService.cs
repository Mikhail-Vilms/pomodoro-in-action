using PomodoroInAction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.ServiceInterfaces
{
    public interface ITicketService
    {
        public bool CreateNewTicket(Ticket ticket);

        public Task<Ticket> GetById(int id);
    }
}
