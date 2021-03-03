using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.Business.Logic.Implementations.Security;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Neoris.Ionleap.Services.Abstractions.Security;
using Neoris.Ionleap.Services.Implementations.Infrastructure;
using System;

namespace Neoris.Ionleap.Services.Implementations.Security
{
    public class UserService : EntityManagerService<User, UserLogic, IonleapContext>, IUserService
    {
        private IUserLogic _userLogic;
        public IUserLogic UserLogic
        {
            get
            {
                if (this._userLogic == null)
                {
                    this._userLogic = new UserLogic();
                }

                return _userLogic;
            }
        }

        public User UserLogged => UserLogic.UserLogged;

        public bool Allowed(string controller, string action)
        {
            try
            {
                return this.UserLogic.Allowed(controller, action);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return default;
        }

        public bool Allowed(string controller, string action, string user)
        {
            try
            {
                return this.UserLogic.Allowed(controller, action, user);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return default;
        }

        public bool Authenticate(string username, string password, out string token)
        {
            try
            {
                return this.UserLogic.Authenticate(username, password, out token);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            token = null;
            return default;
        }
    }
}
