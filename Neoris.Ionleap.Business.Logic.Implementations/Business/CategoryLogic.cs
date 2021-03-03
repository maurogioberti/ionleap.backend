using Neoris.Ionleap.Business.Logic.Abstractions.Business;
using Neoris.Ionleap.Business.Logic.Implementations.Infrastructure;
using Neoris.Ionleap.ResourceAccess.DataBase;
using Neoris.Ionleap.ResourceAccess.Entities.Business;


namespace Neoris.Ionleap.Business.Logic.Implementations.Business
{
    public class CategoryLogic : EntityManagerLogic<Category, IonleapContext>, ICategoryLogic
    {
    }
}
