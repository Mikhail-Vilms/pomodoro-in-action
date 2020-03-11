using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(PomodoroAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
