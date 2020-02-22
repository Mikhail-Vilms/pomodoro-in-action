using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KanbanContainer>>> GetAll()
        {
            IEnumerable<KanbanContainer> containers = await _unitOfWork.Containers.GetAll();
            return Ok(containers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KanbanContainer>> Get(int id)
        {
            KanbanContainer container = await _unitOfWork.Containers.GetById(id);

            if (container == null)
            {
                return NotFound();
            }

            return Ok(container);
        }

        [HttpPost]
        public ActionResult<KanbanContainer> Post([FromBody] KanbanContainer container)
        {
            _unitOfWork.Containers.Create(container);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(Get), new { id = container.Id }, container);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] KanbanContainer container)
        {
            if (id != container.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Containers.Update(container);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            KanbanContainer container = await _unitOfWork.Containers.GetById(id);

            if (container == null)
            {
                return NotFound();
            }

            _unitOfWork.Containers.Delete(container);
            _unitOfWork.Save();

            return Ok();
        }
    }
}