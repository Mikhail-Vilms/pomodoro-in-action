using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private PomodoroAppDbContext _dbContext;
        private BoardRepository _board;

        public UnitOfWork(PomodoroAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBoardRepository Board {
            get {
                if (_board == null)
                {
                    _board = new BoardRepository(_dbContext);
                }

                return _board;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
