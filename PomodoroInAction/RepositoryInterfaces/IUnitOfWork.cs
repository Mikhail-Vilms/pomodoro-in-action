using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public interface IUnitOfWork
    {
        IBoardRepository Board { get; }
        IContainerRepository Containers { get; }
        ITicketRepository Tickets { get; }
        public void Save();
    }
}
