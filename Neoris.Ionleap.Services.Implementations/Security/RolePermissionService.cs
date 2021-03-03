using Neoris.Ionleap.Business.Logic.Implementations.Security;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Neoris.Ionleap.Services.Abstractions.Security;
using Neoris.Ionleap.Services.Implementations.Infrastructure;

namespace Neoris.Ionleap.Services.Implementations.Security
{
    public class RolePermissionService : EntityManagerService<RolePermission, RolePermissionLogic, IonleapContext>, IRolePermissionService
    {
    }
}
