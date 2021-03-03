using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.Business.Logic.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;

namespace Neoris.Ionleap.Business.Logic.Implementations.Security
{
    public class UserRoleLogic : EntityManagerLogic<UserRole, IonleapContext>, IUserRoleLogic
    {
    }
}
