using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.Business.Logic.Implementations.Security;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Neoris.Ionleap.Services.Abstractions.Security;
using Neoris.Ionleap.Services.Implementations.Infrastructure;
using System;
using System.Collections.Generic;

namespace Neoris.Ionleap.Services.Implementations.Security
{
    public class PermissionService : EntityManagerService<Permission, PermissionLogic, IonleapContext>, IPermissionService
    {
        private IPermissionLogic _permissionLogic;
        public IPermissionLogic PermissionLogic
        {
            get
            {
                if (this._permissionLogic == null)
                {
                    this._permissionLogic = new PermissionLogic();
                }

                return _permissionLogic;
            }
        }
        
        public List<Permission> Get(User user)
        {
            try
            {
                return this.PermissionLogic.Get(user);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return default;
        }
    }
}