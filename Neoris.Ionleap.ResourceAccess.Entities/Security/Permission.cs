using System;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;

namespace Neoris.Ionleap.ResourceAccess.Entities.Security
{
    public class Permission : BaseEntity
    {
        public string Controller { get; set; }

        public string Action { get; set; }

    }
}