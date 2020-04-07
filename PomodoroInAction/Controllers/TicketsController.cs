using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using PomodoroInAction.ServiceInterfaces;
using PomodoroInAction.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PomodoroInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;
        private readonly ILogger _logger;

        public TicketsController(ITicketService service, ILoggerFactory loggerFactory)
        {
            _service = service;
            _logger = loggerFactory.CreateLogger("PomodoroInAction.Controllers.TicketsController");
        }

        [AllowAnonymous]
        [ModelStateValidationActionFilter]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Ticket>> Post([FromBody]Ticket ticket)
        {
            //ICollection<ValidationResult> results = new List<ValidationResult>(); // Will contain the results of the validation
            
            //bool isValid = Validator.TryValidateObject(ticket, new ValidationContext(ticket), results, true); // Validates the object and its properties using the previously created context.

            bool isValid = ModelState.IsValid;

            await _service.Create(ticket);
            
            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, ticket);
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Ticket>> Get(int id)
        {
            Ticket ticket = await _service.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPut("{id}"), ModelStateValidationActionFilter]
        public async Task<IActionResult> Put(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            Ticket oldTicket = await _service.GetById(id);

            if (oldTicket == null)
            {
                return NotFound();
            }

            oldTicket.DisplayName = ticket.DisplayName;
            oldTicket.Description = ticket.Description;
            oldTicket.SortOrder = ticket.SortOrder;
            oldTicket.KanbanContainerId = ticket.KanbanContainerId;

            await _service.Update(oldTicket);

            return NoContent();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            Ticket ticket = await _service.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            await _service.Delete(ticket);

            return Ok();
        }
    }
}