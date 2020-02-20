using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
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
        public async Task<ActionResult<IEnumerable<Board>>> GetAll()
        {
            IEnumerable<Board> boards = await _unitOfWork.Board.GetAll();
            return Ok(boards);
        }

        // GET: api/boards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Board>> Get(int id)
        {
            Board board = await _unitOfWork.Board.GetById(id);

            if (board == null)
            {
                return NotFound();
            }

            return Ok(board);
        }

        // POST: api/boards
        [HttpPost]
        public ActionResult<Board> Post([FromBody] Board board)
        {
            _unitOfWork.Board.Create(board);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(Get), new { id = board.Id }, board);
        }

        // PUT: api/boards/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Board board)
        {
            if (id != board.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Board.Update(board);
            _unitOfWork.Save();

            return Ok();
        }

        // DELETE: api/boards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Board board = await _unitOfWork.Board.GetById(id);
            
            if (board == null)
            {
                return NotFound();
            }

            _unitOfWork.Board.Delete(board);
            _unitOfWork.Save();

            return Ok();
        }
    }
}      