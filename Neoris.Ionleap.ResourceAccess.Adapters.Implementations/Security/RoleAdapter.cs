using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using System.Collections.Generic;
using System.Linq;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Security
{
    public class RoleAdapter : EntityManagerAdapter<Role, IonleapContext>, IRoleAdapter
    {
        public List<Role> Get(User user)
        {
            using (DbContext)
            {
                return (DbContext as IonleapContext)?.UsersRoles.Where(r => r.UserIdentity == user.Identity).Select(r => r.Role).ToList();
            }
        }
    }
}