using Neoris.Ionleap.RESTful.Infrastructure.ActionFilters;
using Neoris.Ionleap.Services.Abstractions.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Neoris.Ionleap.RESTful.Infrastructure.Policies
{
    public class AllowPolicy : AuthorizationHandler<AllowRequirement>
    {
        private readonly IUserService _userService;

        public AllowPolicy(IUserService userService)
        {
            _userService = userService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AllowRequirement requirement)
        {
            IPrincipal user = context.User;

            if (!user.Identity.IsAuthenticated)
            {
                return Task.CompletedTask;
            }

            string username = user.Identity.Name;

            string action = "";
            string controller = "";

            //Create permission string based on the requested controller name and action name in the format 'controllername-action'
            var mvcContext = context.Resource as AuthorizationFilterContext;
            if (mvcContext?.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                action = descriptor.ActionName;
                controller = descriptor.ControllerName;
            }

            if (_userService.Allowed(controller, action, username))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
