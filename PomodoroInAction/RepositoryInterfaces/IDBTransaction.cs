using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public interface IDBTransaction
    {
        IBoardRepository Boards { get; }
        IAppUserBoardRepo UserBoards { get; }
        IContainerRepository Containers { get; }
        ITicketRepository Tickets { get; }

        public void Save();
    }
}
