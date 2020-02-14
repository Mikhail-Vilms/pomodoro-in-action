using PomodoroInAction.RepositoryInterfaces;

namespace PomodoroInAction.Repositories
{
    public interface IUnitOfWork
    {
        IBoardRepository Board { get; }
        public void Save();
    }
}
