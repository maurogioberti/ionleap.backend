using System;
using System.ComponentModel.DataAnnotations;

namespace Neoris.Ionleap.ResourceAccess.Requests
{
    public class AuthenticationRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
