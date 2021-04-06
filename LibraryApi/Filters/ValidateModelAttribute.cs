using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public bool SerilazeModelState { get; set; } = true;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                if (SerilazeModelState)
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                else
                {
                    context.Result = new BadRequestResult();
                }
            }
        }
    }
}
