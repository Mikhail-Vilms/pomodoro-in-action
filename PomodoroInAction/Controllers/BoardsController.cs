using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using System.Collections.Generic;

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
            return _unitOfWork.Board.GetAll();
        }

        // GET: api/boards/5
        [HttpGet("{id}")]
        public ActionResult<Board> GetBoard(int id)
        {
            Board board = _unitOfWork.Board.GetById(id);

            if (board == null)
            {
                return NotFound();
            }

            return board;
        }

        // POST: api/boards
        [HttpPost]
        public ActionResult<Board> PostBoard(Board board)
        {
            _unitOfWork.Board.Insert(board);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetBoard), new { id = board.Id }, board);
        }

        // PUT: api/boards/5
        [HttpPut("{id}")]
        public IActionResult PutBoard(int id, Board board)
        {
            if (id != board.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Board.Update(board);
            _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/boards/5
        [HttpDelete("{id}")]
        public ActionResult<Board> DeleteBoard(int id)
        {
            Board board = _unitOfWork.Board.GetById(id);
            
            if (board == null)
            {
                return NotFound();
            }

            _unitOfWork.Board.Delete(board);
            _unitOfWork.Save();

            return board;
        }
    }
}      