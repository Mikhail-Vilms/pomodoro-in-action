using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public class ContainerRepository : BaseRepository<KanbanContainer>, IContainerRepository
    {
        public ContainerRepository(PomodoroAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
