using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using System.Collections.Generic;

namespace Neoris.Ionleap.Business.Logic.Abstractions.Security
{
    public interface IRoleLogic: IEntityManagerLogic<Role>
    {
        List<Role> Get(User user);
    }
}
