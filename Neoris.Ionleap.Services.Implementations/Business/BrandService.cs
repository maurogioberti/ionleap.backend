using Neoris.Ionleap.Business.Logic.Implementations.Business;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Business;
using Neoris.Ionleap.Services.Abstractions.Business;
using Neoris.Ionleap.Services.Implementations.Infrastructure;

namespace Neoris.Ionleap.Services.Implementations.Business
{
    public class BrandService : EntityManagerService<Brand, BrandLogic, IonleapContext>, IBrandService
    {
    }
}
