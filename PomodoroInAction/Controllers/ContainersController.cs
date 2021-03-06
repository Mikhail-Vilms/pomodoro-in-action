﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using PomodoroInAction.ServiceInterfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PomodoroInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly IContainerService _service;

        public ContainersController(IContainerService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<KanbanContainer> Post([FromBody] KanbanContainer container)
        {
            if (_service.Create(container))
            {
                return CreatedAtAction(nameof(GetContainer), new { id = container.Id }, container);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Board>> GetContainer(int id)
        {
            //string userId = User.Claims.First(c => c.Type == "UserID").Value;
            KanbanContainer container = await _service.Get(id);
            return Ok(container);
        }

        [HttpPut("{id}"), ModelStateValidationActionFilter]
        public async Task<IActionResult> Put(int id, [FromBody] KanbanContainer container)
        {
            if (id != container.Id)
            {
                return BadRequest();
            }

            KanbanContainer oldContainer = await _service.Get(id);

            if (oldContainer == null)
            {
                return NotFound();
            }

            oldContainer.DisplayName = oldContainer.DisplayName;
            oldContainer.Description = oldContainer.Description;
            oldContainer.SortOrder = oldContainer.SortOrder;
            oldContainer.BoardId = oldContainer.BoardId;

            await _service.Update(oldContainer);

            return NoContent();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            KanbanContainer container = await _service.Get(id);

            if (container == null)
            {
                return NotFound();
            }

            await _service.Delete(container);

            return Ok();
        }

        [Authorize]
        [HttpPost("{containerId}")]
        [Route("{containerId}/set_sort_order")]
        public async Task<ActionResult> SetSortOrderForTickets(
            int containerId,
            [FromBody] IEnumerable<int> sortedTicketIds)
        {
            //string userId = User.Claims.First(c => c.Type == "UserID").Value;

            if (!await _service.SetSortOrderForTickets(containerId, sortedTicketIds))
            {
                return BadRequest("Error while setting sort order for tickets");
            }

            return Ok();
        }
    }
}