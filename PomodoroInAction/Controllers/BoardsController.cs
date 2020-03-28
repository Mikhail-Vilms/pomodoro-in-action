using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.ServiceInterfaces;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PomodoroInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardService _service;

        public BoardsController(IBoardService boardService)
        {
            _service = boardService;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Board> Post([FromBody] Board newBoard)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            _service.CreateNewBoard(newBoard, userId);

            return CreatedAtAction(nameof(GetKanbanBoard), new { id = newBoard.Id }, newBoard);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Board>>> GetPersonalBoards()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            return Ok(await _service.GetPersonalBoards(userId));
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Board>> GetKanbanBoard(int id)
        {
            //string userId = User.Claims.First(c => c.Type == "UserID").Value;
            Board board = await _service.GetKanbanBoard(id);
            return Ok(board);
        }
        
        [Authorize]
        [HttpPost("{id}")]
        [Route("{id}/set_sort_order")]
        public async Task<ActionResult<Board>> SetSortOrderForContainers(
            int id, 
            [FromBody] IEnumerable<int> orderedIds)
        {
            //string userId = User.Claims.First(c => c.Type == "UserID").Value;

            Debug.WriteLine(" *** *** *** orderedIds: " + orderedIds);

            if ( !await _service.SetSortOrderForContainers(id, orderedIds))
            {
                return BadRequest("Error while setting sort order for containers");
            }
            
            return Ok();
        }

        /*
        // PUT: api/boards/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Board board)
        {
            if (id != board.Id)
            {
                return BadRequest();
            }

            _transaction.Board.Update(board);
            _transaction.Save();

            return Ok();
        }

        // DELETE: api/boards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Board board = await _transaction.Board.GetById(id);

            if (board == null)
            {
                return NotFound();
            }

            _transaction.Board.Delete(board);
            _transaction.Save();

            return Ok();
        }
        */
    }
}      