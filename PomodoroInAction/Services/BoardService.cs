using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using PomodoroInAction.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomodoroInAction.Services
{
    public class BoardService : IBoardService
    {
        private readonly IDBTransaction _transaction;

        public BoardService(IDBTransaction transaction)
        {
            _transaction = transaction;
        }

        public void CreateNewBoard(Board board, string userId)
        {
            _transaction.Boards.Create(board);
            _transaction.UserBoards.GiveOwnership(userId, board.Id);
            _transaction.Save();
        }

        public async Task<IEnumerable<Board>> GetPersonalBoards(string userId)
        {
            IEnumerable<AppUserBoard> _userBoards = await _transaction.UserBoards.GetPersonalBoards(userId);

            IEnumerable<Board> boards = _userBoards.Select(userBoard => userBoard.Board);

            return boards;
        }

        public async Task<Board> GetKanbanBoard(int id)
        {
            return await _transaction.Boards.GetKanbanBoard(id);
        }

        public async Task<bool> SetSortOrderForContainers(int boardId, IEnumerable<int> orderedIds)
        {
            if ( !await ContainersBelongToBoard(boardId, orderedIds) )
            {
                return false;
            }

            int _sortPosition = 0;

            foreach (int containerId in orderedIds)
            {
                KanbanContainer container = await _transaction.Containers.GetById(containerId);
                container.SortOrder = _sortPosition++;
                _transaction.Containers.Update(container);
            }

            return true;
        }

        public async Task<bool> ContainersBelongToBoard(int boardId, IEnumerable<int> containerIds)
        {
            foreach (int containerId in containerIds)
            {
                if (!await _transaction.Containers.Exists(containerId, boardId))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
