using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using System.Collections.Generic;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security
{
    public interface IPermissionAdapter : IEntityManagerAdapter<Permission>
    {
        List<Permission> Get(Role role);
    }
}