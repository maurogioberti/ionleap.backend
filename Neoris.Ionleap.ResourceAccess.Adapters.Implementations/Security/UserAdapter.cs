using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using System.Collections.Generic;
using System.Linq;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Security
{
    public class UserAdapter : EntityManagerAdapter<User, IonleapContext>, IUserAdapter
    {
        public override User Get(string username)
        {
            using (DbContext)
            {
                return (DbContext as IonleapContext)?.Users.Single(u => u.Active && u.Username == username);
            }
        }
    }
}