using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(PomodoroAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
