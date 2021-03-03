using Neoris.Ionleap.Business.Logic.Abstractions.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Entities.Infrastructure;

namespace Neoris.Ionleap.Services.Abstractions.Infrastructure
{
    public interface IEntityManagerService<TEntity, TLogic> : IEntityReaderService<TEntity, TLogic>
        where TEntity : BaseEntity
        where TLogic : IEntityManagerLogic<TEntity>
    {
        void Save(TEntity entity);

        TEntity Add(TEntity entity);

        void Modify(int id, TEntity entity);

        void Remove(int id);
    }
}
