using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAll()
        {
            IEnumerable<Ticket> containers = await _unitOfWork.Tickets.GetAll();
            return Ok(containers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> Get(int id)
        {
            Ticket ticket = await _unitOfWork.Tickets.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPost]
        public ActionResult<Ticket> Post([FromBody] Ticket ticket)
        {
            _unitOfWork.Tickets.Create(ticket);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Tickets.Update(ticket);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Ticket ticket = await _unitOfWork.Tickets.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _unitOfWork.Tickets.Delete(ticket);
            _unitOfWork.Save();

            return Ok();
        }
    }
}