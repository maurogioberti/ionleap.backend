using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Neoris.Ionleap.Services.Abstractions.Infrastructure;

namespace Neoris.Ionleap.Services.Abstractions.Security
{
    public interface IRoleService : IEntityManagerService<Role, IRoleLogic>
    {
    }
}
