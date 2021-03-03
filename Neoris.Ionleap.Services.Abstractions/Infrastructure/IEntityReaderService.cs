using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;
using System.Collections.Generic;
using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;

namespace Neoris.Ionleap.Services.Abstractions.Infrastructure
{
    public interface IEntityReaderService<TEntity, TLogic> 
        where TEntity : BaseEntity
        where TLogic : IEntityReaderLogic<TEntity>
    {
        List<TEntity> GetAll();

        TEntity Get(int id);

        TEntity Get(string description);

        List<TEntity> GetLike(string description);
    }
}