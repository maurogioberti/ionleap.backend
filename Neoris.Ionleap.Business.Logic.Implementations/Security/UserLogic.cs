using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.Business.Logic.Implementations.Infrastructure;
using Neoris.Ionleap.CrossCutting.Configuration;
using Neoris.Ionleap.CrossCutting.Utils.Cryptography;
using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Security;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Neoris.Ionleap.Business.Logic.Implementations.Security
{
    public class UserLogic : EntityManagerLogic<User, IonleapContext>, IUserLogic
    {
        private IUserAdapter _userAdapter;
        protected IUserAdapter UserAdapter
        {
            get => _userAdapter ??= new UserAdapter();
        }

        private IRoleLogic _roleLogic;
        protected IRoleLogic RoleLogic
        {
            get => _roleLogic ??= new RoleLogic();
        }

        private IPermissionLogic _permissionLogic;
        protected IPermissionLogic PermissionLogic
        {
            get => _permissionLogic ??= new PermissionLogic();
        }

        public User UserLogged { get; private set; }

        public UserLogic()
        {
        }

        public UserLogic(IUserAdapter userAdapter, IRoleLogic roleLogic, IPermissionLogic permissionLogic)
        {
            _userAdapter = userAdapter;
            _roleLogic = roleLogic;
            _permissionLogic = permissionLogic;
        }

        public User Get(string username)
        {
            return this.UserAdapter.Get(username);
        }

        public List<Role> GetRoles(User user)
        {
            return this.RoleLogic.Get(user);
        }

        public bool Authenticate(string username, string password, out string token)
        {
            token = "";
            var userRequested = this.Get(username);
            
            if (userRequested == null)
            {
                return false;
            }

            string passwordEncrypted = HashPassword.CreatePasswordHash(userRequested.PasswordSalt, password);

            if (userRequested.Username == username && userRequested.Password == passwordEncrypted)
            {
                UserLogged = userRequested;
            }
            else
            {
                return false;
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(ConfigurationModule.Security.TokenSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserLogged.Username),
                    new Claim(ClaimTypes.NameIdentifier, UserLogged.Identity.ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(ConfigurationModule.Security.TokenMinutesAlive),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenJwt = tokenHandler.CreateToken(tokenDescriptor);

            if (tokenJwt == null)
            {
                return false;
            }

            token = tokenHandler.WriteToken(tokenJwt);

            return true;
        }

        private bool Allowed(User user, string controller, string action)
        {
            return user.IsAdmin || this.PermissionLogic.Get(user).Any(up => up.Controller == controller && up.Action == action);
        }

        public bool Allowed(string controller, string action)
        {
            return Allowed(UserLogged, controller, action);
        }

        public bool Allowed(string controller, string action, string username)
        {
            User user = this.Get(username);
            return Allowed(user, controller, action);
        }
    }
}
