using Neoris.Ionleap.ResourceAccess.Entities.Security;

namespace Neoris.Ionleap.ResourceAccess.Responses.Security
{
    public class UserResponse : User
    {
        public new string Password => null;

        public new string PasswordSalt => null;
    }
}