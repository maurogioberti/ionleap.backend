using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using System.Collections.Generic;

namespace Neoris.Ionleap.Business.Logic.Abstractions.Security
{
    public interface IUserLogic : IEntityManagerLogic<User>
    {
        public User UserLogged { get; }
        new User Get(string username);
        bool Allowed(string controller, string action);
        bool Allowed(string controller, string action, string user);
        bool Authenticate(string username, string password, out string token);
    }

}
