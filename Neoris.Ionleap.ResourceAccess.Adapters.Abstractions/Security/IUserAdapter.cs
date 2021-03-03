using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Security;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security
{
    public interface IUserAdapter : IEntityManagerAdapter<User>
    {
        User Get(string username);
    }
}