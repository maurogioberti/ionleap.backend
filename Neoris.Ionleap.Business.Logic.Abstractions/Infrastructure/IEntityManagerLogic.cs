using System.Collections.Generic;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;

namespace Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure
{
    public interface IEntityManagerLogic<TEntity> : IEntityReaderLogic<TEntity> where TEntity : BaseEntity
    {
        void Save(TEntity entity);

        TEntity Add(TEntity entity);

        void Modify(int id, TEntity entity);

        void Remove(int id);
    }
}
