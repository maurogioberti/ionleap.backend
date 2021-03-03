using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using System;

namespace Neoris.Ionleap.ResourceAccess.Entities.Security
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public bool IsAdmin { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public long? PersonalId { get; set; }

        public int? EmployeeFileNumber { get; set; }

        public DateTime DateBirth { get; set; }

        public string Email { get; set; }

        public string ProfilePictureUrl { get; set; }

        public bool Active { get; set; }

    }
}