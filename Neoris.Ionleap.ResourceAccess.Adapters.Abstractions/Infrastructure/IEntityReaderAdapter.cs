using System.Collections.Generic;

namespace Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Infrastructure
{
    public interface IEntityReaderAdapter<TEntity> 
        where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity Get(int id);

        TEntity Get(string description);

        List<TEntity> GetLike(string description);
    }
}
