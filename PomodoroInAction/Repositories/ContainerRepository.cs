using System.Threading.Tasks;
using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public class ContainerRepository : BaseRepository<KanbanContainer>, IContainerRepository
    {
        public ContainerRepository(PomodoroAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> Exists(int containerId, int boardId)
        {
            KanbanContainer container = await _dbSet.FindAsync(containerId);

            return container != null && container.BoardId.Equals(boardId);
        }
    }
}
