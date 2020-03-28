using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using PomodoroInAction.ServiceInterfaces;
using PomodoroInAction.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PomodoroInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketsController(ITicketService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult<Ticket> Post([FromBody] Ticket ticket)
        {
            if (_service.CreateNewTicket(ticket))
            {
                return CreatedAtAction(nameof(Get), new { id = ticket.Id }, ticket);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Ticket>> Get(int id)
        {
            Ticket ticket = await _service.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Ticket>>> GetAll()
        //{
        //    IEnumerable<Ticket> containers = await _unitOfWork.Tickets.GetAll();
        //    return Ok(containers);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Ticket ticket)
        //{
        //    if (id != ticket.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _unitOfWork.Tickets.Update(ticket);
        //    _unitOfWork.Save();

        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    Ticket ticket = await _unitOfWork.Tickets.GetById(id);

        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Tickets.Delete(ticket);
        //    _unitOfWork.Save();

        //    return Ok();
        //}
    }
}