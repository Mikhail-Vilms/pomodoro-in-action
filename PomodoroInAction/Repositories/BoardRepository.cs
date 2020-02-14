using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(PomodoroAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
