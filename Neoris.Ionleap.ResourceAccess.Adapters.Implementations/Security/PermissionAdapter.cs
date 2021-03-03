using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using System.Collections.Generic;
using System.Linq;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Security
{
    public class PermissionAdapter : EntityManagerAdapter<Permission, IonleapContext>, IPermissionAdapter
    {
        public List<Permission> Get(Role role)
        {
            using (DbContext)
            {
                return (DbContext as IonleapContext)?.RolesPermissions.Where(r => r.Role.Identity == role.Identity).Select(p => p.Permission).ToList();
            }
        }
    }
}