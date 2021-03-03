using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neoris.Ionleap.ResourceAccess.Entities.Security
{
    public class UserRole : BaseEntity
    {
        [Column("UserId")]
        public int UserIdentity { get; set; }
        public User User { get; set; }
        [Column("RoleId")]
        public int RoleIdentity { get; set; }
        public Role Role { get; set; }
    }
}
