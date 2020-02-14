using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;

namespace PomodoroInActionTests.Repositories
{
    [TestClass()]
    public class BaseRepositoryTests
    {
        private PomodoroAppDbContext _context;
        
        public BaseRepositoryTests(PomodoroAppDbContext context)
        {
            _context = context;
        } 
        
        // [TestInitialize]
        public void TestInit()
        {
        }

        // [TestMethod()]
        public void Insert_Insert5Records_Test()
        {
            IBaseRepository<Board> repo = new BaseRepository<Board>(_context);
            
            Board board = new Board
            {
                Id = 1,
                DisplayName = "Display Name 1",
                Description = "Description 1",
                SortOrder = 1
            };

            repo.Insert(board);

            board = new Board
            {
                Id = 2,
                DisplayName = "Display Name 2",
                Description = "Description 2",
                SortOrder = 2
            };

            repo.Insert(board);
        }
    }
}
