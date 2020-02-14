using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BoardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/boards
        [HttpGet]
        public IEnumerable<Board> GetBoards()
        {
            Console.WriteLine(" == api/boards");

            Board board = new Board
            {
                Id = 1,
                DisplayName = "Display Name 1",
                Description = "Description 1",
                SortOrder = 1
            };

            _unitOfWork.Board.Insert(board);

            board = new Board
            {
                Id = 2,
                DisplayName = "Display Name 2",
                Description = "Description 2",
                SortOrder = 2
            };

            _unitOfWork.Board.Insert(board);


            return _unitOfWork.Board.GetAll();
        }
    }
}