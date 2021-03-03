using System.Collections.Generic;
using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Security;

namespace Neoris.Ionleap.Business.Logic.Abstractions.Security
{
    public interface IPermissionLogic : IEntityManagerLogic<Permission>
    {
        List<Permission> Get(User user);
    }
}
