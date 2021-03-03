using Neoris.Ionleap.Business.Logic.Abstractions.Business;
using Neoris.Ionleap.ResourceAccess.Entities.Business;
using Neoris.Ionleap.Services.Abstractions.Infrastructure;

namespace Neoris.Ionleap.Services.Abstractions.Business
{
    public interface ICategoryService : IEntityManagerService<Category, ICategoryLogic>
    {
    }
}
