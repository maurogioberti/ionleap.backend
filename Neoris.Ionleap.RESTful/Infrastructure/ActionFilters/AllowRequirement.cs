using Microsoft.AspNetCore.Authorization;

namespace Neoris.Ionleap.RESTful.Infrastructure.ActionFilters
{
    public class AllowRequirement : IAuthorizationRequirement
    {
        public AllowRequirement()
        {

        }
    }
}
