using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neoris.Ionleap.ResourceAccess.Entities.Security
{
    public class RolePermission : BaseEntity
    {
        [Column("RoleId")]
        public int RoleIdentity { get; set; }
        public Role Role { get; set; }
        [Column("PermissionId")]
        public int PermissionIdentity { get; set; }
        public Permission Permission { get; set; }
    }
}
