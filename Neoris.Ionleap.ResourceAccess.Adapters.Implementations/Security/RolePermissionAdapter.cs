using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Security
{
    public class RolePermissionAdapter : EntityManagerAdapter<RolePermission, IonleapContext>, IRolePermissionAdapter
    {
    }
}
