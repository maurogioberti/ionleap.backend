using System.ComponentModel.DataAnnotations;
using Neoris.Ionleap.CrossCutting.Utils.Mapper;
using Neoris.Ionleap.ResourceAccess.Entities.Security;

namespace Neoris.Ionleap.ResourceAccess.Responses.Security
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse(User user, string token) : base()
        {
            User = AutoMap.Map<User, UserResponse>(user);
            Token = token;
        }

        [Required]
        public string Token { get; set; }

        [Required]
        public UserResponse User { get; set; }
    }
}