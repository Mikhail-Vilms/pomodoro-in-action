using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using System.Collections.Generic;

namespace PomodoroInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContainersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/boards
        //[HttpGet]
        //public IEnumerable<KanbanContainer> GetBoards()
        //{
        //    return _unitOfWork.Containers.GetAll();
        //}
    }
}