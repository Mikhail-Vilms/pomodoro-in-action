using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private PomodoroAppDbContext _dbContext;
        private BoardRepository _board;
        private ContainerRepository _containers;
        private TicketRepository _tickets;

        public UnitOfWork(PomodoroAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBoardRepository Board
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
