using Microsoft.EntityFrameworkCore;
using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;
using System.Threading.Tasks;

namespace PomodoroInAction.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(PomodoroAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Board> GetKanbanBoard(int id)
        {
            return await this._dbContext
                .Boards
                .Include(board => board.Containers)
                .ThenInclude(container => container.Tickets)
                .SingleAsync(board => board.Id == id);
        }
    }
}
