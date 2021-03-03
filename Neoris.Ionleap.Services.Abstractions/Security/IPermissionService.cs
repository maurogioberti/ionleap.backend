using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Neoris.Ionleap.Services.Abstractions.Infrastructure;
using System.Collections.Generic;

namespace Neoris.Ionleap.Services.Abstractions.Security
{
    public interface IPermissionService : IEntityManagerService<Permission, IPermissionLogic>
    {
        List<Permission> Get(User user);
    }
}