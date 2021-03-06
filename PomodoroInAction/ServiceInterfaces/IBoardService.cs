﻿using PomodoroInAction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.ServiceInterfaces
{
    public interface IBoardService
    {
        public void CreateNewBoard(Board board, string userId);

        public Task<IEnumerable<Board>> GetPersonalBoards(string userId);

        public Task<Board> GetKanbanBoard(int id);

        public Task<bool> SetSortOrderForContainers(int boardId, IEnumerable<int> orderedIds);
    }
}
