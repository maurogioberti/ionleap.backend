using System.Linq;
using System.Net.Http;
using Neoris.Ionleap.ResourceAccess.Responses.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Neoris.Ionleap.RESTful.Infrastructure.Attributes
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var response = new BaseResponse<object>(false, context.ModelState.First().Value.ToString());

                context.Result = new BadRequestObjectResult(response);
            }

            base.OnActionExecuting(context);
        }
    }
}