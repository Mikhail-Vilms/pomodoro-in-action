using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public class DBTransaction : IDBTransaction
    {
        private readonly PomodoroAppDbContext _dbContext;

        private BoardRepository _board;
        private AppUserBoardRepo _userBoards;
        private ContainerRepository _containers;
        private TicketRepository _tickets;
        
        public DBTransaction(PomodoroAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBoardRepository Boards
        {
            get
            {
                if (_board == null)
                {
                    _board = new BoardRepository(_dbContext);
                }

                return _board;
            }
        }

        public IAppUserBoardRepo UserBoards
        {
            get
            {
                if (_userBoards == null)
                {
                    _userBoards = new AppUserBoardRepo(_dbContext);
                }

                return _userBoards;
            }
        }

        public IContainerRepository Containers
        {
            get
            {
                if (_containers == null)
                {
                    _containers = new ContainerRepository(_dbContext);
                }

                return _containers;
            }
        }

        public ITicketRepository Tickets
        {
            get
            {
                if (_tickets == null)
                {
                    _tickets = new TicketRepository(_dbContext);
                }

                return _tickets;
            }
        }

        public void Save()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
