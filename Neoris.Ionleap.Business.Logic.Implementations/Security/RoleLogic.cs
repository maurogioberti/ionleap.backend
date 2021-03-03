using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.Business.Logic.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Security;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using System.Collections.Generic;

namespace Neoris.Ionleap.Business.Logic.Implementations.Security
{
    public class RoleLogic : EntityManagerLogic<Role, IonleapContext>, IRoleLogic
    {
        private IRoleAdapter _roleAdapter;
        protected IRoleAdapter RoleAdapter
        {
            get => _roleAdapter ??= new RoleAdapter();
        }
        public List<Role> Get(User user)
        {
            return this.RoleAdapter.Get(user);
        }
    }
}
