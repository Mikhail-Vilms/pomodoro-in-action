using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using PomodoroInAction.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.Services
{
    public class ContainerService : IContainerService
    {
        private readonly IDBTransaction _transaction;

        public ContainerService(IDBTransaction transaction)
        {
            _transaction = transaction;
        }

        public bool CreateNewContainer(KanbanContainer container)
        {
            try
            {
                _transaction.Containers.Create(container);
                _transaction.Save();

                return true;
            }
            catch(Exception ex)
            {
                // #TODO log ex
                return false;
            }
        }

        public Task<IEnumerable<Board>> FetchContainersForBoard(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
