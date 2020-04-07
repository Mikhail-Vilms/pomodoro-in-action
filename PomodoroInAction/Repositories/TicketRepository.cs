using Microsoft.EntityFrameworkCore;
using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;
using System.Threading.Tasks;

namespace PomodoroInAction.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(PomodoroAppDbContext dbContext) : base(dbContext) {}
        public override async Task<Ticket> GetById(int id)
        {

            return await _dbSet
                .Include(ticket => ticket.KanbanContainer)
                .SingleAsync(ticket => ticket.Id == id);
        }
    }
}


