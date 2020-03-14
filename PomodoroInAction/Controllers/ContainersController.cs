using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using PomodoroInAction.ServiceInterfaces;
using System.Collections.Generic;
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
            if (_service.CreateNewContainer(container))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            // return CreatedAtAction(nameof(Get), new { id = container.Id }, container);

        }




        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<KanbanContainer>>> GetAll()
        //{
        //    IEnumerable<KanbanContainer> containers = await _unitOfWork.Containers.GetAll();
        //    return Ok(containers);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<KanbanContainer>> Get(int id)
        //{
        //    KanbanContainer container = await _unitOfWork.Containers.GetById(id);

        //    if (container == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(container);
        //}



        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] KanbanContainer container)
        //{
        //    if (id != container.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _unitOfWork.Containers.Update(container);
        //    _unitOfWork.Save();

        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    KanbanContainer container = await _unitOfWork.Containers.GetById(id);

        //    if (container == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Containers.Delete(container);
        //    _unitOfWork.Save();

        //    return Ok();
        //}
    }
}