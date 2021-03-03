using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Business;
using Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Business;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Implementations.Business
{
    public class CustomerAdapter : EntityManagerAdapter<Customer, IonleapContext>, ICustomerAdapter
    {
    }
}
