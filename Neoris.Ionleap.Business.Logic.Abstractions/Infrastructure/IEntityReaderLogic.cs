using System.Collections.Generic;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using System.Linq;

namespace Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure
{
    public interface IEntityReaderLogic<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll();

        TEntity Get(int id);

        TEntity Get(string description);

        List<TEntity> GetLike(string description);
    }
}
