using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;

namespace Neoris.Ionleap.ResourceAccess.Entities.Business
{
    public class Customer : BaseEntity
    {
        public bool BusinessPrice { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public long? PersonalId { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public decimal Salary { get; set; }
    }
}
