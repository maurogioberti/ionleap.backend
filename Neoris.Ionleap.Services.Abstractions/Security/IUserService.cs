using System.Collections.Generic;
using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Neoris.Ionleap.Services.Abstractions.Infrastructure;

namespace Neoris.Ionleap.Services.Abstractions.Security
{
    public interface IUserService : IEntityManagerService<User, IUserLogic>
    {
        public User UserLogged { get; }
        bool Allowed(string controller, string action);
        bool Allowed(string controller, string action, string user);
        bool Authenticate(string username, string password, out string token);
    }
}
