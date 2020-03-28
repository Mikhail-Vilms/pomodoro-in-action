using Microsoft.EntityFrameworkCore;
using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;
using System.Diagnostics;
using System.Linq;
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
            /*
            return await this._dbContext
                .Boards
                .Include(board => board.Containers)
                .ThenInclude(container => container.Tickets)
                .SingleAsync(board => board.Id == id);
            */

            Board board = await this._dbContext
                .Boards
                .Include(board => board.Containers)
                .ThenInclude(container => container.Tickets)
                .SingleAsync(board => board.Id == id);

            

            
            Debug.WriteLine("*** *** *** board: " + board + " _ " + board.DisplayName);

            Debug.WriteLine("*** board.Containers: " + board.Containers);

            board.Containers = 
                board.Containers
                .Select(container =>
                {
                    container.Tickets = container.Tickets.OrderBy(ticket => ticket.SortOrder).ToList();
                    return container;
                })
                .OrderBy(container => container.SortOrder)
                .ToList();

            Debug.WriteLine("*** board.Containers: " + board.Containers);
            return board;
        }
    }
}
