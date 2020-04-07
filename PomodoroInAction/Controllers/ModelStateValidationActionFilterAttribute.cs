using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PomodoroInAction.Models;
using System.Diagnostics;
using System.Linq;

namespace PomodoroInAction.Controllers
{
    public class ModelStateValidationActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is BaseEntity);

            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Model is null");
                return;
            }
            
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult( 
                    new { errors = context.ModelState } );
            }
        }
    }
}
