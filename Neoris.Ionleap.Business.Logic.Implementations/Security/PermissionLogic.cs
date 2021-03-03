using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.Business.Logic.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Security;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using System.Collections.Generic;

namespace Neoris.Ionleap.Business.Logic.Implementations.Security
{
    public class PermissionLogic : EntityManagerLogic<Permission, IonleapContext>, IPermissionLogic
    {
        private IPermissionAdapter _permissionAdapter;
        protected IPermissionAdapter PermissionAdapter
        {
            get => _permissionAdapter ??= new PermissionAdapter();
            set => _permissionAdapter = value;
        }

        private IRoleLogic _roleLogic;
        protected IRoleLogic RoleLogic
        {
            get => _roleLogic ??= new RoleLogic();
            set => _roleLogic = value;
        }
        public List<Permission> Get(User user)
        {
            var userRoles = this.RoleLogic.Get(user);

            List<Permission> userPermissions = new List<Permission>();

            foreach (var userRole in userRoles)
            {
                var rolePermissions = this.PermissionAdapter.Get(userRole);
                userPermissions.AddRange(rolePermissions);
            }

            return userPermissions;
        }
    }
}