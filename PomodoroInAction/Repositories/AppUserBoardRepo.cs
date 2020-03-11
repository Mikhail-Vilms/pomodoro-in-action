using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PomodoroInAction.Models;
using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public class AppUserBoardRepo : IAppUserBoardRepo
    {
        private readonly PomodoroAppDbContext _context;
        private readonly DbSet<AppUserBoard> _dbSet;

        public AppUserBoardRepo(PomodoroAppDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<AppUserBoard>();
        }

        public async Task<IEnumerable<AppUserBoard>> GetPersonalBoards(string userId)
        {
            Debug.WriteLine(" *** 2) userId: " + userId);

            return await _dbSet
                .Where(record => record.AppUserId.Equals(userId))
                .Include(record => record.Board)
                .ToListAsync();
        }

        public void GiveOwnership(string userId, int boardId)
        {
            AppUserBoard _userBoard = new AppUserBoard()
            {
                BoardId = boardId,
                AppUserId = userId,
                IsOwner = true
            };

            _context.Add(_userBoard);

            _context.SaveChanges();
        }
    }
}
